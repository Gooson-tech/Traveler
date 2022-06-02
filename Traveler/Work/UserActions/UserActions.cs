using System;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;
using static Traveler.MyraUI.Mode;
using static Traveler.SceneCameraController;
using static Microsoft.Xna.Framework.Input.Keys;
using static Nez.Input;
using static Nez.TweenExt;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.PhysicsShapes;
using Nez.Sprites;
using Nez.Textures;

namespace Traveler;

public class UserActions
{
    private readonly PaintActions _paintActions;
    private readonly Party _party;
    private readonly Scene _scene;
    private readonly MyraUI _myraUI;
    private Camera _sceneCamera;

    public UserActions(Scene scene, Party party, PaintActions paintActions, MyraUI myraUI)
    {
        _party = party;
        _paintActions=paintActions;
        _scene = scene;
        _myraUI = myraUI;
        _sceneCamera = scene.Camera;
    }

    private Vector2 _last=Vector2.Zero;
    public void CheckForInput()
    {
        CameraZoom(_sceneCamera, MouseWheel);
        if (MiddleMouseButtonPressed)
        {
            CameraFollow(_sceneCamera, _party, false);
        }
        if (MiddleMouseButtonReleased)
        {
            _sceneCamera.Entity.TweenPositionTo(_party.Position, 2f)
                .SetEaseType(EaseType.ElasticInOut)
                .Start();
            CameraFollow(_sceneCamera, _party, true);
        }
        else if (MiddleMouseButtonDown)
        {
            //posTween.SetTweenedValue(_sceneCamera.MouseToWorldPoint());
            //posTween.SetTargetAndType();

           
            //_sceneCamera.SetPosition();
            //_sceneCamera.MouseToWorldPoint();
            //.TweenPositionTo(_pos, .1f)
            //  .SetEaseType(EaseType.ElasticOut)
            //  .Start();
            if (Vector2.Distance(_last, ScaledMousePosition) > 100f)
            {
                _sceneCamera.SetPosition(_sceneCamera.MouseToWorldPoint());
            }
        }
        switch (_myraUI.SelectedMode)
        {
            case Paint:
                PaintInstruction(_scene, _paintActions, _myraUI);
                break;
            case TravelToClicked: 
                TravelInstruction(_scene, _party, _myraUI);
                break;
            case MyraUI.Mode.None:
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }
    private static void PaintInstruction(Scene scene, PaintActions paintActions, MyraUI myraUI)
    {
        if (MyraUI.MouseIsOver || myraUI.BiomeName != "")
            return;

        var biome = Biome.Cached.ContainsKey(myraUI.BiomeName)
            ? Biome.Cached[myraUI.BiomeName]
            : new Biome(myraUI.BiomeName, myraUI.SelectedClimate);

        paintActions.PaintBiome(
            scene,
            biome,
            (Color)myraUI.UseColor!,
            myraUI.SplotchSize,
            scene.Camera.MouseToWorldPoint(),
            LeftMouseButtonDown
        );
        paintActions.Erase(scene.Camera.MouseToWorldPoint(), RightMouseButtonDown);
    }
    private static void TravelInstruction(Scene scene, Party party, MyraUI myraUI)
    {
        var mousePosition = scene.Camera.MouseToWorldPoint();
        
        party.MoveTo(
            pos: mousePosition,
            moveCondition: LeftMouseButtonDown,
            moveConditionReleased: LeftMouseButtonReleased,
            stopCondtion: IsKeyPressed(Space)
        ); 

        if (party.InsideBiome == null)
            return;
        var climateDataIndex = Date.TimeIndex(party.InsideBiome.Climate, myraUI.Year!, myraUI.Month!, myraUI.Day!, myraUI.Hour!);
        var climateNow = party.InsideBiome.GetClimateAt(climateDataIndex);
        UIText.Weather = $"Name:{party.InsideBiome.Name}\r\n" + $"ClimateData:{climateNow}";
        myraUI.InformationBox.Text = $"Name:{party.InsideBiome.Name}\r\n" + $"ClimateData:{climateNow}";
    }
}