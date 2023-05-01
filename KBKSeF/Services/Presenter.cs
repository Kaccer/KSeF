using KBKSeF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static KBKSeF.Structures;

namespace KBKSeF.Services
{
    public class Presenter : IPresenter
    {
        private readonly IKSeFClient kseFClient;
        private readonly IDataTableHelper dataTableHelper;
        private string referenceNumber = string.Empty;
        private string sessionToken = string.Empty;

        public Presenter()
        {
            var url = "https://ksef-test.mf.gov.pl/api";
            kseFClient = new KSeFClient(url, new MessageHelper(url), new MessageBodyHelper(), new EncryptionHelper(), new ResponseParser());
            dataTableHelper = new DataTableHelper();
        }

        public async Task PresentAuthorize(string nip)
        {
            var challenge = await kseFClient.SendChallengeMessage(nip);

            var token = await kseFClient.InitializeToken(challenge, nip);

            sessionToken = token.SessionToken.Token;
            referenceNumber = token.ReferenceNumber;
        }

        public async Task<int> PresentStatusCheck()
        {
            var status = await kseFClient.CheckStatusAsync(referenceNumber, sessionToken);
            return status;
        }

        public async Task<Tuple<DataTable,List<string>>> PresentSearch(DateTime since, DateTime till, bool isSellInvoice, int page)
        {
            var response = await kseFClient.Search(sessionToken, since, till, isSellInvoice, page);
            var numberOfPages = (int)Math.Ceiling(response.numberOfElements / 100.0);
            var pages = Enumerable.Range(1, numberOfPages).Select(x => x.ToString()).ToList();
            return new Tuple<DataTable, List<string>>(dataTableHelper.PrepareDataTable(response, isSellInvoice), pages);
        }

        public DataTable PresentSearchFiltered(string columnName, string columnValue, bool isSellInvoice)
        {
            return dataTableHelper.PrepareDataTable(columnName, columnValue, isSellInvoice);
        }
    }
}
