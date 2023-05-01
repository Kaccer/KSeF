using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSeF
{
    namespace Exceptions
    {
        public class FaultyChallengeResponseException : Exception 
        {
            public FaultyChallengeResponseException(string message) : base(message) { }
        }

        public class FaultyInitializeTokenResponseException : Exception 
        {
            public FaultyInitializeTokenResponseException(string message) : base(message) { }
        }

        public class FaultyCheckStatusResponseException : Exception 
        {
            public FaultyCheckStatusResponseException(string message) : base(message) { }
        }

        public class FaultySearchResponseException : Exception
        {
            public FaultySearchResponseException(string message) : base(message) { }
        }
    }
}
