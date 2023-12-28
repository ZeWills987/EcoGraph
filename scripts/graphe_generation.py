# All import of programme
import sys, getopt
import pandas as pd
import utils

import df_gen

# Ordre d'entré des arguments 
# graphe pays + données + periode(start/end ou start)

#str(args) = la liste des arguments

# variable global of script
global graph,countries,types,periods,graphes,countries_data,types_data,period_data,engine
graph=""
countries=[]
types=[]
periods=[]
graphes=pd.DataFrame({"curve","map","pie","stick"})
countries_data=pd.DataFrame()
types_data=pd.DataFrame()
period_data=pd.DataFrame()

# Function main of programme
def main(argv):
    global graph,countries,types,periods,engine
    engine = utils.connect_to_db()
    try:
        opts, args = getopt.getopt(argv,"u:hg:c:d:p:",["credit=","usage=","help=","graph=","country=","data=","period="])
    except getopt.GetoptError:
        help()
        sys.exit(2)
    for opt, arg in opts:
        opt=str(opt)
        arg=str(arg)
        if opt in ("-h","--help"):
            print("help is good")
            help()
        if opt in ("-g","--graph"):
            graph=arg
        if opt in ("-c","g--country"):
            str_country=arg
            countries=str_country.split(",")
        if opt in ("-d", "--data"):
            str_type=arg
            types=str_type.split(",")
        if opt in ("-p", "--period"):
            str_period=arg
            periods=str_period.split("-")
        if opt in ("-u", "--usage"):
            graph=arg
            if graph in graphes:
                usage()

    graph_type()

# Graph selection with all check assosiate of them.
def graph_type():
    global graph,countries,countries_data,engine
    if graph == "line":
        print("Graph selection : line graph selected")
        get_countries_database() # get all 
        country_choice() # check user list of countries 
        get_data_country_database()
        data_choice() # check data choice
        get_periode_database()#get period of data 
        period_choice()#check period of data
        if (len(countries)>1 and len(types)==1) :
            get_periode_database()#get period of data 
            period_choice()#check period of data
            print("Success check : generation of the countries graph line")
            df_gen.graph("line1",periods[0],periods[1],types,countries)
        elif len(countries)==1 and len(types)>1:
            get_periode_database()#get period of data 
            period_choice()#check period of data 
            df_gen.graph("line2",periods[0],periods[1],types,countries)
            print("Success check : generation of the data types graph line")
        elif len(countries)==1 and len(types)==1:
            print("Success check : generation of the normal graph line")

        else:
            print("Error check : imposible to draw a graph with n data types and n countries")
            usage()
        engine.close()
        exit()

    if graph == "map":
        print("Graph selection : map graph selected")
        get_countries_database()# get all countries
        get_all_data_database()# get all data
        data_choice()#check the choice of data 
        if len(types)==1 :
            get_periode_database()#get period of data 
            period_choice()#check period of data 
            if len(periods)==2:
                #function map generation
                print("Success check : generation of the graph map")
                df_gen.graph(graph,periods[0],periods[1],types)
            else:
                print("Error : number of argument for periods is out of min-max period lenght for a map (min/max number = 2)")
        else:
            print("Error : number of data type arguments is out of min-max number data lenght for a map (min/max number = 1)")
        engine.close()#Close database connection
        exit()

    if graph == "pie":
        print("Graph selection : pie graph selected")
        get_countries_database() # get all countries
        country_choice() # check user list of countries 
        get_data_country_database()
        data_choice() # check data choice
        get_periode_database()#get period of data 
        period_choice()#check period of data 
        engine.close() 
        print("Success check : generation of the pie chart")
        df_gen.graph(graph, periods[0], periods[1], types, countries)
        exit()

    if graph == "scatter":
        print("Graph selection : scatter graph selected")
        get_countries_database() # get all countries
        country_choice() # check user list of countries
        if len(countries)==1:
            get_data_country_database()
            if len(types)==1:
                data_choice()
                get_periode_database()
                period_choice()
                if periods[0] < periods[1]:
                    #function scatter
                    print("Success check : generation of the scatter graph")
                    df_gen.graph(graph, periods[0], periods[1], types, countries)
                else:
                    print("Error : periods order is starting year <= ending years")
            else:
                print("Error : number of arguments for data type arguments is out of min-max number data lenght for a scatter graph (min/max number = 1)")
        else:
            print("Error : number of arguments for countries argument is out of min-max countries lenght for a scatter graph (min/max number = 1)")
        engine.close()
        exit()


    if graph == "pie":
        print("Graph selection : pie graph selected")
        get_countries_database() # get all countries
        country_choice() # check user list of countries 
        get_data_country_database()
        data_choice() # check data choice
        get_periode_database()#get period of data 
        period_choice()#check period of data 
        engine.close() 
        print("Success check : generation of the pie chart")
        df_gen.graph(graph, periods[0], periods[1], types, countries)
        exit()

    if graph == "scatter":
        print("Graph selection : scatter graph selected")
        get_countries_database() # get all countries
        country_choice() # check user list of countries
        if len(countries)==1:
            get_data_country_database()
            if len(types)==2:
                data_choice()
                get_periode_database()
                period_choice()
                if periods[0] < periods[1]:
                #function scatter
                    print("Success check : generation of the scatter graph")
                    df_gen.graph(graph, periods[0], periods[1], types, countries)
                else:
                    print("Error : periods order is starting year <= ending years")
            else:
                print("Error : number of arguments for data type arguments is out of min-max number data lenght for a scatter graph (min/max number = 2)")
        else:
            print("Error : number of arguments for countries argument is out of min-max countries lenght for a scatter graph (min/max number = 1)")
        engine.close()
        exit()

    elif graph=="":
        print("Graph selection : empty graph argument")
        help()
        engine.close()
        exit()
    else:
        print("Graph selection : unknow graph type")
        help()
        engine.close()
        exit()

