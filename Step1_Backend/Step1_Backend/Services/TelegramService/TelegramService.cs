using Microsoft.Extensions.Options;
using Step1_Backend.Helpers;
using Step1_Backend.Models;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Step1_Backend.Services.TelegramService
{
    public class TelegramService : ITelegramService
    {
        private readonly TelegramBotClient _client;
        private readonly TelegramSettings _settings;
        public TelegramService(IOptions<TelegramSettings> config)
        {
            _settings = config.Value;
            _client = new TelegramBotClient(_settings.Token);
        }
        public async Task SendTelegramNotification(Reservation reservation)
        {
            var message = $"🔔 *New Reservation*\n\n" +
              $"Parent Name: {reservation.ParentName}\n" +
              $"Child Name: {reservation.ChildName}\n" +
              $"Child Age: {reservation.ChildAge}\n" +
              $"Phone Number: {reservation.PhoneNumber}\n" +
              $"Email: {reservation.Email}\n" +
              $"Trainer Name: {reservation.Trainer.ArabicName}\n" +
              $"Created at: {reservation.CreationDate:dd/MM/yyyy h:m tt}";

            await _client.SendMessage(
                chatId: _settings.ChatId,
                text: message,
                parseMode: ParseMode.Markdown
            );
        }
    }
}
