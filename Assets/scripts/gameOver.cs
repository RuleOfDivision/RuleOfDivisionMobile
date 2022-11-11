using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
    private bool ready;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        ready = false;
        StartCoroutine(cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.anyKey && ready == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    IEnumerator cooldown()
    {
        yield return new WaitForSecondsRealtime(1f);
        ready = true;
    }
}
