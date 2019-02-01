using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagesSendingDbContext db = new MessagesSendingDbContext();
            /*  User user = new User();
            user.UserId = "+380994006143";
              user.FullName = "Alexander";
              user.Address = "alexander.lysenko1@gmail.com";

              db.Users.Add(user);
              db.SaveChanges();*/

            Console.WriteLine("Input phone number:");
            string phoneNumber = Console.ReadLine();
            Regex phoneRegex = new Regex(@"^\+[0-9]{12}");
            if (!phoneRegex.IsMatch(phoneNumber))
            {
                Console.WriteLine("Invalid phone number");
                return;
            }
            User user = db.Users.FirstOrDefault(p => p.UserId == phoneNumber);
            string answer;
            if (user == null)
            {
                Console.WriteLine("Cant find user");
                Console.WriteLine("Want to regitrate(Yes/No)");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    db.Users.Add(UserRegistration());
                    db.SaveChanges();
                    string[] vs = new string[1];
                    Main(vs);
                    return;
                }
                else
                {
                    Console.WriteLine("Thanks for visit");
                    return;
                }
            }
            Console.WriteLine("Input password: ");
            if (user.Passeword == Console.ReadLine())
            {
                Console.WriteLine("Log in");
            }
            else
            {
                Console.WriteLine("Wrong password!");
                Console.WriteLine("Thanks for visit");
                return;
            }
              
            Console.WriteLine("Want you add new message?(Yes/No): ");
            answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                Message newMessage = new Message();
                newMessage.Sender = user;
                Console.WriteLine("Input message's text:");
                newMessage.TextOfMessage = Console.ReadLine();
                do
                {
                    Console.WriteLine("Input recipient's phone number: ");
                    phoneNumber = Console.ReadLine();
                    if (!phoneRegex.IsMatch(phoneNumber))
                    {
                        Console.WriteLine("Invalid phone number");
                        return;
                    }
                    Recepient recepient = db.Recepients.FirstOrDefault(p => p.RecepientId == phoneNumber);
                    if (user == null)
                    {
                        Console.WriteLine("Cant find reciepient");
                        Console.WriteLine("Want to regitrate(Yes/No)");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes")
                        {
                            Recepient newRecepient = RecepientRegistration();
                            db.Recepients.Add(newRecepient);

                        }
                        else
                        {
                            Console.WriteLine("Thanks for visit");
                            return;
                        }
                    }
                }
                while (answer=="no");
            }
        

        }
        static User UserRegistration()
        {
            User newUser = new User();
            Console.WriteLine("Input phone number: ");
            newUser.UserId = Console.ReadLine();
            Console.WriteLine("Input password: ");
            newUser.Passeword = Console.ReadLine();
            Console.WriteLine("Input full name: ");
            newUser.FullName = Console.ReadLine();
            Console.WriteLine("Input address: ");
            newUser.Address = Console.ReadLine();
            return newUser;
        }

        static Recepient RecepientRegistration()
        {
            Recepient newRecepient = new Recepient();
            Console.WriteLine("Input phone number: ");
            newRecepient.RecepientId = Console.ReadLine();
            Console.WriteLine("Input full name: ");
            newRecepient.FullName = Console.ReadLine();
           
            return newRecepient;
        }


    }



}
    
