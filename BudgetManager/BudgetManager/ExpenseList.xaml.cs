using BudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseList : ContentPage
    {
        public double ExpenseTotal_List { get; set; }
        public ExpenseList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var expense = new List<Expense>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.csv");

            foreach(var filename in files)
            {
                string file = File.ReadAllText(filename);
                string[] array = file.Split(',');
                //string[] array = file.Split(new char[] { ',' });

                expense.Add(new Expense
                {
                    Filename = filename,
                    Text = array[0],
                    Date = File.GetCreationTime(filename),
                    Amount = array[1]
                    //Category = (ExpenseCategory)Enum.ToObject(typeof(ExpenseCategory), int.Parse(array[2]))
                });
                ExpenseTotal_List += double.Parse(array[1]);
            }
            
            listView.ItemsSource = expense.OrderByDescending(n => n.Date).ToList();
            //listView.ItemsSource = expense.OrderBy(e => e.Amount).ToList();
        }

        async void OnExpenseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntry
            {
                BindingContext = new Expense()
            });
        }

        private async void OnListViewItemSelected(object sender,
            SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenseEntry
                {
                    BindingContext = e.SelectedItem as Expense
                });
            }
        }
    }
}