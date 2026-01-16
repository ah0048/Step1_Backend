using Microsoft.Extensions.Options;
using Step1_Backend.Helpers;
using Step1_Backend.Models;
using System.Runtime.InteropServices;
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

        public async Task SendPaymentOrderNotification(PaymentOrder paymentOrder)
        {
            // 1. Get the Egypt Time Zone
            TimeZoneInfo egyptZone;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                egyptZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            }
            else
            {
                egyptZone = TimeZoneInfo.FindSystemTimeZoneById("Africa/Cairo");
            }

            // 2. Convert the UTC CreationDate to Egypt Time
            var egyptTime = TimeZoneInfo.ConvertTimeFromUtc(paymentOrder.CreationDate, egyptZone);

            var message = $"🔔 *New Payment Order*\n\n" +
              $"Parent Name: {paymentOrder.ParentName}\n" +
              $"Child Name: {paymentOrder.ChildName}\n" +
              $"Phone Number: {paymentOrder.PhoneNumber}\n" +
              $"Email: {paymentOrder.Email}\n" +
              $"Package: {paymentOrder.Package.Title}\n" +
              //$"Payment Status: {paymentOrder.OrderStatus.ToString()}\n" +
              $"Created at: {egyptTime:dd/MM/yyyy hh:mm:ss tt}";

            await _client.SendMessage(
                chatId: _settings.ChatId,
                text: message,
                parseMode: ParseMode.Markdown
            );
        }

        public async Task SendReservationNotification(Reservation reservation)
        {
            // 1. Get the Egypt Time Zone
            TimeZoneInfo egyptZone;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                egyptZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            }
            else
            {
                egyptZone = TimeZoneInfo.FindSystemTimeZoneById("Africa/Cairo");
            }

            // 2. Convert the UTC CreationDate to Egypt Time
            var egyptTime = TimeZoneInfo.ConvertTimeFromUtc(reservation.CreationDate, egyptZone);

            string planArabicPlan = reservation.subscriptionPlan switch
            {
                SubscriptionPlan.ArabicFoundation => "تاسيس عربي",
                SubscriptionPlan.EnglishFoundation => "تاسيس انجليزي",
                SubscriptionPlan.SkillsDevelopment => "تنمية مهارات",
                _ => "غير محدد"
            };

            string planArabicInterval = reservation.subscriptionInterval switch
            {
                SubscriptionInterval.Monthly => "شهري",
                SubscriptionInterval.Quarterly => "ربع سنوي",
                SubscriptionInterval.Yearly => "سنوي",
                _ => "غير محدد"
            };

            var message = $"🔔 *New Reservation*\n\n" +
              $"Parent Name: {reservation.ParentName}\n" +
              $"Child Name: {reservation.ChildName}\n" +
              $"Child Age: {reservation.ChildAge}\n" +
              $"Phone Number: {reservation.PhoneNumber}\n" +
              $"Email: {reservation.Email}\n" +
              $"Trainer Name: {reservation.Trainer.ArabicName}\n" +
              $"Subscription Plan: {planArabicPlan}\n" +
              $"Subscription Interval: {planArabicInterval}\n" +
              $"Created at: {egyptTime:dd/MM/yyyy hh:mm:ss tt}";

            await _client.SendMessage(
                chatId: _settings.ChatId,
                text: message,
                parseMode: ParseMode.Markdown
            );
        }
    }
}
