using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Traveler;

public interface INavigate
{
    public float Speed { get; set; }
    public Queue<Vector2> MoveLocations { get; set; }
    public void Move();
}