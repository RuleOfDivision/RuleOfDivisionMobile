using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRound : MonoBehaviour
{
    public AudioSource music;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        music.Play();
        spawner.GetComponent<RoundManager>().enemiesleft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
