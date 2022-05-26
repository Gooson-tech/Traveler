using System;
using Microsoft.Xna.Framework;
using Nez;
using static Microsoft.Xna.Framework.Input.Keys;
using static Nez.Input;

namespace DndApp;

public class UserActions
{
    private readonly PaintActions _paintActions;
    private readonly Party _party;
    private readonly Scene _scene;
    private readonly UI _ui;

 
    public UserActions(Scene scene, Party party, PaintActions paintActions, UI ui)
    {
        _party = party;
        _paintActions=paintActions;
        _scene = scene;
        _ui = ui;
    }
    public void CheckForInput()
    {

        switch (_ui.SelectedMode)
        {
            case UI.Mode.Paint:
            {
                if (!_ui.OnTop && _ui.UseColor!=null && _ui.BiomeName!="")
                {
                    var biome = !Biome.Cached.ContainsKey(_ui.BiomeName) 
                        ? new Biome(_ui.BiomeName, _ui.SelectedClimate) 
                        : Biome.Cached[_ui.BiomeName];
                    _paintActions.PaintBiome
                        (_scene, biome, (Color)_ui.UseColor!, _ui.SplotchSize, _scene.Camera.MouseToWorldPoint(), LeftMouseButtonDown); 
                    _paintActions.Erase
                        (_scene.Camera.MouseToWorldPoint(), RightMouseButtonDown);
                }
                break;
            }
            case UI.Mode.TravelToClicked: 
            {
                _party.MoveTo(pos: _scene.Camera.MouseToWorldPoint(), MoveCondition: LeftMouseButtonDown, LeftMouseButtonReleased, 
                    stopButton: IsKeyPressed(Space));
                if (_party.InsideBiome != null)
                {
                    var climateDataIndex = 
                        Date.TimeIndex(_party.InsideBiome.Climate, _ui.Year!, _ui.Month!, _ui.Day!, _ui.Hour!);
                    var climateNow = 
                        _party.InsideBiome.GetClimateAt(climateDataIndex);
                    UIText.Weather = 
                        $"Name:{_party.InsideBiome.Name}\r\n" + $"ClimateData:{climateNow}";

                    _ui.InformationBox.Text =
                        $"Name:{_party.InsideBiome.Name}\r\n" + $"ClimateData:{climateNow}";
                }
                break;
            }
            case UI.Mode.None:
            {
                break;
            }
            default: throw new ArgumentOutOfRangeException(nameof(_ui.SelectedMode), _ui.SelectedMode, "");
        }
    }
}