using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moveTutorial : MonoBehaviour
{
    public Transform target;
    public LayerMask whatIsPlayer;
    public Vector3[] positions;
    private int posIndex;
    public GameObject winScreen;
    public TextMeshProUGUI howManyLeft;
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
        Collider[] colList = Physics.OverlapBox(target.position, target.localScale / 2f, Quaternion.identity, whatIsPlayer);
        
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < colList.Length)
        {
            if(colList[i].tag == "Player")
            {
                Debug.Log("YES");
                posIndex += 1;
                correct.Play();
                break;
            }
            i++;
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
        
        

    }
}
