using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTelegramBot.Handlers;

public class CommandHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ErrorHandler _errorHandler;

    public CommandHandler(ITelegramBotClient botClient, ErrorHandler errorHandler)
    {
        _botClient = botClient;
        _errorHandler = errorHandler;
    }

    public async Task HandleAsync(Update update)
    {
        await _errorHandler.ExecuteAsync(
            nameof(TextHandler),
            update,
            async () =>
            {
                var message = update.Message;
                var chatId = update.Message.Chat.Id;
                var text = message.Text;

                switch (text)
                {
                    case "/start":
                        await _botClient.SendMessage(chatId, "Welcome"); break;
                } //switch case yozilgani keyin o'zgartirishga oson bo'lishi uchun
            });
    }
}