using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteContainer : Singleton<NoteContainer>
{
    private AudioClip[] clips;
    private List<KeyValuePair<int, string>> notePos = new List<KeyValuePair<int, string>>();
    // Start is called before the first frame update
    void Awake()
    {
        clips = Resources.LoadAll<AudioClip>("Notes/");
        InitializeNotePos();
    }

    void InitializeNotePos()
    {
        notePos.Add(new KeyValuePair<int, string>(-4, "2C"));
        notePos.Add(new KeyValuePair<int, string>(-3, "2D"));
        notePos.Add(new KeyValuePair<int, string>(-2, "2E"));
        notePos.Add(new KeyValuePair<int, string>(-1, "2F"));
        notePos.Add(new KeyValuePair<int, string>(0, "2G"));
        notePos.Add(new KeyValuePair<int, string>(1, "2A"));
        notePos.Add(new KeyValuePair<int, string>(2, "2B"));
        notePos.Add(new KeyValuePair<int, string>(3, "3C"));
        notePos.Add(new KeyValuePair<int, string>(4, "3D"));
        notePos.Add(new KeyValuePair<int, string>(5, "3E"));
        notePos.Add(new KeyValuePair<int, string>(6, "3F"));
        notePos.Add(new KeyValuePair<int, string>(7, "3G"));
        notePos.Add(new KeyValuePair<int, string>(8, "3A"));
        notePos.Add(new KeyValuePair<int, string>(9, "3B"));
        notePos.Add(new KeyValuePair<int, string>(10, "4C"));
        notePos.Add(new KeyValuePair<int, string>(17, "4C"));
        notePos.Add(new KeyValuePair<int, string>(18, "4D"));
        notePos.Add(new KeyValuePair<int, string>(19, "4E"));
        notePos.Add(new KeyValuePair<int, string>(20, "4F"));
        notePos.Add(new KeyValuePair<int, string>(21, "4G"));
        notePos.Add(new KeyValuePair<int, string>(22, "4A"));
        notePos.Add(new KeyValuePair<int, string>(23, "4B"));
        notePos.Add(new KeyValuePair<int, string>(24, "5C"));
    }

    public int GetNotePos(string name)
    {
        foreach (KeyValuePair<int,string> note in notePos)
        {
            if (name == note.Value) return note.Key;
        }

        return 99;
    }

    public string GetNoteName(int pos)
    {
        foreach(KeyValuePair<int,string> note in notePos)
        {
            if (pos == note.Key) return note.Value;
        }

        return "ERROR";
    }

    public AudioClip GetClip (string name, bool sharp)
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
        Debug.Log("error finding clip \"" + name + "\"");
        return clips[0];
    }

}
