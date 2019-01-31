using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Recepient
    {
        [Key]
        public string RecepientId { get; set; }
        public string FullName { get; set; }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                Regex adressRegex = new Regex(@"^\+[0-9]{12}");

                if (adressRegex.IsMatch(value))
                {
                    address = value;
                }
                else
                {
                    Console.WriteLine("Invalid adress ");

                }

            }
        }

        public ICollection<Message> Messages { get; set; }

        public Recepient()
        {
            Messages = new List<Message>();
        }
    }
}
