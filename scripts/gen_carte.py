import sys
import geopandas as gpd
import matplotlib.pyplot as plt
import random
import contextily as cx
import utils

def gen(df, unite_donnee, periode): #données géographique et données
    df_base = gpd.read_file(utils.SETTINGS["countries_file"])
    fig, ax = plt.subplots(1, figsize=(10, 10))
    type_donnee = df.columns[1]
    
    df_base.plot(ax=ax, color='#D5E3D8')
    df.plot(ax=ax,column=type_donnee, legend=True,legend_kwds={"label": type_donnee+" ("+unite_donnee+")", "orientation": "horizontal"})
    ax.set_xlim(-20, 40)
    ax.set_ylim(30, 72)
    plt.title(label=type_donnee+" in the EU ("+periode+")", wrap=True)
    plt.savefig(utils.save_string) #nom de la carte avec son emplacement