using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace DndApp;

public class Splotch : Entity
{
    private static int _numCount;
    private static int _lastRenderLayer;
    public int RenderLayer { get; }
    private static Sprite sprite = new (CreateCircleTexture(150, Color.White));
    public Splotch(Color color, int radius = 32)
    {
        Name = "splotch#" + _numCount++;
        radius /= 20; //arbitrary good size
        Scale= new Vector2(radius, radius);
        var spriteRender = new SpriteRenderer(sprite) { 
            RenderLayer = _lastRenderLayer--,
            Color = color,
        };
        var  collider = new CircleCollider { IsTrigger = true, Enabled = false, };
        RenderLayer = spriteRender.RenderLayer;
        AddComponent(spriteRender);
        AddComponent(collider);
    }
    private static Texture2D CreateCircleTexture(int radius, Color color)
    {
        var texture = new Texture2D(Core.GraphicsDevice, radius, radius);
        var colorData = new Color[radius * radius];

        var diam = radius / 2f;
        var diamSq = diam * diam;

        for (var x = 0; x < radius; x++)
        for (var y = 0; y < radius; y++)
        {
            var index = x * radius + y;
            var pos = new Vector2(x - diam, y - diam);

            if (pos.LengthSquared() <= diamSq) 
                colorData[index] = color;
            else 
                colorData[index] = Color.Transparent;
        }
        texture.SetData(colorData);
        return texture;
    }
}  
/*
    private static Texture2D CreateSquareTexture(int width, int height, Color color)
    {
        var whiteRectangle = new Texture2D(Core.GraphicsDevice, width, height);
        whiteRectangle.SetData(new[] { color });
        return whiteRectangle;
    }
    */