using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialPart2 : MonoBehaviour
{
    private bool ready;
    public GameObject phoneUI;
    public GameObject part2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        ready = false;
        phoneUI.SetActive(false);

        StartCoroutine(startDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && ready == true)
        {
            part2.SetActive(true);
            gameObject.SetActive(false);

            
        }
    }

    IEnumerator startDelay()
    {
        
        yield return new WaitForSecondsRealtime(1f);
        ready = true;
    }
}
