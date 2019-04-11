using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class Sendmessage : MonoBehaviour
{

    public static string message = "0";

    public void SendingMessage(string val)
    {
        message = val;

        //if (val.Equals("1"))
        //{
        //    GameObject.Find("GameManager").SendMessage("SendStart");
        //}

        //else if (val.Equals("2"))
        //{
        //    GameObject.Find("GameManager").SendMessage("SendAnalysis");
        //}

        //else if (val.Equals("3") || val.Equals("4"))
        //{
        //    //GameObject.Find("CodeManager").SendMessage("SelectMenu", val);
        //    NextScene();
        //    Thread.Sleep(1000);
        //}

        Debug.Log(message);
    }



    public void ButtonClick()
    {
        SendMessage("SendingMessage", "1");
    }

    void NextScene()
    {
        SceneManager.LoadScene("End");
    }
}
