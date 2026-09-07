using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MGNamespace;

internal static class Program
{
    private static readonly TaskCompletionSource<bool> s_gameExit =
        new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

    private static Game1 s_game;

    private static async Task Main()
    {
        Game1 game = new Game1();
        s_game = game;

        try
        {
            game.Exiting += OnGameExiting;
            game.Run();
            await s_gameExit.Task;
        }
        finally
        {
            s_gameExit.TrySetResult(true);
            s_game = null;
            game.Dispose();
        }
    }

    internal static bool Tick()
    {
        Game1 game = s_game;
        if (game == null)
        {
            return !s_gameExit.Task.IsCompleted;
        }

        game.Tick();
        return !s_gameExit.Task.IsCompleted;
    }

    private static void OnGameExiting(object sender, ExitingEventArgs eventArgs)
    {
        s_gameExit.TrySetResult(true);
    }
}
