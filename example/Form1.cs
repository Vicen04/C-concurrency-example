using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Concurrent;

namespace Assigment_V024491H
{   
    /// <summary>
    /// Most of the program is explained in the documentation
    /// </summary>
    public partial class Form1 : Form
    {
        bool allDates = false, allSupplierTypes = false, allShops = false, allSuppliers = false, calculating = false;
        double TotalCost;
        string storeSelected, weekSelected, YearSelected, providerSelected, Provider_typeSelected;
        // this is to link the shop codes with the shop names
        Dictionary<string, string> stores = new Dictionary<string, string>();
        Task calculate;
        public static string TimeToLoad;
        static string storeCodesFile;
        static string storeDataFolder;
        Chart chart;
                
        public Form1()
        {
            InitializeComponent();
            Select_folder.Description = "Select the folder that contains the shops cvs files";
            Select_folder.ShowDialog();
            Select_file.Title = "Select the file that contains the shops codes and names";
            Select_file.ShowDialog();                       
            LoadData();           
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Text = TimeToLoad;
            for (int i = 1; i < 53; i++)
                Weeks.Items.Add(i);
            timer1.Interval = 25;
            timer2.Interval = 25;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (calculating)
            {
                Result.Text = "Wait until the current calculation finishes";
                Time_to_calculate.Text = null;
            }
            else if((Weeks.SelectedItem == null && !allDates) || (Provider.SelectedItem == null && !allSuppliers) || (Provider_type.SelectedItem == null && !allSupplierTypes) || (Shops.SelectedItem == null && !allShops))
            {
                Result.Text = "Select at least one option in every field please";
                Time_to_calculate.Text = null;
            }
            else
            {
                if (!allShops)
                stores.TryGetValue(Shops.SelectedItem.ToString(), out storeSelected);
                if (!allDates)
                {
                    weekSelected = Weeks.SelectedItem.ToString();
                    YearSelected = Years.Value.ToString();
                }
                if (!allSuppliers)
                    providerSelected = Provider.SelectedItem.ToString();
                if (!allSupplierTypes)
                    Provider_typeSelected = Provider_type.SelectedItem.ToString();

                TotalCost = 0;
                calculate = Task.Factory.StartNew(() =>
                   {
                       TotalCost = Calculate(allShops, allSupplierTypes, allSuppliers, allDates);                      
                   });
                timer1.Start();
                calculating = true;
            }
        }

        private void AllDates_CheckedChanged(object sender, EventArgs e)
        {
            if (All_dates.Checked == true)
            {
                allDates = true;
                Weeks.ClearSelected();
                Weeks.SelectionMode = SelectionMode.None;
            }
            else
            {
                allDates = false;
                Weeks.SelectionMode = SelectionMode.One;
                All_selected.Checked = false;
            }
        }

        private void AllProviders_CheckedChanged(object sender, EventArgs e)
        {
            if (All_providers.Checked == true)
            {
                Provider.ClearSelected();
                Provider.SelectionMode = SelectionMode.None;
                allSuppliers = true;
            }

            else
            {
                allSuppliers = false;
                Provider.SelectionMode = SelectionMode.One;
                All_selected.Checked = false;
            }
        }

        private void All_Provider_types_CheckedChanged(object sender, EventArgs e)
        {
            if (All_Provider_types.Checked == true)
            {
                allSupplierTypes = true;
                Provider_type.ClearSelected();
                Provider_type.SelectionMode = SelectionMode.None;
            }
            else
            {
                allSupplierTypes = false;
                Provider_type.SelectionMode = SelectionMode.One;
                All_selected.Checked = false;
            }
        }

        private void All_shops_CheckedChanged(object sender, EventArgs e)
        {
            if (All_shops.Checked == true)
            {
                allShops = true;
                Shops.ClearSelected();
                Shops.SelectionMode = SelectionMode.None;
            }
            else
            {
                allShops = false;
                Shops.SelectionMode = SelectionMode.One;
                All_selected.Checked = false;
            }
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All_selected.Checked == true)
            {
                All_dates.Checked = All_providers.Checked = All_Provider_types.Checked = All_shops.Checked = true;               
            }
            else
                All_dates.Checked = All_providers.Checked = All_Provider_types.Checked = All_shops.Checked = false;

