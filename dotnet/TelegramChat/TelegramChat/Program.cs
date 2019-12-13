using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramChat
{
    class Program
    {
        private static TelegramBotClient _botClient;

        private static readonly ConcurrentDictionary<long, string> LastCommands =
            new ConcurrentDictionary<long, string>();

        private static readonly ConcurrentDictionary<long, string> LastChats = new ConcurrentDictionary<long, string>();
        private static readonly ConcurrentDictionary<long, string> BancoDestino = new ConcurrentDictionary<long, string>();

        private static readonly string[] Bancos =
            {"Santander", "Banco do Brasil", "Caixa", "Itaú", "Bradesco", "Inter"};

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                _botClient = new TelegramBotClient("REPLACE_WITH_YOUT_BOT_TOKEN_ID");
                var me = _botClient.GetMeAsync().Result;
                Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

                _botClient.OnMessage += Bot_OnMessage;
                _botClient.StartReceiving();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine("Inner: " + e.InnerException.Message);
            }

            Console.WriteLine("Serviço de monitoramento ativo");
            Console.ReadKey();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                // 647475442
                if (e.Message.Text == null) return;

                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}: {e.Message.Text}.");

                var text = e.Message.Text;

                // Comandos
                if (text.StartsWith("/"))
                {
                    LastCommands.TryRemove(e.Message.Chat.Id, out _);
                    LastChats.TryRemove(e.Message.Chat.Id, out _);

                    switch (text.ToLower())
                    {
                        case "/start":
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text: "Você pode ver minha lista de comandos digitando `/` no chat.",
                                parseMode: ParseMode.Markdown);
                            break;

                        case "/remessa":
                            LastCommands[e.Message.Chat.Id] = text;
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text:
                                "Digite *sim* para confirmar geração de remessa de todos os boletos pendentes do *dia*.",
                                parseMode: ParseMode.Markdown);
                            break;

                        case "/ted":
                            LastCommands[e.Message.Chat.Id] = text;

                            var rkm = new ReplyKeyboardMarkup();
                            rkm.ResizeKeyboard = true;
                            rkm.OneTimeKeyboard = false;
                            rkm.Keyboard =
                                new[]
                                {
                                    new[]
                                    {
                                        new KeyboardButton("Santander"),
                                        new KeyboardButton("Banco do Brasil"),
                                        new KeyboardButton("Caixa"),
                                    },
                                    new[]
                                    {
                                        new KeyboardButton("Itaú"),
                                        new KeyboardButton("Bradesco"),
                                        new KeyboardButton("Inter"),
                                    }
                                };
                            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Me diga, qual o banco *origem* da transferência?",
                                ParseMode.Markdown,
                                replyMarkup: rkm);
                            break;

                        case "/remessasemana":
                            LastCommands[e.Message.Chat.Id] = text;
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text:
                                "Digite *sim* para confirmar geração de remessa de todos os boletos pendentes da *semana*.",
                                parseMode: ParseMode.Markdown);
                            break;
                        case "/chatbotsamples":
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text:
                                "Exemplos de palavras para conversar com o chat:\n" +
                                "-oi\n" +
                                "-me mande um sticker\n" +
                                "-me mande um video\n" +
                                "-me ajude com esta api",
                                parseMode: ParseMode.Markdown);
                            break;

                        case "/indicador":
                            await _botClient.SendPhotoAsync(
                                chatId: e.Message.Chat,
                                photo: @"https://i.imgur.com/hGWOkD6.png",
                                caption: "<b>Invoice</b>. <a href=\"http://atstechnology.com.br/\">Veja mais</a>",
                                parseMode: ParseMode.Html
                            );
                            break;
                    }

                    return;
                }

                // Confirmação para executar comando
                if (LastCommands.TryRemove(e.Message.Chat.Id, out var lastCommand))
                {
                    if (text.ToLower() == "sim")
                    {
                        var remessaId = new Random().Next(int.MaxValue);
                        await _botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text:
                            $"Ação `{lastCommand.Remove(0, 1)}` *confirmada*, vá tomar um café enquanto realizamos o trabalho!.\n" +
                            $"Remessa gerada: *{remessaId}*\n" +
                            $"Em breve lhe retornamos com mais informações.",
                            parseMode: ParseMode.Markdown);

                        Task.Run(async () =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text:
                                $"Hora de continuar ao trabalho, finalizamos o arquivo da remessa *{remessaId}*!\n" +
                                $"{new Random().Next(10, 100)} títulos, totalizando {new Random().Next(10000, 100000):C2}.",
                                parseMode: ParseMode.Markdown,
                                replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                                    $"Download do arquivo",
                                    "https://1drv.ms/t/s!AqLpZQID9HOD6AVoinUXut5PX3aG?e=zP8CFY"
                                )));

                            await _botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text: "Você também pode",
                                replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                                    $"Enviar para o banco",
                                    "https://1drv.ms/t/s!AqLpZQID9HOD6AVoinUXut5PX3aG?e=zP8CFY"
                                )));


