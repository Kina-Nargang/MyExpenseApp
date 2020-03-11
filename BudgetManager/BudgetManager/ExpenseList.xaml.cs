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
        public ExpenseList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
            var expense = new List<Expense>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.txt");

            // this logic is not ready yet
            foreach(var filename in files)
            {
                string file = File.ReadAllText(filename);
                string[] array = file.Split(',');

                expense.Add(new Expense
                {
                    Filename = filename,
                    Text = array[1],
                    Date = DateTime.Parse(array[0]),
                    Amount = array[2],
                    Category = (ExpenseCategory)Enum.GetName(typeof(ExpenseCategory),2)
                    //Category = ExpenseCategory.Children
                });

               
                listView.ItemsSource = expense.OrderBy(n => n.Date).ToString();
            }
            
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