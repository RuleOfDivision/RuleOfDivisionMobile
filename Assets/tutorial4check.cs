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
    public void WinScreenDarnIt(){winScreen.SetActive(true);}
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<playermove>().divider > 9)
        {
            //Debug.Log(player.GetComponent<playermove>().divider + "is divider according to check");
            winScreen.SetActive(true);
        }        
    }
}
