using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject explosion;
    GameObject exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, 0.5f);
        Destroy(this.gameObject, 3f);
    }
    void OnTriggerEnter(Collider c)
    {
        exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(exp, 5f);
       
    }
}
