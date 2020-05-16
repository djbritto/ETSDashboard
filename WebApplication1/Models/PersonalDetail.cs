using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class PersonalDetail
    {
        [DataMember]
        public string RegNo { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public DateTime AdmissionDate { get; set; }
    }
}