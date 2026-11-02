using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField]List<GameObject> notes;
    [SerializeField] List<GameObject> allNotes;
    int noteCount;


    public void AddNote(GameObject note)
    {
        allNotes.Remove(note);
        notes.Add(note);
        noteCount += 1;

        if(noteCount == 2)
        {
            List<EnemyBase> enemies = ManagerProvider.Instance.GetEnemies();

            foreach (EnemyBase enemy in enemies)
            {
                enemy.StartAttackRoutine();
            }
            noteCount = 0;
        }
    }

    public void AddAllNotes(GameObject note)
    {
        allNotes.Add(note);
    }

    public void ChangeNotes()
    {
        foreach(GameObject note in allNotes)
        {
            note.GetComponent<Note>().ChangeNote();
        }
    }

    public void ChangeNoteToBasic()
    {
        foreach (GameObject note in allNotes)
        {
            note.GetComponent<Note>().SetBasicNote();
        }
    }

    public List<GameObject> GetNotes()
    {
        return notes;
    }

    public void DeleteNote()
    {
        if(notes.Count > 0)
        {
            notes.Remove(notes[0]);
        }
    }

}
