using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public string note;
    public bool sharp;
    public AudioClip sound;
    Staff staff;
    // Start is called before the first frame update
    void Start()
    {
        //staff = GetComponentInParent<Staff>();
        //transform.localScale.Set((float)staff.noteScale, (float)staff.noteScale, 1f);
        FindNote();
    }

    public void FindNote()
    {
        //QuantizeY();
        float notePos = (this.transform.position.y - (float)GetComponentInParent<Staff>().botLineY);
        if (notePos != 0) notePos /= (float)GetComponentInParent<Staff>().noteSpace;
        note = NoteContainer.Instance.GetNoteName((int)Mathf.Round(notePos));
        //Debug.Log(this.transform.localPosition.y + ", " + notePos + ", " + note);
        sound = NoteContainer.Instance.GetClip(note, sharp);
    }

    void QuantizeY ()
    {
        float yPos = this.transform.localPosition.y;
        float noteSpace = (float)GetComponentInParent<Staff>().noteSpace;
        if (yPos % noteSpace != 0)
        {
            Debug.Log(yPos);
            yPos = Mathf.Round(yPos / noteSpace) * noteSpace;
            Debug.Log(yPos);
            transform.localPosition.Set(this.transform.localPosition.x, yPos, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //FindNote();
    }
}
