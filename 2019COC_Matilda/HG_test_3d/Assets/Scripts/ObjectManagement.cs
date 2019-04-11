using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectManagement : MonoBehaviour {

    bool[] is_active = new bool[5] { true, false, false, false, false };
    public static string currentstate;
    GameObject obj1; //Layer1
    GameObject obj2;
    GameObject obj3;
    GameObject obj4;
    GameObject obj5; //Layer5

    Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Layer0").GetComponent<Animator>();
        SetStart();
        currentstate = ConfirmCurrentState();
        SetState(1);
        Debug.Log("cur" + currentstate);

        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
        Debug.Log("Send Success");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) SelectLayer("0");
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectLayer("1");
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectLayer("2");
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectLayer("3");
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectLayer("4");

    }

    void SetStart()
    {

        obj1 = GameObject.FindGameObjectWithTag("Layer1");
        obj2 = GameObject.FindGameObjectWithTag("Layer2");
        obj3 = GameObject.FindGameObjectWithTag("Layer3");
        obj4 = GameObject.FindGameObjectWithTag("Layer4");
        obj5 = GameObject.FindGameObjectWithTag("Layer5");

        obj2.SetActive(false);
        obj3.SetActive(false);
        obj4.SetActive(false);
        obj5.SetActive(false);


    }

    public string ConfirmCurrentState()
    {
        Debug.Log("ConfirmCurrentState");
        string state = "none";
        for (int i = 1; i < 6; i++)
        {
            if (is_active[i-1])
            {
                state = "Layer" + i.ToString();
            }
        }
        Debug.Log("ConfirmCurrentState end");
        return state;
    }

    void SelectLayer(string data)
    {
        Debug.Log("function: SelectLayer. Data :" + data);
        int funcIDX = Convert.ToInt16(data);
        
        //off 상태
        if (currentstate == "Layer1")
        {
            if (funcIDX == 0) Layer2();
        }

        // 홈 화면
        else if (currentstate == "Layer2")
        {
            if (funcIDX == 0) Layer3();
            else if (funcIDX == 1) Layer4();
            else if(funcIDX == 2) Layer5();
            else if (funcIDX == 3) Layer1();
        }
        // 조명
        else if (currentstate == "Layer3")
        {
            if (funcIDX == 0) Layer2();
            if (funcIDX == 1) return; //off
            if (funcIDX == 2) return; //on
        }
        
        // 창문
        else if (currentstate == "Layer4")
        {
            if (funcIDX == 0) Layer2();

            if (funcIDX == 1) anim.SetTrigger("goDown"); //Window down
            if (funcIDX == 2) anim.SetTrigger("goUp"); //Window up

        }


        // 노래
        else if (currentstate == "Layer5")
        {
            if (funcIDX == 0) Layer2();
            if (funcIDX == 1) GameObject.Find("MusicSMALL").SendMessage("VolumeDown");
            if (funcIDX == 2) GameObject.Find("MusicSMALL").SendMessage("VolumeUp");
            if (funcIDX == 3) GameObject.Find("MusicSMALL").SendMessage("PlaySE");
            if (funcIDX == 4) GameObject.Find("MusicSMALL").SendMessage("Mute");
        }

    }

    // 시작화면(전원 off 상태)
    public void Layer1()
    {
        SetState(1);
        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
    }
    // 기능 선택화면(창문, 공기, 노래, off)
    public void Layer2()
    {
        SetState(2);
        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
    }

    // 창문 기능(운전석up, 운전석down, 조수석up, 조수석down, Home)
    public void Layer3()
    {
        SetState(3);
        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
    }

    // 외부공기유입차단 ( on/off, Home)
    public void Layer4()
    {
        SetState(4);
        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
    }

    // 창문 기능(재생/일시정지, 볼륨up, 볼륨down, 다음곡재생, Home)
    public void Layer5()
    {
        SetState(5);
        GameObject.Find("GameManager").SendMessage("SendCurrentState", currentstate);
    }

    public void SetState(int k)
    {
        if(k == 1)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(false);
        }

        if (k == 2)
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(false);
        }

        if (k == 3)
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
            obj4.SetActive(false);
            obj5.SetActive(false);
        }

        if (k == 4)
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(true);
            obj5.SetActive(false);
        }

        if (k == 5)
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(true);
        }

        currentstate = "Layer" + k.ToString();
    }
}
