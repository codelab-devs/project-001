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

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {

        if (update.Message is not { Text: { } messageText } || update.Message.Type != MessageType.Text)
            return;

        var chatId = update.Message.Chat.Id;
        var firstName = update.Message.Chat.FirstName;

        Console.WriteLine($"{firstName} yozdi: {messageText}");

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: messageText,
            cancellationToken: cancellationToken);
    }

    static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Xatolik yuz berdi: {exception.Message}");
        return Task.CompletedTask;
    }
}