using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject endGameCanvas;
    [SerializeField]
    private GameObject Player;
    public GameObject button;
    public GameObject button2;
    public GameObject img1;
    public GameObject img2;
    public GameObject Note;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelEnd();
        }
    }

    public void LevelEnd()
    {
        Time.timeScale = 0f;
        endGameCanvas.SetActive(true);
        button.SetActive(false);
        button2.SetActive(false);
        img1.SetActive(false);
        img2.SetActive(false);
        Note.SetActive(false);
        AudioManager.instance.Pause("LoopTrack");
    }
}
