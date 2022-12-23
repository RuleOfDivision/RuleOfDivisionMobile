using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut5 : MonoBehaviour
{
    public GameObject mainchar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("haha, divider is now 4");
        mainchar.GetComponent<playermove>().divider = 4;
    }
}
