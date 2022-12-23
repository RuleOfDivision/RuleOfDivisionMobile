
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playermove : MonoBehaviour
{
      private bool attacking;
      public bool enemyIsKill; //!reference roundMgr
      private int TexIndex;
      public float divider;
      public float chambersRadius = 5000f; //traffy reference??
      public float dist;
      private Vector3 targetPos;
      [SerializeField] private float speed;
      List<GameObject> gameObjects = new List<GameObject>();
      public GameObject attackButton;
      public GameObject plusButton;
      public GameObject minusButton;
      public TextMeshProUGUI currentNumUI;
      List<Transform> transforms = new List<Transform>();
      public Transform attackBox;
      public Transform playerPos;
      public Transform tMin;
      Ray cameraRay;                // The ray that is cast from the camera to the mouse position
      RaycastHit cameraRayHit;    // The object that the ray hits
      //for touch
      public Joystick joystick;    //for touch, don't touch
      public LayerMask whatIsEnemy;
      private Animator playerAnimator;
      public Animator swordAnimator;
      private CharacterController contr;
      private AudioSource sound;
      public AudioClip[] soundClips;

      public Material playerMat;
      public Texture[] albedos;

      /*outdated targeting system
      public Transform enem0;
      public Transform enem1;
      public Transform enem2;
      public Transform enem3;
      */

      void Awake() {
            divider = 2;     

      }
      void Start()
      {
            TexIndex = PlayerPrefs.GetInt("selSkin");
            playerMat.SetTexture("_MainTex", albedos[TexIndex]);
            attacking = false;
            playerAnimator = GetComponent<Animator>();
            contr = GetComponent<CharacterController>();
            sound = GetComponent<AudioSource>();

      }
      Transform GetClosestEnemy(List<Transform> transforms)
      {
            tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = playerPos.position;
            foreach (Transform t in transforms)
            {
                  dist = Vector3.Distance(t.position, currentPos);
                  if (dist < minDist)
                  {
                        tMin = t;
                        minDist = dist;
                  }
            }
            return tMin;
      }
      /*public Transform ReturntMin(){

            Collider[] targetColList = Physics.OverlapSphere(playerPos.position, chambersRadius, whatIsEnemy);
            if(enemyIsKill){
                  for (int i = 0; i < targetColList.Length; i++)
                  {
                        transforms.Remove(targetColList[i].GetComponent<Transform>());
                        tMin = GetClosestEnemy(transforms);
                  }
                  enemyIsKill = false;
                  return tMin;
            }
            else
            {
                  for (int i = 0; i < targetColList.Length; i++)
                  {
                  transforms.Add(targetColList[i].GetComponent<Transform>());
                  tMin = GetClosestEnemy(transforms);
                  }
                  Debug.Log("i was at house eating dorito when phone ring.");
                  return null;
            }
      }*/
      public Transform ReturntMin()
      {
            Collider[] targetColList = Physics.OverlapSphere(playerPos.position, chambersRadius, whatIsEnemy);
            for (int i = 0; i < targetColList.Length; i++)
            {
                  transforms.Add(targetColList[i].GetComponent<Transform>());
            }
            tMin = GetClosestEnemy(transforms);
            return tMin;
      }

      void Update()
      {
            currentNumUI.SetText("Nämnare: " + divider);
            //moving
            float x = joystick.Horizontal;
            float z = joystick.Vertical;

            Vector3 Movement = new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);

            //transform.position = transform.position + Movement;
            Movement.y += -9.81f * Time.deltaTime;
            contr.Move(Movement);

            float moving = z + x;
            playerAnimator.SetFloat("moving", Mathf.Abs(moving));
            swordAnimator.SetBool("swing", attacking);
            if(enemyIsKill)
            {
                  transforms.Clear();
                  enemyIsKill = false;
                  ReturntMin();
            }
            else
            {
                  ReturntMin();
                  playerPos.LookAt(tMin);
            }
//            Debug.Log(SceneManager.GetActiveScene().name);
            if(Application.platform == RuntimePlatform.Android) {
                  Debug.Log("it's android");
                  if(SceneManager.GetActiveScene().name != "mainmenu" && Input.GetKeyDown(KeyCode.Escape)){
                        Debug.Log("yep, i should change scene");
                        SceneManager.LoadScene("mainmenu");
                  }
                  else if(SceneManager.GetActiveScene().name == "mainmenu" && Input.GetKeyDown(KeyCode.Escape))
                  {
                        Application.Quit();
                  } 
                             
            }
//            Debug.Log("current ui" + currentNumUI.text + "actual correct num: " + divider);
            //transform.right = GetClosestEnemy(transforms).position;

      }
      public void Attack()
      {            
            if (attacking == false)
            {
                  StartCoroutine(DivideBy(divider));
            }
      }
      public void IncreaseDiv()
      {
            divider++;
            Debug.Log("increase div to: " + divider);

            if (divider >= 10)
            {
                  divider = 10;
            }
            if (divider <= 2)
            {
                  divider = 2;
            }

      }
      public void decreaseDiv()
      {
            divider--;
            Debug.Log("Decrease div to: " + divider);

            if (divider >= 10)
            {
                  divider = 10;
            }
            if (divider <= 1)
            {
                  divider = 2f;
            }
      }


      private IEnumerator DivideBy(float dmg)
      {
            sound.clip = soundClips[0];
            sound.Play();
            attacking = true;
            //yield return new WaitForSeconds(0.33f);

            Collider[] colList = Physics.OverlapBox(attackBox.position, attackBox.localScale / 1, Quaternion.identity, whatIsEnemy);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < colList.Length)
            {
                  if (colList[i].tag == "enemy")
                  {
                        Debug.Log("hit enemy");
                        sound.clip = soundClips[1];
                        sound.Play();
                        if (SceneManager.GetActiveScene().name == "tutorial5" || SceneManager.GetActiveScene().name == "tutorial6")
                        {
                              colList[i].gameObject.GetComponent<TutorialHealth>().takeDamage(divider);
                        }
                        /*
                        else if(SceneManager.GetActiveScene().name == "tutorial6")
                        {
                              get fukt
                        }*/
                        else
                        {
                              colList[i].gameObject.GetComponent<enemyHealth>().takeDamage(divider);
                        }

                        //colList[i].GetComponent<>()
                        break;
                  }
                  i++;
            }

            yield return new WaitForSeconds(0.75f);
            Debug.Log("attacked");
            attacking = false;
      }
}
