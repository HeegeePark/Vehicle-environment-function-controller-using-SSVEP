using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Controller : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("1번 누름");
            GameObject.Find("Network").SendMessage("UserMode", "1");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("2번 누름");
            GameObject.Find("Network").SendMessage("UserMode", "2");
        }
    }

    public void Reciever(string data)
    {
        StringSplit(data);
    }

    public void StringSplit(string text)
    {
        Debug.Log("수신된 데이터: " + text);
        char[] delimiterChars = { ' ', ',', '|', ';', '\t', ':' };
        string[] words = text.Split(delimiterChars);

        for (int i = 0; i < 4; i++)
        {
            Debug.Log(words[i]);
        }
    }
}
