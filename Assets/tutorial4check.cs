using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial4check : MonoBehaviour
{
    private float currentNum;
    public GameObject player;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<playermove>().divider > 9)
        {
            winScreen.SetActive(true);
        }
        else
            winScreen.SetActive(false);
        
    }
}
