using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IPresenter
    {
        public Task PresentAuthorize(string nip);

        public Task<int> PresentStatusCheck();

        public Task<Tuple<DataTable, List<string>>> PresentSearch(DateTime since, DateTime till, bool isSellInvoice, int page);

        public DataTable PresentSearchFiltered(string columnName, string columnValue, bool isSellInvoice);
    }
}
