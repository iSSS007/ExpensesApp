﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesApp.Models
{
    public class Expense
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public Expense()
        {

        }
        public static int InsertExpense(Expense expense)
            {
            using(SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
                {
                connection.CreateTable<Expense>();
                return connection.Insert(expense);
                }
            }
        public static List<Expense> GetExpenseList()
            {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
                {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().ToList();
                }
            }
        public static List<Expense> GetExpenses(string category)
            {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(x => x.Category==category).ToList();
                }
            }
        public static float TotalExpenseAmount()
            {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(x=>x.Amount);
                }
            }
        }
    }
