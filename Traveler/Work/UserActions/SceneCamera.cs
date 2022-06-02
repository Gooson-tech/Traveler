using Microsoft.Xna.Framework;
using Nez;

namespace Traveler;

public static class SceneCameraController
{
    public static void Setup(Camera camera,uint x = 0, uint y = 0, float minZoom = .1f, float maxZoom = 100f)
    {
        camera.Position = new Vector2(x, y);
        camera.SetMinimumZoom(minZoom);
        camera.SetMaximumZoom(maxZoom);
    }
    public static void CameraFollow(Camera camera, Entity entity, bool allowed = true)
    {
        if (!allowed)
        {
            camera.Entity.RemoveComponent<FollowCamera>();
            return;
        }

        if (camera.Entity.HasComponent<FollowCamera>())
            camera.Entity.RemoveComponent<FollowCamera>();
        camera.Entity.AddComponent(new FollowCamera(entity, FollowCamera.CameraStyle.CameraWindow));
      
    }
    private static int _previousScrollWheelValue = 0;
    public static void CameraZoom(Camera camera, int scrollWheelValue)
    {
        
        if (scrollWheelValue < _previousScrollWheelValue)
        {
            if (camera.RawZoom > 2)
                camera.RawZoom -= 1;
            else
                camera.RawZoom -= .06f;
        }
        else if (scrollWheelValue > _previousScrollWheelValue)
        {
            if (camera.RawZoom > 2)
                camera.RawZoom += 1;
            else
                camera.RawZoom += .06f;
        }
        _previousScrollWheelValue = scrollWheelValue;
    }
    public static void SwapCameras(Scene scene, Camera camNum1, Camera camNum2)
    {

    }

}