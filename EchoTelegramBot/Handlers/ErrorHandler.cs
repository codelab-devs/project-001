using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

public class ErrorHandler
{
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(ILogger<ErrorHandler> logger)
    {
        _logger = logger;
    }

    public async Task ExecuteAsync(
        string handlerName,
        Update update,
        Func<Task> action)
    {
        try
        {
            // Handler ishlaydi
            await action();

            // Error bo‘lmasa ham logging
            LogUpdateInfo(handlerName, update, null);
        }
        catch (Exception ex)
        {
            // Error bo‘lsa logging
            LogUpdateInfo(handlerName, update, ex);
        }
    }

    private void LogUpdateInfo(string handlerName, Update update, Exception? ex)
    {
        string? stickerId = null;
        int? photoSize = null;

        if (update?.Message?.Sticker != null) stickerId = update.Message.Sticker.FileId;

        if (update?.Message?.Photo != null) photoSize = update.Message.Photo.Length;

        if (ex != null)
            _logger.LogError(ex,
                "Handler: {Handler} | StickerId: {StickerId} | PhotoCount: {PhotoCount}",
                handlerName,
                stickerId,
                photoSize);
        else
            _logger.LogInformation(
                "Handler: {Handler} | StickerId: {StickerId} | PhotoCount: {PhotoCount}",
                handlerName,
                stickerId,
                photoSize);
    }
}