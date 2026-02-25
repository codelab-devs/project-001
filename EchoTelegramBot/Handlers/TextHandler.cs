using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTelegramBot.Handlers;

public class TextHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ErrorHandler _errorHandler;

    public TextHandler(ITelegramBotClient botClient, ErrorHandler errorHandler)
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
                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;
                if (string.IsNullOrEmpty(update.Message?.Text) && update.Message?.Text == null)
                    return;
                await _botClient.SendMessage(chatId, messageText);
            });
    }
}