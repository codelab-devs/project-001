using EchoTelegramBot.Handlers;
using EchoTelegramBot.Routing;
using EchoTelegramBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var token = context.Configuration["BotSettings:Token"];

        services.AddSingleton<ITelegramBotClient>(
            new TelegramBotClient(token));

        services.AddSingleton<UpdateRouter>();
        services.AddSingleton<TextHandler>();
        services.AddSingleton<PhotoHandler>();
        services.AddSingleton<StickerHandler>();
        services.AddSingleton<CommandHandler>();
        services.AddSingleton<ErrorHandler>();
        services.AddSingleton<BotService>();
    })
    .Build();

var botService = host.Services.GetRequiredService<BotService>();
botService.Start();

await host.RunAsync();