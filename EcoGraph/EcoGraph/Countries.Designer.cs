namespace EcoGraph
{
    partial class Countries
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
            this.checkedListBoxCountries = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelCheck = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // checkedListBoxCountries
            // 
            this.checkedListBoxCountries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxCountries.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxCountries.FormattingEnabled = true;
            this.checkedListBoxCountries.Location = new System.Drawing.Point(42, 25);
            this.checkedListBoxCountries.Name = "checkedListBoxCountries";
            this.checkedListBoxCountries.Size = new System.Drawing.Size(195, 255);
            this.checkedListBoxCountries.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.Transparent;
            this.buttonOK.BackgroundImage = global::EcoGr_aph.Properties.Resources.button_2_;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(275, 239);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(126, 39);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Valider";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelCheck
            // 
            this.panelCheck.BackColor = System.Drawing.Color.White;
            this.panelCheck.Location = new System.Drawing.Point(32, 12);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Size = new System.Drawing.Size(218, 284);
            this.panelCheck.TabIndex = 4;
            // 
            // Countries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(101)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(419, 308);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkedListBoxCountries);
            this.Controls.Add(this.panelCheck);
            this.Name = "Countries";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxCountries;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel panelCheck;
    }
}