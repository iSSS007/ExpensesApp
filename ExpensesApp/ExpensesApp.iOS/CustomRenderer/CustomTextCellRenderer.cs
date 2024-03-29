﻿using ExpensesApp.iOS.CustomRenderer;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly:ExportRenderer(typeof(TextCell),typeof(CustomTextCellRenderer))]
namespace ExpensesApp.iOS.CustomRenderer
    {
    public class CustomTextCellRenderer : TextCellRenderer
        {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
            {
            var cell= base.GetCell(item, reusableCell, tv);
            switch (item.StyleId)
                {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;
                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;
                case "disclosure":
                    default:
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;
                }
            return cell;
            }
        }
    }