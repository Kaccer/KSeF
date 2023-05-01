using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBKSeF
{
    public class Structures
    {
        public struct SubjectType
        {
            public const string Subject1 = "subject1";
            public const string Subject2 = "subject2";
        }

        public static class Subject1Headers
        {
            public const string issuedToIdentifier = "Identyfikator nabywcy";
            public const string issuedToName = "Nazwa nabywcy";
            public const string ksefReferenceNumber = "Nr KSeF";
            public const string invoiceReferenceNumber = "Nr faktury";
            public const string invoicingDate = "Data wystawienia";
            public const string net = "Netto";
            public const string gross = "Brutto";
            public const string vat = "Vat";
        }

        public static class Subject2Headers
        {
            public const string issuedByIdentifier = "Identyfikator sprzedawcy";
            public const string issuedByName = "Nazwa sprzedawcy";
            public const string ksefReferenceNumber = "Nr KSeF";
            public const string invoiceReferenceNumber = "Nr faktury";
            public const string invoicingDate = "Data wystawienia";
            public const string acquisitionTimestamp = "Data otrzymania";
            public const string net = "Netto";
            public const string gross = "Brutto";
            public const string vat = "Vat";
        }
    }
}
