using UnityEngine;
using System.Collections;

public class Metronome : Singleton<Metronome>
{
    [Range (1.0F, 300.0F)]
    public double bpm = 140.0F;

    double nextTick = 0.0F; // The next tick in dspTime
    //double sampleRate = 0.0F;
    bool ticked = false;

    AudioSource aS;

    void Start()
    {
        double startTick = AudioSettings.dspTime;
        //sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (60.0 / bpm);

        aS = GetComponent<AudioSource>();
        aS.Play();
    }

    void LateUpdate()
    {
        if (!ticked && nextTick >= AudioSettings.dspTime)
        {
            ticked = true;
            BroadcastMessage("OnTick");
        }
    }

    // Just an example OnTick here
    void OnTick()
    {
        Debug.Log("Tick");
        //GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while (dspTime >= nextTick)
        {
            aS.PlayScheduled(nextTick);

            ticked = false;
            nextTick += timePerTick;
        }

    }
}