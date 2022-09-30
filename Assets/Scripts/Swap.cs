public class Swap
{
    private Sphere_Texture_Rotation_Manager _sphereManager;

    public Swap(Sphere_Texture_Rotation_Manager SphereManager)
    {
        _sphereManager = SphereManager;
    }

    public void SwapSphereTextureScale(int counter)
    {
        var sphereDetails = _sphereManager.SphereDetailsSo.SphereDetailsList[_sphereManager.Counter];
        var sphereSO = _sphereManager.SphereDetailsSo;
        if (_sphereManager.Toggle == true)
        {
            sphereSO.ApplyTexture(_sphereManager.cubeRenderer, counter);
            sphereSO.ApplyScale(_sphereManager.Sphere.transform, counter);
        }
    }

    public void SwapSphereSpeed(int counter)
    {
        var sphereDetails = _sphereManager.SphereDetailsSo.SphereDetailsList[_sphereManager.Counter];
        if(_sphereManager.Toggle == true)
        {
            _sphereManager.degreesPerSecond = sphereDetails.RotationSpeed;
        }
    }
}