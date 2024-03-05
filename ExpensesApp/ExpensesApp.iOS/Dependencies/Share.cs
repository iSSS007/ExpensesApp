﻿using ExpensesApp.Interfaces;
using ExpensesApp.iOS.Dependencies;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.iOS.Dependencies
    {
    public class Share : IShare
        {
        public async Task Show(string title, string message, string filePath)
            {
            }
        }
    }