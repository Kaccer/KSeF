using KSeF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IMessageBodyHelper
    {
        public Stream CreateTokenBody(string challenge, string nip, string token);

        public QueryRequest CreateQueryBody(DateTime since, DateTime till, bool isSellInvoice);

        public AuthorisationChallengeRequest CreateChallengeBody(string nip);
    }
}
