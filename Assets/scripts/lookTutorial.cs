using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lookTutorial : MonoBehaviour
{

    public Transform target;
    public LayerMask whatIsPlayer;
    public Vector3[] positions;
    private int posIndex;
    public GameObject winScreen;
    public TextMeshProUGUI howManyLeft;
    Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    RaycastHit cameraRayHit; 
    private int frames;
    public LayerMask layer;
    private AudioSource correct;

    // Start is called before the first frame update
    void Start()
    {
        posIndex = 0;   
        correct = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if(frames > 59)
        {
            frames = 0;
        }
        
        if(posIndex < 5)
        {
            transform.position = positions[posIndex];
        }
        else
        {
            winScreen.SetActive(true);
        }

        if(posIndex < 6)
        {
            howManyLeft.text = posIndex.ToString() + "/" + "5";
        }

        if(frames % 5 == 0) //If the remainder of the current frame divided by 10 is 0 run the function.
        { 
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            // If the ray strikes an object...
            if (Physics.Raycast(cameraRay, out cameraRayHit, Mathf.Infinity, layer) && Time.timeScale != 0) 
            {
                // ...and if that object is the ground...
                if(cameraRayHit.transform.tag=="tutorialMouse")
                {
                    Debug.Log("YES");
                    posIndex += 1;
                    correct.Play();
                    
                }
            }
        }
        
    }
}
