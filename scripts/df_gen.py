import pandas as pd
import geopandas as gpd
import utils
import gen_carte
import gen_line_1_n
import gen_line_2_1
import gen_pie
import gen_scatter

def graph(type_graph, date_debut, date_fin, types_valeur, pays=None):  # type_graph est un string qui defini le type de graphique (map,line1,line2,pie,scatter), date_debut est la date du début du graphique et date_fin est la date de la fin. types_valeur est une liste qui contient le ou les types de valeurs. pays est une liste qui contient le ou les pays  (null pour map, un pays pour line2 et scatter, et plusieur pour le reste ).
    conn = utils.connect_to_db()
    c=conn.cursor()
    if type_graph=="map":
        df=pd.read_sql("select avg(valeur) as '"+types_valeur[0]+"',codeISO3 from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" group by codeISO3", conn)
        unite=pd.read_sql("select uniteType from Type where nomType= '"+types_valeur[0]+"'", conn)
        unite=unite["uniteType"][0]
        unite=unite.strip()
        df2=gpd.read_file(utils.SETTINGS["countries_file"])
        df2=df2[df2["EU_STAT"]=="T"]
        df2=df2.sort_values(by = 'ISO3_CODE')
        df2=df2.reset_index()

        df3=gpd.GeoDataFrame(df, geometry=df2.geometry)
        df3=df3[['geometry',types_valeur[0]]]
        gen_carte.gen(df3, unite+" (period average)", ""+date_debut+"-"+date_fin)
        
        
    if type_graph=="line1":
        df=pd.read_sql("select distinct annee from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" order by annee", conn)
        for i in pays:
            c.execute("select valeur from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" and nomPays='"+i+"' order by annee")
            feur=list(c.fetchall())
            feur2 = [int(i[0]) for i in feur]
            df=df.assign(i=feur2)
            df=df.rename(columns={"i":i})
        gen_line_1_n.gen(df, types_valeur[0], date_debut+"-"+date_fin)
    
    if type_graph=="line2":
        df=pd.read_sql("select annee, valeur from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" and nomPays='"+pays[0]+"' order by annee", conn)
        c.execute("select valeur from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[1]+"' and annee between "+date_debut+" and "+date_fin+" and nomPays='"+pays[0]+"' order by annee")
        feur=list(c.fetchall())
        feur2 = [int(i[0]) for i in feur]
        df=df.assign(i=feur2)
        df=df.rename(columns={"valeur":types_valeur[0]})
        df=df.rename(columns={"i":types_valeur[1]})
        gen_line_2_1.gen(df, pays[0], date_debut+"-"+date_fin)
        
    if type_graph=="pie":  
        unite=pd.read_sql("select uniteType from Type where nomType= '"+types_valeur[0]+"'", conn)
        unite=unite["uniteType"][0]
        unite=unite.strip()   
        string_pays="("
        for i in pays:
            string_pays+="'"+i+"',"
        string_pays=string_pays[:-1]+")"
        df=pd.read_sql("select sum(valeur), nomPays from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" and nomPays in "+string_pays+" group by nomPays", conn)
        df=df.rename(columns={"":types_valeur[0]})
        gen_pie.gen(df, unite, date_debut+"-"+date_fin)
        
    if type_graph == "scatter":
        df=pd.read_sql("select annee as year, valeur from Donnee inner join Type on Donnee.idType=Type.idType inner join Pays on Donnee.idPays=Pays.idPays where nomType='"+types_valeur[0]+"' and annee between "+date_debut+" and "+date_fin+" and nomPays='"+pays[0]+"' order by annee", conn)
        df=df.rename(columns={"valeur":types_valeur[0]})
        gen_scatter.gen(df, pays[0], date_debut+"-"+date_fin)

