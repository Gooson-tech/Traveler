using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
namespace DndApp;
public abstract class MyEntity: Entity, IAlive
{
    public bool Paused { get; set; }
    public float Speed { get; set; }
    public Queue<Vector2> MoveLocation { get; set; }
    public MyEntity(string spriteName, float speed)
    {
        this.Speed = speed;
        var sprite = new SpriteSetup();
        sprite.UseSprite(spriteName);
        this.AddComponent<SpriteSetup>();
    }

    private static string DirectionAnimation(Vector2 direction)
    {
        var animation = direction switch
        {
            { Y: < 0 } => "WalkUp", { Y: > 0 } => "WalkDown",
            _ => direction switch
            { { X: < 0 } => "WalkLeft", { X: > 0 } => "WalkRight",
                _ => "WalkDown"
            }
        };
        return animation;
    }
    public void Move(Vector2 destination)
    {
        var animator = this.GetComponent<SpriteAnimator>();
        var mover = this.GetComponent<Mover>();

        if (MoveLocation.Peek() == this.Position)
            MoveLocation.Dequeue();
        else
        {
            Vector2 direction = Vector2.Normalize(MoveLocation.Peek() - Position);

            if (direction == Vector2.Zero) { animator.Pause(); }
            else
            {
                var animation= DirectionAnimation(direction);
                if (!animator.IsAnimationActive(animation)) animator.Play(animation);
                else animator.UnPause();
                var movement = direction * Speed * Time.DeltaTime;
                mover.CalculateMovement(ref movement, out _);
                mover.ApplyMovement(movement);
            }
        }
    }
    public override void Update()
    {
        base.Update();

        if (Paused)
        {
            
        }
        if (MoveLocation.Count > 0)
            Move(MoveLocation.Peek());
    }
    public class SpriteSetup: Nez.Component
    { public void UseSprite(string spriteLocation)
        {
            // load up our character texture atlas. we have different characters in 1 - 6.png for variety
            var texture = this.Entity.Scene.Content.LoadTexture($"Content/Assets/Sprites/{spriteLocation}.png");
            var sprites = Sprite.SpritesFromAtlas(texture, 16, 16);

            var mover = this.Entity.AddComponent(new Mover());
            var animator = this.Entity.AddComponent<SpriteAnimator>();

            // add a shadow that will only be rendered when our player is behind the details layer of the tilemap (RenderLayer -1). The shadow   // must be in a renderLayer ABOVE the details layer to be visible.
            var shadow = this.Entity.AddComponent(new SpriteMime(this.Entity.GetComponent<SpriteRenderer>()));
            shadow.Color = new Color(10, 10, 10, 80);
            shadow.Material = Material.StencilRead();
            shadow.RenderLayer = -2; // ABOVE our tilemap layer so it is visible

            // extract the animations from the atlas
            animator.Speed = 1;
            animator.AddAnimation("WalkLeft", new[] { sprites[2], sprites[6], sprites[10], sprites[14] });
            animator.AddAnimation("WalkRight", new[] { sprites[3], sprites[7], sprites[11], sprites[15] });
            animator.AddAnimation("WalkDown", new[] { sprites[0], sprites[4], sprites[8], sprites[12] });
            animator.AddAnimation("WalkUp", new[] { sprites[1], sprites[5], sprites[9], sprites[13] });
        }

    }

}
public class Party : MyEntity
{
    public Party(string spriteName, float speed) : base(spriteName, speed) { }

    public override void Update()
    {
        base.Update();
    }

}
public interface IAlive: INavigate
{

}
public interface ISpriteSetup
{
    void SetupSprite();
}
public interface IWorldReader
{
    public void LocationLook(Vector2 position);
}
public interface INavigate
{
    public bool Paused { get; set; }
    public float Speed { get; set; }
    public Queue<Vector2> MoveLocation{ get; set; }
    public void Move(Vector2 destination);

}