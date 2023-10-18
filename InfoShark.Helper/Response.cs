using System.Runtime.Serialization;

namespace InfoShark.Helper
{
    [DataContract]
    public class Response<T>
    {
        [DataMember(Name = "status")]
        public bool Status { get; set; } = false;

        [DataMember(Name = "message")]
        public string Message { get; set; } = string.Empty;

        [DataMember(Name = "data")]
        public T? Data { get; set; }

        [DataMember(Name = "list")]
        public IEnumerable<T>? List { get; set; }

        [DataMember(Name = "recordCount")]
        public int? RecordCount { get; set; }
    }
}
