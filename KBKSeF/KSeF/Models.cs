#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace KSeF.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class AuthorisationChallengeRequest
    {
        [JsonProperty("contextIdentifier")]
        public ContextIdentifier ContextIdentifier { get; set; }


    }

    public partial class ContextIdentifier
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
    public partial class ContextName
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tradeName")]
        public string TradeName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set;}
    }
    public partial class AuthorisationChallengeRequestResponse
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("challenge")]
        public string Challenge { get; set; }
    }

    public partial class InitTokenRequestResponse
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("sessionToken")]
        public SessionToken SessionToken { get; set; }
    }
    public partial class SessionToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("context")]
        public SessionTokenContext Context { get; set; }
    }

    public partial class SessionTokenContext
    {
        [JsonProperty("context")]
        public ContextIdentifier Context { get; set; }

        [JsonProperty("contextName")]
        public ContextName ContextName { get; set; }

        [JsonProperty("credentialsRoleList")]
        public CredentialRole[] credentialRoles { get; set; }
    }

    public partial class CredentialRole
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("roleType")]
        public string RoleType { get; set; }

        [JsonProperty("roleDescription")]
        public string RoleDescription { get; set; }
    }

    public partial class QueryRequest
    {
        [JsonProperty("queryCriteria")]
        public QueryCriteria QueryCriteria { get; set; }
    }

    public partial class QueryCriteria
    {
        [JsonProperty("subjectType")]
        public string SubjectType { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
        
        [JsonProperty("invoicingDateFrom")]
        public DateTime InvoicingDateFrom { get; set; }
        
        [JsonProperty("invoicingDateTo")]
        public DateTime InvoicingDateTo { get; set; }
    }


    public partial class Exception
    {
        public List<ExceptionDetailList> exceptionDetailList { get; set; }
        public string referenceNumber { get; set; }
        public string serviceCode { get; set; }
        public string serviceCtx { get; set; }
        public string serviceName { get; set; }
        public DateTime timestamp { get; set; }
    }

    public partial class ExceptionDetailList
    {
        public int exceptionCode { get; set; }
        public string exceptionDescription { get; set; }
    }

    public partial class ExceptionResponse
    {
        public Exception exception { get; set; }
    }

    public partial class StatusResponse
    {
        public DateTime timestamp { get; set; }
        public string referenceNumber { get; set; }
        public int numberOfElements { get; set; }
        public int pageSize { get; set; }
        public int pageOffset { get; set; }
        public int processingCode { get; set; }
        public string processingDescription { get; set; }
        public List<object> invoiceStatusList { get; set; }
    }

    public class HashSHA
    {
        public string algorithm { get; set; }
        public string encoding { get; set; }
        public string value { get; set; }
    }

    public class InvoiceHash
    {
        public HashSHA hashSHA { get; set; }
        public int fileSize { get; set; }
    }

    public class InvoiceHeaderList
    {
        public string invoiceReferenceNumber { get; set; }
        public string ksefReferenceNumber { get; set; }
        public InvoiceHash invoiceHash { get; set; }
        public string invoicingDate { get; set; }
        public DateTime acquisitionTimestamp { get; set; }
        public SubjectBy subjectBy { get; set; }
        public SubjectTo subjectTo { get; set; }
        public string net { get; set; }
        public string vat { get; set; }
        public string gross { get; set; }
        public string currency { get; set; }
    }

    public partial class IssuedByIdentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public partial class IssuedByName
    {
        public string type { get; set; }
        public string tradeName { get; set; }
        public string fullName { get; set; }
    }

    public partial class IssuedToIdentifier
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public partial class IssuedToName
    {
        public string type { get; set; }
        public object tradeName { get; set; }
        public string fullName { get; set; }
    }

    public partial class SearchResponse
    {
        public DateTime timestamp { get; set; }
        public string referenceNumber { get; set; }
        public int numberOfElements { get; set; }
        public int pageSize { get; set; }
        public int pageOffset { get; set; }
        public List<InvoiceHeaderList> invoiceHeaderList { get; set; }
    }

    public partial class SubjectBy
    {
        public IssuedByIdentifier issuedByIdentifier { get; set; }
        public IssuedByName issuedByName { get; set; }
    }

    public partial class SubjectTo
    {
        public IssuedToIdentifier issuedToIdentifier { get; set; }
        public IssuedToName issuedToName { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
