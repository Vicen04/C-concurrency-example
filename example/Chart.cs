using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example
{
    //Made to create a chart that will display the data selected for comparisons, works in a similar way as the form
    public partial class Chart : Form
    {
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea;
        System.Windows.Forms.DataVisualization.Charting.Legend legend;
        System.Windows.Forms.DataVisualization.Charting.Series series;
        private ListBox.ObjectCollection shops, suppliers, supplies;
        ListBox dates = new ListBox();
        public List<string> count;
        public string shopSelected, supplierSelected, suppliesSelected, dateSelected;
        string choice1, choice2;
        bool shops1 = false, shops2 = false, suppliers1 = false, suppliers2 = false, supplies1 = false, supplies2 = false, dates1 = false, dates2 = false;
        public bool ready = false, allShops, allSupplies, allDates, allSuppliers, listShops, listDates, listSuppliers, listSupplies;

        int loop;

        //Create and hide until its done
        public Chart(ListBox shop, ListBox provider, ListBox provider_supplies)
        {                       
            InitializeComponent();
            chart1.SendToBack();
            chart1.Hide();
            Restart.Hide();
            count = new List<string>();
            shops = shop.Items;
            suppliers = provider.Items;
            supplies = provider_supplies.Items;
            for (int j = 2013; j < 2015; j++)
            {
                for (int i = 1; i < 53; i++)
                {
                    dates.Items.Add(i.ToString() + "_" + j.ToString());
                }
            }
            CreateVisuals();
        }

        //set up the data and the chart
        public void BindData()
        {
            chart1.ChartAreas.Add(chartArea);
            chart1.Series.Add(series);
            chart1.Legends.Add(legend);
            chart1.Titles.Add("Cost " + choice1 + choice2);
            chart1.Titles[0].Font = new Font("Arial", 15.5f, FontStyle.Regular);
            chart1.Titles[0].ForeColor = Color.OrangeRed;
            chart1.Show();
            chart1.BringToFront();
            Restart.Show();
            Restart.Enabled = true;           
        }

        //checkbox, works in the same way as the form, but here, all the boxes cannot be clicked
        private void Date_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(dates.Items);
            allDates = listShops = listSuppliers = listSupplies = false;
            allShops = allSuppliers = allSupplies = listDates = true;
        }

        private void Shops_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(shops);
            allShops = listDates = listSuppliers = listSupplies = false;
            allDates = allSuppliers = allSupplies = listShops = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Comparisons.Enabled = Accept_1.Enabled = false;
            Comparisons.ForeColor = Accept_1.ForeColor = label1.ForeColor = SystemColors.InactiveCaption;
            loop = decimal.ToInt32(Comparisons.Value);            
            Date.Enabled = Shops.Enabled = Supplies.Enabled = Suppliers.Enabled = listBox1.Enabled = Accept_2.Enabled = true;
            listBox1.BackColor = SystemColors.Window;
            Supplies.ForeColor = Suppliers.ForeColor = Date.ForeColor =  Shops.ForeColor = listBox1.ForeColor = Accept_2.ForeColor = SystemColors.ControlText;
            select_text1.Text = "Remaining values to select: " + loop;
        }

        private void Suppliers_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(suppliers);
            allSuppliers = listDates = listShops = listSupplies = false;
            allShops = allDates = allSupplies = listSuppliers =true;
        }

        private void Supplies_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(supplies);
            allSupplies = listDates = listSuppliers = listShops = false;
            allShops = allSuppliers = allDates = listSupplies = true;
        }

        private void Dates_2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(dates.Items);
            dates1 = true;
            shops1 = supplies1 = suppliers1 = false;
        }

        private void Shops_2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(shops);
            shops1 = true;
            dates1 = supplies1 = suppliers1 = false;
        }

        private void Suppliers_2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(suppliers);
            suppliers1 = true;
            dates1 = supplies1 = shops1 = false;
        }

        private void Supplies_2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(supplies);
            supplies1 = true;
            dates1 = suppliers1 = shops1 = false;
        }

        private void dates_3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(dates.Items);
            dates2 = true;
            shops2 = supplies2 = suppliers2 = false;
        }

        private void Shops_3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(shops);
            shops2 = true;
            dates2 = supplies2 = suppliers2 = false;
        }

        private void Suppliers_3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(suppliers);
            suppliers2 = true;
            dates2 = supplies2 = shops2 = false;
        }

        private void Supplies_3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(supplies);
            supplies2 = true;
            dates2 = suppliers2 = shops2 = false;
        }

        private void Accept_2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0 && listBox1.SelectedItem != null)
            {               
                Suppliers.Enabled = Shops.Enabled = Date.Enabled = Supplies.Enabled = false;
                StopSelecting.Enabled = true;
                StopSelecting.ForeColor = SystemColors.ControlText;
                Supplies.ForeColor = Suppliers.ForeColor = Date.ForeColor = Shops.ForeColor = SystemColors.InactiveCaption;
                count.Add(listBox1.SelectedItem.ToString());
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.ClearSelected();
                loop--;
                select_text1.Text = "Remaining values to select: " + loop;
            }
            else
                select_text1.Text = "Please, select a value";

            if (StopSelecting.Checked)
            {
                loop = 0;
            }

            if (loop <= 0)
            {
                select_text1.Text = null;
                Accept_2.Enabled = listBox1.Enabled = StopSelecting.Enabled = false;
                Accept_2.ForeColor = listBox1.ForeColor = Text1.ForeColor = StopSelecting.ForeColor = SystemColors.InactiveCaption;
                listBox1.BackColor = SystemColors.ActiveBorder;
                if (allDates)
                {
                    Dates_2.ForeColor = SystemColors.ControlText;
                    Dates_2.Enabled = true;
                }
                if (allShops)
                {
                    Shops_2.ForeColor = SystemColors.ControlText;
                    Shops_2.Enabled = true;
                }
                if (allSuppliers)
                {
                    Suppliers_2.Enabled = true;
                    Suppliers_2.ForeColor = SystemColors.ControlText;
                }
                if (allSupplies)
                {
                    Supplies_2.Enabled = true;
                    Supplies_2.ForeColor = SystemColors.ControlText;
                }
                listBox2.Enabled = Accept_3.Enabled = NotNedded1.Enabled = true;
                listBox2.ForeColor = Accept_3.ForeColor = label2.ForeColor = NotNedded1.ForeColor = SystemColors.ControlText;
                listBox2.BackColor = SystemColors.Window;
            }
        }

        //self explanatory
        private void Restart_Click(object sender, EventArgs e)
        {
            chart1.SendToBack();
            chart1.Hide();
            Restart.Enabled = false;
            Restart.Hide();
            Comparisons.Enabled = Accept_1.Enabled = true;
            Comparisons.ForeColor = Accept_1.ForeColor = label1.ForeColor = SystemColors.WindowText;
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            shops1 = shops2 = suppliers1 = suppliers2 = supplies1 = supplies2 = dates1 = dates2 = false;
            shopSelected = supplierSelected = suppliesSelected = dateSelected = null;
            count.Clear();
            Cancel_list_3.Checked = NotNedded1.Checked = StopSelecting.Checked = false;
        }

        private void Accept_3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0 && listBox2.SelectedItem != null || NotNedded1.Checked)
            {
                select_text2.Text = null;
                Suppliers_2.Enabled = Shops_2.Enabled = Dates_2.Enabled = Supplies_2.Enabled = Accept_3.Enabled = NotNedded1.Enabled = false;
                Dates_2.ForeColor = Shops_2.ForeColor = Supplies_2.ForeColor = Suppliers_2.ForeColor = Accept_3.ForeColor = listBox2.ForeColor = label2.ForeColor = NotNedded1.ForeColor = SystemColors.InactiveCaption;
                listBox2.BackColor = SystemColors.ActiveBorder;
                if (allDates && !dates1)
                {
                    dates_3.ForeColor = SystemColors.ControlText;
                    dates_3.Enabled = true;
                }
                else
                    allDates = false;

                if (allShops && !shops1)
                {
                    Shops_3.ForeColor = SystemColors.ControlText;
                    Shops_3.Enabled = true;
                }
                else
                    allShops = false;

                if (allSuppliers && !suppliers1)
                {
                    Suppliers_3.Enabled = true;
                    Suppliers_3.ForeColor = SystemColors.ControlText;
                }
                else
                    allSuppliers = false;

                if (allSupplies && !supplies1)
                {
                    Supplies_3.Enabled = true;
                    Supplies_3.ForeColor = SystemColors.ControlText;
                }
                else
                    allSupplies = false;

                listBox3.Enabled  = Accept_4.Enabled = Cancel_list_3.Enabled = true;
                listBox3.ForeColor = Accept_4.ForeColor = label3.ForeColor = Cancel_list_3.ForeColor = SystemColors.ControlText;
                listBox3.BackColor = SystemColors.Window;               
                if (!NotNedded1.Checked)
                {
                    if (dates1)
                    {
                        choice1 = "at week" + listBox2.SelectedItem.ToString();
                        dateSelected = listBox2.SelectedItem.ToString();
                    }
                    else if (shops1)
                    {
                        choice1 = "for the shop " + listBox2.SelectedItem.ToString();
                        shopSelected = listBox2.SelectedItem.ToString();
                    }
                    else if (supplies1)
                    {
                        choice1 = "of " + listBox2.SelectedItem.ToString();
                        suppliesSelected = listBox2.SelectedItem.ToString();
                    }
                    else if (suppliers1)
                    {
                        choice1 = "from " + listBox2.SelectedItem.ToString();
                        supplierSelected = listBox2.SelectedItem.ToString();
                    }
                }
                listBox2.ClearSelected();
            }
            else
                select_text2.Text = "Please, select a value";
        }

        //if everything is set up right, it will set up everything so the calculation can be performed
        private void Accept_4_Click(object sender, EventArgs e)
        {
            if ((listBox3.Items.Count != 0 && listBox3.SelectedItem != null) || Cancel_list_3.Checked)
            {
                select_text3.Text = null;
                Suppliers.Enabled = Shops.Enabled = Date.Enabled = Supplies.Enabled = listBox3.Enabled = Accept_4.Enabled = Cancel_list_3.Enabled = false;
                dates_3.ForeColor = Shops_3.ForeColor = Supplies_3.ForeColor = Suppliers_3.ForeColor = listBox3.ForeColor = Accept_4.ForeColor = Cancel_list_3.ForeColor = SystemColors.InactiveCaption;
                listBox3.BackColor = SystemColors.ActiveBorder;
                if (!Cancel_list_3.Checked)
                {                
                    if (dates2)
                    {
                        dateSelected = listBox3.SelectedItem.ToString();
                        allDates = false;
                        choice2 = " at week " + listBox3.SelectedItem.ToString();
                    }
                    else if (shops2)
                    {
                        shopSelected = listBox3.SelectedItem.ToString();
                        allShops = false;
                        choice2 = " for the shop " + listBox3.SelectedItem.ToString();
                    }
                    else if (supplies2)
                    {
                        suppliesSelected = listBox3.SelectedItem.ToString();
                        allSupplies = false;
                        choice2 = " of " + listBox3.SelectedItem.ToString();
                    }
                    else if (suppliers2)
                    {
                        supplierSelected = listBox3.SelectedItem.ToString();
                        allSuppliers = false;
                        choice2 = " from " + listBox3.SelectedItem.ToString();
                    }
                    
                }
                else
                    choice2 = null;
                listBox3.ClearSelected();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                ready = true;
            }
            else
                select_text3.Text = "Please, select a value";
        }

        //Visual data for the chart
        public void CreateVisuals()
        {
            chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            series = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartArea.Name = "ChartArea1";
            series.ChartArea = "ChartArea1";
            series.Legend = "Legend1";
            series.Name = "Cost in GBP";
            legend.Name = "Legend1";
        }

        //visual data that will be displayed after the calculation is done
        public void BindVisualsData(string data, double calculate)
        {
            series.Points.AddXY(data, calculate);
            if (series.Points.Count % 3 == 0)
            series.Points[series.Points.Count - 1].Color = System.Drawing.Color.FromArgb(255, 255/ series.Points.Count, 255/ (series.Points.Count * series.Points.Count), series.Points.Count * series.Points.Count % 255);
            else if (series.Points.Count % 3 == 1)
                series.Points[series.Points.Count - 1].Color = System.Drawing.Color.FromArgb(255, 255 / (series.Points.Count * series.Points.Count), series.Points.Count * series.Points.Count % 255, 255 / series.Points.Count);
            else
                series.Points[series.Points.Count - 1].Color = System.Drawing.Color.FromArgb(255, series.Points.Count * series.Points.Count % 255, 255 / series.Points.Count, 255 / series.Points.Count);
        }
    }
}
