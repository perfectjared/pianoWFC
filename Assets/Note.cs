using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public string note;
    public bool sharp;
    // Start is called before the first frame update
    void Start()
    {
        FindNote();
    }

    public void FindNote()
    {
        QuantizeY();
        float notePos = (this.transform.localPosition.y - (float)GetComponentInParent<Staff>().botLineY);
        if (notePos != 0) notePos /= (float)GetComponentInParent<Staff>().noteSpace;
        Debug.Log(this.transform.localPosition.y + ", " + notePos);
        switch ((int)notePos)
        {
            case -4:
                note = "C2";
                break;
            case -3:
                note = "D2";
                break;
            case -2:
                note = "E2";
                break;
            case -1:
                note = "F2";
                break;
            case 0:
                note = "G2";
                break;
            case 1:
                note = "A2";
                break;
            case 2:
                note = "B2";
                break;
            case 3:
                note = "C3";
                break;
            case 4:
                note = "D3";
                break;
            case 5:
                note = "E3";
                break;
            case 6:
                note = "F3";
                break;
            case 7:
                note = "G3";
                break;
            case 8:
                note = "A3";
                break;
            case 9:
                note = "B3";
                break;
            case 10:
                note = "C4";
                break;
            case 11:
                note = "D4";
                break;
            case 12:
                note = "E4";
                break;
            case 13:
                note = "F4";
                break;
            case 14:
                note = "G4";
                break;
            case 15:
                note = "A4";
                break;
            case 16:
                note = "B4";
                break;
            case 17:
                note = "C5";
                break;
            default:
                note = "ERROR";
                break;
        }
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
    }
}
