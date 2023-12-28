import math
import matplotlib.pyplot as plt
import pandas as pd
import random as rd
import scipy.stats as stats
import numpy as np
import utils

def gen(dataframe, country, period):
    x, y = dataframe[dataframe.columns[0]], dataframe[dataframe.columns[1]]
    plt.scatter(x, y)
    plt.xlabel(dataframe.columns[0])
    plt.ylabel(dataframe.columns[1])
    plt.title("evolution of "+dataframe.columns[1]+" in "+country+" ("+period+")", fontsize = 'x-large', wrap=True)
    linear_regression(x, y)
    
    plt.legend(bbox_to_anchor = (1.02, 1), loc = 'upper left', borderaxespad=0, title="reg. line(s)")
    plt.savefig(utils.save_string, bbox_inches='tight')

def lim_for_depth(x):
    table = [0.9, 0.5, 0.5]
    if x < len(table):
        return table[x]
    else:
        return 0.45

def linear_regression(x, y, d=0):
    result = stats.linregress(x, y)
    f = float(result[0]) * x + float(result[1]) # f is the regression line
    r = np.corrcoef(x, y)[0][1]

    if abs(r) > lim_for_depth(d) or len(x) <= 5:
        equation = str(round(result[0], 4)) + "x"+ (" + " if result[1] > 0 else " - ") + str(abs(round(result[1], 2)))
        plt.plot(x, f, "red" if r < 0 else "green" , label = equation)

    else:
        mid = len(x)//2
        linear_regression(x[:mid+1], y[:mid+1], d+1)
        linear_regression(x[mid-1:], y[mid-1:], d+1)
