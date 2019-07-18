using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockpit : MonoBehaviour
{
    Cargobay cargo; 
    GameObject player;
   public float turnspeed = 3f, hp = 100f, maxspeed = 2f, speed;
    float tempspeed, nextfire, rate = 5f, origiturnspeed;
    bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        cargo =  FindObjectOfType<Cargobay>();
        origiturnspeed = turnspeed;
        player = transform.parent.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (crew.Count > 0 && ship.getat("fuel") > 0)
        if (cargo.fuel > 0)
        {

            //---------------------------------------------------------------------------------
            //turn
            player.transform.Rotate(0f, Input.GetAxis("Horizontal") * turnspeed, 0f);
            //fowrads and back
            tempspeed += Input.GetAxis("Vertical") / 10;

            if (Mathf.Abs(tempspeed) < maxspeed)
            {
                speed = tempspeed;

            }



            player.transform.Translate(0f, 0f, speed);
            if (Input.GetKey(KeyCode.Q))//move ship l
            {
                player.transform.Translate(-1f, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.E))//move ship r
            {
                player.transform.Translate(1f, 0f, 0f);
            }


            //fuel
            if (speed != 0 && nextfire > Time.time)
            {
                nextfire = Time.time + rate;
                cargo.fuel -= (float) 0.1 * speed;
            }

        }
        if (damaged && hp == 100)
        {
            turnspeed = origiturnspeed;
            damaged = false;
        }
    }
    void OnTriggerEnter(Collider c)
    {

        if (c.name == "bullet")
        {
            hp -= 1;
        }
        else if (c.name == "missile")
        {
            hp -= 10;
        }

        hp -= 10;

        turnspeed = origiturnspeed * hp / 100;//turnspeed
            damaged = true;
        //Debug.Log(c.name);
    }
}
