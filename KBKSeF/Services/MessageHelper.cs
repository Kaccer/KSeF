using KBKSeF.Interfaces;
using KSeF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Services
{
    public class MessageHelper : IMessageHelper
    {
        private readonly string url;
        public MessageHelper(string url) { 
            this.url = url;
        }

        public HttpRequestMessage CreateChallengeMessage(AuthorisationChallengeRequest body)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url + "/online/Session/AuthorisationChallenge")
            };
            message.Headers.Add("Accept", "application/json");

            message.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return message;
        }

        public HttpRequestMessage CreateTokenMessage(Stream body)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url + "/online/Session/InitToken")
            };
            message.Headers.Add("Accept", "application/json");

            message.Content = new StreamContent(body);
            return message;
        }

        public HttpRequestMessage CreateRequestMessage(QueryRequest body, string sessionToken, int page)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url + "/online/Query/Invoice/Sync?PageSize=100&PageOffset=" + (page - 1))
            };

            message.Headers.Add("Accept", "application/json");
            message.Headers.Add("SessionToken", sessionToken);

            message.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return message;
        }

        public HttpRequestMessage CreateStatusMessage(string referenceNumber, string sessionToken)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + "/online/Session/Status/" + referenceNumber + "?PageSize=20&PageOffset=0")
            };
            message.Headers.Add("Accept", "application/json");
            message.Headers.Add("SessionToken", sessionToken);

            return message;
        }
    }
}
