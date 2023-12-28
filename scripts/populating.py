import math
import pandas as pd
import geopandas as gpd
import matplotlib.pyplot as plt
import re

import utils


conn = utils.connect_to_db()
c = conn.cursor()

def add_countries():
    df = gpd.read_file(utils.SETTINGS["countries_file"])
    df = df[df.EU_STAT=="T"] #filtering out the non-EU countries
    df = df[['NAME_ENGL','ISO3_CODE']]
    df = df.rename(columns={'NAME_ENGL':'nomPays', 'ISO3_CODE':'codeISO3'})
    
    conn = utils.connect_to_db()
    c = conn.cursor()
    
    for i, row in df.iterrows():
        req = "INSERT INTO Pays (nomPays, codeISO3) values ('"+row[0]+"','"+row[1]+"')"
        
        try:
            c.execute(req)
            conn.commit()
        except:
            print("error on request : "+req)
    
    conn.close()
    
def add_from_csv(path, source, type_name, unit):
    df = pd.read_csv(path)

    if source == "shift":
        add_from_shift(df, type_name, unit)
    elif source == "worldbank":
        add_from_worldbank(df, type_name, unit)
   
def transfo_shift_date(x):
    return x.split('-')[0]

def add_type_to_db(c, name, unit):
    try:
        add_query = "INSERT INTO Type (nomType, uniteType) values ('"+name+"','"+unit+"')"
        c.execute(add_query)
    except utils.sqlite3.IntegrityError:
        pass

def val_or_null(val):
    if val == 'nan':
        return 'NULL'
    return val

def insert_data(conn, id_type, id_country, val, an):
    c = conn.cursor()
    try:
        insert = "INSERT INTO Donnee (idType, idPays, valeur, annee) values ("+id_type+","+id_country+","+val_or_null(val)+","+an+")"
        c.execute(insert) 
    except utils.sqlite3.IntegrityError:
        print("error "+insert)

def find_id_of_country(country, liste):
    country = country.strip()
    for tup in liste:
        a = tup[1].strip()
        if a in country:
            return tup[0]

def add_from_shift(df, type_name, unit):
    type_name_over_pop = type_name+" / M inhabitants"
    unit_over_pop = unit+" / M inhab."
    
    add_type_to_db(c, type_name, unit)
    add_type_to_db(c, type_name_over_pop, unit_over_pop)
    
    recup_id_type = "SELECT idType from Type where nomType='"+type_name+"'"
    c.execute(recup_id_type)
    id_type = c.fetchone()[0]
    
    recup_id_type_over_pop = "SELECT idType from Type where nomType='"+type_name_over_pop+"'"
    c.execute(recup_id_type_over_pop)
    id_type_over_pop = c.fetchone()[0]
    
    df = df.rename(columns={df.columns[0]:"annee"})
    df['annee'] = df['annee'].map(transfo_shift_date)
    
    for _, row in df.iterrows():
        for country in df.columns[1:]:
            annee = row["annee"]
            val = row[country]
            
            recup_id_country = "SELECT idPays, nomPays from Pays"
            c.execute(recup_id_country)
            id_country = c.fetchall()
            id_country = find_id_of_country(country, id_country)
            if id_country is not None:
                pop_that_year_query = "SELECT valeur from Donnee inner join Pays on Pays.idPays = Donnee.idPays inner join Type on Type.idType = Donnee.idType where nomType='Population' and Pays.idPays="+str(id_country)+" and annee="+str(annee)+""
                c.execute(pop_that_year_query)
                pop_in_country_that_year = c.fetchone()
                    
                if pop_in_country_that_year is not None:
                    pop_in_country_that_year = pop_in_country_that_year[0]
                    if not pop_in_country_that_year == 0:
                        val_over_pop = float(val) / float(pop_in_country_that_year)
                        insert_data(conn, str(id_type_over_pop), str(id_country), str(val_over_pop), str(annee))
                    
                insert_data(conn, str(id_type), str(id_country), str(val), str(annee))   

def add_from_worldbank(df, type_name, unit):
    add_type_to_db(c, type_name, unit)
    
    div = 1
    if type_name.lower() == "population":
        div = 1000000
    
    recup_id_type = "SELECT idType from Type where nomType='"+type_name+"'"
    c.execute(recup_id_type)
    id_type = c.fetchone()[0]
    
    for _, row in df.iterrows():
        country = row[0]
        recup_id_country = "SELECT idPays, nomPays from Pays"
        c.execute(recup_id_country)
        id_country = c.fetchall()
        id_country = find_id_of_country(country, id_country)
        
        if id_country is not None:
            for year in df.columns[5:]:
                if not math.isnan(row[year]):
                    val = str(int(row[year]/div))
                    insert_data(conn, str(id_type), str(id_country), str(val), str(year))
        
def add_all_from_shift():
    for file in utils.all_shift_files():
        true_f = file.split("/")[-1]
        name = true_f.split("_")[0]
        name = re.sub( r"([A-Z])", r" \1", name).strip()
        print(name)
        unit = true_f.split("_")[-1].split(".")[0]
        add_from_csv(file, "shift", name, unit)

def add_population():
    add_from_csv(utils.SETTINGS["data_folder"]+"/world_pop.csv", "worldbank", "Population", "M inhabitants")

def empty_all():
    c.execute("delete from Donnee")
    c.execute("delete from Pays")
    c.execute("delete from Type")

def fill_empty_database():
    add_countries()
    add_population()
    add_all_from_shift()
    conn.commit()
    conn.close()
    
def fill_database():
    empty_all()
    fill_empty_database()
    
fill_database()