//                            var rkm = new ReplyKeyboardMarkup();
//                            rkm.Keyboard =
//                                new KeyboardButton[][]
//                                {
//                                    new KeyboardButton[]
//                                    {
//                                        new KeyboardButton("Enviar para o banco")
//                                    }
//                                };
//                            await _botClient.SendTextMessageAsync(e.Message.Chat.Id, "Opçoes", replyMarkup: rkm);
                        });
                    }
                    else if (Bancos.Contains(text))
                    {
                        if (lastCommand == "/ted")
                        {
                            var rkm = new ReplyKeyboardMarkup();
                            rkm.ResizeKeyboard = true;
                            rkm.OneTimeKeyboard = true;
                            rkm.Keyboard =
                                new[]
                                {
                                    new[]
                                    {
                                        new KeyboardButton("Santander"),
                                        new KeyboardButton("Banco do Brasil"),
                                        new KeyboardButton("Caixa"),
                                    },
                                    new[]
                                    {
                                        new KeyboardButton("Itaú"),
                                        new KeyboardButton("Bradesco"),
                                        new KeyboardButton("Inter"),
                                    }
                                };

                            LastCommands[e.Message.Chat.Id] = "/ted-valor";
                            await _botClient.SendTextMessageAsync(e.Message.Chat.Id,
                                "e qual o *destino* deste dinheiro?",
                                ParseMode.Markdown,
                                replyMarkup: rkm);
                        }
                        else if (lastCommand == "/ted-valor")
                        {
                            LastCommands[e.Message.Chat.Id] = "/ted-finalizar";
                            BancoDestino[e.Message.Chat.Id] = text;
                            await _botClient.SendTextMessageAsync(e.Message.Chat.Id,
                                "Estamos quase lá, só preciso saber qual *valor* para movimentar:",
                                ParseMode.Markdown);
                        }
                    }
                    else if (lastCommand == "/ted-finalizar")
                        await _botClient.SendTextMessageAsync(e.Message.Chat.Id,
                            $"Transferência entre bancos realizada.\n" +
                            $"Valor: R$ {text}.\n" +
                            $"Pode levar até 15 minutos para estar disponível em sua conta {BancoDestino[e.Message.Chat.Id]}.");
                    else
                        await _botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: $"Ação *cancelada*!",
                            ParseMode.Markdown);

                    return;
                }

                // Chat bot
                LastCommands.TryRemove(e.Message.Chat.Id, out _);
                LastChats.TryGetValue(e.Message.Chat.Id, out var lastChat);
                string responseText = null;
                switch (text.ToLower())
                {
                    case "oi":
                        responseText = "Olá, tudo bem?";
                        break;
                    case "sim" when lastChat == "oi":
                        responseText = "Que legal!";
                        break;
                    case "me mande um sticker":
                        await _botClient.SendStickerAsync(
                            chatId: e.Message.Chat,
                            sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"
                        );
                        break;
                    case "me mande um video":
                        await _botClient.SendVideoAsync(
                            chatId: e.Message.Chat,
                            video: "https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"
                        );
                        break;
                    case "me ajude com esta api":
                        await _botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat, // or a chat id: 123456789
                            text: "Claro, clique aqui para visualizar *todos os parâmetros* da api `sendMessage`",
                            parseMode: ParseMode.Markdown,
                            disableNotification: true,
                            replyToMessageId: e.Message.MessageId,
                            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                                "Clique aqui!!!",
                                "https://core.telegram.org/bots/api#sendmessage"
                            ))
                        );
                        break;
                    /*case "iniciar pesquisa":
                        // Só funuciona em grupo ou canais
                        var pollMessage = await botClient.SendPollAsync(
                            chatId: e.Message.Chat,
                            question: "Did you ever hear the tragedy of Darth Plagueis The Wise?",
                            options: new []
                            {
                                "Yes for the hundredth time!",
                                "No, who`s that?"
                            }
                        );

                        // Parar questionário e apresentr respostas
                        var poll = await botClient.StopPollAsync(
                            chatId: pollMessage.Chat.Id,
                            messageId: pollMessage.MessageId
                        );
                        break;*/
                    default:
                        responseText = "Nenhuma ação para: " + e.Message.Text;
                        break;
                }

                if (!string.IsNullOrWhiteSpace(responseText))
                    await _botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: responseText);

                LastChats[e.Message.Chat.Id] = text.ToLower();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner: " + ex.InnerException.Message);
            }
        }
    }
}