using KBKSeF.Interfaces;
using KSeF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static KBKSeF.Structures;

namespace KBKSeF.Services
{
    public class DataTableHelper : IDataTableHelper
    {
        private List<InvoiceHeaderList> lastSearch = new();
        public DataTable PrepareDataTable(SearchResponse data, bool isSellInvoice)
        {
            lastSearch = data.invoiceHeaderList;
            return PrepareDataTable(data.invoiceHeaderList, isSellInvoice);
        }
        public DataTable PrepareDataTable(string columnNameFilter, string columnValueFilter, bool isSellInvoice)
        {
            var data = lastSearch;
            string fieldName = GetFieldName(columnNameFilter, isSellInvoice);
            var filteredData = data.Where((x) => {
                return fieldName switch
                {
                    nameof(Subject1Headers.issuedToIdentifier) => x.subjectTo.issuedToIdentifier.identifier.ToString().Contains(columnValueFilter),
                    nameof(Subject1Headers.issuedToName) => x.subjectTo.issuedToName.fullName.ToString().Contains(columnValueFilter),
                    nameof(Subject2Headers.issuedByIdentifier) => x.subjectBy.issuedByIdentifier.identifier.ToString().Contains(columnValueFilter),
                    nameof(Subject2Headers.issuedByName) => x.subjectBy.issuedByName.fullName.ToString().Contains(columnValueFilter),
                    _ => x.GetType().GetProperty(fieldName).GetValue(x).ToString().Contains(columnValueFilter),
                };
            }).ToList();
            return PrepareDataTable(filteredData ?? new List<InvoiceHeaderList>(), isSellInvoice);
        }
        private DataTable PrepareDataTable(List<InvoiceHeaderList> data, bool isSellInvoice)
        {
            DataTable dt = new();
            if (data.Count > 0)
            {
                var firstElement = data[0];
                FieldInfo[] fields = GetFields(isSellInvoice);
                foreach (var field in fields)
                {
                    var value = field.GetValue(null);
                    if (value != null)
                        dt.Columns.Add(value.ToString());
                }
                foreach (var element in data)
                {
                    DataRow row = dt.NewRow();
                    foreach (var field in fields)
                    {
                        var value = field.GetValue(null);
                        if (value == null) 
                            continue;
                        var fieldValueName = value.ToString();
                        if (fieldValueName == null)
                            continue;
                        var fieldName = field.Name;
                        switch(fieldName)
                        {
                            case nameof(Subject1Headers.issuedToIdentifier):
                                row[fieldValueName] = element.subjectTo.issuedToIdentifier.identifier;
                                break;
                            case nameof(Subject1Headers.issuedToName):
                                row[fieldValueName] = element.subjectTo.issuedToName.fullName;
                                break;
                            case nameof(Subject2Headers.issuedByIdentifier):
                                row[fieldValueName] = element.subjectBy.issuedByIdentifier.identifier;
                                break;
                            case nameof(Subject2Headers.issuedByName):
                                row[fieldValueName] = element.subjectBy.issuedByName.fullName;
                                break;
                            case nameof(Subject1Headers.vat):
                            case nameof(Subject1Headers.gross):
                            case nameof(Subject1Headers.net):
                                var propertyInfoCurrency = element.GetType().GetProperty(fieldName);
                                if (propertyInfoCurrency == null)
                                    continue;
                                row[fieldValueName] = propertyInfoCurrency.GetValue(element) + " " + element.currency;
                                break;
                            default:
                                var propertyInfo = element.GetType().GetProperty(fieldName);
                                if (propertyInfo == null)
                                    continue;
                                row[fieldValueName] = propertyInfo.GetValue(element);
                                break;
                        }
                        if(String.IsNullOrEmpty(row[fieldValueName].ToString()))
                        {
                            row[fieldValueName] = "-";
                        }
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        private static FieldInfo[] GetFields(bool isSellInvoice)
        {
            return (isSellInvoice ? typeof(Subject1Headers) : typeof(Subject2Headers)).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                         .Where(f => f.IsLiteral && f.FieldType == typeof(string))
                                         .ToArray();
        }

        private static string GetFieldName(string columnName, bool isSellInvoice ) 
        {
            foreach (FieldInfo fieldInfo in (isSellInvoice ? typeof(Subject1Headers) : typeof(Subject2Headers)).GetFields())
            {
                object? fieldValue = fieldInfo.GetValue(null);
                if (fieldValue != null && fieldValue.Equals(columnName))
                {
                    return  fieldInfo.Name;
                }
            }
            return columnName;
        }
    }
}
