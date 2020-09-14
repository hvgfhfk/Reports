using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.SqlServer.Server;
using System.Timers;

namespace Reports_Bot
{
    class Reports
    {
        private readonly DiscordSocketClient _client;

        /***********************************************************************/
        /*                          RUST DISCORD SERVER                        */
        // Starting Channel
        ulong _Reports = 750054227845447680; // [불만-보내기] 750054227845447680 
        ulong _Reportschnl = 750381463626580048; // [어드민 불만 확인] 750381463626580048
        /***********************************************************************/
        /*                          TEST DISCORD SERVER                        */
        // 일반 채널 [ TEST DISCORD SERVER ] // [일반] 742778987394236539 // [ad] 750006603222351985
        ulong T_Starting = 751520298578346075; // [일반] 742778987394236539
        /***********************************************************************/

        static void Main(string[] args)
        { new Reports().MainAsync().GetAwaiter().GetResult(); }

        public Reports()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            await _client.SetStatusAsync(UserStatus.DoNotDisturb); // 봇의 상태 메세지 변경
            await _client.SetGameAsync("채팅 확인 ");
            await _client.LoginAsync(TokenType.Bot, "NzE5NTI2MjA3Njk5NTUwMjc5.Xt4tAA.bOiePvWjFuA3bf0mJV_S7PrHiT4"); // reports 봇
           // await _client.LoginAsync(TokenType.Bot, "NzUxMzU5OTg0MzMxMjU5OTU1.X1H8gw.IVE0uPvFNcPthQuQ0Qx61C1SfSA"); // Test 봇
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());

            return Task.CompletedTask;
        }

        private Task Ready()
        {
            Console.WriteLine($"{_client.CurrentUser} 연결됨!");

            return Task.CompletedTask;
        }

        public async Task MessageReceivedAsync(SocketMessage message)
        {
            var _Reports = message.Channel.Id == 750054227845447680;
            var A_Reportschnl = _client.GetChannel(_Reportschnl) as IMessageChannel;

            if(_Reports)
            {
                if(message.Content == "@ㄹㅇㄷ")
                {
                    await message.DeleteAsync();
                }
                else
                {
                    await message.DeleteAsync();
                    await A_Reportschnl.SendMessageAsync("[ " + message.Author + " ]" + " : " + message.Content + " <@&564052608181075968> / <@&556780742319931433>");
                }
            }
            

        }
    }
} 