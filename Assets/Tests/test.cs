using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class test
{
    private Sphere_Texture_Rotation_Manager sphereManager;
    private Sphere_Details_SO sphereDetails;
    private Swap swap;
    private MeshRenderer renderer; // Later Redacted [MeshRenderer]
    private Sphere_Details details;


    [SetUp]
    public void SetUp()
    {
        sphereManager = new GameObject().AddComponent<Sphere_Texture_Rotation_Manager>();
        sphereDetails = ScriptableObject.CreateInstance<Sphere_Details_SO>();
        swap = new Swap(sphereManager);
        renderer = sphereManager.gameObject.AddComponent<MeshRenderer>();
        renderer.sharedMaterial = new Material(Shader.Find("Standard"));

        details = new Sphere_Details
        {
            SphereColor = Color.white
        };
        sphereDetails.SphereDetailsList = new List<Sphere_Details>();
        sphereDetails.SphereDetailsList.Add(details);
    }

    [Test]
    public void Amount_NEW()
    {
        //ACT
        int NewAmount = Sphere_Texture_Rotation_Manager.TestFunction(amount: 5);
        
        //Assert
        Assert.AreEqual(10,NewAmount);
    }
    [Test]
    public void Speed_Rate_Check()
    {
        //ACT
        int index = 0;
        sphereDetails.ApplyScale(renderer.transform, index);
        float Expected = sphereDetails.SphereDetailsList[index].ScaleFactor;
        float Actual = renderer.transform.localScale.magnitude;
        
        //Assert
        Assert.AreEqual(Expected,Actual);
    }
    [Test]
    public void Sphere_Texture_Check()
    {
        //ACT
        int index = 0;
        sphereDetails.ApplyTexture(renderer, index);
        Texture Actual = renderer.sharedMaterial.mainTexture;
        Texture Expected = sphereDetails.SphereDetailsList[index].SphereTexture;

        //Assert
        Assert.AreEqual(Expected, Actual);
        
    }
    [Test]
    public void Sphere_Color_Check()
    {
        //ACT
        int index = 0;
        sphereDetails.ApplyColor(renderer, index);
        Color Actual = renderer.sharedMaterial.color;
        Color Expected = sphereDetails.SphereDetailsList[index].SphereColor;

        //Assert
        Assert.AreEqual(Expected, Actual);
    }
}
