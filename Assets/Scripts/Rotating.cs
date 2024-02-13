using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotating : MonoBehaviour
{
    public Transform Handle;
    public Slider sliders;
    public void Rotate()
    {
        Handle.eulerAngles = new Vector3(Handle.rotation.x, Handle.rotation.y, (sliders.value - sliders.minValue) / (sliders.maxValue - sliders.minValue) * -360);
        
    }
}
