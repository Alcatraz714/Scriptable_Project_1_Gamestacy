using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdapterViewItem : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] RawImage TextureImage;
    [SerializeField] Button button;
    [SerializeField] MeshRenderer Renderer;
    [SerializeField] Sphere_Details_SO scriptable;
    [SerializeField] Sphere_Texture_Rotation_Manager ap;

    public void UpdateView(Sphere_Details sp)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => Change(sp));
        backgroundImage.color = sp.SphereColor;
        TextureImage.texture = sp.SphereTexture;
    }
    
    public void Change(Sphere_Details sp)
    {
        ap.Change(sp);
    }
}

