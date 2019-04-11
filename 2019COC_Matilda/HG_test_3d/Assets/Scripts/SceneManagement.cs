using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneManagement : MonoBehaviour
{

    void SelectScene(string[] list)
    {
        int curstate = Convert.ToInt16(list[0]);
        int funcIDX = Convert.ToInt16(list[1]);

        //off 상태
        if (curstate == 0) {
            if (funcIDX == 0) Layer2();
        }

        // 홈 화면
        else if (curstate == 1)
        {
            if (funcIDX == 0) State_2_1();
            if (funcIDX == 1) State_2_2();
            if (funcIDX == 2) State_2_3();
            if (funcIDX == 3) State_0();
        }

        // 창문
        else if (curstate == 2)
        {
            if (funcIDX == 0) Layer2();
            //if (funcIDX == 1) State_2_2();
            //if (funcIDX == 2) State_2_3();
            //if (funcIDX == 3) State_0();
            //if (funcIDX == 4) State_0();
        }

        // 외부공기유입차단
        else if (curstate == 3)
        {
            if (funcIDX == 0) Layer2();
            //if (funcIDX == 1) State_2_2();
            //if (funcIDX == 2) State_2_3();
        }

        // 노래
        else if (curstate == 4)
        {
            if (funcIDX == 0) Layer2();
            //if (funcIDX == 1) State_2_2();
            //if (funcIDX == 2) State_2_3();
            //if (funcIDX == 3) State_0();
            //if (funcIDX == 4) State_0();
        }

    }
    
    
    // 시작화면(전원 off 상태)
    public void State_0()
    {
        SceneManager.LoadScene("State_0");
        GameObject.Find("CodeManager").SendMessage("SendStart");
        GameObject.Find("CodeManager").SendMessage("SendCurrentState", 0);
    }
    // 기능 선택화면(창문, 공기, 노래, off)
    public void Layer2()
    {
        SceneManager.LoadScene("Layer2");
        GameObject.Find("CodeManager").SendMessage("SendCurrentState", 1);
    }

    // 창문 기능(운전석up, 운전석down, 조수석up, 조수석down, Home)
    public void State_2_1()
    {
        SceneManager.LoadScene("State_2_1");
        GameObject.Find("CodeManager").SendMessage("SendCurrentState", 2);
    }

    // 외부공기유입차단 ( on/off, Home)
    public void State_2_2()
    {
        SceneManager.LoadScene("State_2_2");
        GameObject.Find("CodeManager").SendMessage("SendCurrentState", 3);
    }

    // 창문 기능(재생/일시정지, 볼륨up, 볼륨down, 다음곡재생, Home)
    public void State_2_3()
    {
        SceneManager.LoadScene("State_2_3");
        GameObject.Find("CodeManager").SendMessage("SendCurrentState", 4);
    }

}
