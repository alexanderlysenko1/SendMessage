using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    [DataContract]
    class User
    {
        [Key] 
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        private string userPhone;
        public string UserPhone
        { 
            get
            {
                return userPhone;
            }
            set
            {
                Regex phoneRegex = new Regex(@"^\+[0-9]{12}");
                
                if (phoneRegex.IsMatch(value))
                {
                    userPhone = value;
                }
                else
                { 
                   Console.WriteLine("Invalid phone number");
                   
                }

            }
  
        }
        public string Passeword { get; set; }
        public string FullName { get; set; }
        protected string userAddress;
        public string Address
        {
            get { return userAddress; }


            set
            {
                Regex phoneRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

                if (phoneRegex.IsMatch(value))
                {
                    userAddress = value;
                }
                else
                {
               Console.WriteLine("Invalid adress ");

                }

            }
        }


        public ICollection<Message> Messages { get; set; }

        public User()
        {
            Messages = new List<Message>();
        }

        public User(string userPhone, string password, string fullName, string address)
        {
            UserPhone = userPhone;
            Passeword = password;
            FullName = fullName;
        }
    }
}