#region *************************************** Check_Function ****************************************************************
#Check period for data country is empty or 
# exist in database
def period_choice():
    global graph,periods,period_data
    tmp_periods=[]
    for period in periods:
        period=period.strip()
        if int(period) in period_data['annee'].values:
            print("Check data : "+period +" is a period of data database")
            tmp_periods.append(period)
        elif period=="":
            print("Check data : empty period")
        else:
            print("Check data : "+period +" is a unknow periode of data database")
    
    if len(tmp_periods)==0:
        print("Check data : all periods of periods is out of data database or periods is empty")
        print("Please get only periods of database")
        usage()
        exit()
    else:
        periods=tmp_periods


#Check data for country is empty 
# or exist in database
def data_choice():
    global types,types_data
    tmp_types=[]
    for type in types:
        type=type.strip()
        if str(type) in types_data["nomType"].values:
            print("Check data : " +type + " is a data of data database")
            tmp_types.append(type)
        elif type=="":
            print("Check data : empty data")
        else:
            print("Check data : " +type +" is a unknow data of database")
    if len(tmp_types)==0:
        print("Check data : all data types is out of data database or data is empty")
        print("Please get only data of database")
        usage()
        exit()
    else:
        types=tmp_types

# Check countrie exist in database and only union european countries
def country_choice():
    global countries
    tmp_countries=[]
    for country in countries:
        country=country.strip()
        if str(country) in countries_data["nomPays"].values:
            print("Check data : "+country + " is in countries database")
            tmp_countries.append(country)
        elif country=="":
            print("Check data : empty country argument")
        else:
            print("Check data : "+country + " is a unknow country of database")

    if len(tmp_countries)==0:
        print("Check data : all countries of list countries is out of countries database or countries is empty")
        print("Please get only union european country")
        usage()
        exit()
    else:
        countries=tmp_countries

#endregion

#region ******************************************* Database ******************************************************************

# Get period of data of country 
def get_periode_database():
    global period_data, countries_data, engine
    condition_country = ""
    condition_data = ""

    i = 0
    for country in countries_data["nomPays"].values:
        if i == len(countries_data) - 1:
            condition_country = condition_country + "'" + str(country) + "'"
        else:
            condition_country = condition_country + "'" + str(country) + "',"
        i = i + 1

    i = 0
    for type in types_data["nomType"].values:
        if i == len(types_data) - 1:
            condition_data = condition_data + "'" + str(type) + "'"
        else:
            condition_data = condition_data + "'" + str(type) + "',"
        i = i + 1

    req = "SELECT annee FROM Donnee INNER JOIN Pays ON Pays.idPays = Donnee.idPays INNER JOIN Type ON Type.idType=Donnee.idType WHERE nomPays IN (" + condition_country + ") AND nomType IN (" + condition_data + ")"
    try:
        period_data = pd.read_sql(req, engine)
        period_data["annee"] = period_data["annee"]
    except Exception as e:
        print("Data base : this error occurred during the execution of the SQL query :")
        print(str(e))

    if len(period_data) == 0:
        print("Data base : no period in the database")
    else:
        print("Data base : successfully retrieved periods from the database")


# Get all data of database
def get_all_data_database():
    global types_data,engine
    req="SELECT nomType FROM Type"
    types_data = pd.read_sql(req,engine)
    types_data['nomType'] = types_data['nomType'].str.strip()
    if len(types_data) == 0:
        print("Data base : no data in the database")
    else:
        print("Data base : successfully retrieved data from the database")

