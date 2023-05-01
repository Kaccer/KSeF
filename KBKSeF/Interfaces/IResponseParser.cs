using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IResponseParser
    {
        public Task<T> Parse<T>(HttpResponseMessage response) where T : new();
    }
}
