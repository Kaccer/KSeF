using KBKSeF.Interfaces;
using KSeF.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Services
{
    public class KSeFClient : IKSeFClient
    {
        private readonly string token = "1E30D959FAB10F4DFFCEFED646757672C270A75E18374D7024466C62506FD637";
        private readonly string key = "-----BEGIN PUBLIC KEY-----\r\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuWosgHSpiRLadA0fQbzshi5TluliZfDsJujPlyYqp6A3qnzS3WmHxtwgO58uTbemQ1HCC2qwrMwuJqR6l8tgA4ilBMDbEEtkzgbjkJ6xoEqBptgxivP/ovOFYYoAnY6brZhXytCamSvjY9KI0g0McRk24pOueXT0cbb0tlwEEjVZ8NveQNKT2c1EEE2cjmW0XB3UlIBqNqiY2rWF86DcuFDTUy+KzSmTJTFvU/ENNyLTh5kkDOmB1SY1Zaw9/Q6+a4VJ0urKZPw+61jtzWmucp4CO2cfXg9qtF6cxFIrgfbtvLofGQg09Bh7Y6ZA5VfMRDVDYLjvHwDYUHg2dPIk0wIDAQAB\r\n-----END PUBLIC KEY-----";

        private readonly HttpClient _httpClient;
        private readonly IMessageHelper _messageHelper;
        private readonly IMessageBodyHelper _messageBodyHelper;
        private readonly IEncryptionHelper _encryptionHelper;
        private readonly IResponseParser _responseParser;
        public KSeFClient(string baseAdress, IMessageHelper messageHelper, IMessageBodyHelper messageBodyHelper, IEncryptionHelper encryptionHelper, IResponseParser responseParser)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAdress)
            };
            _messageHelper = messageHelper;
            _messageBodyHelper = messageBodyHelper;
            _encryptionHelper = encryptionHelper;
            _responseParser = responseParser;
        }

        public async Task<AuthorisationChallengeRequestResponse> SendChallengeMessage(string nip)
        {
            var body = _messageBodyHelper.CreateChallengeBody(nip);

            var message = _messageHelper.CreateChallengeMessage(body);

            var response = _httpClient.Send(message);

            var status = (int)response.StatusCode;

            if (status == 201) 
            {
                return await _responseParser.Parse<AuthorisationChallengeRequestResponse>(response);
            }
            else
            {
                var error = await _responseParser.Parse<ExceptionResponse>(response);
                var errorMessage = string.Join("\n", error.exception.exceptionDetailList.Select(x => x.exceptionDescription));
                throw new KSeF.Exceptions.FaultyChallengeResponseException(errorMessage);
            }
        }

        public async Task<InitTokenRequestResponse> InitializeToken(AuthorisationChallengeRequestResponse challenge, string nip)
        {
            var encryptedToken = _encryptionHelper.EncryptToken(this.token, this.key, challenge.Timestamp);

            var body = _messageBodyHelper.CreateTokenBody(challenge.Challenge, nip, encryptedToken);

            var message = _messageHelper.CreateTokenMessage(body);

            var response = _httpClient.Send(message);

            var status = (int)response.StatusCode;

            if (status == 201)
            {
                return await _responseParser.Parse<InitTokenRequestResponse>(response);
            }
            else
            {
                var error = await _responseParser.Parse<ExceptionResponse>(response);
                var errorMessage = string.Join("\n", error.exception.exceptionDetailList.Select(x => x.exceptionDescription));
                throw new KSeF.Exceptions.FaultyInitializeTokenResponseException(errorMessage);
            }
        }
        public async Task<int> CheckStatusAsync(string referenceNumber, string sessionToken)
        {
            var message = _messageHelper.CreateStatusMessage(referenceNumber, sessionToken);

            var response = await _httpClient.SendAsync(message);

            var status = (int)response.StatusCode;

            if (status == 200)
            {
                var content = await _responseParser.Parse<StatusResponse>(response);
                return content.processingCode;
            }
            else
            {
                var error = await _responseParser.Parse<ExceptionResponse>(response);
                var errorMessage = string.Join("\n", error.exception.exceptionDetailList.Select(x => x.exceptionDescription));
                throw new KSeF.Exceptions.FaultyCheckStatusResponseException(errorMessage);
            }
        }

        public async Task<SearchResponse> Search(string sessionToken, DateTime since, DateTime till, bool isSellInvoice, int page)
        {
            var body = _messageBodyHelper.CreateQueryBody(since, till, isSellInvoice);

            var message = _messageHelper.CreateRequestMessage(body, sessionToken, page);

            var response = await _httpClient.SendAsync(message);

            var status = (int)response.StatusCode;

            if (status == 200)
            {
                return await _responseParser.Parse<SearchResponse>(response);
            }
            else
            {
                var error = await _responseParser.Parse<ExceptionResponse>(response);
                var errorMessage = string.Join("\n", error.exception.exceptionDetailList.Select(x => x.exceptionDescription));
                throw new KSeF.Exceptions.FaultySearchResponseException(errorMessage);
            }
        }
    }
}
