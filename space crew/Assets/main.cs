using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    //static float[] shipinventory = {100, 100, 50 };
    List<Ship> ships = new List<Ship>();
    public GameObject player, field, dust;
    float mousesense = 20f, top = -200, bottom = 200, distance;
    int particules = 400;
    string[] shipmodel = { "ship1", "ship2" };
    bool third = false;

    Ship spawnship(string n, int numb)
    {

        // create player ship
        ships.Add(new Ship(n));
        //spawn player ship 
        ships[ships.Count - 1].setshiphandle((GameObject)Instantiate(Resources.Load("Prefabs/" + shipmodel[numb])));
        return ships[ships.Count - 1];
    }
    // Start is called before the first frame update
    void Start()
    {
        GameMenu home = new GameMenu();
        home.menuinit();

        playership(spawnship("Outlaw Star", 0).getshiphandle());


        foreach (var shi in ships)
        {
            shi.Start();
            foreach (var sec in shi.getsections())
            {
                sec.Start();
            }
        }

        field = GameObject.Find("starfield");
    }
    void playership(GameObject x)
    {
        player = x;
    }
    // Update is called once per frame
    void Update()
    {
        camerarig();
        starfield();
        foreach (var shi in ships)
        {
            foreach (var sec in shi.getsections())
            {
                sec.Update();
            }
        }
    }
    void camerarig()
    {
        if (third)
        {
            //third person
            Camera.main.transform.parent.position = player.transform.position;
            // Camera.main.transform.parent.Rotate(0f, Input.GetAxis("Mouse X") * mousesense, 0f);
            Camera.main.transform.parent.rotation = player.transform.rotation;
        }
        else
        {
            //top down
            Camera.main.transform.position = player.transform.position + new Vector3(0f,50f,0f);
            Camera.main.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        }
        
        
        
    }

    void starfield()
    {
        while (particules > 0)
        {

            dust = (GameObject)Instantiate((GameObject)Resources.Load("Prefabs/dust"), new Vector3(Random.Range(top, bottom), Random.Range(top, bottom), Random.Range(top, bottom)), Quaternion.identity);
            dust.transform.parent = field.transform;
            particules--;
        }
        distance = Vector3.Distance(field.transform.position, player.transform.position);
        if (distance > 150)
        {
            field.transform.position = player.transform.position;
        }
    }
}
public class GameMenu{
    GameObject creditsmenu, mainmenu;
    
    public void menuinit()
    {
        Button play, load, options, credits, quit, backc;
        play = GameObject.Find("play").GetComponent<Button>();
        play.onClick.AddListener(newgame);
        load = GameObject.Find("load").GetComponent<Button>();
        load.onClick.AddListener(loadgame);
        options = GameObject.Find("options").GetComponent<Button>();
        options.onClick.AddListener(gameoptions);
        credits = GameObject.Find("credits").GetComponent<Button>();
        credits.onClick.AddListener(gamecredits);
        quit = GameObject.Find("quit").GetComponent<Button>();
        quit.onClick.AddListener(quitgame);
        backc = GameObject.Find("backc").GetComponent<Button>();
        backc.onClick.AddListener(creditmain);
        mainmenu = GameObject.Find("mainmenu");
        creditsmenu = GameObject.Find("creditsmenu");
        creditsmenu.SetActive(false);
    }
    void newgame()
    {
        mainmenu.SetActive(false);

    }
    void loadgame()
    {

    }
    void gameoptions()
    {

    }
    void gamecredits()
    {
        mainmenu.SetActive(false);
        creditsmenu.SetActive(true);
    }
    void quitgame()
    {
        Application.Quit();
    }
    void creditmain()
    {
        mainmenu.SetActive(true);
        creditsmenu.SetActive(false);
    }
    void hud()
    {

    }
}
public class Ship
{
    GameObject shiphandle;
    string name;
  
    float[] attribute = { 100,100,50 };
    string[] attributename = { "fuel", "ammo", "missile" };
    List<Section> sections = new List<Section>();
    
    public Ship(string nam)
    {
       
        name = nam;
        
    }
    public void Start()
    {
        string[] types = { "cockpit", "medbay", "sensor", "cargobay", "engine", "turret", "missile", "reactor", "lifesupport" };
        for(int i = 0; i < types.Length; i++)
        {
            sections.Add(new Section(this, shiphandle.transform.GetChild(i).gameObject ,types[i]));
        }
        
    }
 
