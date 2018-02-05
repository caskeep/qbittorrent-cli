﻿using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using QBittorrent.Client;

namespace QBittorrent.CommandLineInterface.Commands
{
    [Command(Description = "Gets or sets global qBittorrent settings.")]
    [Subcommand("info", typeof(Info))]
    public partial class GlobalCommand : ClientRootCommandBase
    {
        [Command(Description = "Gets the global transfer info.")]
        public class Info : AuthenticatedCommandBase
        {
            protected override async Task<int> OnExecuteAuthenticatedAsync(QBittorrentClient client, CommandLineApplication app, IConsole console)
            {
                var info = await client.GetGlobalTransferInfoAsync();
                console.PrintObject(info);
                return ExitCodes.Success;
            }
        }
    }
}