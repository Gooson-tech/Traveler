using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
namespace DndApp;

public class Party : Entity, IAlive
{
    private readonly string _spriteLocation;
    private Mover _mover;
    private SpriteAnimator _animator;
    private int _count = 0;
    public bool AllowMovement;
    public Vector2 LastRecordedMousePos = new(0, 0);
    public float Speed { get; set; }
    public Queue<Vector2> MoveLocations { get; set; } = new();
    public bool move { get; set; }

    public Party(string spriteLocation, float speed)
    {
        this.Speed = speed;
        _spriteLocation = spriteLocation;
    }

    public override void OnAddedToScene()
    {
        base.OnAddedToScene();
        var texture = this.Scene.Content.LoadTexture(_spriteLocation);
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

    private static string DirectionAnimation(Vector2 direction)
    {
        var animation = direction switch
        {
            { Y: < 0 } => "WalkUp",
            { Y: > 0 } => "WalkDown",
            _ => direction switch
            {
                { X: < 0 } => "WalkLeft",
                { X: > 0 } => "WalkRight",
                _ => "WalkDown"
            }

        };
        return animation;
    }


    public void Move()
    {
  

        var animator = this.GetComponent<SpriteAnimator>();
        var mover = this.GetComponent<Mover>();

        var distance = Vector2.Distance(MoveLocations.Peek(), this.Position);
        Vector2 direction = Vector2.Normalize(MoveLocations.Peek() - this.Position);
        var arrived = distance <= 2;
        if (!arrived)
        {
            var animation = DirectionAnimation(direction);
            if (!animator.IsAnimationActive(animation)) animator.Play(animation);
            else animator.UnPause();
            var movement = direction * Speed * Time.DeltaTime;
            mover.CalculateMovement(ref movement, out _);
            mover.ApplyMovement(movement);
        }
        else
        {
            animator.Pause();
            MoveLocations.Dequeue();
            _count++;
        }
    }

    public override void Update()
    {
        base.Update();
        if (!move) return;
        

        if (MoveLocations.Count == 0) {
            StopReset();
            return;
        }
        else { Move(); }

    }
    
    public void StopReset()
    {
        MoveLocations.Clear();
        _animator.Stop();
    }
 

}


public class MyWorldPosition : Component, ITriggerListener {

    //colision result
    #region ITriggerListener implementation

    public static string CurrentBiome;

    void ITriggerListener.OnTriggerEnter(Collider other, Collider self)
    {

        CurrentBiome = other.GetComponent<IDd>().ID;
    }

    void ITriggerListener.OnTriggerExit(Collider other, Collider self)
    {
        Debug.Log("triggerExit: {0}", other.Entity.Name);
    }

    #endregion


}