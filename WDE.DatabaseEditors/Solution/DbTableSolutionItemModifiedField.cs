﻿namespace WDE.DatabaseEditors.Solution
{
    public class DbTableSolutionItemModifiedField
    {
        public string DbFieldName { get; }
        public object OriginalValue { get; }
        public object? NewValue { get; }
        
        public DbTableSolutionItemModifiedField(string dbFieldName, object originalValue, object? newValue)
        {
            DbFieldName = dbFieldName;
            OriginalValue = originalValue;
            NewValue = newValue;
        }
    }
}