            All_shops_CheckedChanged(sender, e);
            All_Provider_types_CheckedChanged(sender, e);
            AllProviders_CheckedChanged(sender, e);
            AllDates_CheckedChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chart == null)
            {                
                chart = new Chart(Shops, Provider, Provider_type);
                chart.Show();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (chart.ready)
            {
                chart.ready = false;
                chart.CreateVisuals();
                if (chart.shopSelected != null)
                stores.TryGetValue(chart.shopSelected, out storeSelected);
                if (chart.dateSelected != null)
                {
                    string[] Split = chart.dateSelected.Split('_');
                    weekSelected = Split[0];
                    YearSelected = Split[1];
                }
                providerSelected = chart.supplierSelected;
                Provider_typeSelected = chart.suppliesSelected;
                Task cat = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < chart.count.Count; i++)
                    {
                        if (chart.listShops)
                            stores.TryGetValue(chart.count[i], out storeSelected);
                        else if (chart.listDates)
                        {
                            string[] DateSplit = chart.count[i].Split('_');
                            weekSelected = DateSplit[0];
                            YearSelected = DateSplit[1];
                        }
                        else if (chart.listSuppliers)
                            providerSelected = chart.count[i];
                        else if (chart.listSupplies)
                            Provider_typeSelected = chart.count[i];
                        double value = Calculate(chart.allShops, chart.allSupplies, chart.allSuppliers, chart.allDates);
                        chart.BindVisualsData(chart.count[i], value);
                    }
                });
                cat.Wait();
                chart.BindData();
            }
            if (chart.IsDisposed)
            {
                chart = null;
                timer2.Stop();
            }            
        }

        private void Clear_all_Click(object sender, EventArgs e)
        {
            if (Weeks.SelectionMode != SelectionMode.None)
                Weeks.ClearSelected();
            All_dates.Checked = false;

            if (Provider.SelectionMode != SelectionMode.None)
                Provider.ClearSelected();
            All_providers.Checked = false;

            if (Provider_type.SelectionMode != SelectionMode.None)
                Provider_type.ClearSelected();
            All_Provider_types.Checked = false;

            if (Shops.SelectionMode != SelectionMode.None)
                Shops.ClearSelected();
            All_shops.Checked = false;
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (calculate.IsCompleted)
            {
                calculate.Wait();
                Result.Text = "Cost: " + Math.Round(TotalCost, 4) + " £";
                Time_to_calculate.Text = TimeToLoad;
                calculating = false;
                timer1.Stop();
            }
        }

        public class Store
        {
            public string StoreCode { get; set; }
            public string StoreLocation { get; set; }
        }

        public void LoadData()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            storeCodesFile = Select_file.FileName;
            storeDataFolder = Select_folder.SelectedPath;
            string storeCodesFilePath = storeCodesFile;
            string[] storeCodesData = File.ReadAllLines(storeCodesFilePath);
            foreach (var storeData in storeCodesData)
            {
                string[] storeDataSplit = storeData.Split(',');
                Store store = new Store { StoreCode = storeDataSplit[0], StoreLocation = storeDataSplit[1] };
                if (!stores.ContainsKey(store.StoreCode))
                {
                    stores.Add(store.StoreLocation, store.StoreCode);
                    Shops.Items.Add(store.StoreLocation);
                }            
            }
            string[] fileNames = Directory.GetFiles(storeDataFolder);
            foreach (var filePath in fileNames)
            {
                string fileNameExt = Path.GetFileName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string[] fileNameSplit = fileName.Split('_');

                string[] orderData = null;
                if (fileNameSplit[1] == "25")
                    orderData = File.ReadAllLines(storeDataFolder + @"\" + fileNameExt);

                if (orderData != null)
                {
                    foreach (var orderInfo in orderData)
                    {
                        string[] orderSplit = orderInfo.Split(',');
                        if(!Provider.Items.Contains(orderSplit[0]))
                        Provider.Items.Add(orderSplit[0]);
                        if(!Provider_type.Items.Contains(orderSplit[1]))
                        Provider_type.Items.Add(orderSplit[1]);
                    }
                }
            }
            stopWatch.Stop();
            TimeToLoad = "Time to initiate: " + stopWatch.Elapsed.TotalSeconds;
        }
        public double Calculate(bool AllShops, bool allSupplies, bool allProviders, bool AllDates)
        {
            string store, week, year, supplier, supplies;
            store = storeSelected;
            week = weekSelected;
            year = YearSelected;
            supplier = providerSelected;
            supplies = Provider_typeSelected;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            
            string[] fileNames = Directory.GetFiles(storeDataFolder);
            ConcurrentQueue<double> values = new ConcurrentQueue<double>();
            int workerThreads = 0, asyncThreads = 0; 
            ThreadPool.GetAvailableThreads(out workerThreads, out asyncThreads);

            int threads = workerThreads / 4, filesToread = fileNames.Length / threads, extraFiles = fileNames.Length % threads, addedThreads= extraFiles / filesToread, filesForTask = extraFiles % filesToread;


            Parallel.For(0, threads + addedThreads, i =>
           {
               for (int j = i * filesToread; j < filesToread * (i + 1); j++)
               values.Enqueue(Getfiles(fileNames[j], AllShops, AllDates, allProviders, allSupplies, store, week, year, supplier, supplies));
           });
            if (filesForTask != 0)
            {
                Task wait = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < filesForTask; i++)
                        values.Enqueue(Getfiles(fileNames[fileNames.Length - extraFiles - 1 + i], AllShops, AllDates, allProviders, allSupplies, store, week, year, supplier, supplies));
                });
                wait.Wait();
            }                 
            stopWatch.Stop();
            TimeToLoad = "Time to calculate: " + Math.Round(stopWatch.Elapsed.TotalSeconds, 4) + " seconds";            
            return values.Sum();                       
        }

        private double Getfiles(string filePath, bool AllShops, bool AllDates, bool allProviders, bool allSupplies, string store, string week, string year, string supplier, string supplies)
        {
            string fileNameExt = Path.GetFileName(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            double cost = 0;

            string[] fileNameSplit = fileName.Split('_');

            string[] orderData = null;
            if (AllDates && AllShops)
            {
                orderData = File.ReadAllLines(storeDataFolder + @"\" + fileNameExt);
            }
            else if (!AllDates && AllShops)
            {
                if (fileNameSplit[1] == week && fileNameSplit[2] == year)
                    orderData = File.ReadAllLines(storeDataFolder + @"\" + fileNameExt);
            }
            else if (AllDates && !AllShops)
            {
                if (fileNameSplit[0] == store)
                    orderData = File.ReadAllLines(storeDataFolder + @"\" + fileNameExt);
            }
            else
            {
                if (fileNameSplit[0] == store && fileNameSplit[1] == week && fileNameSplit[2] == year)
                    orderData = File.ReadAllLines(storeDataFolder + @"\" + fileNameExt);
            }
            if (orderData != null)
            {
                ConcurrentQueue<double> values = new ConcurrentQueue<double>();
                Parallel.For(0, 2, i =>
                {
                    for (int j = i * orderData.Length / 2; j < ((i + 1) * orderData.Length / 2); j++)
                    {
                        values.Enqueue(ReadFiles(orderData[j], allProviders, allSupplies, supplier, supplies));
                    }                   
                });
                cost = values.Sum();
            }
            return cost;
        }

        double ReadFiles(string orderInfo, bool allProviders, bool allSupplies, string supplier, string supplies)
        {                         
                    string[] orderSplit = orderInfo.Split(',');
                    double cost = 0;

                    if (allProviders && allSupplies)
                        cost = Convert.ToDouble(orderSplit[2]);

                    else if (!allProviders && allSupplies)
                    {
                        if (supplier == orderSplit[0])
                            cost = Convert.ToDouble(orderSplit[2]);
                    }
                    else if (allProviders && !allSupplies)
                    {
                        if (supplies == orderSplit[1])
                            cost = Convert.ToDouble(orderSplit[2]);
                    }
                    else
                    {
                        if (supplier == orderSplit[0] && supplies == orderSplit[1])
                            cost = Convert.ToDouble(orderSplit[2]);
                    }
            return cost;
        }
    }
    
}
