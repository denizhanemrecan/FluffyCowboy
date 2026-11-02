using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] PlayerProjectile playerProjectile;
    EnemyBase closestEnemy;

    int comboNumber = 0;
    Swipe currentNoteSwipe;
    Swipe currentSwipe;
    GameObject currentNote;

    List<EnemyBase> enemies;
    GameObject player;

    private void Start()
    {
        enemies = ManagerProvider.Instance.GetEnemies();
        player = ManagerProvider.Instance.GetPlayer();
    }

    public void CountCombo()
    {
        if(currentNoteSwipe != Swipe.None)
        {
            if (currentNoteSwipe == currentSwipe)
            {
                comboNumber += 1;
                currentSwipe = Swipe.None;
                currentNote.GetComponent<Note>().isSwiped = true;
            }
            else
            {
                comboNumber = 0;
                ManagerProvider.Instance.GetNoteManager().ChangeNoteToBasic();
                ManagerProvider.Instance.GetNoteProducer().isRandomSprite = false;
                currentNote.GetComponent<Image>().color = Color.red;
            }
        }
        if(comboNumber == 1)
        {
            Shot();
            comboNumber = 0;
            ManagerProvider.Instance.GetNoteManager().ChangeNoteToBasic();
            ManagerProvider.Instance.GetNoteProducer().isRandomSprite = false;
        }
    }

    public void SetCurrentSwipe(Swipe _currentSwipe)
    {
        currentSwipe = _currentSwipe;
    }

    public void SetCurrentNoteSwipe(Swipe _currentNoteSwipe , GameObject _currentNote)
    {
        currentNoteSwipe = _currentNoteSwipe;
        currentNote = _currentNote;
    }

    public void Shot()
    {
        if (GetClosestEnemy())
        {
            Vector3 direction = GetClosestEnemy().transform.position - firePoint.transform.position;
            direction = direction.normalized;

            GameObject gameObject = Instantiate(playerProjectile.gameObject, firePoint.transform.position, Quaternion.identity);
            gameObject.GetComponent<PlayerProjectile>().Fire(10f, 10f, direction, firePoint.transform.position);
        }
    }

    public EnemyBase GetClosestEnemy()
    {
        float minDistance = 0;
        ;
        foreach (EnemyBase enemy in enemies)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if (minDistance == 0)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }

            if (minDistance > distance)
            {
                closestEnemy = enemy;
                minDistance = distance;
            }
        }

        return closestEnemy;
    }
}
