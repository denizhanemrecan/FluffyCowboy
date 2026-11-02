using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NotePair
{
    public Swipe swipe;
    public Sprite swipeSprite;
}

public class Note : MonoBehaviour
{
    public List<NotePair> swipeNotes;
    public NotePair basicSwipe;
    public NotePair currentNotePair;
    [SerializeField] float moveSpeed;
    [SerializeField] float killTime;
    bool isAlreadyInList = false;
    public bool isSwiped = false;

    private void FixedUpdate()
    {

        float positionX = transform.localPosition.x + transform.parent.localPosition.x;

        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f, 0f));
        StartCoroutine("KillObject");
        
        if(positionX < 120f
            && positionX > -120f && !isAlreadyInList)
        {
            ManagerProvider.Instance.GetNoteManager().AddNote(gameObject);
            ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().SetCurrentNoteSwipe(currentNotePair.swipe, gameObject);
            isAlreadyInList = true;
        }

        if(isAlreadyInList && positionX < -120f)
        {
            ManagerProvider.Instance.GetNoteManager().DeleteNote();
            if(currentNotePair.swipe != Swipe.None && !isSwiped)
            {
                ManagerProvider.Instance.GetPlayer().GetComponent<PlayerShoot>().CountCombo();
            } 
            isAlreadyInList = false;
            
        }
    }

    IEnumerator KillObject()
    {
        yield return new WaitForSeconds(killTime);
        Destroy(gameObject);
    }

    public void ChangeNote()
    {
        int randomInt = Random.Range(0,swipeNotes.Count);
        currentNotePair = swipeNotes[randomInt];

        GetComponent<Image>().sprite = currentNotePair.swipeSprite;
    }

    public void SetBasicNote()
    {
        currentNotePair = basicSwipe;
        GetComponent<Image>().sprite = currentNotePair.swipeSprite;
    }




}
