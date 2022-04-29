using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject camera3D;
    public GameObject camera2D;

    AudioListener camera3Daudio;
    AudioListener camera2Daudio;

    public int valorCamera;

    // Start is called before the first frame update
    void Start()
    {
        camera3Daudio = camera3D.GetComponent<AudioListener>();
        camera2Daudio = camera2D.GetComponent<AudioListener>();
        CameraChange(PlayerPrefs.GetInt("Camera", 0));
    }

    public void SwitchCameraControl()
    {
        CameraChange(valorCamera);       
    }

    public void CameraChange(int valor)
    {
        if (valor == 0)
        {
            PlayerPrefs.SetInt("Camera", valorCamera);
            valorCamera += 1;
            camera2D.SetActive(false);
            camera2Daudio.enabled = false;

            camera3D.SetActive(true);
            camera3Daudio.enabled = true;
        }
        else if (valor == 1)
        {
            PlayerPrefs.SetInt("Camera", valorCamera);
            valorCamera = 0;
            camera2D.SetActive(true);
            camera2Daudio.enabled = true;

            camera3D.SetActive(false);
            camera3Daudio.enabled = false;
        }
    }
}


