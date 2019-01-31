﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    class MessagesSendingDbContext: DbContext
    {
        public MessagesSendingDbContext() : base("MessagesSendingDB2") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Recepient> Recepients { get; set; }


    }

}