    public List<Section> getsections()
    {
        return sections;
    }
    public void setshiphandle(GameObject x)
    {
        shiphandle = x;
    }
    public GameObject getshiphandle()
    {
        return shiphandle;
    }
    public string getname()
    {
        return name;
    }
    public void setat(string a,float v)
    {
        for(int i = 0; i < attributename.Length; i++)
        {
            if(a == attributename[i])
            {
                attribute[i] = v;
            }
        }       
    }
    public float getat(string a)
    {
        for (int i = 0; i < attributename.Length; i++)
        {
            if (a == attributename[i])
            {
                return attribute[i];
                
            }
        }
        return -1;
    }
}
public class Section
{
    //string[] types = { "cockpit", "medbay", "sensor", "cargobay", "engine", "turret", "missile", "reactor", "lifesupport"};
    float[] attribute = {      100f,    3f,         0,       0,        20f ,          0.1f,        0,         0,                  0};
    string[] attributename = { "hp","turnspeed", "speed", "tempspeed", "maxspeed", "healrate", "origispeed", "origiturnspeed", "origihealrate"};
    string type;
    List<Crewmember> crew = new List<Crewmember>();
    Ship ship;
    GameObject model,section;
    bool damaged = false;
    float nextfire,rate = 5f;
 
    public Section(Ship s, GameObject m, string t )
    {
        ship = s;
        type = t;
        model = m;
    }
    public GameObject getmodel()
    {
        return model;
    }
    public void Start()
    {
        setat("origiturnspeed", getat("turnspeed"));
        setat("origispeed", getat("speed"));
    }
    public void Update()
    {
        if (type == "cockpit")
        {

            //if (crew.Count > 0 && ship.getat("fuel") > 0)
            if ( ship.getat("fuel") > 0)
            {
                
                //---------------------------------------------------------------------------------
                //turn
                ship.getshiphandle().transform.Rotate(0f, Input.GetAxis("Horizontal") * getat("turnspeed"), 0f);
                //fowrads and back
                setat("tempspeed", getat("tempspeed") + Input.GetAxis("Vertical") / 10);

                if (Mathf.Abs(getat("tempspeed")) < getat("maxspeed"))
                {
                    setat("speed", getat("tempspeed"));

                }

                //setat("speed",  getat("tempspeed"));

                ship.getshiphandle().transform.Translate(0f, 0f, getat("speed"));
                //fuel
                if(getat("speed") != 0 && nextfire > Time.time)
                {
                    nextfire = Time.time + rate;
                    ship.setat("fuel", ship.getat("fuel") - (int) (0.1 * getat("speed")));
                }

                //-------------------------------------------------------------------------------
            }
            if(damaged && getat("hp") ==100)
            {
                setat("turnspeed", getat("origturnspeed"));
            }
           
        }    
        if (type == "medbay")
        {
            if (crew.Count == 0)
            {
                foreach (var x in crew)
                {
                    if (x.gethp() + getat("healrate") < 101)
                    {
                        x.sethp(x.gethp() + getat("healrate"));
                    }
                }
            }
            if (damaged && getat("hp") == 100)
            {
                setat("healrate", getat("orighealrate"));
            }
        }
        if (type == "missile")
        {
            
        }
    }
    public void setat(string a, float v)
    {
        for (int i = 0; i < attributename.Length; i++)
        {
            if (a == attributename[i])
            {
                attribute[i] = v;
            }
        }
    }
    public float getat(string a)
    {
        for (int i = 0; i < attributename.Length; i++)
        {
            if (a == attributename[i])
            {
                return attribute[i];

            }
        }
        return -1;
    }
    void Addcrew(Crewmember c)
    {
        crew.Add(c);
    }
    void Removecrew(Crewmember c)
    {
        
        crew.Remove(c);
    }
    void OnTriggerEnter(Collider c)
    {
        
        if(c.name == "bullet")
        {
            setat("hp", getat("hp") - 1);
        }
        else if (c.name == "missile")
        {
            setat("hp", getat("hp") - 10);
        }

        if(type == "cockpit")
        {
            setat("turnspeed",getat("origturnspeed") * getat("hp") / 100);//turnspeed
            damaged = true;
        }
        if (type == "medbay")
        {
            setat("healrate",  getat("orighealrate") * getat("hp") / 100);//healrate
        }
        if (type == "sensor")
        {
            //range
        }
        if (type == "cargobay")
        {
            //drop
        }
        if (type == "engine")
        {
            //maxspeed
        }
        if (type == "turret")
        {
            //firerate
        }
        if (type == "missile")
        {
            //firerate
        }
        if (type == "reactor")
        {
            //explode
        }
        if (type == "lifesupport")
        {
            //o2 rate
        }
        
    }
}
public class Crewmember
{
    string name;
    float hp;
    string profession;
    public Crewmember(string n, float h, string prof)
    {
        name = n;
        hp = h;
        profession = prof;
    }
    public float gethp()
    {
        return hp;
    }

    public void sethp(float h)
    {
        hp = h;
    }

}
public class Pickup
{
    string name;
    int quantity = 10;
    GameObject pickupmodel;
}
public class Missile
{
    GameObject missilemodel;
}
public class Bullet
{
    GameObject Bulletmodel;
}

