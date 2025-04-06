using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmailMessageService : IMessageSendService
    {
        public Task SendMessageAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
