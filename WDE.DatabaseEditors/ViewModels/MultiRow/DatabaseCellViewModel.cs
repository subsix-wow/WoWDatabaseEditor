﻿using System;
using WDE.DatabaseEditors.Data.Structs;
using WDE.DatabaseEditors.Models;
using WDE.MVVM;
using WDE.MVVM.Observable;

namespace WDE.DatabaseEditors.ViewModels.MultiRow
{
    public class DatabaseCellViewModel : ObservableBase
    {
        public DatabaseEntityViewModel Parent { get; }
        public DatabaseEntity ParentEntity { get; }
        public IDatabaseField TableField { get; }
        public IParameterValue ParameterValue { get; }
        public bool IsVisible { get; private set; } = true;
        public bool IsModified { get; private set; }
        public string? OriginalValueTooltip { get; private set; }
        public bool CanBeNull => true;//Parent.CanBeNull;
        public bool IsReadOnly => false;
        public bool CanBeSetToNull => CanBeNull && !IsReadOnly;
        public bool CanBeReverted => !IsReadOnly;
        
        public string ColumnName { get; }

        public DatabaseCellViewModel(DbEditorTableGroupFieldJson columnDefinition, DatabaseEntityViewModel parent, DatabaseEntity parentEntity, IDatabaseField tableField, IParameterValue parameterValue)
        {
            Link(tableField, tf => tf.IsModified, () => IsModified);
            ColumnName = columnDefinition.DbColumnName;
            ParentEntity = parentEntity;
            Parent = parent;
            TableField = tableField;
            ParameterValue = parameterValue;

            AutoDispose(parameterValue.ToObservable().SubscribeAction(_ =>
            {
                OriginalValueTooltip =
                    tableField.IsModified ? "Original value: " + parameterValue.OriginalString : null;
                RaisePropertyChanged(nameof(OriginalValueTooltip));
                RaisePropertyChanged(nameof(AsBoolValue));
            }));
        }

        public bool AsBoolValue
        {
            get => ((ParameterValue as ParameterValue<long>)?.Value ?? 0) != 0;
            set
            {
                if (ParameterValue is ParameterValue<long> longParam)
                {
                    longParam.Value = value ? 1 : 0;
                }
            }
        }
    }
}