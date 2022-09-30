using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Sphere_Texture_Rotation_Manager : MonoBehaviour
{
    public MeshRenderer cubeRenderer;
    public Sphere_Details_SO SphereDetailsSo;
    public GameObject Sphere;
    public float degreesPerSecond = 20;
    public bool Toggle = true;
    public Button ToggleButton;
    public int Counter;
    [SerializeField] private float SpeedRate = 10;
    [SerializeField] private int Limit1 = 0;
    [SerializeField] private int Limit2 = 4;
    private readonly Swap _swap;

    public Sphere_Texture_Rotation_Manager()
    {
        _swap = new Swap(this);
    }

    void Start()
    {
        cubeRenderer.material.mainTexture = SphereDetailsSo.SphereDetailsList[0].SphereTexture;
    }

    void Update() 
    {
        Sphere.transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
    }

    public static int TestFunction(int amount)
    {
        return (amount * 2);
    }
    
    public void Speedup()
    {
        degreesPerSecond += SpeedRate;
    }

    public void Slowdown()
    {
        degreesPerSecond -= SpeedRate;
    }

    public void ToggleButtons()
    {
        Toggle = !Toggle;
    }
    
    public void Change(Sphere_Details sp)
    {
        int Index= 0;
        for( int i=0; i<SphereDetailsSo.SphereDetailsList.Count; i++)
        {
            if (SphereDetailsSo.SphereDetailsList[i]==sp){
                Index=i;
            }
        }
        _swap.SwapSphereTextureScale(Index);
        _swap.SwapSphereSpeed(Index);
    }

    private void SwapChanges()
    {
        _swap.SwapSphereTextureScale(Counter);
        _swap.SwapSphereSpeed(Counter);
    }

    public void NextColor()
    {
        if(Counter < Limit2)
        {
            Counter++;
            SwapChanges();
        }
    }

    public void PrevColor()
    {
        if(Counter > Limit1)
        {
            Counter --;
            SwapChanges();
        }
    }
}
