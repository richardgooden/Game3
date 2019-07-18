using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    GameObject spawn,cargobay,cockpit;
    // Start is called before the first frame update
    void Start()
    {
        spawn = this.transform.GetChild(0).gameObject;
        cargobay = Instantiate((GameObject)Resources.Load("Prefabs/cargobay"));
        cargobay.transform.parent = this.transform;
        cockpit = Instantiate((GameObject)Resources.Load("Prefabs/cockpit"));
        cockpit.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate((GameObject)Resources.Load("Prefabs/missile"), spawn.transform.position, spawn.transform.rotation);
            
        }
    }
}
