using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }
        public Command ExportCommand { get; set; }
        public CategoriesVM()
        {
            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpenseCategory();
            //ShareReport();
            }

        public void GetExpenseCategory()
            {
            CategoryExpensesCollection.Clear();
            float totalExpenseAmount = Expense.TotalExpenseAmount();
                foreach (var category in Categories)
                {
                var expenses = Expense.GetExpenses(category);
                float expenseAmountCategory = expenses.Sum(e=>e.Amount);
                CategoryExpenses categoryExpenses = new CategoryExpenses()
                    {
                    Category = category,
                    ExpensePercentage = expenseAmountCategory/totalExpenseAmount,
                    };
                CategoryExpensesCollection.Add(categoryExpenses);
                }
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
        public class CategoryExpenses
            {
            public string Category { get; set; }
            public float ExpensePercentage { get; set; }
            }
        public async void ShareReport()
            {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports",CreationCollisionOption.OpenIfExists);
            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);
            using(StreamWriter sw = new StreamWriter(txtFile.Path))
                {
                foreach (var ce in CategoryExpensesCollection)
                    {
                    sw.WriteLine($"{ce.Category} - {ce.ExpensePercentage:p}");
                    }
                }
            var shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense Report", "Here is your expense report", txtFile.Path);
            }
        }
}
