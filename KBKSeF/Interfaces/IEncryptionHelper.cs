using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF.Interfaces
{
    public interface IEncryptionHelper
    {
        public string EncryptToken(string token, string key, DateTimeOffset timeStamp);
    }
}
