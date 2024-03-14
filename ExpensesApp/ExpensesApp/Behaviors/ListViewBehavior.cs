﻿using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.Behaviors
    {
    public class ListViewBehavior:Behavior<ListView>
        {
        ListView listView;
        protected override void OnAttachedTo(ListView bindable)
            {
            base.OnAttachedTo(bindable);
            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
            }
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
            Expense selectedExpense = (Expense)listView.SelectedItem;
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
            }
        protected override void OnDetachingFrom(ListView bindable)
            {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_ItemSelected;
            }
        }
    }
