using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByTouch : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("debug");
        for(int i = 0; i < Input.touchCount; i++){
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position); 
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
            }
        /*
        if(Input.touchCount > 0){
        
            Touch touch = Input.GetTouch(0);
            
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;
        }
        */
    }
}
