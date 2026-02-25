using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTelegramBot.Handlers;

public class StickerHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ErrorHandler _errorHandler;

    public StickerHandler(ITelegramBotClient botClient, ErrorHandler errorHandler)
    {
        _botClient = botClient;
        _errorHandler = errorHandler;
    }

    public async Task HandleAsync(Update update)
    {
        await _errorHandler.ExecuteAsync(
            nameof(StickerHandler),
            update,
            async () =>
            {
                var chatId = update.Message.Chat.Id;
                var sticker = update.Message.Sticker;
                var stickerId = sticker.FileId;
                if (sticker != null) await _botClient.SendMessage(chatId, $"Sticker ID: {stickerId}");
            });
    }
}