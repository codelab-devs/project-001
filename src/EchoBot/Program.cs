using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EchoBot;

class Program
{
    private static readonly string Token = "8595258461:AAF87pKGDabPkBxiaNaw_bHCCLHa1e4rb70";

    static async Task Main()
    {
        var botClient = new TelegramBotClient(Token);
        using var cts = new CancellationTokenSource();

       
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[] { UpdateType.Message } 
        };

        Console.WriteLine("Bot ishga tushdi... Xabarlarni kutmoqdaman.");

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        await Task.Delay(-1, cts.Token);
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
    {
        if (update.Message is not { } message)
            return;

        switch (message.Type)
        {
            case MessageType.Text:
             
                if (message.Text != null && message.Text.StartsWith('/'))
                    await ProcessCommandMessage(botClient, message, ct);
                else
                    await ProcessTextMessage(botClient, message, ct);
                break;

            case MessageType.Photo:
                await ProcessPhotoMessage(botClient, message, ct);
                break;

            case MessageType.Sticker:
                await ProcessStickerMessage(botClient, message, ct);
                break;
        }
    }

    static async Task ProcessCommandMessage(ITelegramBotClient botClient, Message message, CancellationToken ct)
    {
        var command = message.Text?.ToLower();
        if (command == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Xush kelibsiz! Men Smart botman .", cancellationToken: ct);
        }
    }

    static async Task ProcessTextMessage(ITelegramBotClient botClient, Message message, CancellationToken ct)
    {
        Console.WriteLine($"{message.Chat.FirstName} yozdi: {message.Text}");
     
        await botClient.SendTextMessageAsync(message.Chat.Id, message.Text ?? "", cancellationToken: ct);
    }

    static async Task ProcessPhotoMessage(ITelegramBotClient botClient, Message message, CancellationToken ct)
    {
     
        var photo = message.Photo;
        if (photo == null || photo.Length == 0) return;

        Console.WriteLine($"{message.Chat.FirstName} rasmni qaytarish.");

        var fileId = photo.Last().FileId;

        await botClient.SendPhotoAsync(
            chatId: message.Chat.Id,
            photo: InputFile.FromFileId(fileId),
            caption: null, 
            cancellationToken: ct);
    }

    static async Task ProcessStickerMessage(ITelegramBotClient botClient, Message message, CancellationToken ct)
    {
       
        if (message.Sticker is not { } sticker) return;
        
        Console.WriteLine($"{message.Chat.FirstName} stiker yubordi.");
        await botClient.SendTextMessageAsync(message.Chat.Id, $"Sticker ID: {sticker.FileId}", cancellationToken: ct);
    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken ct)
    {
        Console.WriteLine($"Xatoli: {exception.Message}");
        return Task.CompletedTask;
    }
}