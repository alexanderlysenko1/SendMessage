﻿using ConsoleApp1.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetMessagesBySenderId(int senderId);
    }
}
