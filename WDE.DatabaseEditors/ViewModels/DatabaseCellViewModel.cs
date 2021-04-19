﻿using Prism.Mvvm;
using WDE.DatabaseEditors.Models;

namespace WDE.DatabaseEditors.ViewModels
{
    public class DatabaseCellViewModel : BindableBase
    {
        public string CategoryName { get; }
        public IDatabaseField TableField { get; }
        public int CategoryIndex { get; }
        public int Order { get; }

        public DatabaseCellViewModel(IDatabaseField tableField, string category, int categoryIndex, int order)
        {
            CategoryName = category;
            CategoryIndex = categoryIndex;
            Order = order;
            TableField = tableField;
        }
    }
}