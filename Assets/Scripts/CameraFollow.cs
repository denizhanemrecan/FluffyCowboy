using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [SerializeField]
    private GameObject player;
    private Vector3 cameraPosition;
    public float camDrag = 2f;
    public float zOffset = 6f;

    void Start()
    {
        cameraPosition = this.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        cameraPosition.z = player.transform.position.z - zOffset;
        //this.transform.position = cameraPosition;
        this.transform.position = Vector3.MoveTowards(this.transform.position, cameraPosition, camDrag * Time.fixedDeltaTime);
    }

}
