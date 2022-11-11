using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TUTORIAL3MOVE : MonoBehaviour
{
    public Transform target;
    public LayerMask whatIsPlayer;
    public Vector3[] positions;
    public int posIndex;
    public GameObject winScreen;
    public TextMeshProUGUI howManyLeft;
    public bool moveOver;
    // Start is called before the first frame update
    void Start()
    {
        posIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveOver = false;
        Collider[] colList = Physics.OverlapBox(target.position, target.localScale / 2f, Quaternion.identity, whatIsPlayer);
        
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < colList.Length)
        {
            if(colList[i].tag == "Player")
            {
                Debug.Log("YES");
                moveOver = true;
                break;
            }
            else
            {
                moveOver = false;
            }
            i++;
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
        
        

    }
}
