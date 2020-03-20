using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLine : MonoBehaviour
{
    private float startX = -2.66f;
    private float endX = 16f;
    public float moveRate = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        float totalDist = endX - startX;
        float totalTime = ((float)Metronome.Instance.bpm / 60) / 60;
        float startY = this.transform.position.y;

        for (float t = 0f; t <= 1f; t += 0.02f)
        {
            this.transform.position.Set(startY, Mathf.Lerp(startX, endX, t), 0);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForEndOfFrame();
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
