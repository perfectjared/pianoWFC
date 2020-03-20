﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputLine : Singleton<OutputLine>
{
    List<GameObject> noteList = new List<GameObject>();
    GameObject staff;

    private void Start()
    {
        staff = GameObject.Find("Output Staff");
    }

    public void Go()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (Transform child in staff.transform)
        {
            if (child.GetComponent<Note>() != null) noteList.Add(child.gameObject);
            Debug.Log("test " + noteList.Count);
        }

        while (true)
        {
            transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}