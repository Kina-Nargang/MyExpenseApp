using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public MainPage()
        {
            InitializeComponent();
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
