using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoGraph
{
    public class Data
    {
        string nameData;
        string typeData;
        double numericValueData;

        public Data(string name, string type,double val)
        {
            nameData = name;
            typeData = type;
            numericValueData = val;
        }
    }
}
