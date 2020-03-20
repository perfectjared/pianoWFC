using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public string note;
    public bool sharp;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        FindNote();
    }

    public void FindNote()
    {
        QuantizeY();
        float notePos = (this.transform.position.y - (float)GetComponentInParent<Staff>().botLineY);
        if (notePos != 0) notePos /= (float)GetComponentInParent<Staff>().noteSpace;
        //Debug.Log(this.transform.localPosition.y + ", " + notePos);
        /*switch ((int)notePos)
        {
            case -4:
                note = "2C";
                break;
            case -3:
                note = "2D";
                break;
            case -2:
                note = "2E";
                break;
            case -1:
                note = "2F";
                break;
            case 0:
                note = "2G";
                break;
            case 1:
                note = "2A";
                break;
            case 2:
                note = "2B";
                break;
            case 3:
                note = "3C";
                break;
            case 4:
                note = "3D";
                break;
            case 5:
                note = "3E";
                break;
            case 6:
                note = "3F";
                break;
            case 7:
                note = "3G";
                break;
            case 8:
                note = "3A";
                break;
            case 9:
                note = "3B";
                break;
            case 10:
            case 17:
                note = "4C";
                break;
            case 18:
                note = "4D";
                break;
            case 19:
                note = "4E";
                break;
            case 20:
                note = "4F";
                break;
            case 21:
                note = "4G";
                break;
            case 22:
                note = "4A";
                break;
            case 23:
                note = "4B";
                break;
            case 24:
                note = "5C";
                break;
            default:
                note = "ERROR";
                break;
        }*/
        note = NoteContainer.Instance.GetNoteName((int)notePos);
        sound = NoteContainer.Instance.GetClip(note, sharp);
    }

    void QuantizeY ()
    {
        float yPos = this.transform.localPosition.y;
        float noteSpace = (float)GetComponentInParent<Staff>().noteSpace;
        if (yPos % noteSpace != 0)
        {
            yPos = Mathf.Round(yPos / noteSpace) * noteSpace;
            this.transform.position.Set(this.transform.position.x, yPos, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindNote();
    }
}
