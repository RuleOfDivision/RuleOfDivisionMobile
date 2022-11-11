using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorTutorial : MonoBehaviour
{
    
    public bool[] bools;
    public GameObject WIN;
    private int index;
    private AudioSource correct;
    
    // Start is called before the first frame update
    void Start()
    {
        correct = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool allTrue = true;
        for(int i = 0; i < 10; ++i )
        {
            if(bools[i] == false)
            {
                allTrue = false;
            }
        }

        if(allTrue)
        {
            WIN.SetActive(true);
        }

        for ( int i = 0; i < 10; ++i )
        {
            if ( Input.GetKeyDown( "" + i ) )
            {
                index = i;
                if(index == 1)
                {
                    break;
                }

                bools[index] = true;
                correct.Play();
                break;
            }
        }
    }
}
