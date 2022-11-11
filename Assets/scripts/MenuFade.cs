using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFade : MonoBehaviour
{   
    public GameObject menu;
    public bool onStartMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == new Vector3(-8.8f, 1f, 0f) && onStartMenu == true)
        {
            menu.SetActive(true);
            onStartMenu = false;
        }
    }
}
