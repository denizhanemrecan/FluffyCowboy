using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerProvider : MonoBehaviour
{
    #region singleton

    public static ManagerProvider Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] NoteManager noteManager;
    [SerializeField] SwipeManager swipeManager;
    [SerializeField] NoteProducer noteProducer;
    [SerializeField] GameObject player;
    [SerializeField] List<EnemyBase> enemies;

    public NoteManager GetNoteManager()
    {
        if(noteManager != null)
        {
            return noteManager;
        }
        else
        {
            Debug.LogWarning("There is no notemanager in Manager Provider!");
            return null;
        }
    }

    public SwipeManager GetSwipeManager()
    {
        if (noteManager != null)
        {
            return swipeManager;
        }
        else
        {
            Debug.LogWarning("There is no swipe manager in Manager Provider!");
            return null;
        }
    }

    public GameObject GetPlayer()
    {
        if (player != null)
        {
            return player;
        }
        else
        {
            Debug.LogWarning("There is no player in Manager Provider!");
            return null;
        }
    }

    public List<EnemyBase> GetEnemies()
    {
        if (enemies != null)
        {
            return enemies;
        }
        else
        {
            Debug.LogWarning("There is no enemy in Manager Provider!");
            return null;
        }
    }

    public void DeleteEnemy(EnemyBase _enemy)
    {
        EnemyBase selectedEnemy = new EnemyBase();
        foreach (EnemyBase enemy in enemies)
        {
            if(enemy == _enemy)
            {
                selectedEnemy = enemy;
            }
        }

        enemies.Remove(selectedEnemy);
    }

    public NoteProducer GetNoteProducer()
    {
        if (noteProducer != null)
        {
            return noteProducer;
        }
        else
        {
            Debug.LogWarning("There is no note producer in Manager Provider!");
            return null;
        }
    }

}
