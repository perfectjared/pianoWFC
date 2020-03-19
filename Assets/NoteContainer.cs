using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer : Singleton<NoteContainer>
{
    private AudioClip[] clips;

    // Start is called before the first frame update
    void Awake()
    {
        clips = Resources.LoadAll<AudioClip>("Notes/");
    }

    public AudioClip getClip (string name, bool sharp)
    {
        if (sharp) name += "s";
        foreach (AudioClip c in clips)
        {
            if (name == c.name) return c;
        }
        if (sharp) name = name.Substring(0, 2);
        foreach (AudioClip c in clips)
        {
            if (name == c.name)
            {
                Debug.Log("false sharp");
                return c;
            }
        }
        Debug.Log("error finding clip");
        return clips[0];
    }

}
