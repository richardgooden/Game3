using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    int particules = 400;
    float distance, top = -200, bottom = 200;
    public GameObject starfield, player;
    GameObject dust;
    // Start is called before the first frame update
    void Start()
    {
        while (particules > 0)
        {
            starfield = GameObject.Find("field");
            dust = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/dust"), new Vector3(Random.Range(top, bottom), Random.Range(top, bottom), Random.Range(top, bottom)), Quaternion.identity);
            dust.transform.parent = starfield.transform;
            particules--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(starfield.transform.position, player.transform.position);//starfield follow ship
        if (distance > 150)
        {
            starfield.transform.position = player.transform.position;
        }
    }
}
