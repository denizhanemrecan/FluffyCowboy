using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;
    public GameObject button;
    public GameObject button2;
    public GameObject img1;
    public GameObject img2;

    public void PauseStart()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        button.SetActive(false);
        button2.SetActive(false);
        img1.SetActive(false);
        img2.SetActive(false);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        button.SetActive(true);
        button2.SetActive(true);
        img1.SetActive(true);
        img2.SetActive(true);
    }
}
