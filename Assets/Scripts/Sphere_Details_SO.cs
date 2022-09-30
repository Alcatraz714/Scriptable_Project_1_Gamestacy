using System;
using System.Collections;
using System.Collections.Generic;
using PlasticGui.WorkspaceWindow;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Sphere_Details", menuName = "Sphere_SO")]
public class Sphere_Details_SO : ScriptableObject
{
    public List<Sphere_Details> SphereDetailsList;
    public void ApplyTexture(MeshRenderer renderer, int index)
    {
        renderer.sharedMaterial.mainTexture =  SphereDetailsList[index].SphereTexture;
    }

    public void ApplyColor(MeshRenderer renderer, int index)
    {
        renderer.sharedMaterial.color = SphereDetailsList[index].SphereColor;
    }

    public void ApplyScale(Transform planetSize, int index)
    {
        float ScaleFactor = SphereDetailsList[index].ScaleFactor;
        planetSize.localScale = new Vector3(ScaleFactor, ScaleFactor, ScaleFactor);
    }
}

[System.Serializable]
public class Sphere_Details
{
    public Texture SphereTexture;
    public Color SphereColor;
    public float ScaleFactor;
    public int RotationSpeed;
    public Sprite thumbnail;
}
