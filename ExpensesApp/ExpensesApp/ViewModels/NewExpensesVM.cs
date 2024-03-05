using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpensesVM : INotifyPropertyChanged
    {

        private string expenseName;

        public string ExpenseName
            {
            get { return expenseName; }
            set { expenseName = value; OnPropertyChanged("ExpenseName"); }
            }
        private string expenseDescription;

        public string ExpenseDescription
            {
            get { return expenseDescription; }
            set { expenseDescription = value; OnPropertyChanged("ExpenseDescription"); }
            }
        private float expenseAmount;

        public float ExpenseAmount
            {
            get { return expenseAmount; }
            set { expenseAmount = value;OnPropertyChanged("ExpenseAmount"); }
            }
        private DateTime expenseDate;

        public DateTime ExpenseDate
            {
            get { return expenseDate; }
            set { expenseDate = value;OnPropertyChanged("ExpenseDate"); }
            }
        private string expenseCategory;

        public string ExpenseCategory
            {
            get { return expenseCategory; }
            set { expenseCategory = value;OnPropertyChanged("ExpenseCategory"); }
            }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            {
            if(PropertyChanged != null)
                {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }
        public Command SaveExpenseCommand { get; set; }
        public NewExpensesVM()
            {
            ExpenseDate=DateTime.Today;
            Categories = new ObservableCollection<string>();
            SaveExpenseCommand = new Command(InsertExpense);
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            GetCategories();
            }
        public void GetExpensesStatus()
            {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus { Name="Random",Status=true });
            ExpenseStatuses.Add(new ExpenseStatus { Name="Random2",Status=false });
            ExpenseStatuses.Add(new ExpenseStatus { Name="Random3",Status=true });
            }
        public void InsertExpense()
            {
            Expense expense = new Expense()
                {
                Name = expenseName,
                Description = expenseDescription,
                Amount = expenseAmount,
                Date = expenseDate,
                Category = expenseCategory
                };
            int response = Expense.InsertExpense(expense);
            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "Expense save failed","Ok");
            }
        private void GetCategories()
            {
            Categories.Clear();
            Categories.Add("HouseRent");
            Categories.Add("Debt");
            Categories.Add("CreditCard");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Other");
            }
        public class ExpenseStatus
            {
            public string Name { get; set; }
            public bool Status { get; set; }
            }
        }
}
