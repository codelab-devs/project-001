using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTelegramBot.Handlers;

public class PhotoHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ErrorHandler _errorHandler;

    public PhotoHandler(ITelegramBotClient botClient, ErrorHandler errorHandler)
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
                var message = update.Message.Photo;

                if (message != null) await _botClient.SendMessage(chatId, "Siz rasm yubordingiz");
            });
    }
}