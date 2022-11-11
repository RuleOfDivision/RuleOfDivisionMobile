using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiCursor : MonoBehaviour
{
    public float curSword;
    public Sprite[] sprites;
    
    
    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 newpos = new Vector3(0,-26,0);

        switch(curSword)
        {
            
            case 2:
                newpos.x = -297.2f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 3:
                newpos.x = -264.7f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 4:
                newpos.x = -232.3f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 5:
                newpos.x = -200f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 6:
                newpos.x = -167.1f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 7:
                newpos.x = -135.1f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 8:
                newpos.x = -102.7f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 9:
                newpos.x = -71.1f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
            case 10:
                newpos.x = -38.1f;
                GetComponent<RectTransform>().anchoredPosition = newpos;
                break;
        }
        */
        if(curSword < 2)
        {
            curSword = 2;
        }
        GetComponent<Image>().sprite = sprites[(int)curSword];
    }
}
