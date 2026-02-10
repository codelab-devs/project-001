using System.Xml.Xsl;
using Telegram.Bot;
using Telegram.Bot.Types;
class Program
{


    static async Task Main()
    {
        try
        {

            Console.WriteLine("Dastur ishga tushdi..");
            Console.WriteLine("Dasturni to'xtatish uchun Ctrl+C ni bosing!");

            string token = "8433044942:AAFyo8iIJpwx7de0P-AUBHOnR2TrqGtC6dc";
            var botClient = new TelegramBotClient(token);

            int numOfUpd = 0;
            while (true) { 
            var updates = await botClient.GetUpdates(numOfUpd);

                foreach (var update in updates) {
                    numOfUpd = update.Id + 1;

                    var message=update.Message;
                    if (message.Text == null)
                    {
                        continue;
                    }
                    //}else if (message.Text == "salom")
                    //{
                    //    await botClient.SendMessage(message.Chat.Id, message.Text = "Assalomu alaykum.\nMen EchoBotman.");
                    //}
                        Console.WriteLine($"Xabar keldi: {message.Text}");
                    await botClient.SendMessage(
                        message.Chat.Id,
                        message.Text);
                    Console.WriteLine($"Botdan yuborildi: {message.Text}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

}





