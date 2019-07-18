using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamescript : MonoBehaviour
{
    GameObject ship;
    public GameObject player;
  
    
   
    // Start is called before the first frame update
    void Start()
    {
        ship = Instantiate(Resources.Load("Prefabs/ship1") as GameObject );//spawn ship
        ship.transform.parent = player.transform;
        //ship = Instantiate(Resources.Load("Prefabs/ship2") as GameObject);//spawn ship

        menuinit();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
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

