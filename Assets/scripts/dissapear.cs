using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*disappear
public class dissapear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == 209.4f)
        {
            Destroy(gameObject);
        }
    }
}
