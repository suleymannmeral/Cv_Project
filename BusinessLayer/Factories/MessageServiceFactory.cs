using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factories
{
    public class MessageServiceFactory
    {
      
            private readonly IServiceProvider _serviceProvider;

            public MessageServiceFactory(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }

            public IMessageSendService CreateMessageService(MessageType type)
            {
                return type switch
                {
                    MessageType.WhatsApp => _serviceProvider.GetRequiredService<WhatsappMessageService>(),
                    MessageType.Telegram => _serviceProvider.GetRequiredService<TelegramMessageService>(),
                    _ => throw new NotSupportedException("Geçersiz mesaj tipi")
                };
            }
        

    }

}
