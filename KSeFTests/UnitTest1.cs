using KBKSeF.Interfaces;
using KBKSeF.Services;
using KSeF.Exceptions;
using KSeF.Models;
using Newtonsoft.Json;
using System.Text;
using static KBKSeF.Structures;

namespace KSeFTests
{
    public class UnitTest1
    {
        private readonly IPresenter presenter;
        private readonly IResponseParser responseParser;
        private readonly IDataTableHelper dataTableHelper;
        public UnitTest1()
        {
            presenter = new Presenter();
            responseParser = new ResponseParser();
            dataTableHelper =  new DataTableHelper();
        }
        [Fact]
        public async Task AuthorizationShouldFailFaultyNip()
        {
            await Assert.ThrowsAsync<FaultyChallengeResponseException>(async () => await presenter.PresentAuthorize("123"));
        }

        [Fact]
        public async Task StatusCheckShouldFailNoAuthorization()
        {
            await Assert.ThrowsAsync<FaultyCheckStatusResponseException>(async () => await presenter.PresentStatusCheck());
        }

        [Fact]
        public async Task ParserShouldParseItCorrectlyAsync()
        {
            var response = new HttpResponseMessage();
            var identifier = new ContextIdentifier()
            {
                Type = "type",
                Identifier = "123"
            };
            response.Content = new StringContent(JsonConvert.SerializeObject(identifier), Encoding.UTF8, "application/json");
            var parsed = await responseParser.Parse<ContextIdentifier>(response);
            Assert.NotNull(parsed);
            Assert.Equal(parsed.Identifier, identifier.Identifier);
        }

        [Fact]
        public void DataHelperShouldReturn1Element()
        {
            SearchResponse sr = new()
            {
                invoiceHeaderList = new List<InvoiceHeaderList>() {
                    new InvoiceHeaderList() { invoiceReferenceNumber = "123", subjectTo = new() { issuedToIdentifier = new(), issuedToName = new() } },
                    new InvoiceHeaderList() { invoiceReferenceNumber = "345", subjectTo = new() { issuedToIdentifier = new(), issuedToName = new() } }
                }
            };

            dataTableHelper.PrepareDataTable(sr, true);
            var dt = dataTableHelper.PrepareDataTable(Subject1Headers.invoiceReferenceNumber, "123", true);
            Assert.Equal(1, dt.Rows.Count);
        }
    }
}