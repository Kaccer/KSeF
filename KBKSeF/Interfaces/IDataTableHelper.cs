using KSeF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IDataTableHelper
    {
        public DataTable PrepareDataTable(SearchResponse data, bool isSellInvoice);

        public DataTable PrepareDataTable(string columnNameFilter, string columnValueFilter, bool isSellInvoice);
    }
}
