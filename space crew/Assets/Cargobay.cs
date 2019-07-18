using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargobay : MonoBehaviour
{
    public float fuel =  100, ammo = 100, missile = 50 ;
    GameObject pickup, drop;
    public GameObject pickupprefab;
    
    // Start is called before the first frame update
    void Start()
    {
        drop = transform.parent.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnTriggerEnter(Collider c)
    {
        
        if(c.gameObject.name == "fuel")
        {
            fuel += 5f;
            Destroy(c.transform.parent.gameObject);
        }

        if (c.name == "missile")
        {
            fuel -= 5f;
            pickup = Instantiate((GameObject)Resources.Load("Prefabs/pickup"), drop.transform.position, drop.transform.rotation);
            pickup.transform.GetChild(0).gameObject.name = "fuel";
        }
    }
}
