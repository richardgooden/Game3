using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class build : MonoBehaviour
{
    //Grid of cubes
    List<GameObject> grid = new List<GameObject>();
    //building objects
    public GameObject invis, wall, door, floor;
    //grid origin x and y
    public float x, y;
    //ship objects
    //List<GameObject> ship = new List<GameObject>();
    GameObject selection;
    public Dropdown dropdown;
    string name;
    List<string> sections = new List<string>() { "invis", "wall", "door", "cockpit", "medbay", "life", "cargo", "turret", "missile", "bedroom", "bathroom", "engine", "dinning", "reactor", "sensor" };
    // Start is called before the first frame update
    void Start()
    {
        dropdown.AddOptions(sections);
        selection = invis;

        //spawn a invisible cube at each position in the grid
        for(int i = 0; i < 48; i++)
        {
            for (int j = 0; j <27; j++) 
            {
               grid.Add( (GameObject) Instantiate(invis, new Vector3( x + (float)(0.5 * i), 0f, y + (float)(0.5 * j)), Quaternion.identity));
                grid[grid.Count -1].gameObject.name = i.ToString() + ',' + j.ToString();
                grid[grid.Count - 1].transform.parent = GameObject.Find("builder").transform;
                    
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit rayhit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayhit, Mathf.Infinity))
            {
                
                for (int i = 0; i < 48; i++)
                {
                    for (int j = 0; j < 27; j++)
                    {
                        foreach (var y in grid)
                        {
                            if (y == rayhit.collider.gameObject.transform.parent.transform.gameObject)
                            {
                                GameObject x = grid[i, j];
                            
                                Debug.Log(selection.name);
                                grid[i, j] = (GameObject)Instantiate(selection, x.transform);
                                //Destroy(x);
                                break;
                             }
                        }
                        

                    }

                }
               
            }

        }
        //highlight cube on mouse over
        

        //select component from drop down
        //invis, wall, door, cockpit, medbay, life, cargo, turret, missile, bedroom, bathroom, engine, dinning, reactor, sensor

        //click on grid to replace with selected component  

        // when save ship is clicked destroy invisible cubes and add remain cubs to a list called ship
        
        // 
    }

    public void dropdown_changed(int index)
    {
        Debug.Log(index);
        switch (index)
        {
           
            case 0:
                selection = invis;
                name = sections[index];
                break;
            case 1:
                selection = wall;
                name = sections[index];
                break;
            case 2:
                selection = door;
                name = sections[index];
                break;
            default:
                selection = floor;
                name = sections[index];
                break;
            
            

        }
        
    }
}
