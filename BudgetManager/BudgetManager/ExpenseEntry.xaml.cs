using BudgetManager.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntry : ContentPage
    {
        private List<string> categories;
        public ExpenseEntry()
        {
            InitializeComponent();
            categories = new List<string>();
            foreach(string name in Enum.GetNames(typeof(ExpenseCategory)))
            {
                categories.Add(name.ToString());
            }

            CategoryPicker.ItemsSource = categories;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (string.IsNullOrEmpty(expense.Filename))
            {
                var filename = Path.Combine(App.FolderPath, 
                    $"{Path.GetRandomFileName()}.expenses.txt");

                File.WriteAllText(filename,expense.Text);
            }
            else
            {
                File.WriteAllText(expense.Filename, expense.Text);
            }

            await Navigation.PopAsync();

        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;

            if(expense == null)
            {
                return;
            }

            if (File.Exists(expense.Filename))
            {
                File.Delete(expense.Filename);
            }

            await Navigation.PopAsync();

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateLabel.Text = e.NewDate.ToString();
        }

       
    }
}