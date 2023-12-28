using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.Diagnostics;

namespace EcoGraph
{
    public partial class Countries : Form
    {
        OleDbConnection dbCon;
        static private List<string> CountriesSelected = new List<string>();

        public Countries(List<string> CountriesAlreadySelected)
        {
            InitializeComponent();
            CountriesSelected = new List<string>(CountriesAlreadySelected);
            Init();
            EcoGraph.RoundedPictureBox(panelCheck);
        }

        private void Init()
        {
            string sql = "SELECT DISTINCT nomPays FROM Pays";
            string chaineBd = "Provider=SQLOLEDB;Data Source=INFO-MSSQL-ETD;Initial Catalog=Equipe3;Uid=etd03;Pwd=k44uYXy3;";
            dbCon = new OleDbConnection(chaineBd);
            dbCon.Open();
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                checkedListBoxCountries.Items.Add(reader.GetString(0).Trim());
            }
            reader.Close();
            foreach(string c in CountriesSelected)
            {    
                string b = c.Replace("'", "");
                if (checkedListBoxCountries.Items.Contains(b))
                {
                    checkedListBoxCountries.SetItemChecked(checkedListBoxCountries.Items.IndexOf(b), true);
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CountriesSelected.Clear();
            foreach(string a in checkedListBoxCountries.CheckedItems)
            {
                string d = a.Trim();
                CountriesSelected.Add("'" + d + "'");
            }
            if (CountriesSelected.Count() <= 1)
            {
                MessageBox.Show("You need to select at least 2 countries.");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            
        }
        public List<string> GetSelectedCountries()
        {
            return CountriesSelected;
        }
    }
}
