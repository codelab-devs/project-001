using EchoTelegramBot.Routing;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EchoTelegramBot.Services;

public class BotService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<BotService> _logger;
    private readonly UpdateRouter _updateRouter;

    public BotService(ITelegramBotClient botClient, UpdateRouter updateRouter, ILogger<BotService> logger)
    {
        _logger = logger;
        _updateRouter = updateRouter;
        _botClient = botClient;
    }

    public void Start()
    {
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions);
        _logger.LogInformation("Bot ishga tushdi..");
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        await _updateRouter.RouteAsync(update);
    }

    private Task HandleErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);
        return Task.CompletedTask;
    }
}