# Get all data of country
def get_data_country_database():
    global types_data,countries,engine
    condition = ""
    i=0

    for country in countries:
        if i==len(countries)-1:
            condition=condition+"'"+str(country)+"'"
        else:   
            condition=condition+"'"+str(country)+"',"
        i=i+1
   
    req="SELECT DISTINCT nomType FROM Type INNER JOIN Donnee ON Donnee.idType = Type.idType INNER JOIN Pays ON Pays.idPays = Donnee.idPays WHERE nomPays in ("+ condition +")"
    try:
        types_data = pd.read_sql(req,engine)
        types_data['nomType'] = types_data['nomType'].str.strip()
    except Exception as e:
        print("Data base : this error occurred during the execution of the SQL query :")
        print(str(e))

    if len(types_data) == 0:
        print("Data base : no data in the database")
    else:
        print("Data base : successfully retrieved data from the database")

#Get all countries of database
def get_countries_database():
    global countries_data,engine
    countries_data = pd.read_sql("SELECT nomPays FROM Pays",engine)
    countries_data['nomPays'] = countries_data['nomPays'].str.strip()
    if len(countries_data) == 0:
        print("Data base : no countries in the database")
    else:
        print("Data base : successfully retrieved countries from the database")

#endregion


# Function help of script with all command option and example
def help():
    print("""\
    #!/usr/bin/env python3
    
    # Help - Usage Guide
    
    # Usage:
    #   python graphe_generation.py [OPTIONS]

    # Options:
    #   -g, --graph <type>       Specify the type of graph to generate. Available options: map, line, pie, scatter.
    #   -c, --country <list>     Specify the countries for the graph (comma-separated for multiple countries).
    #   -d, --data <type>        Specify the type of data for the graph.
    #   -p, --period <range>     Specify the time period for the data (start-end).
    
    # Description:
    #   This script generates different types of graphs based on the provided options. The available graph types are:
    #   - Map: Generates a map graph with all available data for a specific time period.
    #   - Line: Generates a line graph for a specific country and data type over a given time period.
    #   - Pie: Generates a pie chart for multiple countries and a specific data type over a given time period.
    #   - Scatter: Generates a scatter plot for a specific country and data type over a given time period.

    # Examples:
    #   Generate a map graph with a available data for the period 2000-2020:
    #   python graphe_generation.py -g map -d "Population" -p "2000-2020"

    #   Generate a normal line graph for the country "France" and the data type "Population" for the period "2010-2020":
    #   python graphe_generation.py -g line -c "France" -d "Population" -p "2010-2020"
    
    #   Generate a line graph for the country "France,Germany" and the data type "Population" for the period "2010-2020":
    #   python graphe_generation.py -g line -c "France,Germany" -d "Population" -p "2010-2020"
    
    #   Generate a line graph for the country "France" and the data type "Population,Carbon Footprint" for the period "2010-2020":
    #   python graphe_generation.py -g line -c "France" -d "Population,Carbon Footprint" -p "2010-2020"

    #   Generate a pie chart for the countries "France, Germany, Italy" and the data type "GDP" for the period "2005-2015":
    #   python graphe_generation.py -g pie -c "France,Germany,Italy" -d "GDP" -p "2005-2015"

    #   Generate a scatter plot for the country "United Kingdom" and the data type "CO2 emissions" for the period "2000-2021":
    #   python graphe_generation.py -g scatter -c "United Kingdom" -d "CO2 emissions" -p "2000-2021"
    """)
    exit()

# Function usage foreach type of graph
def usage():
    global graph
    if graph == "map":
        print("""
        # Usage -g, --graph map :
        #   python graphe_generation.py -g map [option]
        #
        # Options:
        #   -d, --data <type>        Specify the type of data for the graph. (number max of data = 1)
        #   -p, --period <range>     Specify the time period for the data (start-end).
        """)
    elif graph == "line":
        print("""
        # Usage -g, --graph line :
        #   python graphe_generation.py -g line [option]
        #
        # Options:
        #   -c, --country <list>     Specify the countries for the graph (comma-separated for multiple countries).
        #   -d, --data <type>        Specify the type of data for the graph.
        #   -p, --period <range>     Specify the time period for the data (start-end).
        """)
    elif graph == "scatter":
        print("""
        # Usage -g, --graph scatter :
        #   python graphe_generation.py -g scatter [option]
        #
        # Options:
        #   -c, --country <list>     Specify the countries for the graph (comma-separated for multiple countries).
        #   -d, --data <type>        Specify the type of data for the graph.
        #   -p, --period <range>     Specify the time period for the data (start-end).
        """)
    elif graph == "pie":
        print("""
        # Usage -g, --graph pie :
        #   python graphe_generation.py -g pie [option]
        #
        # Options:
        #   -c, --country <list>     Specify the countries for the graph (comma-separated for multiple countries).
        #   -d, --data <type>        Specify the type of data for the graph.
        #   -p, --period <range>     Specify the time period for the data (start-end).
        """)
    else:
        print("Bien joué, tu as trouvé le moyen de fair n'importe quoi.")      
    exit()

# Function crédit
def credit():
    print("By William Tchang")
    exit()


# The call of main function
if __name__ == "__main__":
    main(sys.argv[1:])