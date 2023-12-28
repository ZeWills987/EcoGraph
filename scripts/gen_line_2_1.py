import matplotlib.pyplot as plt
import utils

def gen(df, pays, periode): # une colonne annee, indic 1, indic 2 (ex co2 population ...) pays sur lequel on taf et periode 
    plt.xlabel("Year")
    
    pl = plt.plot(df[df.columns[0]], df[df.columns[1]], color='blue')
    plt.legend(pl, df.columns[1].split(), bbox_to_anchor=(1.12, 1), loc='upper left', borderaxespad=0,)
    plt.ylabel(df.columns[1])
    
    ax2 = plt.gca().twinx()
    pl2 = ax2.plot(df[df.columns[0]], df[df.columns[2]], color='red')
    plt.legend(pl2, df.columns[2].split(), bbox_to_anchor=(1.12, 0.93), loc='upper left', borderaxespad=0,)
    plt.ylabel(df.columns[2])
    
    plt.title("Relationship between "+df.columns[1]+" and "+df.columns[2]+" in "+pays+" ("+periode+")", wrap=True)
    plt.savefig(utils.save_string, bbox_inches='tight')