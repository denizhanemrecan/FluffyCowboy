using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public bool isForwardEmpty = true, isBackEmpty = true, isRightEmpty = true, isLeftEmpty = true;

    bool isForwardDirection = false, isBackDirection = false, isRightDirection = false, isLeftDirection = false;
    GameObject player;
    int countSteps = 0;

    [SerializeField] EnemyProjectile enemyProjectile;
    [SerializeField] GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        player = ManagerProvider.Instance.GetPlayer();
    }

    public void StartAttackRoutine()
    {
        CheckMovement();
    }

    void CheckNearSquares()
    {
        isForwardEmpty = true; isBackEmpty = true; isRightEmpty = true; isLeftEmpty = true;

        var ray1 = new Ray(this.transform.position, this.transform.forward);
        var ray2 = new Ray(this.transform.position, this.transform.forward * -1);
        var ray3 = new Ray(this.transform.position, this.transform.right);
        var ray4 = new Ray(this.transform.position, this.transform.right * -1);
        RaycastHit hit;
        if (Physics.Raycast(ray1, out hit))
        {
            Vector3 obstaclePosition = hit.transform.position;
            float distance = Vector3.Distance(transform.position, obstaclePosition);

            if (distance == 1)
            {
                isForwardEmpty = false;
            }
        }

        if (Physics.Raycast(ray2, out hit))
        {
            Vector3 obstaclePosition = hit.transform.position;
            float distance = Vector3.Distance(transform.position, obstaclePosition);

            if (distance == 1)
            {
                isBackEmpty = false;
            }
        }

        if (Physics.Raycast(ray3, out hit))
        {
            Vector3 obstaclePosition = hit.transform.position;
            float distance = Vector3.Distance(transform.position, obstaclePosition);

            if (distance == 1)
            {
                isRightEmpty = false;
            }
        }

        if (Physics.Raycast(ray4, out hit))
        {
            Vector3 obstaclePosition = hit.transform.position;
            float distance = Vector3.Distance(transform.position, obstaclePosition);

            if (distance == 1)
            {
                isLeftEmpty = false;
            }
        }
    }

    private void CheckMovement()
    {
        CheckNearSquares();
        Vector3 direction = transform.position - player.transform.position;
        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.z))
        {
            if (direction.z > 0)
            {
                if (isBackEmpty && !isBackDirection)
                {
                    transform.Translate(Vector3.back);
                }
                else if (direction.x > 0 && isRightEmpty)
                {
                    transform.Translate(Vector3.right);
                    isBackDirection = false;
                }
                else if(direction.x < 0 && isLeftEmpty)
                {
                    transform.Translate(Vector3.left);
                    isBackDirection = false;
                }
                else if (isForwardEmpty)
                {
                    transform.Translate(Vector3.forward);
                    isBackDirection = true;
                }
            }
            else if (direction.z < 0)
            {
                if (isForwardEmpty && !isForwardDirection)
                {
                    transform.Translate(Vector3.forward);
                }
                else if (direction.x > 0 && isRightEmpty)
                {
                    transform.Translate(Vector3.right);
                    isForwardDirection = false;
                }
                else if (direction.x < 0 && isLeftEmpty)
                {
                    transform.Translate(Vector3.left);
                    isForwardDirection = false;
                }
                else if (isBackEmpty)
                {
                    transform.Translate(Vector3.forward * -1);
                    isForwardDirection = true;
                }
                
            }
            else
            {
                if (direction.x > 0)
                {
                    Shot(Vector3.left);
                }
                else if (direction.x < 0)
                {
                    Shot(Vector3.right);
                }
            }
        }
        else if (Mathf.Abs(direction.z) > Mathf.Abs(direction.x))
        {
            if (direction.x > 0)
            {
                if (isLeftEmpty && !isLeftDirection)
                {
                    transform.Translate(Vector3.left);
                }
                else if (direction.z > 0 && isBackEmpty)
                {
                    transform.Translate(Vector3.forward * -1);
                    isLeftDirection = false;
                }
                else if (direction.z < 0 && isForwardEmpty)
                {
                    transform.Translate(Vector3.forward);
                    isLeftDirection = false;
                }
                else if (isRightEmpty)
                {
                    transform.Translate(Vector3.right);
                    isLeftDirection = true;
                }
            }
            else if (direction.x < 0)
            {
                if (isRightEmpty && !isRightDirection)
                {
                    transform.Translate(Vector3.right);
                }
                else if (direction.z > 0 && isBackEmpty)
                {
                    transform.Translate(Vector3.forward * -1);
                    isRightDirection = false;
                }
                else if (direction.z < 0 && isForwardEmpty)
                {
                    transform.Translate(Vector3.forward);
                    isRightDirection = false;
                }
                else if (isLeftEmpty)
                {
                    transform.Translate(Vector3.left);
                    isRightDirection = true;
                }
            }
            else
            {
                if (direction.z > 0)
                {
                    Shot(Vector3.forward * -1);
                }
                else if (direction.z < 0)
                {
                    Shot(Vector3.forward);
                }
            }
        }
        //if(direction.x == 0 && direction.z > 0)
        //{
        //    Shot(Vector3.forward);
        //}
        //else if(direction.x == 0 && direction.z < 0)
        //{
        //    Shot(Vector3.forward * -1);
        //}
        //else if(direction.z == 0 && direction.x > 0)
        //{
        //    Shot(Vector3.right);
        //}
        //else if (direction.z == 0 && direction.x < 0)
        //{
        //    Shot(Vector3.left);
        //}

        //if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z) && direction.z > 0 && isRightEmpty)
        //{
        //    transform.Translate(Vector3.right);
        //}
        //else if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z) && direction.z < 0 && isLeftEmpty)
        //{
        //    transform.Translate(Vector3.left);
        //}
        //else if (Mathf.Abs(direction.z) > Mathf.Abs(direction.x) && direction.x < 0 && isForwardEmpty)
        //{
        //    transform.Translate(Vector3.forward);
        //}
        //else if (Mathf.Abs(direction.z) > Mathf.Abs(direction.x) && direction.x > 0 && isBackEmpty)
        //{
        //    transform.Translate(Vector3.forward * -1);
        //}
    }

    private void Shot(Vector3 direction)
    {
        if (enemyProjectile)
        {
            GameObject gameObject = Instantiate(enemyProjectile.gameObject, firePoint.transform.position, Quaternion.identity);
            gameObject.GetComponent<EnemyProjectile>().Fire(10f, 10f, direction, firePoint.transform.position);
        }
    }

    private void IncreaseSteps()
    {
        countSteps += 1;

        if(countSteps == 2)
        {
            isForwardEmpty = true; isBackEmpty = true; isRightEmpty = true; isLeftEmpty = true;
        }
    }
}
