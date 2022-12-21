using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class loadNext : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    public GameObject m_Text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator loadLevel()
    {
        string targetLevel = PlayerPrefs.GetString("nextLevel");
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(targetLevel);

        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            percentageText.text = progress * 100f + "%";
            //Debug.Log(progress);

            if (operation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.SetActive(true);
                //Wait to you press the space key to activate the Scene
                //if (Input.anyKey)
                    //Activate the Scene
                    //operation.allowSceneActivation = true;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
