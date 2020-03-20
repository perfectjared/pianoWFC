using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLine : Singleton<InputLine>
{
    private float startX = -2.66f;
    private float endX = 16f;
    public float moveRate = 0.02f;
    public GameObject notePrefab;
    private Staff staff;
    private bool go = false;
    // Start is called before the first frame update
    void Start()
    {
        staff = GetComponentInParent<Staff>();
    }

    IEnumerator Go()
    {
        if (go) StopCoroutine(Go());
        go = true;
        float totalTime = (60f / ((float)Metronome.Instance.bpm)) * 4;
        float startY = this.transform.localPosition.y;

        for (float t = 0f; t <= totalTime; t += 0.02f)
        {
            transform.localPosition = new Vector3(Mathf.Lerp(startX, endX, t / totalTime), startY, 0);
            //Debug.Log(t / totalTime + " " + transform.localPosition.x);
            yield return new WaitForSeconds(0.02f);
        }

        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        //Destroy(this);
        yield return new WaitForEndOfFrame();
    }

    public void PlaceNote(string note)
    {
        if (!go) StartCoroutine(Go());
        Debug.Log("placing " + note);
        float y = (float)staff.botLineY + (float)(staff.noteSpace * NoteContainer.Instance.GetNotePos(note));
        GameObject placed = Instantiate(notePrefab, new Vector3(transform.position.x, y, 0), new Quaternion(0, 0, 0, 0), transform.parent) as GameObject;
        placed.transform.localScale = new Vector3((float)staff.noteScale, (float)staff.noteScale, 1f);
    }

    public float GetX()
    {
        return this.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
