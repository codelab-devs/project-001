using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace EchoTelegramBot;

public class EchoBot
{
    private readonly ITelegramBotClient botClient;
    int numberOfUpdate = 0;

    public EchoBot(string botToken)
    {
        botClient = new TelegramBotClient(botToken);
    }

    public async Task StartAsync()
    {
        while (true)
        {
            try
            {
                var updates = await botClient.GetUpdates(numberOfUpdate, timeout: 30);

                foreach (var update in updates)
                {
                    numberOfUpdate = update.Id + 1;

                    var message = update.Message;
                    if (update.Type != UpdateType.Message && string.IsNullOrEmpty(message.Text))
                    {
                        continue;
                    }

                    await botClient.SendMessage(
                        message.Chat.Id,
                        message.Text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Xatolik: {e}");
                await Task.Delay(2000);
            }
        }
    }
}