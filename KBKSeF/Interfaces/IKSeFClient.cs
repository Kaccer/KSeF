using KSeF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IKSeFClient
    {
        public Task<AuthorisationChallengeRequestResponse> SendChallengeMessage(string nip);

        public Task<InitTokenRequestResponse> InitializeToken(AuthorisationChallengeRequestResponse challenge, string nip);

        public Task<int> CheckStatusAsync(string referenceNumber, string sessionToken);

        public Task<SearchResponse> Search(string sessionToken, DateTime since, DateTime till, bool isSellInvoice, int page);
    }
}
