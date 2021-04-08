﻿using System;
using System.Collections.Generic;
using System.Linq;
using DynamicData;
using DynamicData.Binding;

namespace WDE.DatabaseEditors.ViewModels
{
    public class DatabaseCellsCategoryViewModel : ObservableCollectionExtended<DatabaseCellViewModel>, IGrouping<(string, int), DatabaseCellViewModel>, IDisposable
    {
        private readonly IDisposable disposable;
        
        public DatabaseCellsCategoryViewModel(IGroup<DatabaseCellViewModel, (string, int)> group) 
        {
            Key = group.GroupKey;

            disposable = group.List
                .Connect()
                .Sort(Comparer<DatabaseCellViewModel>.Create((x, y) => x.Order.CompareTo(y.Order)))
                .Bind(this)
                .Subscribe();
        }

        public int GroupOrder => Key.Item2;
        public string CategoryName => Key.Item1;
        public (string, int) Key { get; private set; }
        public void Dispose() => disposable.Dispose();
    }
}