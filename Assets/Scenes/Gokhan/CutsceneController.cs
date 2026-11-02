using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public int currentBeat= 0;
    public int numberOfBeats;

    public Vector3[] cameraPositions;
    public Vector3[] cameraRotations;
    public string[] dialogBoxes;

    
    public GameObject dialogBox;
    public Text dialogText;

    float skipLock = 1;

    private void Start()
    {
        SetBeat(0);
    }

    void FixedUpdate()
    {
        if (skipLock > 0)
        {
            skipLock -= Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        if (skipLock <= 0)
        {
            if (Input.anyKeyDown)
            {
                skipLock = 1;
                if (currentBeat < numberOfBeats - 1)
                {
                    currentBeat += 1;
                    SetBeat(currentBeat);
                }
            }
        }
    }

    void SetBeat(int beat)
    {
        Camera.main.transform.position = cameraPositions[beat];
        Camera.main.transform.eulerAngles = cameraRotations[beat];
        if (dialogBoxes[beat] != "")
        {
            dialogBox.SetActive(true);
            dialogText.text = dialogBoxes[beat];
            
        }
        else
        {
            dialogBox.SetActive(false);
        }
        
    }
}
