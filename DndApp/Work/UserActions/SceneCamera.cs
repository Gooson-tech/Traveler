using Microsoft.Xna.Framework;
using Nez;

namespace DndApp;

public static class SceneCamera
{
    private static Camera _camera;
    public static void SetCamera(Camera camera)=> _camera = camera;
    public static void Center()=>Core.Scene.Camera.SetPosition(new Vector2(0, 0));
    public static void CameraFollow(Entity move) {}
    public static void SetUp(Camera camera)
    {
        _camera= camera;
        _camera.Position = new Vector2(0, 0);
        _camera.SetMinimumZoom(.1f);
        _camera.SetMaximumZoom(100);
    }
    private static int _previousScrollWheelValue = 0;
    public static void CameraZoom(int scrollWheelValue)
    {
        if (scrollWheelValue < _previousScrollWheelValue)
        {
            if (_camera.RawZoom > 2)
                _camera.RawZoom -= 1;
            else
                _camera.RawZoom -= .06f;
        }
        else if (scrollWheelValue > _previousScrollWheelValue)
        {
            if (_camera.RawZoom > 2)
                _camera.RawZoom += 1;
            else
                _camera.RawZoom += .06f;
        }
        _previousScrollWheelValue = scrollWheelValue;
    }
    public static void SwapCameras(int camNum1, int camNum2, bool sceneCamEnabled) {
        _camera.SetEnabled(sceneCamEnabled);
        _camera.Entity.GetComponents<FollowCamera>()[camNum1].SetEnabled(isEnabled: true);
        _camera.Entity.GetComponents<FollowCamera>()[camNum2].SetEnabled(isEnabled: false);
    }

}