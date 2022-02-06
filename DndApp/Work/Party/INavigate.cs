using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;

namespace DndApp;

public interface INavigate
{
    public bool Paused { get; set; }
    public float Speed { get; set; }
    public List<Vector2> MoveLocations { get; set; }
    public void Move();
}