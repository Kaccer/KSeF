using KBKSeF.Interfaces;
using KSeF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Services
{
    public class ResponseParser : IResponseParser
    {
        public async Task<T> Parse<T>(HttpResponseMessage response) where T : new()
        {
            using Stream receiveStream = await response.Content.ReadAsStreamAsync();
            using StreamReader readStream = new(receiveStream, Encoding.UTF8);
            return JsonConvert.DeserializeObject<T>(readStream.ReadToEnd()) ?? new T();
        }
    }
}
