namespace EcoGraph
{
    partial class EcoGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitleGraph = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelDataType = new System.Windows.Forms.Label();
            this.labelGraphType = new System.Windows.Forms.Label();
            this.labelEra1 = new System.Windows.Forms.Label();
            this.labelEra2 = new System.Windows.Forms.Label();
            this.buttonVisualize = new System.Windows.Forms.Button();
            this.comboBoxCountries = new System.Windows.Forms.ComboBox();
            this.comboBoxGraphType = new System.Windows.Forms.ComboBox();
            this.comboBoxDataType1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPeriodStart = new System.Windows.Forms.ComboBox();
            this.comboBoxPeriodEnd = new System.Windows.Forms.ComboBox();
            this.textBoxListCountries = new System.Windows.Forms.TextBox();
            this.comboBoxDataType2 = new System.Windows.Forms.ComboBox();
            this.labelCountriesChosen = new System.Windows.Forms.Label();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panelGraphType = new System.Windows.Forms.Panel();
            this.panelCountry = new System.Windows.Forms.Panel();
            this.panelData1 = new System.Windows.Forms.Panel();
            this.panelData2 = new System.Windows.Forms.Panel();
            this.panelPS = new System.Windows.Forms.Panel();
            this.panelPE = new System.Windows.Forms.Panel();
            this.panelCountries = new System.Windows.Forms.Panel();
            this.panelImg = new System.Windows.Forms.Panel();
            this.textBoxIDCard = new System.Windows.Forms.TextBox();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonChoiceCountries = new System.Windows.Forms.Button();
            this.panelData1.SuspendLayout();
            this.panelData2.SuspendLayout();
            this.panelCountries.SuspendLayout();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleGraph
            // 
            this.labelTitleGraph.AutoSize = true;
            this.labelTitleGraph.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleGraph.Font = new System.Drawing.Font("Colonna MT", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleGraph.ForeColor = System.Drawing.Color.White;
            this.labelTitleGraph.Location = new System.Drawing.Point(66, 81);
            this.labelTitleGraph.Name = "labelTitleGraph";
            this.labelTitleGraph.Size = new System.Drawing.Size(460, 101);
            this.labelTitleGraph.TabIndex = 0;
            this.labelTitleGraph.Text = "EcoGr³aph";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.BackColor = System.Drawing.Color.Transparent;
            this.labelCountry.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelCountry.ForeColor = System.Drawing.Color.White;
            this.labelCountry.Location = new System.Drawing.Point(106, 399);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(115, 66);
            this.labelCountry.TabIndex = 6;
            this.labelCountry.Text = "Country";
            // 
            // labelDataType
            // 
            this.labelDataType.AutoSize = true;
            this.labelDataType.BackColor = System.Drawing.Color.Transparent;
            this.labelDataType.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelDataType.ForeColor = System.Drawing.Color.White;
            this.labelDataType.Location = new System.Drawing.Point(102, 546);
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(141, 66);
            this.labelDataType.TabIndex = 7;
            this.labelDataType.Text = "Data type :";
            // 
            // labelGraphType
            // 
            this.labelGraphType.AutoSize = true;
            this.labelGraphType.BackColor = System.Drawing.Color.Transparent;
            this.labelGraphType.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGraphType.ForeColor = System.Drawing.Color.White;
            this.labelGraphType.Location = new System.Drawing.Point(100, 247);
            this.labelGraphType.Name = "labelGraphType";
            this.labelGraphType.Size = new System.Drawing.Size(159, 66);
            this.labelGraphType.TabIndex = 8;
            this.labelGraphType.Text = "Graph type :";
            // 
            // labelEra1
            // 
            this.labelEra1.AutoSize = true;
            this.labelEra1.BackColor = System.Drawing.Color.Transparent;
            this.labelEra1.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelEra1.ForeColor = System.Drawing.Color.White;
            this.labelEra1.Location = new System.Drawing.Point(91, 768);
            this.labelEra1.Name = "labelEra1";
            this.labelEra1.Size = new System.Drawing.Size(98, 66);
            this.labelEra1.TabIndex = 9;
            this.labelEra1.Text = "From :";
            // 
            // labelEra2
            // 
            this.labelEra2.AutoSize = true;
            this.labelEra2.BackColor = System.Drawing.Color.Transparent;
            this.labelEra2.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelEra2.ForeColor = System.Drawing.Color.White;
            this.labelEra2.Location = new System.Drawing.Point(314, 769);
            this.labelEra2.Name = "labelEra2";
            this.labelEra2.Size = new System.Drawing.Size(48, 66);
            this.labelEra2.TabIndex = 10;
            this.labelEra2.Text = "to";
            // 
            // buttonVisualize
            // 
            this.buttonVisualize.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.buttonVisualize.Location = new System.Drawing.Point(1658, 912);
            this.buttonVisualize.Name = "buttonVisualize";
            this.buttonVisualize.Size = new System.Drawing.Size(224, 80);
            this.buttonVisualize.TabIndex = 11;
            this.buttonVisualize.Text = "Visualize";
            this.buttonVisualize.UseVisualStyleBackColor = true;
            this.buttonVisualize.Click += new System.EventHandler(this.buttonVisualize_Click);
            // 
            // comboBoxCountries
            // 
            this.comboBoxCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCountries.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCountries.FormattingEnabled = true;
            this.comboBoxCountries.Location = new System.Drawing.Point(106, 465);
            this.comboBoxCountries.Name = "comboBoxCountries";
            this.comboBoxCountries.Size = new System.Drawing.Size(521, 42);
            this.comboBoxCountries.TabIndex = 13;
            this.comboBoxCountries.TextUpdate += new System.EventHandler(this.RefreshInfoCountries);
            this.comboBoxCountries.TextChanged += new System.EventHandler(this.RefreshInfoCountries);
            // 
            // comboBoxGraphType
            // 
            this.comboBoxGraphType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxGraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraphType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGraphType.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGraphType.FormattingEnabled = true;
            this.comboBoxGraphType.Location = new System.Drawing.Point(106, 318);
            this.comboBoxGraphType.Name = "comboBoxGraphType";
            this.comboBoxGraphType.Size = new System.Drawing.Size(521, 42);
            this.comboBoxGraphType.TabIndex = 15;
            this.comboBoxGraphType.TextUpdate += new System.EventHandler(this.RefreshInfoGraph);
            this.comboBoxGraphType.TextChanged += new System.EventHandler(this.RefreshInfoGraph);
            // 
            // comboBoxDataType1
            // 
            this.comboBoxDataType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDataType1.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDataType1.FormattingEnabled = true;
            this.comboBoxDataType1.Location = new System.Drawing.Point(10, 10);
            this.comboBoxDataType1.Name = "comboBoxDataType1";
            this.comboBoxDataType1.Size = new System.Drawing.Size(521, 42);
            this.comboBoxDataType1.TabIndex = 16;
            this.comboBoxDataType1.TextUpdate += new System.EventHandler(this.RefreshInfoData);
            this.comboBoxDataType1.TextChanged += new System.EventHandler(this.RefreshInfoData);
            // 
            // comboBoxPeriodStart
            // 
            this.comboBoxPeriodStart.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriodStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPeriodStart.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPeriodStart.FormattingEnabled = true;
            this.comboBoxPeriodStart.Location = new System.Drawing.Point(207, 788);
            this.comboBoxPeriodStart.Name = "comboBoxPeriodStart";
            this.comboBoxPeriodStart.Size = new System.Drawing.Size(98, 42);
            this.comboBoxPeriodStart.TabIndex = 19;
            this.comboBoxPeriodStart.TextUpdate += new System.EventHandler(this.RefreshInfoPeriodS);
            this.comboBoxPeriodStart.TextChanged += new System.EventHandler(this.RefreshInfoPeriodS);
            // 
            // comboBoxPeriodEnd
            // 
            this.comboBoxPeriodEnd.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriodEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPeriodEnd.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPeriodEnd.FormattingEnabled = true;
            this.comboBoxPeriodEnd.Location = new System.Drawing.Point(366, 788);
            this.comboBoxPeriodEnd.Name = "comboBoxPeriodEnd";
            this.comboBoxPeriodEnd.Size = new System.Drawing.Size(98, 42);
            this.comboBoxPeriodEnd.TabIndex = 20;
            this.comboBoxPeriodEnd.TextChanged += new System.EventHandler(this.RefreshInfoPeriodE);
            // 
            // textBoxListCountries
            // 
            this.textBoxListCountries.BackColor = System.Drawing.Color.White;
            this.textBoxListCountries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxListCountries.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxListCountries.ForeColor = System.Drawing.Color.Black;
            this.textBoxListCountries.Location = new System.Drawing.Point(13, 18);
            this.textBoxListCountries.Multiline = true;
            this.textBoxListCountries.Name = "textBoxListCountries";
            this.textBoxListCountries.Size = new System.Drawing.Size(155, 306);
            this.textBoxListCountries.TabIndex = 22;
            // 
            // comboBoxDataType2
            // 
            this.comboBoxDataType2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxDataType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDataType2.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDataType2.FormattingEnabled = true;
            this.comboBoxDataType2.Location = new System.Drawing.Point(10, 8);
            this.comboBoxDataType2.Name = "comboBoxDataType2";
            this.comboBoxDataType2.Size = new System.Drawing.Size(521, 42);
            this.comboBoxDataType2.TabIndex = 23;
            this.comboBoxDataType2.TextUpdate += new System.EventHandler(this.RefreshInfoData2);
            this.comboBoxDataType2.TextChanged += new System.EventHandler(this.RefreshInfoData2);
            // 
            // labelCountriesChosen
            // 
            this.labelCountriesChosen.AutoSize = true;
            this.labelCountriesChosen.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelCountriesChosen.ForeColor = System.Drawing.Color.White;
            this.labelCountriesChosen.Location = new System.Drawing.Point(1664, 249);
            this.labelCountriesChosen.Name = "labelCountriesChosen";
            this.labelCountriesChosen.Size = new System.Drawing.Size(219, 66);
            this.labelCountriesChosen.TabIndex = 24;
            this.labelCountriesChosen.Text = "Countries chosen :";
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Amiri", 18F, System.Drawing.FontStyle.Bold);
            this.labelLoading.Location = new System.Drawing.Point(1662, 846);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(132, 66);
            this.labelLoading.TabIndex = 26;
            this.labelLoading.Text = "Loading ...";
            // 
            // panelGraphType
            // 
            this.panelGraphType.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelGraphType.BackColor = System.Drawing.Color.White;
            this.panelGraphType.Location = new System.Drawing.Point(96, 306);
            this.panelGraphType.Name = "panelGraphType";
            this.panelGraphType.Size = new System.Drawing.Size(541, 63);
            this.panelGraphType.TabIndex = 27;
            // 
            // panelCountry
            // 
            this.panelCountry.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelCountry.BackColor = System.Drawing.Color.White;
            this.panelCountry.Location = new System.Drawing.Point(96, 457);
            this.panelCountry.Name = "panelCountry";
            this.panelCountry.Size = new System.Drawing.Size(541, 57);
            this.panelCountry.TabIndex = 28;
            // 
            // panelData1
            // 
            this.panelData1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelData1.BackColor = System.Drawing.Color.White;
            this.panelData1.Controls.Add(this.comboBoxDataType1);
            this.panelData1.Location = new System.Drawing.Point(96, 604);
            this.panelData1.Name = "panelData1";
            this.panelData1.Size = new System.Drawing.Size(541, 59);
            this.panelData1.TabIndex = 28;
            // 
            // panelData2
            // 
            this.panelData2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelData2.BackColor = System.Drawing.Color.White;
            this.panelData2.Controls.Add(this.comboBoxDataType2);
            this.panelData2.Location = new System.Drawing.Point(96, 679);
            this.panelData2.Name = "panelData2";
            this.panelData2.Size = new System.Drawing.Size(541, 58);
            this.panelData2.TabIndex = 28;
            // 
            // panelPS
            // 
            this.panelPS.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelPS.BackColor = System.Drawing.Color.White;
            this.panelPS.Location = new System.Drawing.Point(195, 780);
            this.panelPS.Name = "panelPS";
            this.panelPS.Size = new System.Drawing.Size(121, 55);
            this.panelPS.TabIndex = 29;
            // 
            // panelPE
            // 
            this.panelPE.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelPE.BackColor = System.Drawing.Color.White;
            this.panelPE.Location = new System.Drawing.Point(356, 780);
            this.panelPE.Name = "panelPE";
            this.panelPE.Size = new System.Drawing.Size(117, 55);
            this.panelPE.TabIndex = 30;
            // 
            // panelCountries
            // 
            this.panelCountries.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelCountries.BackColor = System.Drawing.Color.White;
            this.panelCountries.Controls.Add(this.textBoxListCountries);
            this.panelCountries.Location = new System.Drawing.Point(1672, 305);
            this.panelCountries.Name = "panelCountries";
            this.panelCountries.Size = new System.Drawing.Size(182, 342);
            this.panelCountries.TabIndex = 31;
            // 
            // panelImg
            // 
            this.panelImg.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelImg.BackColor = System.Drawing.Color.White;
            this.panelImg.Controls.Add(this.textBoxIDCard);
            this.panelImg.Controls.Add(this.pictureBoxGraph);
            this.panelImg.Location = new System.Drawing.Point(725, 95);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(902, 850);
            this.panelImg.TabIndex = 28;
            // 
            // textBoxIDCard
            // 
            this.textBoxIDCard.BackColor = System.Drawing.Color.White;
            this.textBoxIDCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIDCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIDCard.Enabled = false;
            this.textBoxIDCard.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIDCard.Location = new System.Drawing.Point(138, 128);
            this.textBoxIDCard.Multiline = true;
            this.textBoxIDCard.Name = "textBoxIDCard";
            this.textBoxIDCard.Size = new System.Drawing.Size(628, 545);
            this.textBoxIDCard.TabIndex = 13;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.BackColor = System.Drawing.Color.White;
            this.pictureBoxGraph.Location = new System.Drawing.Point(41, 26);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(807, 791);
            this.pictureBoxGraph.TabIndex = 12;
            this.pictureBoxGraph.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EcoGr_aph.Properties.Resources.carotteMascotte_1_;
            this.pictureBox1.Location = new System.Drawing.Point(528, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 145);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // buttonChoiceCountries
            // 
            this.buttonChoiceCountries.BackColor = System.Drawing.Color.Transparent;
            this.buttonChoiceCountries.BackgroundImage = global::EcoGr_aph.Properties.Resources.button_2_;
            this.buttonChoiceCountries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChoiceCountries.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChoiceCountries.Location = new System.Drawing.Point(106, 457);
            this.buttonChoiceCountries.Name = "buttonChoiceCountries";
            this.buttonChoiceCountries.Size = new System.Drawing.Size(126, 39);
            this.buttonChoiceCountries.TabIndex = 21;
            this.buttonChoiceCountries.Text = "Choose";
            this.buttonChoiceCountries.UseVisualStyleBackColor = false;
            this.buttonChoiceCountries.Click += new System.EventHandler(this.buttonChoiceCountries_Click);
            // 
            // EcoGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(101)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelData2);
            this.Controls.Add(this.labelLoading);
            this.Controls.Add(this.buttonChoiceCountries);
            this.Controls.Add(this.comboBoxPeriodEnd);
            this.Controls.Add(this.comboBoxPeriodStart);
            this.Controls.Add(this.comboBoxGraphType);
            this.Controls.Add(this.comboBoxCountries);
            this.Controls.Add(this.buttonVisualize);
            this.Controls.Add(this.labelEra1);
            this.Controls.Add(this.labelTitleGraph);
            this.Controls.Add(this.panelGraphType);
            this.Controls.Add(this.panelCountry);
            this.Controls.Add(this.panelData1);
            this.Controls.Add(this.panelPS);
            this.Controls.Add(this.panelPE);
            this.Controls.Add(this.panelImg);
            this.Controls.Add(this.labelEra2);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelGraphType);
            this.Controls.Add(this.labelDataType);
            this.Controls.Add(this.panelCountries);
            this.Controls.Add(this.labelCountriesChosen);
            this.Name = "EcoGraph";
            this.Text = "EcoGr³aph";
            this.panelData1.ResumeLayout(false);
            this.panelData2.ResumeLayout(false);
            this.panelCountries.ResumeLayout(false);
            this.panelCountries.PerformLayout();
            this.panelImg.ResumeLayout(false);
            this.panelImg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleGraph;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelDataType;
        private System.Windows.Forms.Label labelGraphType;
        private System.Windows.Forms.Label labelEra1;
        private System.Windows.Forms.Label labelEra2;
        private System.Windows.Forms.Button buttonVisualize;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.ComboBox comboBoxCountries;
        private System.Windows.Forms.ComboBox comboBoxGraphType;
        private System.Windows.Forms.ComboBox comboBoxDataType1;
        private System.Windows.Forms.ComboBox comboBoxPeriodStart;
        private System.Windows.Forms.ComboBox comboBoxPeriodEnd;
        private System.Windows.Forms.Button buttonChoiceCountries;
        private System.Windows.Forms.TextBox textBoxListCountries;
        private System.Windows.Forms.ComboBox comboBoxDataType2;
        private System.Windows.Forms.Label labelCountriesChosen;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Panel panelGraphType;
        private System.Windows.Forms.Panel panelCountry;
        private System.Windows.Forms.Panel panelData1;
        private System.Windows.Forms.Panel panelData2;
        private System.Windows.Forms.Panel panelPS;
        private System.Windows.Forms.Panel panelPE;
        private System.Windows.Forms.Panel panelCountries;
        private System.Windows.Forms.Panel panelImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxIDCard;
    }
}