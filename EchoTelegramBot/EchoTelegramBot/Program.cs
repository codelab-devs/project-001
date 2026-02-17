using System.Xml.Xsl;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace EchoTelegramBot
{
    public class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Bot ishga tushdi..");
            string botToken = "8433044942:AAFyo8iIJpwx7de0P-AUBHOnR2TrqGtC6dc";

            using var cancellationTokenSource = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = new[] { UpdateType.Message },
            };
            var botClient = new TelegramBotClient(botToken);


            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                errorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cancellationTokenSource.Token);
            await Task.Delay(-1, cancellationTokenSource.Token);
        }


        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            if (update.Message is null || update.Type == UpdateType.Message)
                return;
            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            if (string.IsNullOrEmpty(messageText))
                return;
            await botClient.SendMessage(
                chatId:chatId,
                text: messageText,
                cancellationToken: cancellationToken);
        }

        private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception error,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Xatolik: {error}");
            return Task.CompletedTask;
        }
    }
}