using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Myra.Graphics2D.UI;
using Nez;
using Nez.Tweens;
using Qml.Net;
using static Traveler.MyraUI.Mode;
using static Microsoft.Xna.Framework.Input.Keys;
using static Nez.Input;

namespace Traveler;
public class UserActions
{
    private readonly PaintActions _paintActions;
    private readonly Party _party;
    private readonly Scene _scene;
    private readonly MyraUI _myraUI;
    private readonly Camera _sceneCamera;
    public UserActions(Scene scene, Party party, PaintActions paintActions, MyraUI myraUI)
    {
        _party = party;
        _paintActions=paintActions;
        _scene = scene;
        _myraUI = myraUI;
        _sceneCamera = scene.Camera;

    }
    public void CheckForInput()
    {
        CameraControls();
        switch (_myraUI.SelectedMode)
        {
            case MyraUI.Mode.None: break;
            case MyraUI.Mode.Menu: break;
            case Edit:
                
                PaintInstruction(_scene, _paintActions, _myraUI);
                break;
            case Travel:
                if (!MyraUI.IsClicked)
                {
                    TravelInstruction(_scene, _party, _myraUI);
                }
                break;
            case MyraUI.Mode.Info: break;
            case MyraUI.Mode.Notes: break;
            case MyraUI.Mode.Fight: break;
            default: break;
        }
    }
    private void CameraControls()
    {
        //zoom controls 
        _sceneCamera.CameraZoom(MouseWheel);

        //unset CameraFollow
        if (MiddleMouseButtonPressed)  
            _sceneCamera.CameraFollow(_party, false);
        //done with panning
        if (MiddleMouseButtonReleased)
        { 
            //move camera back to party
            _sceneCamera.Entity.TweenPositionTo(_party.Position, 2f)
                .SetEaseType(EaseType.ElasticInOut)
                .Start();

            //reset to following the party
            _sceneCamera.CameraFollow(_party, true);
        }
        else if (MiddleMouseButtonDown)
            _sceneCamera.SetPosition(Input.MousePositionDelta.ToVector2() + _sceneCamera.Position);
    }

    private static bool firstTime = true; 
    private static void PaintInstruction(Scene scene, PaintActions paintActions, MyraUI myraUI)
    {
        if (firstTime)
        {
            firstTime = false;
            return;
        }

        if (Input.IsKeyPressed(Keys.A))
            QmlEngineControls.Engine.RaiseSignal("hideSignal");
        else if (Input.IsKeyPressed(Keys.S))
            QmlEngineControls.Engine.RaiseSignal("showSignal");


        //var biome = Biome.Cached[UIINTERCHANGE.CurrentBiome.Name];
        //  
        //
        //paintActions.PaintBiome(
        //    scene,
        //    biome,
        //    (Color)myraUI.UseColor!,
        //    myraUI.SplotchSize,
        //    scene.Camera.MouseToWorldPoint(),
        //    LeftMouseButtonDown
        //);
        //paintActions.Erase(scene.Camera.MouseToWorldPoint(), RightMouseButtonDown);
    }
    private static void TravelInstruction(Scene scene, Party party, MyraUI myraUI)
    {
        party.MoveTo(
            pos: scene.Camera.MouseToWorldPoint(),
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