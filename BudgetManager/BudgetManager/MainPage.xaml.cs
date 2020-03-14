using BudgetManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetManager
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string Total { get; set; }
        public string Budget { get; set; }
        public string Balance { get; set; }

        public MainPage()
        {
            InitializeComponent();

            BalanceCalulation();
        }

        private void BalanceCalulation() { 

            // set up expense
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.csv");
            double ExpenseTotal = 0.00;

            // first time run, expense file doesn't exist yet.
            if(files.ToString() == null)
            {
                ExpenseTotal = 0.00;
            }
            else
            {
                foreach (var filename in files)
                {
                    string file = File.ReadAllText(filename);
                    string[] array = file.Split(',');

                    ExpenseTotal += double.Parse(array[1]);
                }
            }

            Total = ExpenseTotal.ToString();

            ShowTotal.Text = "$" + Total;

            //set up budget
            string filename_budget = Path.GetFileName("*.MonthlyBudget.txt");

            // first time run, budget file doesn't exist yet. Or file is empty
            if (!File.Exists(filename_budget) || File.ReadAllText(filename_budget).Length == 0)
            {
                Budget = "0.00";
            }
            else
            {
                Budget = File.ReadAllText(filename_budget);
            }           

            ShowBudget.Text = "$" + Budget;

            //balance
            double balance = double.Parse(Budget) - double.Parse(Total);

            //format: -$0.00
            if(balance < 0)
            {
                balance = -balance;
                Balance = balance.ToString();
                ShowBalance.Text = "-$" + Balance;
            }
            else
            {
                // $0.00
                Balance = balance.ToString();
                ShowBalance.Text = "$" + Balance;
            }

        }

        private async void Expense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntry());
        }

        private async void Budget_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BudgetEntry());
        }
    }
}
