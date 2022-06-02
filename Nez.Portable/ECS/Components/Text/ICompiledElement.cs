using Microsoft.Xna.Framework;

namespace Nez
{
    interface ICompiledElement
    {
        Vector2 Size { get; }
        Vector2 Position { get; set; }
        void Render(Batcher batcher, Vector2 offset);
    }
}