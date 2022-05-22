using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace DndApp;
public class Party : Alive
{
    public Party(string spriteLocation, float speed) : base(spriteLocation, speed) { }
    public override void OnAddedToScene()
    {
        base.OnAddedToScene();
        var texture = Scene.Content.LoadTexture(_spriteLocation);
        var sprites = Sprite.SpritesFromAtlas(texture, 16, 16);

        _mover = this.AddComponent(new Mover());
        _animator = this.AddComponent<SpriteAnimator>();
        this.AddComponent(new BoxCollider());
        
        // add a shadow that will only be rendered when our player is behind the details layer of the tilemap (RenderLayer -1). The shadow
        // must be in a renderLayer ABOVE the details layer to be visible.
        var shadow = this.AddComponent(new SpriteMime(this.GetComponent<SpriteRenderer>()));
        shadow.Color = new Color(10, 10, 10, 80);
        shadow.Material = Material.StencilRead();
        shadow.RenderLayer = -2; // ABOVE our tiledmap layer so it is visible
        this.AddComponent(new MyWorldPosition());

        _animator.AddAnimation("WalkLeft", new[] { sprites[2], sprites[6], sprites[10], sprites[14] });
        _animator.AddAnimation("WalkRight", new[] { sprites[3], sprites[7], sprites[11], sprites[15] });
        _animator.AddAnimation("WalkDown", new[] { sprites[0], sprites[4], sprites[8], sprites[12] });
        _animator.AddAnimation("WalkUp", new[] { sprites[1], sprites[5], sprites[9], sprites[13] });
    }
 
}