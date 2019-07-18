using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homescreen : MonoBehaviour
{
    GameObject creditsmenu, mainmenu, playmenu, loadmenu, homemenu, hud, pausemenu, statusmenu, contextmenu;
    Button play, load, credits, quit, backc, backp, backl, newg, save1, save2, save3, save4, resume, save, quitp;  
    // Start is called before the first frame update
    void Start()
    {
        
        play = GameObject.Find("Play").GetComponent<Button>();
        play.onClick.AddListener(mainplay);

        load = GameObject.Find("Load").GetComponent<Button>();
        load.onClick.AddListener(playload);

        newg = GameObject.Find("Newg").GetComponent<Button>();
        newg.onClick.AddListener(playnewg);

        credits = GameObject.Find("Credits").GetComponent<Button>();
        credits.onClick.AddListener(maincredits);

        quit = GameObject.Find("Quit").GetComponent<Button>();
        quit.onClick.AddListener(mainquit);

        backc = GameObject.Find("Backc").GetComponent<Button>();
        backc.onClick.AddListener(creditsmain);

        backp = GameObject.Find("Backp").GetComponent<Button>();
        backp.onClick.AddListener(playmain);

        backl = GameObject.Find("Backl").GetComponent<Button>();
        backl.onClick.AddListener(loadplay);

        save1 = GameObject.Find("Save1").GetComponent<Button>();
        save1.onClick.AddListener(loadsave1);

        save2 = GameObject.Find("Save2").GetComponent<Button>();
        save2.onClick.AddListener(loadsave2);

        save3 = GameObject.Find("Save3").GetComponent<Button>();
        save3.onClick.AddListener(loadsave3);

        save4 = GameObject.Find("Save4").GetComponent<Button>();
        save4.onClick.AddListener(loadsave4);

        resume = GameObject.Find("Resume").GetComponent<Button>();
        resume.onClick.AddListener(resumegame);

        save = GameObject.Find("Save").GetComponent<Button>();
        save.onClick.AddListener(savegame);

        quitp = GameObject.Find("Quitp").GetComponent<Button>();
        quitp.onClick.AddListener(quitmain);

        hud = GameObject.Find("hud");
        pausemenu = GameObject.Find("pausemenu");
        statusmenu = GameObject.Find("statusmenu");

        mainmenu = GameObject.Find("mainmenu");
        creditsmenu = GameObject.Find("creditsmenu");
        playmenu = GameObject.Find("playmenu");
        loadmenu = GameObject.Find("loadmenu");
        homemenu = GameObject.Find("homescreen");
        hud = GameObject.Find("hud");
        contextmenu = GameObject.Find("contextmenu");

        creditsmenu.SetActive(false);
        playmenu.SetActive(false);
        loadmenu.SetActive(false);
        hud.SetActive(false);
        contextmenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            contextmenu.SetActive(true);
            contextmenu.transform.position = Input.mousePosition;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            contextmenu.SetActive(false);
        }
    }


    void mainplay() {
        mainmenu.SetActive(false);
        playmenu.SetActive(true);
    }
    void playload() {
        playmenu.SetActive(false);
        loadmenu.SetActive(true);
    }
    void maincredits() {
        mainmenu.SetActive(false);
        creditsmenu.SetActive(true);
    }
    void mainquit() {
        Application.Quit();
    }
    void creditsmain() {
        creditsmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
    void playmain() {
        playmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
    void loadplay() {
        loadmenu.SetActive(false);
        playmenu.SetActive(true);
       
    }
    void playnewg()
    {
        homemenu.SetActive(false);
        hud.SetActive(true);
    }  
    void loadsave1()
    {
        homemenu.SetActive(false);
        hud.SetActive(true);
    }
    void loadsave2()
    {
        homemenu.SetActive(false);
        hud.SetActive(true);
    }
    void loadsave3()
    {
        homemenu.SetActive(false);

    }
    void loadsave4()
    {
        homemenu.SetActive(false);
    }
   

    void resumegame()
    {
        pausemenu.SetActive(false);
    }
    void savegame()
    {

    }
    void quitmain()
    {
        hud.SetActive(false);
        homemenu.SetActive(true);
        playmain();
    }
}
