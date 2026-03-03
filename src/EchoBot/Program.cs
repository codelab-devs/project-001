using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MurodEchoBot;

class Program
{
    private static readonly string Token = "8595258461:AAF87pKGDabPkBxiaNaw_bHCCLHa1e4rb70";

    static async Task Main()
    {
        var botClient = new TelegramBotClient(Token);
        using var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            ThrowPendingUpdates = true
        };

        Console.WriteLine("Smart Echo Bot ishga tushdi (Rasm qaytarish rejimi).");

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

        try
        {
            switch (message.Type)
            {
                case MessageType.Text:
                    await ProcessTextMessage(botClient, message, ct);
                    break;

                case MessageType.Photo:
                    var photoId = message.Photo[^1].FileId;
                    await botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: InputFile.FromFileId(photoId),
                        caption: " ",
                        cancellationToken: ct);
                    break;

                case MessageType.Sticker:
                
                    string stickerId = message.Sticker?.FileId ?? "ID topilmadi";
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Sticker ID: {stickerId}",
                        cancellationToken: ct);
                    break;

                default:
                    Console.WriteLine($"[INFO] Boshqa turdagi xabar: {message.Type}");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Xatolik: {ex.Message}");
        }
    }

    static async Task ProcessTextMessage(ITelegramBotClient botClient, Message message, CancellationToken ct)
    {
        string text = message.Text ?? "";

        if (text.Equals("/sart", StringComparison.OrdinalIgnoreCase))
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Xush kelibsiz! Rasm matn stiker yuboring, men uni qaytaraman.",
                cancellationToken: ct);
            return;
        }

        await botClient.SendTextMessageAsync(message.Chat.Id, $" {text}", cancellationToken: ct);
    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken ct)
    {
        Console.WriteLine($"[API ERROR] {exception.Message}");
        
        return Task.CompletedTask;
    }
}