using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLevel : MonoBehaviour
{
    private bool ready;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        ready = false;
        StartCoroutine(startDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && ready == true)
        {

            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    IEnumerator startDelay()
    {

        yield return new WaitForSecondsRealtime(1f);
        ready = true;
    }
}
