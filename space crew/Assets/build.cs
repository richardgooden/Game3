using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    //Grid of cubes
    GameObject[,] grid = new GameObject[48,27];
    //building objects
    public GameObject invis, wall, door, cockpit, medbay, life, cargo, turret, missile, bedroom, bathroom, engine, dinning, reactor, sensor;
    //grid origin x and y
    public float x, y;
    //ship objects
    //List<GameObject> ship = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        

        //spawn a invisible cube at each position in the grid
        for(int i = 0; i < 48; i++)
        {
            for (int j = 0; j <27; j++) 
            {
               grid[i,j] = (GameObject) Instantiate(invis, new Vector3( x + (float)(0.5 * i), 0f, y + (float)(0.5 * j)), Quaternion.identity);
                grid[i, j].gameObject.name = i.ToString() + "," + j.ToString();  
                    
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //highlight cube on mouse over


        //select component from drop down
        //invis, wall, door, cockpit, medbay, life, cargo, turret, missile, bedroom, bathroom, engine, dinning, reactor, sensor

        //click on grid to replace with selected component  

        // when save ship is clicked destroy invisible cubes and add remain cubs to a list called ship
        
        // 
    }
}
