using BusinessLayer.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TelegramMessageService : IMessageSendService
    {

        private readonly string _botToken = "7727134478:AAG-Hp_mSnfFdg78cH9oRSiEXGfDsnVapqw";
        private readonly string _chatId = "-912123725";
      

        public TelegramMessageService()
        {
           
        }

        public async Task SendMessageAsync(string message)
        {
            using HttpClient client = new HttpClient();
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage?chat_id={_chatId}&text={Uri.EscapeDataString(message)}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                   
                    throw new Exception($"Telegram API hatası: {response.StatusCode} - {responseContent}");
                }

                
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }

      
    }

}
