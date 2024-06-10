using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using discordbot.other;
using DSharpPlus.Interactivity.Extensions;

namespace discordbot.commands
{
    public class GeneralCommands : BaseCommandModule
    {

        [Command("test")]
            public async Task TestCommand(CommandContext ctx)
        {
            var interactivity = Program.Client.GetInteractivity();

            var messageToRetrieve = await interactivity.WaitForMessageAsync(message => message.Content == "Hello");
            if (messageToRetrieve.Result.Content == "Hello")
            {
                await ctx.Channel.SendMessageAsync($"{ctx.User.Username} said Hello");
            }

        }

        [Command("test1")]
        public async Task Test1Command(CommandContext ctx)
        {
            var interactivity = Program.Client.GetInteractivity();

            var messageToReact = await interactivity.WaitForReactionAsync(message => message.Message.Id == 1249861786098729012);
            if (messageToReact.Result.Message.Id == 1249861786098729012)
            {
                await ctx.Channel.SendMessageAsync($"{ctx.User.Username} reacted with the emoji {messageToReact.Result.Emoji.Name}");
            }
        }

        [Command("whoami")]
        public async Task IdCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"{ctx.User.Username}");
            await ctx.Channel.SendMessageAsync($"{ctx.User.Id}");
            await ctx.Channel.SendMessageAsync($"{ctx.User.Flags}");
            await ctx.Channel.SendMessageAsync($"{ctx.User.AvatarUrl}");
        }

        [Command("add")]
        public async Task Add(CommandContext ctx, int number1, int number2)
        {
            int result = number1 + number2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("subtract")]
        public async Task Subtract(CommandContext ctx, int number1, int number2)
        {
            int result = number2 - number1;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("multiply")]
        public async Task Multiply(CommandContext ctx, int number1, int number2)
        {
            int result = number1 * number2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("divide")]
        public async Task Divide(CommandContext ctx, int number1, int number2)
        {
            int result = number1 / number2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("embed")]
        public async Task EmbedMessage(CommandContext ctx)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "This is my first discord embed",
                Description = $"This command was executed by {ctx.User.Username}",
                Color = DiscordColor.CornflowerBlue
            };

            await ctx.Channel.SendMessageAsync(message);
        }

        [Command("cardgame")]
        public async Task CardGame(CommandContext ctx)
        {
            var userCard = new CardSystem();

            var userCardEmbed = new DiscordEmbedBuilder
            {
                Title = $"Your card is {userCard.SelectedCard}",
                Color = DiscordColor.Gold
            };

            await ctx.Channel.SendMessageAsync(embed: userCardEmbed);  

            var botCard = new CardSystem();

            var botCardEmbed = new DiscordEmbedBuilder
            {
                Title = $"The bot drew a {botCard.SelectedCard}",
                Color = DiscordColor.Cyan
            };

            await ctx.Channel.SendMessageAsync(embed: botCardEmbed);

            if (userCard.SelectedNumber > botCard.SelectedNumber)
            {
                var winMessage = new DiscordEmbedBuilder
                {
                    Title = "Congratulations, you win!",
                    Color = DiscordColor.Blue
                };

                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }
            else
            {
                var loseMessage = new DiscordEmbedBuilder
                {
                    Title = "You lost the game!",
                    Color = DiscordColor.Red
                };

                await ctx.Channel.SendMessageAsync(embed: loseMessage);
            }
        }
    }
}
