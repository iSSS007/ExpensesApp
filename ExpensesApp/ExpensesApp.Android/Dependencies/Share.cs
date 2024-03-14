using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
    {
    public class Share : IShare
        {
        public Task Show(string title, string message, string filePath)
            {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(CrossCurrentActivity.Current.AppContext, "com.companyname.expensesapp.provider", new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);
            var chooserIntent = Intent.CreateChooser(intent,title);
            chooserIntent.AddFlags(ActivityFlags.NewTask);
            chooserIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooserIntent);
            return Task.FromResult(true);
            }
        }
    }