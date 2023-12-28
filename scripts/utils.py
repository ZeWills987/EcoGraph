import sqlite3
import pymssql
import json
import os

#fonction d'extraction de fichier json :
def extract(file : str):
    with open(file) as j_file:
        dico = json.load(j_file)
    return dico

global SETTINGS
SETTINGS = extract("../settings.json")

def connect_to_db():
    if (SETTINGS["using_mssql"]):
        db_set = SETTINGS["mssql_connect"]
        conn = pymssql.connect(server=db_set["server"], user=db_set["user"], password=db_set["password"], database=db_set["database"])
    else:
        conn = sqlite3.connect(SETTINGS["local_db_file"])
    return conn

def all_shift_files():
    p_to_shift = SETTINGS["data_folder"]+"/"+SETTINGS["shift_folder"]
    l = os.listdir(p_to_shift)
    
    files = []
    
    for i in range(len(l)):
        if l[i].split(".")[-1] == "csv":
            files.append(p_to_shift +"/"+ l[i])
        
    return files

save_string = SETTINGS["shared_image_folder"]+"/im.png"