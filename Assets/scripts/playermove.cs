
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playermove : MonoBehaviour
{
      [SerializeField] private float speed;
      public GameObject attackButton;
      public GameObject plusButton;
      public GameObject minusButton;
      Ray cameraRay;                // The ray that is cast from the camera to the mouse position
      RaycastHit cameraRayHit;    // The object that the ray hits
      public float divider;
      //for touch
      public Joystick joystick;    //for touch
      private bool attacking;
      public Transform attackBox;
      public LayerMask whatIsEnemy;
      private Animator playerAnimator;
      public Animator swordAnimator;
      private CharacterController contr;
      private AudioSource sound;

      public TextMeshProUGUI currentNumUI;

      public AudioClip[] soundClips;

      public Material playerMat;
      public Texture[] albedos;
      private int TexIndex;

      public Transform playerPos;
      private Vector3 targetPos;
      var gameObjects = new List<GameObject>();

      /*outdated targeting system
      public Transform enem0;
      public Transform enem1;
      public Transform enem2;
      public Transform enem3;
      //---------------------------------
      */

      void Start()
      {
            TexIndex = PlayerPrefs.GetInt("selSkin");
            playerMat.SetTexture("_MainTex", albedos[TexIndex]);
            attacking = false;
            playerAnimator = GetComponent<Animator>();
            contr = GetComponent<CharacterController>();
            sound = GetComponent<AudioSource>();

      }

      public void SayHello() //test
      {
            Debug.Log("Hello");
            return;
      }
      Transform GetClosestEnemy(Transform[] enemies)
      {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = playerPos.position;
            foreach (Transform t in enemies)
            {
                  float dist = Vector3.Distance(t.position, currentPos);
                  if (dist < minDist)
                  {
                        tMin = t;
                        minDist = dist;
                  }
            }
            return tMin;
      }
      void Update()
      {
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
            Debug.Log(divider);
            currentNumUI.text = "Nämnare: " + divider;
            //Vector3 lookTarget = GetClosestEnemy(enemies).position;
            //playerPos.LookAt(lookTarget);

            Collider[] colList = Physics.OverlapBox(attackBox.position, attackBox.localScale / 1, Quaternion.identity, whatIsEnemy);
            for (int i = 0; i < colList.Length; i++)
            {
                  gameObjects.Add(colList[i].GetComponent<GameObject>());

            }
            GetClosestEnemy(enemList);

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
