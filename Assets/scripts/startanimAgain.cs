using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startanimAgain : MonoBehaviour
{
    
    // Start is called before the first frame update
    
    void OnEnable()
    {
        GetComponent<Animator>().Play("countdown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
