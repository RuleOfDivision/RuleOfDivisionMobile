using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial3Manager : MonoBehaviour
{
    public GameObject move;
    public GameObject look;
    public GameObject win;
    private AudioSource correct;

    void Start()
    {
        correct = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(move.activeInHierarchy == false  /*&& look.activeInHierarchy == false*/)
        {
            win.SetActive(true);
        }

        if(move.GetComponent<TUTORIAL3MOVE>().moveOver && look.GetComponent<TUTORIAL3lOOK>().mouseOver)
        {
            move.GetComponent<TUTORIAL3MOVE>().posIndex += 1;
            look.GetComponent<TUTORIAL3lOOK>().posIndex += 1;
            correct.Play();
        }
    }
}
