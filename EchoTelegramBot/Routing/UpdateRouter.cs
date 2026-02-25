using EchoTelegramBot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EchoTelegramBot.Routing;

public class UpdateRouter
{
    private readonly ITelegramBotClient _botClient;
    private readonly CommandHandler _commandHandler;
    private readonly PhotoHandler _photoHandler;
    private readonly StickerHandler _stickerHandler;
    private readonly TextHandler _textHandler;

    public UpdateRouter(CommandHandler commandHandler,
        PhotoHandler photoHandler,
        StickerHandler stickerHandler,
        TextHandler textHandler,
        ITelegramBotClient botClient)
    {
        _commandHandler = commandHandler;
        _photoHandler = photoHandler;
        _stickerHandler = stickerHandler;
        _textHandler = textHandler;
        _botClient = botClient;
    }

    public async Task RouteAsync(Update update)
    {
        if (update.Message?.Text?.StartsWith("/") == true)
            await _commandHandler.HandleAsync(update);
        else if (update.Message.Sticker != null)
            await _stickerHandler.HandleAsync(update);
        else if (update.Message.Text != null)
            await _textHandler.HandleAsync(update);
        else if (update.Message.Photo != null)
            await _photoHandler.HandleAsync(update);
        else
            await _botClient.SendMessage(
                update.Message.Chat.Id,
                "Siz yuborgan xabar turi hozircha qo'llab quvvatlanmaydi!");
    }
}