using Katzi.Error;
using SDL3;

namespace Katzi.Framework;

public static class KatziFramework
{
    /// <summary>
    /// Gets the current value of the hight resolution counter.
    /// </summary>
    public static ulong PerformanceCounter => SDL.GetPerformanceCounter();

    /// <summary>
    /// Gets the count per second of the high resolution counter.
    /// </summary>
    public static ulong PerformanceFrequency => SDL.GetPerformanceFrequency();

    public static bool Init()
    {
        try
        {
            if (!SDL.Init(SDL.InitFlags.Video))
                throw new Exception($"SDL couldn't initialize: {SDL.GetError()}");

            if (!TTF.Init())
                throw new Exception($"SDL TTF couldn't initialize: {SDL.GetError()}");
        }
        catch (Exception)
        {
            KerrorWindow error = new()
            {
                Title = "KatziFramework failed to initialize",
                Text = "The application you tried to run failed to initialize SDL.\n This is likely because you don't have SDL installed on your system.",
                Button1 = "Quit",
                Button2 = "Install SDL3",
                ButtonCount = 2,
            };

            bool running = true;
            while (running)
            {
                int result = error.Pull();

                if (result == 0)
                    running = false;
            }

            return false;
        }

        return true;
    }

    public static void Quit()
    {
        SDL.Quit();
        TTF.Quit();
    }
}
