using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace MGNamespace;

[SupportedOSPlatform("browser")]
internal static partial class HostExports
{
    // Game.Run() cannot own the main loop in the browser.
    // It has to return control to the browser, which calls this method
    // each animation frame to tick the game.
    [JSExport]
    internal static bool Tick() => Program.Tick();
}
