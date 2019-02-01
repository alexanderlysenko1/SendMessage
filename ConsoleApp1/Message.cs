using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    [DataContract]
    class Message
    {
        [Key]
        public int MessageId { get; set; }
        [DataMember]
        public string SenderPhone { get; set; }
        [DataMember]
        public string RecepientPhone { get; set; }
        [DataMember]
        public DateTime DateOfSend { get; set; }
        [DataMember]
        public DateTime TimeOfSend { get; set; }
        [DataMember]
        public string TextOfMessage { get; set; }
        [ForeignKey("SenderPhone")]
        public User Sender { get; set; }
        [ForeignKey("RecepientPhone")]
        public Recepient Recepient { get; set; }
    }
}

