using Step1_Backend.Models;

namespace Step1_Backend.Services.TelegramService
{
    public interface ITelegramService
    {
        Task SendReservationNotification(Reservation reservation);
        Task SendPaymentOrderNotification(PaymentOrder paymentOrder);
    }
}
