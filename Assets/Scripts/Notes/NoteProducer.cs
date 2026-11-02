using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteProducer : MonoBehaviour
{
    [SerializeField] GameObject notePrefab;
    [SerializeField] GameObject parentObject;
    [SerializeField] float producePeriod;

    public bool isRandomSprite = false;
    public bool canPlay = false;

    public bool isProducing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartProduce");
        StartCoroutine("MusicPlay");
    }

    IEnumerator StartProduce()
    {
        while (isProducing)
        {
            GameObject gameObject = Instantiate<GameObject>(notePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            gameObject.transform.SetParent(parentObject.GetComponent<RectTransform>().transform);

            gameObject.GetComponent<RectTransform>().anchoredPosition.Set(0, 0);
            gameObject.GetComponent<RectTransform>().anchorMin.Set(0, 1);
            gameObject.GetComponent<RectTransform>().anchorMax.Set(0, 1);
            gameObject.GetComponent<RectTransform>().pivot.Set(0, 0);

            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            ManagerProvider.Instance.GetNoteManager().AddAllNotes(gameObject);
            if (isRandomSprite)
            {
                gameObject.GetComponent<Note>().ChangeNote();
            }
            else
            {
                gameObject.GetComponent<Note>().SetBasicNote();
            }
            yield return new WaitForSeconds(producePeriod);
        }

    }

    public IEnumerator MusicPlay()
    {
        yield return new WaitForSeconds(1.5f);
        AudioManager.instance.Play("LoopTrack");

        yield return null;
    }
}
