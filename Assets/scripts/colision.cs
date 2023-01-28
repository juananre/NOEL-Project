using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    Vector3 orginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        orginalPosition = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.tag == "piso")
        {
            gameObject.transform.position = orginalPosition;
        }
    }
}
