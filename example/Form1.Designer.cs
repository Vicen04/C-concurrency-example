namespace Assigment_V024491H
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Provider = new System.Windows.Forms.ListBox();
            this.Provider_type = new System.Windows.Forms.ListBox();
            this.Weeks = new System.Windows.Forms.ListBox();
            this.Shops = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Years = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.All_dates = new System.Windows.Forms.CheckBox();
            this.All_providers = new System.Windows.Forms.CheckBox();
            this.All_Provider_types = new System.Windows.Forms.CheckBox();
            this.All_shops = new System.Windows.Forms.CheckBox();
            this.Result = new System.Windows.Forms.Label();
            this.Clear_all = new System.Windows.Forms.Button();
            this.All_selected = new System.Windows.Forms.CheckBox();
            this.Text1 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.text3 = new System.Windows.Forms.Label();
            this.text4 = new System.Windows.Forms.Label();
            this.Time_to_calculate = new System.Windows.Forms.Label();
            this.Weeks_title = new System.Windows.Forms.Label();
            this.Years_title = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Select_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.Select_file = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Years)).BeginInit();
            this.SuspendLayout();
            // 
            // Provider
            // 
            this.Provider.FormattingEnabled = true;
            this.Provider.Location = new System.Drawing.Point(93, 401);
            this.Provider.Name = "Provider";
            this.Provider.Size = new System.Drawing.Size(165, 108);
            this.Provider.TabIndex = 0;
            // 
            // Provider_type
            // 
            this.Provider_type.FormattingEnabled = true;
            this.Provider_type.Location = new System.Drawing.Point(430, 401);
            this.Provider_type.Name = "Provider_type";
            this.Provider_type.Size = new System.Drawing.Size(214, 108);
            this.Provider_type.TabIndex = 2;
            // 
            // Weeks
            // 
            this.Weeks.FormattingEnabled = true;
            this.Weeks.Location = new System.Drawing.Point(392, 139);
            this.Weeks.Name = "Weeks";
            this.Weeks.Size = new System.Drawing.Size(120, 95);
            this.Weeks.TabIndex = 4;
            // 
            // Shops
            // 
            this.Shops.FormattingEnabled = true;
            this.Shops.Location = new System.Drawing.Point(795, 401);
            this.Shops.Name = "Shops";
            this.Shops.Size = new System.Drawing.Size(156, 108);
            this.Shops.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(668, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // Years
            // 
            this.Years.Location = new System.Drawing.Point(568, 176);
            this.Years.Maximum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.Years.Minimum = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.Years.Name = "Years";
            this.Years.Size = new System.Drawing.Size(120, 20);
            this.Years.TabIndex = 9;
            this.Years.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1100, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // All_dates
            // 
            this.All_dates.AutoSize = true;
            this.All_dates.Location = new System.Drawing.Point(507, 254);
            this.All_dates.Name = "All_dates";
            this.All_dates.Size = new System.Drawing.Size(66, 17);
            this.All_dates.TabIndex = 11;
            this.All_dates.Text = "All dates";
            this.All_dates.UseVisualStyleBackColor = true;
            this.All_dates.CheckedChanged += new System.EventHandler(this.AllDates_CheckedChanged);
            // 
            // All_providers
            // 
            this.All_providers.AutoSize = true;
            this.All_providers.Location = new System.Drawing.Point(133, 515);
            this.All_providers.Name = "All_providers";
            this.All_providers.Size = new System.Drawing.Size(83, 17);
            this.All_providers.TabIndex = 12;
            this.All_providers.Text = "All providers";
            this.All_providers.UseVisualStyleBackColor = true;
            this.All_providers.CheckedChanged += new System.EventHandler(this.AllProviders_CheckedChanged);
            // 
            // All_Provider_types
            // 
            this.All_Provider_types.AutoSize = true;
            this.All_Provider_types.Location = new System.Drawing.Point(486, 515);
            this.All_Provider_types.Name = "All_Provider_types";
            this.All_Provider_types.Size = new System.Drawing.Size(106, 17);
            this.All_Provider_types.TabIndex = 13;
            this.All_Provider_types.Text = "All provider types";
            this.All_Provider_types.UseVisualStyleBackColor = true;
            this.All_Provider_types.CheckedChanged += new System.EventHandler(this.All_Provider_types_CheckedChanged);
            // 
            // All_shops
            // 
            this.All_shops.AutoSize = true;
            this.All_shops.Location = new System.Drawing.Point(837, 515);
            this.All_shops.Name = "All_shops";
            this.All_shops.Size = new System.Drawing.Size(68, 17);
            this.All_shops.TabIndex = 14;
            this.All_shops.Text = "All shops";
            this.All_shops.UseVisualStyleBackColor = true;
            this.All_shops.CheckedChanged += new System.EventHandler(this.All_shops_CheckedChanged);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Result.Location = new System.Drawing.Point(1106, 478);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(0, 13);
            this.Result.TabIndex = 15;
            // 
            // Clear_all
            // 
            this.Clear_all.Location = new System.Drawing.Point(477, 578);
            this.Clear_all.Name = "Clear_all";
            this.Clear_all.Size = new System.Drawing.Size(126, 38);
            this.Clear_all.TabIndex = 16;
            this.Clear_all.Text = "Clear all";
            this.Clear_all.UseVisualStyleBackColor = true;
            this.Clear_all.Click += new System.EventHandler(this.Clear_all_Click);
            // 
            // All_selected
            // 
            this.All_selected.AutoSize = true;
            this.All_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.All_selected.Location = new System.Drawing.Point(1141, 172);
            this.All_selected.Name = "All_selected";
            this.All_selected.Size = new System.Drawing.Size(120, 24);
            this.All_selected.TabIndex = 17;
            this.All_selected.Text = "Calculate all";
            this.All_selected.UseVisualStyleBackColor = true;
            this.All_selected.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // Text1
            // 
            this.Text1.AutoSize = true;
            this.Text1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Navy;
            this.Text1.Location = new System.Drawing.Point(125, 347);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(101, 22);
            this.Text1.TabIndex = 18;
            this.Text1.Text = "Providers";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.text2.ForeColor = System.Drawing.Color.Navy;
            this.text2.Location = new System.Drawing.Point(491, 347);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(91, 22);
            this.text2.TabIndex = 19;
            this.text2.Text = "Supplies";
            // 
            // text3
            // 
            this.text3.AutoSize = true;
            this.text3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.text3.ForeColor = System.Drawing.Color.Navy;
            this.text3.Location = new System.Drawing.Point(833, 347);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(75, 22);
            this.text3.TabIndex = 20;
            this.text3.Text = "Shops ";
            // 
            // text4
            // 
            this.text4.AutoSize = true;
            this.text4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.text4.ForeColor = System.Drawing.Color.Navy;
            this.text4.Location = new System.Drawing.Point(503, 72);
            this.text4.Name = "text4";
            this.text4.Size = new System.Drawing.Size(52, 22);
            this.text4.TabIndex = 21;
            this.text4.Text = "Date";
            // 
            // Time_to_calculate
            // 
            this.Time_to_calculate.AutoSize = true;
            this.Time_to_calculate.ForeColor = System.Drawing.Color.DarkBlue;
            this.Time_to_calculate.Location = new System.Drawing.Point(1106, 497);
            this.Time_to_calculate.Name = "Time_to_calculate";
            this.Time_to_calculate.Size = new System.Drawing.Size(0, 13);
            this.Time_to_calculate.TabIndex = 22;
            // 
            // Weeks_title
            // 
            this.Weeks_title.AutoSize = true;
            this.Weeks_title.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.Weeks_title.ForeColor = System.Drawing.Color.Navy;
            this.Weeks_title.Location = new System.Drawing.Point(428, 107);
            this.Weeks_title.Name = "Weeks_title";
            this.Weeks_title.Size = new System.Drawing.Size(55, 18);
            this.Weeks_title.TabIndex = 23;
            this.Weeks_title.Text = "Weeks";
            // 
            // Years_title
            // 
            this.Years_title.AutoSize = true;
            this.Years_title.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.Years_title.ForeColor = System.Drawing.Color.Navy;
            this.Years_title.Location = new System.Drawing.Point(597, 107);
            this.Years_title.Name = "Years_title";
            this.Years_title.Size = new System.Drawing.Size(48, 18);
            this.Years_title.TabIndex = 24;
            this.Years_title.Text = "Years";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Select_folder
            // 
            this.Select_folder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1339, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 109);
            this.button2.TabIndex = 25;
            this.button2.Text = "Create Graph";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 658);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Years_title);
            this.Controls.Add(this.Weeks_title);
            this.Controls.Add(this.Time_to_calculate);
            this.Controls.Add(this.text4);
            this.Controls.Add(this.text3);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.All_selected);
            this.Controls.Add(this.Clear_all);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.All_shops);
            this.Controls.Add(this.All_Provider_types);
            this.Controls.Add(this.All_providers);
            this.Controls.Add(this.All_dates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Years);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Shops);
            this.Controls.Add(this.Weeks);
            this.Controls.Add(this.Provider_type);
            this.Controls.Add(this.Provider);
            this.Name = "Form1";
            this.Text = "UI test";
            ((System.ComponentModel.ISupportInitialize)(this.Years)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Provider;
        private System.Windows.Forms.ListBox Provider_type;
        private System.Windows.Forms.ListBox Weeks;
        private System.Windows.Forms.ListBox Shops;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Years;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox All_dates;
        private System.Windows.Forms.CheckBox All_providers;
        private System.Windows.Forms.CheckBox All_Provider_types;
        private System.Windows.Forms.CheckBox All_shops;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Button Clear_all;
        private System.Windows.Forms.CheckBox All_selected;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.Label text2;
        private System.Windows.Forms.Label text3;
        private System.Windows.Forms.Label text4;
        private System.Windows.Forms.Label Time_to_calculate;
        private System.Windows.Forms.Label Weeks_title;
        private System.Windows.Forms.Label Years_title;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog Select_folder;
        private System.Windows.Forms.OpenFileDialog Select_file;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer2;
    }
}

