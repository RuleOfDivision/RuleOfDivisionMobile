using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public GameObject parent;
    public LayerMask whatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(parent.GetComponent<enemyMove>().attacking == false)
            {
                parent.GetComponent<enemyMove>().attacking = true;
                StartCoroutine(parent.GetComponent<enemyMove>().attackPlayer());
            }
        }
        
    }
/*
    private void Update()
    {
        Collider[] colList = Physics.OverlapBox(transform.position, transform.localScale/10, Quaternion.identity, whatIsPlayer);
        
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < colList.Length)
        {
            if(colList[i].tag == "ball")
            {
                Debug.Log("YES");
                AI.GetComponent<tennisAI>().ShootBack(colList[i]);
            }
            i++;
        }
        
    }
    */
}
