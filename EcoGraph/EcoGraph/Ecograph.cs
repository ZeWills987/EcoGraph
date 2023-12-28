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
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace EcoGraph
{
    public partial class EcoGraph : Form
    {
        #region Attributes Python
        private readonly string cmdStr;
        private readonly string pythonPath;
        private readonly string simpleScriptName;
        private readonly string imgPath;
        private readonly string jsonPath;
        private Dictionary<string, string> mssql_settings;
        #endregion

        OleDbConnection dbCon;
        List<string> CountriesList = new List<string>();
        List<string> TypeGraphList = new List<string>();
        List<string> TypeDataList = new List<string>();
        List<string> YearsList = new List<string>();
        List<string> CountriesChoice = new List<string>();
        string countriesString;
        string country;
        string graph;
        string data;
        string data2;
        string dataID;
        string yearID;
        string unitID;
        string startPeriod = null;
        string endPeriod = null;

        public EcoGraph()
        {
            jsonPath = @"..\..\..\..\settings.json";

            mssql_settings = ExtractMSsqlSettings(jsonPath);

            InitializeComponent();
            InitializeCountries("SELECT DISTINCT nomPays FROM Pays");
            InitializeTypeGraph();
            InitializeTypeData("SELECT DISTINCT nomType FROM Type","");
            InitializePeriod("SELECT DISTINCT annee FROM Donnee ORDER BY annee DESC");
            cmdStr = "powershell.exe";
            pythonPath = @"..\..\..\..\scripts\";
            simpleScriptName = "graphe_generation.py";
            imgPath = @"..\..\..\..\shared\";
            comboBoxCountries.Enabled = false;
            comboBoxDataType1.Enabled = false;
            comboBoxPeriodStart.Enabled = false;
            comboBoxPeriodEnd.Enabled = false;
            comboBoxDataType2.Enabled = false;
            comboBoxDataType2.Visible = false;
            panelData2.Visible = false;
            buttonVisualize.Enabled = false;
            buttonChoiceCountries.Visible = false;
            textBoxListCountries.Visible = false;
            textBoxListCountries.Enabled = false;
            panelCountries.Visible = false;
            labelCountriesChosen.Visible = false;
            labelLoading.Visible = false;
            textBoxIDCard.Visible = false;
          
            //pictureBoxGraph.Image = Image.FromFile(@"..\..\..\imgJu\base.png");
            RoundedPictureBox(panelGraphType);
            RoundedPictureBox(panelCountry);
            RoundedPictureBox(panelData1);
            RoundedPictureBox(panelData2);
            RoundedPictureBox(panelPS);
            RoundedPictureBox(panelPE);
            RoundedPictureBox(panelCountries);
            RoundedPictureBox(panelImg);

        }

        #region Init data bases
        private Dictionary<string, string> ExtractMSsqlSettings(string path)
        {
            string[] wantedInfo = { "server", "user", "password", "database" };

            string formatLine;
            string[] valLine;
            Dictionary<string, string> settings = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(jsonPath);

            foreach (string line in lines) {
                formatLine = line.Trim();
                formatLine = Regex.Replace(formatLine, "\"", "");
                formatLine = Regex.Replace(formatLine, ",", "");
                valLine = formatLine.Split(':');

                if (wantedInfo.Contains(valLine[0].Trim())) {
                    settings[valLine[0].Trim()] = valLine[1].Trim();
                }
                
            }
            return settings;
        }
        
        private string ChaineBd()
        {
            return "Provider=SQLOLEDB;Data Source="+mssql_settings["server"]+";Initial Catalog="+mssql_settings["database"]+";Uid="+mssql_settings["user"]+";Pwd="+mssql_settings["password"]+"";
        }

        private void InitializeCountries(string sql)
        {
            comboBoxCountries.Items.Clear();
            dbCon = new OleDbConnection(ChaineBd());
            dbCon.Open();
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CountriesList.Add(reader.GetString(0));
                comboBoxCountries.Items.Add(reader.GetString(0));
            }
            reader.Close(); 
        }

        private void InitializeTypeGraph()
        {
            TypeGraphList.Add("Map");
            TypeGraphList.Add("Pie chart");
            TypeGraphList.Add("Scatter plot"); 
            TypeGraphList.Add("Line 1 country 2 data");
            TypeGraphList.Add("Line N countries 1 data"); 
            TypeGraphList.Add("Identity Card of a country"); 
            foreach (string type in TypeGraphList)
            {
                comboBoxGraphType.Items.Add(type);
            }
        }

        private void InitializeTypeData(string sql,string type)
        {
            comboBoxDataType1.Items.Clear();
            comboBoxDataType2.Items.Clear();
            dbCon = new OleDbConnection(ChaineBd());
            dbCon.Open();
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            Console.WriteLine(sql);
            while (reader.Read())
            {
                if (country != null && sql.Equals("SELECT DISTINCT valeur, MAX(annee), uniteType FROM Donnee INNER JOIN Pays ON Pays.idPays = Donnee.idPays INNER JOIN Type ON Donnee.idType = Type.idType WHERE nomPays = '" + country.Trim() + "' AND nomType = '" + type.Trim() + "' AND annee = (SELECT MAX(annee) FROM Donnee INNER JOIN Pays ON Pays.idPays = Donnee.idPays INNER JOIN Type ON Donnee.idType = Type.idType WHERE nomPays = '" + country.Trim() + "' AND nomType = '" + type.Trim() + "') GROUP BY valeur, uniteType"))
                {
                    Console.WriteLine("a" + reader.GetInt16(1).ToString());
                    dataID = reader.GetDecimal(0).ToString();
                    yearID = reader.GetInt16(1).ToString();
                    unitID = reader.GetString(2);

                }
                else
                {
                    comboBoxDataType1.Items.Add(reader.GetString(0));
                    comboBoxDataType2.Items.Add(reader.GetString(0));
                    if (!TypeDataList.Contains(reader.GetString(0)))
                    {
                        TypeDataList.Add(reader.GetString(0));
                    }
                }                
            }
            reader.Close();
        }

        private void InitializePeriod(string sql)
        {
            comboBoxPeriodStart.Items.Clear();
            comboBoxPeriodEnd.Items.Clear();
            YearsList.Clear();
            dbCon = new OleDbConnection(ChaineBd());
            dbCon.Open();
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            Console.WriteLine("requete sql" + sql);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                YearsList.Add(reader.GetInt16(0).ToString());
                comboBoxPeriodStart.Items.Add(reader.GetInt16(0).ToString());
                comboBoxPeriodEnd.Items.Add(reader.GetInt16(0).ToString());
            }
            reader.Close();
        }
        #endregion

        #region Refresh data
        private void RefreshInfoGraph(object sender, EventArgs e)
        {
            graph = comboBoxGraphType.Text;       
            ChangeGraph("graph");
            buttonVisualize.Enabled = false;
            switch (graph)
            {
                case "Map":
                    pictureBoxGraph.Visible = true;
                    buttonChoiceCountries.Visible = false;
                    labelCountry.Text = "";
                    comboBoxCountries.Visible = false;
                    panelCountry.Visible = false;
                    labelCountriesChosen.Visible = false;

                    textBoxIDCard.Visible = false;

                    labelDataType.Visible = true;
                    comboBoxDataType1.Visible = true;
                    panelData1.Visible = true;
                    comboBoxDataType1.Enabled = true;

                    comboBoxDataType2.Visible = false;
                    panelData2.Visible = false;

                    comboBoxPeriodStart.Visible = true;
                    panelPS.Visible = true;

                    comboBoxPeriodEnd.Visible = true;
                    panelPE.Visible = true;

                    break;
                case "Pie chart":
                    pictureBoxGraph.Visible = true;

                    labelCountry.Visible = true;
                    comboBoxCountries.Visible = false;
                    panelCountry.Visible = false;
                    labelCountry.Text = "Countries";
                    buttonChoiceCountries.Visible = true;
                    panelCountries.Visible = true;
                    textBoxListCountries.Visible = true;
                    labelCountriesChosen.Visible = true;

                    textBoxIDCard.Visible = false;

                    labelDataType.Visible = true;
                    comboBoxDataType1.Visible = true;
                    panelData1.Visible = true;
                    comboBoxDataType1.Enabled = false;

                    comboBoxDataType2.Visible = false;
                    panelData2.Visible = false;

                    labelEra1.Visible = true;
                    comboBoxPeriodStart.Visible = true;
                    panelPS.Visible = true;

                    labelEra2.Visible = true;
                    comboBoxPeriodEnd.Visible = true;
                    panelPE.Visible = true;
                    break;
                case "Scatter plot":
                    pictureBoxGraph.Visible = true;

                    labelCountry.Visible = true;
                    comboBoxCountries.Visible = true;
                    panelCountry.Visible = true;
                    labelCountry.Text = "Country";
                    buttonChoiceCountries.Visible = false;
                    textBoxListCountries.Visible = false;
                    labelCountriesChosen.Visible = false;

                    textBoxIDCard.Visible = false;

                    labelDataType.Visible = true;
                    comboBoxDataType1.Visible = true;
                    panelData1.Visible = true;
                    comboBoxDataType1.Enabled = false;

                    comboBoxDataType2.Visible = false;
                    panelData2.Visible = false;

                    labelEra1.Visible = true;
                    comboBoxPeriodStart.Visible = true;
                    panelPS.Visible = true;

                    labelEra2.Visible = true;
                    comboBoxPeriodEnd.Visible = true;
                    panelPE.Visible = true;
                    break;
                case "Line 1 country 2 data":
                    pictureBoxGraph.Visible = true;

                    labelCountry.Visible = true;
                    comboBoxCountries.Visible = true;
                    panelCountry.Visible = true;
                    labelCountry.Text = "Country";
                    buttonChoiceCountries.Visible = false;
                    textBoxListCountries.Visible = false;
                    labelCountriesChosen.Visible = false;

                    textBoxIDCard.Visible = false;

                    labelDataType.Visible = true;
                    comboBoxDataType1.Visible = true;
                    panelData1.Visible = true;
                    comboBoxDataType1.Enabled = false;

                    comboBoxDataType2.Visible = true;
                    panelData2.Visible = true;
                    comboBoxDataType2.Enabled = false;

                    labelEra1.Visible = true;
                    comboBoxPeriodStart.Visible = true;
                    panelPS.Visible = true;

                    labelEra2.Visible = true;
                    comboBoxPeriodEnd.Visible = true;
                    panelPE.Visible = true;
                    break;
                case "Line N countries 1 data":
                    pictureBoxGraph.Visible = true;

                    labelCountry.Visible = true;
                    comboBoxCountries.Visible = false;
                    panelCountry.Visible = false;
                    labelCountry.Text = "Countries";
                    buttonChoiceCountries.Visible = true;
                    panelCountries.Visible = true;
                    textBoxListCountries.Visible = true;
                    labelCountriesChosen.Visible = true;

                    textBoxIDCard.Visible = false;

                    labelDataType.Visible = true;
                    comboBoxDataType1.Visible = true;
                    panelData1.Visible = true;
                    comboBoxDataType1.Enabled = false;

                    comboBoxDataType2.Visible = false;
                    panelData2.Visible = false;
                    comboBoxDataType2.Enabled = false;

                    labelEra1.Visible = true;
                    comboBoxPeriodStart.Visible = true;
                    panelPS.Visible = true;

                    labelEra2.Visible = true;
                    comboBoxPeriodEnd.Visible = true;
                    panelPE.Visible = true;
                    break;
                case "Identity Card of a country":
                    pictureBoxGraph.Visible = false;

                    labelCountry.Visible = true;
                    comboBoxCountries.Visible = true;
                    panelCountries.Visible = false;
                    labelCountry.Text = "Country";
                    buttonChoiceCountries.Visible = false;
                    textBoxListCountries.Visible = false;
                    labelCountriesChosen.Visible = false;
                    panelCountry.Visible = true;

                    textBoxIDCard.Visible = true;

                    labelDataType.Visible = false;
                    comboBoxDataType1.Enabled = false;
                    comboBoxDataType1.Visible = false;
                    panelData1.Visible = false;

                    comboBoxDataType2.Visible = false;
                    comboBoxDataType2.Enabled = false;
                    panelData2.Visible = false;

                    labelEra1.Visible = false;
                    labelEra2.Visible = false;
                    comboBoxPeriodStart.Visible = false;
                    comboBoxPeriodEnd.Visible = false;
                    panelPS.Visible = false;
                    panelPE.Visible = false;
                    break;
            }
        }

        private void RefreshInfoCountries(object sender, EventArgs e)
        {
            country = comboBoxCountries.Text;
            ChangeGraph("country");
            if (country != null || countriesString != null)
            {
                comboBoxDataType1.Text = "";
                data = null;
                comboBoxDataType1.Enabled = true;


                comboBoxDataType2.Text = "";
                data2 = null;
                comboBoxDataType2.Enabled = true;

                comboBoxPeriodStart.Text = "";
                startPeriod = null;
                comboBoxPeriodStart.Enabled = false;

                comboBoxPeriodEnd.Text = "";
                endPeriod = null;
                comboBoxPeriodEnd.Enabled = false;
            }
            buttonVisualize.Enabled = false;
            if (graph.Equals("Map"))
            {
                InitializeTypeData("SELECT DISTINCT nomType FROM Type ","");
            }
            else if (graph.Equals("Identity Card of a country"))
            {
                foreach (string type in TypeDataList)
                {
                    Console.WriteLine(type);
                    InitializeTypeData("SELECT DISTINCT valeur, MAX(annee), uniteType FROM Donnee INNER JOIN Pays ON Pays.idPays = Donnee.idPays INNER JOIN Type ON Donnee.idType = Type.idType WHERE nomPays = '" + country.Trim() + "' AND nomType = '" + type.Trim() + "' AND annee = (SELECT MAX(annee) FROM Donnee INNER JOIN Pays ON Pays.idPays = Donnee.idPays INNER JOIN Type ON Donnee.idType = Type.idType WHERE nomPays = '" + country.Trim() + "' AND nomType = '" + type.Trim() + "') GROUP BY valeur, uniteType", type.Trim());
                    Console.WriteLine("1");
                    textBoxIDCard.Text += type.Trim() + " : " + dataID.Trim() + " " + unitID.Trim() + " (" + yearID.Trim() + ") ";
                    textBoxIDCard.Text += Environment.NewLine;
                }
            }
            else
            {
                InitializeTypeData("SELECT DISTINCT nomType FROM Type INNER JOIN Donnee ON Donnee.idType = Type.idType INNER JOIN Pays ON Pays.idPays = Donnee.idPays WHERE nomPays = '" + country.Trim() + "'","");
            }
        }

        private void RefreshInfoData(object sender, EventArgs e)
        {
            data = comboBoxDataType1.Text;
            data2 = comboBoxDataType2.Text;
            ChangeGraph("data1");
            if (data != null && graph != "Line 1 country 2 data")
            {
                comboBoxPeriodStart.Enabled = true;
                comboBoxPeriodStart.Text = "";
                startPeriod = null;

                comboBoxPeriodEnd.Enabled = true;
                comboBoxPeriodEnd.Text = "";
                endPeriod = null;
            }
            buttonVisualize.Enabled = false;
            if (data != null && (country != null && countriesString != null))
            {
                if (graph.Equals("Map"))
                {
                    InitializePeriod("SELECT DISTINCT annee FROM Donnee INNER JOIN Type ON Type.idType = Donnee.idType WHERE nomType = '" + data.Trim() + "' ORDER BY annee DESC");
                }
                else if (graph.Equals("Pie chart") || graph.Equals("Line N countries 1 data"))
                {
                    InitializePeriod("SELECT DISTINCT annee FROM Donnee INNER JOIN Type ON Type.idType = Donnee.idType INNER JOIN Pays ON Pays.idPays  = Donnee.idPays WHERE nomType = '" + data.Trim() + "' AND nomPays IN (" + countriesString.Trim() + ") ORDER BY annee DESC");
                }
                else if (graph.Equals("Line 1 country 2 data"))
                {
                    comboBoxDataType2.Items.Remove(data);
                    return;
                }
                else
                {
                    InitializePeriod("SELECT DISTINCT annee FROM Donnee INNER JOIN Type ON Type.idType = Donnee.idType INNER JOIN Pays ON Pays.idPays = Donnee.idPays WHERE nomType = '" + data.Trim() + "' AND nomPays = '" + country.Trim() + "' ORDER BY annee DESC");
                }
            }
            
        }

        private void RefreshInfoData2(object sender, EventArgs e)
        {
            data2 = comboBoxDataType2.Text;
            ChangeGraph("data2");
            if (data != null && (country != null || countriesString != null))
            {
                InitializePeriod("SELECT DISTINCT annee FROM Donnee INNER JOIN Type ON Type.idType = Donnee.idType INNER JOIN Pays ON Pays.idPays = Donnee.idPays WHERE nomType IN ('" + data.Trim() + "','" + data2.Trim() + "') AND nomPays = '" + country.Trim() + "' ORDER BY annee DESC");
                comboBoxPeriodStart.Enabled = true;
                comboBoxPeriodStart.Text = "";
                startPeriod = null;

                comboBoxPeriodEnd.Enabled = true;
                comboBoxPeriodEnd.Text = "";
                endPeriod = null;
            }
        }

        private void RefreshInfoPeriodS(object sender, EventArgs e)
        {
            startPeriod = comboBoxPeriodStart.Text;
            comboBoxPeriodEnd.Items.Clear();
            ChangeGraph("startP");
            if (startPeriod != null && startPeriod != "")
            {
                foreach (string s in YearsList)
                {
                    if (int.Parse(startPeriod) < int.Parse(s))
                    {
                        comboBoxPeriodEnd.Items.Add(s);
                    }
                }
                comboBoxPeriodEnd.Text = endPeriod;
                if (startPeriod.Equals(endPeriod))
                {
                    MessageBox.Show("It is not possible to enter the same year.");
                    buttonVisualize.Enabled = false;
                }
                else if (startPeriod != null && endPeriod != null)
                {
                    buttonVisualize.Enabled = true;
                }
            }
                   
        }

        private void RefreshInfoPeriodE(object sender, EventArgs e)
        {
            endPeriod = comboBoxPeriodEnd.Text;
            ChangeGraph("endP");
            if (startPeriod.Equals(endPeriod))
            {
                MessageBox.Show("It is not possible to enter the same year.");
                buttonVisualize.Enabled = false;
            }
            else if (startPeriod != null && endPeriod != null)
            {
                buttonVisualize.Enabled = true;
            }
        }
        #endregion

        #region Cmd to python

        private Process GenerateCmd()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = cmdStr;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WorkingDirectory = Path.GetDirectoryName(pythonPath);
            cmd.Start();
            return cmd;
        }

        private void CmdAction(string line, Process cmd)
        {
            cmd.StandardInput.WriteLine(line);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
        #endregion
        private void DisplayResult(string fileNameImage)
        {

            using (Image img = Image.FromFile(imgPath + fileNameImage))
            {
                if (graph.Equals("Map"))
                {
                    pictureBoxGraph.Location = new Point(63, 44);
                    pictureBoxGraph.Image = new Bitmap(img,new Size(800, 791));
                }
                else if(graph.Equals("Pie chart") || graph.Equals("Line N countries 1 data"))
                {
                    pictureBoxGraph.Location = new Point(104, 172);
                    pictureBoxGraph.Image = new Bitmap(img);
                }
                else if(graph.Equals("Line 1 country 2 data"))
                {
                    pictureBoxGraph.Location = new Point(67, 172);
                    pictureBoxGraph.Image = new Bitmap(img);
                }
                else if (graph.Equals("Scatter plot"))
                {
                    pictureBoxGraph.Location = new Point(90, 205);
                    pictureBoxGraph.Image = new Bitmap(img);
                }
            }
            labelLoading.Visible = false;
        }
        

        private string ReturnLine()
        {
            string l = "";
            Console.WriteLine("enter");
            switch (graph)
            {
                case "Map":
                    l += "-g map -d '" + data.TrimEnd() + "' -p '" + startPeriod + "-" + endPeriod + "'";
                    break;
                case "Pie chart":
                    l += "-g pie -c '" + countriesString.Replace("'", "") + "' -d '" + data.Trim() + "' -p '" + startPeriod + "-" + endPeriod + "'";
                    break;
                case "Scatter plot":
                    l += "-g scatter -c '" + country.Trim() + "' -d '" + data.TrimEnd() + "' -p '" + startPeriod + "-" + endPeriod + "'";
                    break;
                case "Line 1 country 2 data":
                    l += "-g line -c '" + country.Trim() + "' -d '" + data.TrimEnd() + "," + data2.TrimEnd() + "' -p '" + startPeriod + "-" + endPeriod + "'";
                    break;
                case "Line N countries 1 data":
                    l += "-g line -c '" + countriesString.Replace("'","") + "' -d '" + data.TrimEnd() + "' -p '" + startPeriod + "-" + endPeriod + "'";
                    break;
            }
            Console.WriteLine(l);
            Console.WriteLine("out");
            return l;
        }
        private void buttonVisualize_Click(object sender, EventArgs e)
        {
            labelLoading.Visible = true;
            Process cmd = GenerateCmd();
            CmdAction("python " + simpleScriptName + " " + ReturnLine(), cmd);
            string output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            DisplayResult("im.png");
        }

        private void buttonChoiceCountries_Click(object sender, EventArgs e)
        {
            Countries cL = new Countries(CountriesChoice);
            cL.ShowDialog();
            CountriesChoice = cL.GetSelectedCountries();
            countriesString = "";
            textBoxListCountries.Clear();
            foreach (string c in CountriesChoice)
            {
                Console.WriteLine(c);
                
                if (!countriesString.Contains(c + ","))
                {
                    countriesString += c + ",";
                    
                }
                textBoxListCountries.ForeColor = Color.Black;
                textBoxListCountries.Text += c.Replace("'", "").Trim();
                textBoxListCountries.Text += Environment.NewLine;

            }
            if(countriesString != null && countriesString.Count()>0)
            {
                countriesString = countriesString.Remove(countriesString.Length - 1, 1);
                comboBoxDataType1.Enabled = true;
                InitializeTypeData("SELECT DISTINCT nomType FROM Type INNER JOIN Donnee ON Donnee.idType = Type.idType INNER JOIN Pays ON Pays.idPays = Donnee.idPays WHERE nomPays IN (" + countriesString.Trim() + ")", "");
            }
            else
            {
                MessageBox.Show("You didn't choose any country :(");

            }
        }

        private void ChangeGraph(string reinit)
        {
            textBoxIDCard.Clear();
            switch (reinit)
            {
                case "graph":
                    CountriesChoice = new List<string>();
                    countriesString = null;
                    country = null;
                    data = null;
                    data2 = null;
                    startPeriod = null;
                    endPeriod = null;

                    comboBoxCountries.Enabled = true;
                    comboBoxCountries.Text = "";
                    comboBoxCountries.Text = null;

                    comboBoxDataType1.Text = null;
                    comboBoxDataType1.Enabled = false;
                    comboBoxDataType2.Text = null;
                    comboBoxDataType2.Enabled = false;

                    comboBoxPeriodStart.Text = null;
                    comboBoxPeriodStart.Enabled = false;
                    comboBoxPeriodEnd.Text = null;
                    comboBoxPeriodEnd.Enabled = false;
                    buttonVisualize.Enabled = false;

                    textBoxListCountries.Visible = false;
                    textBoxListCountries.Clear();
                    panelCountries.Visible = false;
                    labelCountriesChosen.Visible = false;
                    pictureBoxGraph.Image = null;
                    break;
                case "country":
                    data = null;
                    data2 = null;
                    startPeriod = null;
                    endPeriod = null;

                    comboBoxDataType1.Text = null;
                    comboBoxDataType1.Enabled = false;
                    comboBoxDataType2.Text = null;
                    comboBoxDataType2.Enabled = false;

                    comboBoxPeriodStart.Text = null;
                    comboBoxPeriodStart.Enabled = false;
                    comboBoxPeriodEnd.Text = null;
                    comboBoxPeriodEnd.Enabled = false;
                    buttonVisualize.Enabled = false;

                    textBoxListCountries.Visible = false;
                    textBoxListCountries.Clear();
                    panelCountries.Visible = false;
                    labelCountriesChosen.Visible = false;
                    break;
                case "data1":
                    data2 = null;
                    startPeriod = null;
                    endPeriod = null;

                    comboBoxDataType2.Text = null;
                    comboBoxDataType2.Enabled = true;

                    comboBoxPeriodStart.Text = null;
                    comboBoxPeriodStart.Enabled = false;
                    comboBoxPeriodEnd.Text = null;
                    comboBoxPeriodEnd.Enabled = false;
                    buttonVisualize.Enabled = false;
                    break;
                case "data2":
                    comboBoxPeriodStart.Text = null;
                    comboBoxPeriodStart.Enabled = false;
                    comboBoxPeriodEnd.Text = null;
                    comboBoxPeriodEnd.Enabled = false;
                    buttonVisualize.Enabled = false;
                    break;
                case "startP": 
                    comboBoxPeriodEnd.Text = null;
                    comboBoxPeriodEnd.Enabled = true;
                    buttonVisualize.Enabled = false;
                    break;
                case "endP":
                    buttonVisualize.Enabled = false;
                    break;
            }
            
        }

        #region design
        static public void RoundedPictureBox(Panel p)
        {
            GraphicsPath gp = new GraphicsPath();
            int d = 50;
            gp.AddArc(0, 0, d, d, 180, 90);
            gp.AddArc(p.Width - d, 0, d, d, 270, 90);
            gp.AddArc(p.Width - d, p.Height - d, d, d, 0, 90);
            gp.AddArc(0, p.Height - d, d, d, 90, 90);
            gp.CloseFigure();
            p.Region = new Region(gp);
        }

        #endregion
    }
}
