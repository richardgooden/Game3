using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float rotationval, speed;
    //public GameObject playerobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotationval += Input.GetAxis("Horizontal");//rotate ship
        //playerobject.transform.rotation = Quaternion.Euler(0f, rotationval, 0f);

        //speed += Input.GetAxis("Vertical") * 0.01f;//move ship f b
        //playerobject.transform.Translate(0f, 0f, speed);

        //if (Input.GetKey(KeyCode.Q))//move ship l
        //{
        //    playerobject.transform.Translate(-1f, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.E))//move ship r
        //{
        //    playerobject.transform.Translate(1f, 0f, 0f);
        //}
    }
}
