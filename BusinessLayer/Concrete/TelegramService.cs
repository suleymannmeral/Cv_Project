using BusinessLayer.Abstract;
using Microsoft.Extensions.Logging;


namespace BusinessLayer.Concrete
{
    public class TelegramService : ITelegramService
    {
        private readonly string _botToken = "7992366461:AAEKduf-vWUiBc0OqvzF7u0up9MembbQAT4";
        private readonly string _chatId = "-4640236751";
        private readonly ILogger<TelegramService> _logger;

        public TelegramService(ILogger<TelegramService> logger)
        {
            _logger = logger;
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
                    _logger.LogError("Telegram API Hatası: {StatusCode} - {Response}", response.StatusCode, responseContent);
                    throw new Exception($"Telegram API hatası: {response.StatusCode} - {responseContent}");
                }

                _logger.LogInformation("Telegram mesajı başarıyla gönderildi: {Response}", responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError("Telegram mesajı gönderilirken hata oluştu: {Message}", ex.Message);
                throw;
            }
        }
    }
}
