using SDL3;

namespace Katzi.Framework;

internal class TextEngine(Renderer renderer) : IDisposable
{
    internal readonly nint _handle = TTF.CreateRendererTextEngine(renderer.Handle);

    public void Dispose()
    {
        TTF.DestroyRendererTextEngine(_handle);
    }
}
