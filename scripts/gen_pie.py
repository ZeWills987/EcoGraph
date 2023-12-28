import matplotlib.pyplot as plt
import utils

def gen(df,unite,periode): #df prend en colonne 0 les valeurs et en colonne 1 les labels
    fig, ax = plt.subplots()
    wedges, texts, autotexts = ax.pie(df[df.columns[0]], autopct='%1.1f%%', radius=1.2)
    ax.set_title(""+df.columns[0]+" in "+unite+" ("+periode+")", wrap=True)
    feur = df[df.columns[1]].values.tolist()
    for i in range(len(feur)):
        feur[i] = feur[i].strip()
    ax.legend(wedges, feur,
          title="Countries",
          loc="center left",
          bbox_to_anchor=(1, 0, 0.5, 1))
    plt.savefig(utils.save_string)