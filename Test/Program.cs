using SDL3;
using Katzi.Framework;

KatziFramework.Init();

Window window = new("KatziFramework example", 800, 600, WindowFlag.Resizable);
Renderer renderer = new(window);

bool running = true;
while (running)
{
    while (SDL.PollEvent(out SDL.Event e))
    {
        if (e.Type == (uint)SDL.EventType.Quit)
        {
            running = false;
        }
    }

    renderer.Clear(Color.CornflowerBlue);

    float rectangleWidth = 100;
    float rectangleHeight = 100;

    Rectangle rectangle = new(window.Width / 2 - rectangleWidth / 2, window.Height / 2 - rectangleHeight / 2, rectangleWidth, rectangleHeight);
    renderer.RenderFilledRectangle(rectangle, Color.Red);

    renderer.Present();
}

KatziFramework.Quit();
