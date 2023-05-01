using KSeF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IMessageHelper
    {
        public HttpRequestMessage CreateChallengeMessage(AuthorisationChallengeRequest body);

        public HttpRequestMessage CreateTokenMessage(Stream body);

        public HttpRequestMessage CreateRequestMessage(QueryRequest body, string sessionToken, int page);

        public HttpRequestMessage CreateStatusMessage(string referenceNumber, string sessionToken);
    }
}
