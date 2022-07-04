using Microsoft.Xna.Framework;
using Nez;

namespace Traveler;

public static class SceneCamera
{
    public static void CameraFollow(this Camera cam, Entity entity, bool allowed = true)
    {
        if (!allowed) 
        {
            cam.Entity.RemoveComponent<FollowCamera>();
            return;
        }

        if (cam.Entity.HasComponent<FollowCamera>())
            cam.Entity.RemoveComponent<FollowCamera>();
        cam.Entity.AddComponent(new FollowCamera(entity, FollowCamera.CameraStyle.CameraWindow));
      




    }
    private static int _previousScrollWheelValue = 0;
    public static void CameraZoom(this Camera cam, int scrollWheelValue)
    {
        
        if (scrollWheelValue < _previousScrollWheelValue)
        {
            if (cam.RawZoom > 2)
                cam.RawZoom -= 1;
            else
                cam.RawZoom -= .06f;
        }
        else if (scrollWheelValue > _previousScrollWheelValue)
        {
            if (cam.RawZoom > 2)
                cam.RawZoom += 1;
            else
                cam.RawZoom += .06f;
        }
        _previousScrollWheelValue = scrollWheelValue;
    }
    public static void SwapCameras(Scene scene, Camera camNum1, Camera camNum2)
    {

    }

}