using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TUTORIAL3lOOK : MonoBehaviour
{
    public Transform target;
    public LayerMask whatIsPlayer;
    public Vector3[] positions;
    public int posIndex;
    public GameObject winScreen;
    public TextMeshProUGUI howManyLeft;
    Ray cameraRay;                // The ray that is cast from the camera to the mouse position
    RaycastHit cameraRayHit; 
    private int frames;
    public LayerMask layer;
    public bool mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        posIndex = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        //mouseOver = false;
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
            gameObject.SetActive(false);
        }

        if(posIndex < 6)
        {
            howManyLeft.text = posIndex.ToString() + "/" + "5";
        }

        if(frames % 3 == 0) //If the remainder of the current frame divided by 10 is 0 run the function.
        {
            mouseOver = false; 
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            // If the ray strikes an object...
            if (Physics.Raycast(cameraRay, out cameraRayHit, Mathf.Infinity, layer) && Time.timeScale != 0) 
            {
                // ...and if that object is the ground...
                if(cameraRayHit.transform.tag=="tutorialMouse")
                {
                    Debug.Log("YES");
                    mouseOver = true;
                    
                }
            }
        }
        
    }
}
