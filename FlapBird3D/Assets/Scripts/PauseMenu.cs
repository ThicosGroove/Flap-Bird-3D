using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject switchCameraButton;
    public GameObject quitButton;
    public GameObject cameraControl;
    public Text textoInicio;

    Principal principal;

    public bool isGamePaused = false;

    void Awake()
    {
        principal = GameObject.FindObjectOfType<Principal>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        switchCameraButton.SetActive(false);
        quitButton.SetActive(false);
        textoInicio.text = "Toque para Começar";
    }

    public void OnCLickPauseButton()
    {
        Time.timeScale = 0f;
        isGamePaused = true;

        resumeButton.SetActive(true);
        switchCameraButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isGamePaused = false;

        resumeButton.SetActive(false);
        switchCameraButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void SwitchCamera()
    {
        cameraControl.GetComponent<CameraControl>().SwitchCameraControl();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TextoInicio()
    {
        if (principal.comecou == true)
        {
            textoInicio.text = "";
        }
    }
}
