using KBKSeF.Interfaces;
using KSeF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KBKSeF.Services
{
    public class MessageBodyHelper : IMessageBodyHelper
    {

        public Stream CreateTokenBody(string challenge, string nip, string token)
        {
            var ms = new MemoryStream();
            var xmlSettings = new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = true,
            };

            XmlWriter w = XmlWriter.Create(ms, xmlSettings);
            w.WriteStartDocument(true);

            const string NS2 = "http://ksef.mf.gov.pl/schema/gtw/svc/types/2021/10/01/0001";
            const string NS3 = "http://ksef.mf.gov.pl/schema/gtw/svc/online/auth/request/2021/10/01/0001";
            const string XSI = "http://www.w3.org/2001/XMLSchema-instance";

            w.WriteStartElement("ns3", "InitSessionTokenRequest", NS3);
            w.WriteAttributeString("xmlns", "", null, "http://ksef.mf.gov.pl/schema/gtw/svc/online/types/2021/10/01/0001");
            w.WriteAttributeString("xmlns", "ns2", null, NS2);
            w.WriteAttributeString("xmlns", "ns3", null, NS3);
            {
                w.WriteStartElement("Context", NS3);
                {
                    w.WriteElementString("Challenge", challenge);
                    w.WriteStartElement("Identifier");
                    w.WriteAttributeString("xmlns", "xsi", null, XSI);
                    w.WriteAttributeString("type", XSI, "ns2:SubjectIdentifierByCompanyType");
                    {
                        w.WriteElementString("Identifier", NS2, nip);
                    }
                    w.WriteEndElement();
                    w.WriteStartElement("DocumentType");
                    {
                        w.WriteElementString("Service", NS2, "KSeF");
                        w.WriteStartElement("FormCode", NS2);
                        {
                            w.WriteElementString("SystemCode", NS2, "FA (1)");
                            w.WriteElementString("SchemaVersion", NS2, "1-0E");
                            w.WriteElementString("TargetNamespace", NS2, "http://crd.gov.pl/wzor/2021/11/29/11089/");
                            w.WriteElementString("Value", NS2, "FA");
                        }
                        w.WriteEndElement();
                    }
                    w.WriteEndElement();
                    w.WriteElementString("Token", token);

                }
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Close();
            ms.Position = 0;
            return ms;
        }

        public QueryRequest CreateQueryBody(DateTime since, DateTime till, bool isSellInvoice)
        {
            var type = isSellInvoice ? Structures.SubjectType.Subject1 : Structures.SubjectType.Subject2;
            var body = new QueryRequest()
            {
                QueryCriteria = new QueryCriteria()
                {
                    SubjectType = type,
                    type = "range",
                    InvoicingDateFrom = since,
                    InvoicingDateTo = till,
                }
            };
            return body;
        }

        public AuthorisationChallengeRequest CreateChallengeBody(string nip)
        {
            var body = new AuthorisationChallengeRequest()
            {
                ContextIdentifier = new ContextIdentifier()
                {
                    Type = "onip",
                    Identifier = nip
                }
            };
            return body;
        }
    }
}
