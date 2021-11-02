using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public ViewSettings view;
    
    public float[] LimitSensitivty=new float[2]{0.1f,10f};
    
    public int[] LimitFieldOfView=new int[2]{70,110};
    
    // Start is called before the first frame update
    void Start()
    {
        view=new ViewSettings();
        view.Sensitivity = 1.0f;
        view.FieldOfView = 60;
        gameObject.SetActive(false);
    }

    public void SetSensitivity(float sensitivity)
    {
        view.Sensitivity = sensitivity;
    }
    
    public void SetFieldOfView(float fieldOfView)
    {
        view.FieldOfView = fieldOfView;
    }
}
