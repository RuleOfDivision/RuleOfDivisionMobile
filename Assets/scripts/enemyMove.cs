using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public int whichEnemNum;
    public Transform playerLocation;
    public bool attacking;
    public LayerMask whatIsPlayer;
    public Transform bounds;
    public GameObject Canvas;
    public GameObject deadprefab;
    private AudioSource enemSound;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        enemSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Vector3.Distance(playerLocation.position, transform.position) < 4.5f && attacking == false)
        {
            
            StartCoroutine(attackPlayer());
        }
        if(attacking == false)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = playerLocation.position;
            /*for (int i = 0; i < 4; i++)
            {
            if(distanceToColleague[i].x < minDistance.x || distanceToColleague[i].y < minDistance.y ||distanceToColleague[i].z < minDistance.z)
            {
                //increase distance!
                colleaguesAI[i] = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
                colleaguesAI[i].destination = playerLocation.position + minDistance;
            }
            }*/
        }
        //!todo make them not move the player
    
        //Debug.Log(Vector3.Distance(playerLocation.position, transform.position));

        if(transform.position.y < -4.416664f)
        {
            Vector3 temppos = new Vector3(transform.position.x,0f,transform.position.z);
            temppos.y = -4.416664f;
            transform.position = temppos;
        }
        //distance to colleague
 


    }

    public IEnumerator attackPlayer()
    {
        Debug.Log("STARTED");
        if(attacking == true)
        {
            yield break;
        }
        attacking = true;
        
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Animator>().SetBool("attacking", true);
        
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("attacking", false);
        yield return new WaitForSeconds(1.1f);
        Collider[] colList = Physics.OverlapBox(transform.position, bounds.localScale * 1.5f, Quaternion.identity, whatIsPlayer);
        
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < colList.Length)
        {
            if(colList[i].tag == "Player")
            {
                Debug.Log("YES");
                enemSound.Play();
                Canvas.GetComponent<UI>().DecreaseHearts();
                //colList[i].GetComponent<>()
                break;
            }
            i++;
        }
        
    
        //Debug.Log("hit");
        attacking = false;
        
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
    }

    /*
    We're no strangers to love
    You know the rules and so do I
    A full commitment's what I'm thinking of
    You wouldn't get this from any other guy
    I just wanna tell you how I'm feeling
    Gotta make you understand

    Never gonna give you up
    Never gonna let you down
    Never gonna run around and desert you
    Never gonna make you cry
    Never gonna say goodbye
    Never gonna tell a lie and hurt you
    */
}
