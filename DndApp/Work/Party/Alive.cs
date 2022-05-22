﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace DndApp;

public abstract class Alive : Entity, ITimeStoppable
{
    protected Mover _mover;
    protected readonly string _spriteLocation;
    protected SpriteAnimator _animator;
    protected readonly Queue<Vector2> _moveLocations = new();
    protected bool _move;

    public Biome InsideBiome => this.GetComponent<MyWorldPosition>().InsideBiome;
    public float Speed { get; set; }
    protected void ResetMovement()
    {
        _move = false;
        _moveLocations.Clear();
        _animator.Stop();
    }
    protected Alive(string spriteLocation, float speed)
    {
        _spriteLocation = spriteLocation;
        Speed = speed;
    }
    private void PerformMoveAction()
    {
        var animator = this.GetComponent<SpriteAnimator>();
        var mover = this.GetComponent<Mover>();
        var distance = Vector2.Distance(_moveLocations.Peek(), this.Position);
        var direction = Vector2.Normalize(_moveLocations.Peek() - this.Position);
        var arrived = distance <= 2f;

        if (!arrived)
        {
            var animation = DirectionAnimation(direction);

            if (animator.IsAnimationActive(animation))
                animator.UnPause();
            else
                animator.Play(animation);
            var movement = direction * Speed * Time.DeltaTime;
            mover.CalculateMovement(ref movement, out _);
            mover.ApplyMovement(movement);
        }
        else
        {
            animator.Pause();
            _moveLocations.Dequeue();
        }
    }

    public override void Update()
    {
        base.Update();
        if (!_move) return;
        if (_moveLocations.Count == 0)
        {
            _moveLocations.Clear();
            _animator.Stop();
            return;
        }
        PerformMoveAction();
    }

    private string DirectionAnimation(Vector2 direction)
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
    private Vector2 _lastPosVector = new(0, 0);
    public void MoveTo(Vector2 pos, bool MoveCondition=true, bool MoveConditionReleased = false, bool stopButton = false)
    {
        if (!MoveCondition && !MoveConditionReleased && !stopButton) return;

        if (stopButton)
        {
            _move = false;
            _animator.Stop();
            ResetMovement();
        }
        else if (MoveCondition)
        {
            if (_move)
                ResetMovement();
            else if (_moveLocations.Count <= 0 || Vector2.Distance(_moveLocations.Last(), _lastPosVector) > 5)
            {
                _moveLocations.Enqueue(pos);
                _lastPosVector = pos;
            }
        }
        else if (MoveConditionReleased)
            _move = true;

        _lastPosVector = pos;
    }
    public void Pause() => this.SetEnabled(false);
    public void Continue() => this.SetEnabled(true);
}