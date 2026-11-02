using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isForwardEmpty = true, isBackEmpty = true, isRightEmpty = true, isLeftEmpty = true;

    void CheckNearSquares()
    {
        isForwardEmpty = true; isBackEmpty = true; isRightEmpty = true; isLeftEmpty = true;
        var ray1 = new Ray(transform.position, Vector3.forward);
        var ray2 = new Ray(transform.position, Vector3.forward * -1);
        var ray3 = new Ray(transform.position, Vector3.left);
        var ray4 = new Ray(transform.position, Vector3.right);
        RaycastHit hit;
        if (Physics.Raycast(ray1, out hit))
        {
            
            Vector3 obstaclePosition = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z);
            float distance = Vector3.Distance(transform.position, obstaclePosition);

            if (distance < 1.1f)
            {
                isForwardEmpty = false;
            }
        }

        if (Physics.Raycast(ray2, out hit))
        {
            Vector3 obstaclePosition = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z);
            float distance = Vector3.Distance(transform.position, obstaclePosition);
            if (distance < 1.1f)
            {
                isBackEmpty = false;
            }
        }

        if (Physics.Raycast(ray3, out hit))
        {
            Vector3 obstaclePosition = new Vector3(hit.transform.position.x, transform.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, obstaclePosition);
            if (distance < 1.1f)
            {
                isLeftEmpty = false;
            }
        }

        if (Physics.Raycast(ray4, out hit))
        {
            Vector3 obstaclePosition = new Vector3(hit.transform.position.x, transform.position.y, transform.position.z);
            float distance = Vector3.Distance(transform.position, obstaclePosition);
            if (distance < 1.1f)
            {
                isRightEmpty = false;
            }
        }
    }

    public void Move(Vector3 direction)
    {
        CheckNearSquares();
        if (direction == Vector3.forward && isForwardEmpty)
        {
            transform.Translate(direction);
        }
        if (direction == Vector3.right && isRightEmpty)
        {
            transform.Translate(direction);
        }
        if (direction == Vector3.left && isLeftEmpty)
        {
            transform.Translate(direction);
        }
        if (direction == Vector3.forward * -1 && isBackEmpty)
        {
            transform.Translate(direction);
        }
    }

}
