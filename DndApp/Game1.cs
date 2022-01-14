﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using Nez;
using Nez.Sprites;
using Nez.Timers;

namespace DndApp;



public class Game1 : Core
{
    private static Entity _eraser;

    // private static void Window_ClientSizeChanged(object sender, System.EventArgs e) => UI.BuildUI();
    private static Vector2 _lstClkLocation = new(0, 0);
    public static Myra.Graphics2D.UI.Desktop desktop;
    
    public static int year=2015, month=1, day=1;
    private static DateTime Date = new DateTime(year,month,day);
    protected override void Initialize()
    {
        base.Initialize();
        //DebugRenderEnabled = true;
        Window.AllowUserResizing = true;
        var mapTexture = Content.LoadTexture(FileLocations.Map);
        SceneSetup(mapTexture);
        UI.BuildUI();
        //UI.BuildUI();
        Screen.SetSize(mapTexture.Width, mapTexture.Height);
        //Window.ClientSizeChanged += Window_ClientSizeChanged;
        Biome Desert = new(name: "Desert", Climates.Desert);
        Biome Tundra= new("Tundra", Climates.Tundra);
        Biome Grassland = new("Grassland", Climates.Grassland);
        Biome.BiomeList.Add(Desert);
        Biome.BiomeList.Add(Tundra);
        Biome.BiomeList.Add(Grassland);
        _eraser = Scene.CreateEntity("Eraser");
        _eraser.AddComponent(new Mouse());

        //TimerManager timerManager = new TimerManager();
        Schedule(1, true, test);

    }

    private static void SceneSetup(Texture2D mapTexture)
    {
        Scene = new Scene();


        var map=Scene.CreateEntity("Map");
        var mapRender=map.AddComponent(new SpriteRenderer(mapTexture));
        mapRender.RenderLayer = 1;

        Scene.SetDesignResolution(mapTexture.Width,
                                  mapTexture.Height,
                                  Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
        SceneCamera.SetUp(Scene.Camera);
        Scene.ClearColor = Color.Black;
        Scene.LetterboxColor = Color.Black;

    }

    public void test(ITimer obj)
    {
        string todaysResults = CollectionExtensions.GetValueOrDefault(Climate.Data1, Date);
        if (todaysResults==default) { Debug.Log("NONE"); }
        else Debug.Log(todaysResults);
    }

    protected override void Update(GameTime gametime)
   {
       base.Update(gametime);
  


       Date=Date.AddHours(1);


       if (!UI.Ontop)
       {
           //camera
           SceneCamera.CameraZoom(Input.MouseWheel);

           if (UI.PaintName != UI.LastUsedPaintName && UI.PaintName != null)
           {
               Biome.CreateNewBiome(UI.PaintName, UI.ClimateType);
               UI.LastUsedPaintName = UI.PaintName;
           }
           if (UI.PaintMode)
           {
               if (Input.LeftMouseButtonDown) DoPainting();
               else if (Input.RightMouseButtonDown)
               {
                   _eraser.Enabled = true;
                   DoErasing();
               }
               else _eraser.Enabled = false;
           }
       }
   }

 

    public static void DoPainting()
   {
       var clkLocation = Game1.Scene.Camera.MouseToWorldPoint();
       clkLocation.Round();
       if (Paint.AllowedRange(_lstClkLocation, clkLocation)) //optimization
       {
           var splotch = new Paint(UI.PaintName, UI.UseColor);
           splotch.SetScale(new Vector2(UI.SplotchSize, UI.SplotchSize));

           _lstClkLocation = clkLocation;
           splotch.SetPosition(Scene.Camera.MouseToWorldPoint());

           Scene.AddEntity(splotch);

       }
   }

    public static void DoErasing()
   {
       var clkLocation = Scene.Camera.MouseToWorldPoint();
       _eraser.SetPosition(clkLocation);
   }


    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        desktop.Render();
    }
}

