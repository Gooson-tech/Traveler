using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;

namespace DndApp;

public interface INavigate
{
    public bool move { get; set; }
    public float Speed { get; set; }
    public Queue<Vector2> MoveLocations { get; set; }
    public void Move();
}