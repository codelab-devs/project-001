using System.Xml.Xsl;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using EchoTelegramBot;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Dastur ishga tushdi..");
        string botToken = "8433044942:AAFyo8iIJpwx7de0P-AUBHOnR2TrqGtC6dc";
        var bot = new EchoBot(botToken);
        await bot.StartAsync();
    }
}