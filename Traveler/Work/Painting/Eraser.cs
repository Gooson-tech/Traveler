using Microsoft.Xna.Framework;
using Nez;

namespace Traveler;

    public class Eraser : Component, ITriggerListener, IUpdatable
    {
        private Mover _move;

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            _move = Entity.AddComponent(new Mover());
            Entity.AddComponent(new CircleCollider());
        }
        void IUpdatable.Update()
        {
            var movement = new Vector2(0f, 0f);
            _move.CalculateMovement(ref movement, out _);
            _move.ApplyMovement(movement);
        }
        void ITriggerListener.OnTriggerEnter(Collider other, Collider self) => other.Entity.Destroy();
        void ITriggerListener.OnTriggerExit(Collider other, Collider self) { /* Debug.Log("triggerExit: {0}", other.Entity.Name);*/ }
    }

