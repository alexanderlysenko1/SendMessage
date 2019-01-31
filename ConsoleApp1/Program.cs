using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  MessagesSendingDbContext db = new MessagesSendingDbContext();  
            User user = new User();
            user.UserId = "+380994006143";
            user.FullName = "Alexander";
            user.Address = "alexander.lysenko1@gmail.com";
         
            db.Users.Add(user);
            db.SaveChanges();*/
           
            short curItem = 0, c;

         
            ConsoleKeyInfo key;

            
            string[] menuItems = { "Registration", "Authorization" };
            do
            {
                
                Console.Clear();

               
                Console.WriteLine("Pick an option . . .");

                
                for (c = 0; c < menuItems.Length; c++)
                {
                    
                    if (curItem == c)
                    {
                        Console.Write(">>");
                        Console.WriteLine(menuItems[c]);
                    }
                    
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }

              
                Console.Write("Select your choice with the arrow keys.");
                key = Console.ReadKey(true);

               
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }
                
            } while (key.KeyChar != 13);

        }
    }
}
