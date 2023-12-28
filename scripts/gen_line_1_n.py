import matplotlib.pyplot as plt
import utils

def gen(dataframe, type, periode):  # une colone annee et une colone pays 1,2,3...n avec des données, type de données et periode
    for i in range(1, len(dataframe.columns)):
        plt.plot(dataframe[dataframe.columns[0]], dataframe[dataframe.columns[i]], label=dataframe.columns[i])
        plt.legend(bbox_to_anchor=(1.02, 1), loc='upper left', borderaxespad=0, title="Pays") 
    plt.xlabel("Year")
    plt.ylabel(type)
    plt.title(""+type+" ("+periode+")", wrap=True)
    plt.savefig(utils.save_string, bbox_inches='tight')