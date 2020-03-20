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
        if (GetComponentInParent<Staff>() == null && GetComponentInParent<TilePainter>() == null)
        {
            transform.parent = GameObject.Find("Output Staff").transform;
            staff = GetComponentInParent<Staff>();
            transform.localScale = new Vector3((float)staff.noteScale, (float)staff.noteScale, 1f);
            QuantizeY();
        }
        if (staff == null) staff = GetComponentInParent<Staff>();
        float notePos = (this.transform.position.y - (float)staff.botLineY);
        if (notePos != 0) notePos /= (float)staff.noteSpace;
        note = NoteContainer.Instance.GetNoteName((int)Mathf.Round(notePos));
        //Debug.Log(this.transform.localPosition.y + ", " + notePos + ", " + note);
        sound = NoteContainer.Instance.GetClip(note, sharp);
    }

    void QuantizeY ()
    {
        float yPos = this.transform.localPosition.y;
        float noteSpace = (float)staff.noteSpace;
        if (yPos % noteSpace != 0)
        {
            //Debug.Log(yPos);
            yPos = Mathf.Round(yPos / noteSpace) * noteSpace;
            //Debug.Log(yPos);
            transform.localPosition.Set(this.transform.localPosition.x, yPos, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindNote();
    }
}
