using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace DndApp;

public class Biome
{

    private string Name;
    public string[] Events;
    public string[] Animals;
    public string[] Enemies;
    public string[] Buildings;
    public Climates ClimateType;
    public static List<Biome> BiomeList = new List<Biome>();
   // private static IEnumerable<string> Climate1 = File.ReadLines("ClimateFile1");

    public static void CreateNewBiome(string paintName, Climates climateType) =>
        BiomeList.AddIfNotPresent(new Biome(paintName, climateType));
    
    public Biome(string name, Climates climateType)
    {
        Name = name;
        ClimateType = climateType;
        if (BiomeList.AddIfNotPresent(this))
        {
            var EventFile = name + "_Events.txt";
            var AnimalsFile = name + "_Animals.txt";
            var BuildingFile = name + "_Buildings.txt";
            var EnemyFile = name + "_Enemies.txt";
            using(StreamWriter sw = File.AppendText(EventFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(AnimalsFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(BuildingFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(EnemyFile)) { sw.WriteLine(""); }

            Events = File.ReadAllLines(EventFile);
            Animals = File.ReadAllLines(EventFile);
            Enemies = File.ReadAllLines(EventFile);
            Buildings = File.ReadAllLines(EventFile);
        }
    }

}

public class Paint : Entity
{
    //private static List<Vector2> PatchLocations=new List<Vector2>();
    private static string LastPaintedID;
    private string ID;
    private static Texture2D texture2d;
    private static Sprite sprite;
    private static bool Initialized;
    private static List<Paint> Splotches;
    private static Material _mat;
    private static SpriteRenderer spriteRender;


    //Used by game to see if patch at location are not too close to last/previous locations (for optimization)
    public static bool AllowedRange(Vector2 lstClkLocation, Vector2 clkLocation)
    {
        //check new patch click location with last location
        if (Vector2.Distance(clkLocation, lstClkLocation) <= 10f) return false;
        //if new patch is less than specified distance between any other patch return false
        if (Splotches != null) return Splotches.All(variable => !(Vector2.Distance(variable.Position, clkLocation) < 8f));
        return true;
    }

    public override void OnAddedToScene()
    {
        base.OnAddedToScene();
        Splotches= Core.Scene.EntitiesOfType<Paint>();

        spriteRender = new SpriteRenderer(sprite);

       // spriteRender.Material = Material.StencilWrite();



       // spriteRender.RenderLayer = 0;
        /*_mat = new Material
       {
           BlendState = new BlendState
           {
               ColorSourceBlend = Blend.SourceColor,
               ColorDestinationBlend = Blend.InverseSourceColor,
               ColorBlendFunction = BlendFunction.Add,
               AlphaSourceBlend = Blend.One,
               AlphaDestinationBlend = Blend.SourceAlpha,
               AlphaBlendFunction = BlendFunction.Min
           },
       };*/

       //spriteRender.Color = new Color(10, 10, 10, 50);
       //spriteRender.Material=_mat;


       spriteRender.RenderLayer++;

        var collider = new CircleCollider { IsTrigger = true, Enabled = false };
        AddComponent(spriteRender);
        AddComponent(collider);


    }

    private static Color lastColor;
    public Paint(string id, Color color)
    {

        ID = id;
       if (Initialized && id == LastPaintedID && color == lastColor)
        {
           LastPaintedID = id;
            lastColor = color;
          return;
        }


        texture2d = CreateCircleText(32, color);
        sprite = new Sprite(texture2d);



        Initialized = true;
        LastPaintedID= id;
        lastColor = color;
    }

    private static Texture2D CreateCircleText(int radius, Color color)
    {
        var texture = new Texture2D(Core.GraphicsDevice, radius, radius);
        var colorData = new Color[radius * radius];

        var diam = radius / 2f;
        var diamsq = diam * diam;

        for (var x = 0; x < radius; x++)
        {
            for (var y = 0; y < radius; y++)
            {
                var index = x * radius + y;
                var pos = new Vector2(x - diam, y - diam);

                if (pos.LengthSquared() <= diamsq)
                    colorData[index] = color;
                else
                    colorData[index] = Color.Transparent;
            }
        }

        texture.SetData(colorData);
        return texture;
    }
}

public class Mouse : Component, ITriggerListener, IUpdatable
{
    private Mover _move;

    public override void OnAddedToEntity()
    {
        base.OnAddedToEntity();
        _move = Entity.AddComponent(new Mover());
        var collider = Entity.AddComponent(new CircleCollider());
    }

    void IUpdatable.Update()
    {
        var movement = new Vector2(0f, 0f);
        _move.CalculateMovement(ref movement, out var res);
        _move.ApplyMovement(movement);
    }

    void ITriggerListener.OnTriggerEnter(Collider other, Collider self) => other.Entity.Destroy();

    void ITriggerListener.OnTriggerExit(Collider other, Collider self)
    {
        /* Debug.Log("triggerExit: {0}", other.Entity.Name);*/
    }
}