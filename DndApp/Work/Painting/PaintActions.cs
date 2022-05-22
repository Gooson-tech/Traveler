using Microsoft.Xna.Framework;
using Nez;

namespace DndApp;

/*if (Input.MiddleMouseButtonPressed)
    {
        // UIText.Weather= "shiny";
        //  UIText.Temperature = "100000f";
    }*/

//if (!UI.PaintMode) return;
//Initiate


public class PaintActions
{
    private static float _allowedDistance = 20f;
    private Entity _eraser;
    private static Vector2 _lastPos;

    public PaintActions(Scene scene)
    {
        _eraser = new Entity();
        _eraser.AddComponent(new Eraser());
        scene.AddEntity(_eraser);
    }
    public void PaintBiome(
        Scene scene, Biome biome, 
        Color color, int size,
        Vector2 locationAt, bool PaintButtonDown)
    {
        if (!PaintButtonDown) return;

        //for slight optimization 
        if (Vector2.Distance(locationAt, _lastPos) < _allowedDistance)
            return;

        var splotch = new Splotch(color, size);
        splotch.SetPosition(locationAt);
        splotch.AddComponent(biome);
        scene.AddEntity(splotch);
        _lastPos = locationAt;
    }
    public void Erase(Vector2 pos, bool EraseButtonDown) =>
        _eraser.Position = EraseButtonDown ? pos : new Vector2(9000, 0);
    public void SetEraser(Scene scene, Entity eraser)
    {
        _eraser = eraser;
    }
}





/*
private Scene _scene;
private Color _color;
private int _size;
public int SetSize {
    get => _size;
    set => _size = value;
}
public Color SetColor {
    get => _color;
    set => _color = value;
}
public Scene SetScene {
    get => _scene;
    set => _scene = value;
}
public float SetAllowedDistance {
    get => _allowedDistance;
    set => _allowedDistance = value;
}*/
/*

public PaintActions() { } 
public PaintActions(Scene scene, Color color, int size)
{
    _scene = scene;
    _color = color;
    _size = size;
}
public PaintActions(Scene scene)
{
    _scene = scene;
}
public PaintActions(Color color)
{
    _color = color;
}
public PaintActions(Color color, int size)
{
    _color = color;
    _size = size;
}*/

/*public void Paint(Vector2 mouseToWorldPoint, bool leftMouseButtonDown)
 {
if (leftMouseButtonDown)
{
    var splotch = new Splotch(_color, _size);
    splotch.SetPosition(mouseToWorldPoint);
    _scene.AddEntity(splotch);
 }
}*/

/*public void Paint(Scene scene, Color color, int size,
    Vector2 mouseToWorldPoint, bool leftMouseButtonDown)
{
    if (leftMouseButtonDown)
    {
        //for slight optimization 
        if (Vector2.Distance(mouseToWorldPoint, _lastPos) < _allowedDistance)
            return;

        var splotch = new Splotch(color, size);
        splotch.SetPosition(mouseToWorldPoint);
        scene.AddEntity(splotch);
        _lastPos = mouseToWorldPoint;
    }
}*/