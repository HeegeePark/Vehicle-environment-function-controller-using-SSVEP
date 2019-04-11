using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Client : MonoBehaviour
{
    //Concrete classes
    private SocketLib socket;   //서버와 통신하는 소켓라이브러리
    private Postbox postbox;    //메세지 큐를 관리하는 우편함
    string userMode = "";
    bool isDetect = false;
    bool[] is_active = new bool[5] { true, false, false, false, false };
    int sec = 3;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SendStart()
    {
        socket.Send("10"); // 뇌파 데이터 측정 시작
        Debug.Log("SendStart");
    }


    public void SendCurrentState(string s)
    {
        string state = s;
        socket.Send(state);
        Debug.Log("SendState : " + state);
    }


    public void Start()
    {
        SocketStart();
    }

    void Update()
    {
        if (isDetect)
        {
            SocketStart();
            userMode = "";
            isDetect = true;
        }

        /*  */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("서버 connect1");
            ResponseData("Data received");
        }
        /*  */
    }


    private void SocketStart()
    {
        socket = new SocketLib();
        postbox = Postbox.GetInstance;
        //큐 탐색 시작
        Debug.Log("큐 탐색 시작");
        StartCoroutine(CheckQueue());

        //데이타 요청 시작
        Debug.Log("요청 시작");
        RequestData();
    }

    //public void UserMode(string mode)
    //{
    //    Debug.Log("10");
    //    userMode = mode;
    //    isDetect = true;
    //}

    //서버에 데이타 요청
    private void RequestData()
    {
        Debug.Log("데이터요청");
        socket.Request();
    }

    //서버에서 응답 받음
    public void ResponseData(string data)
    {
        Debug.Log("서버 응답");
        data = data.Split('\0')[0];

        //GameObject.Find("Controller").SendMessage("Reciever", data);
        Debug.Log(data);
        GameObject.Find("GameManager").SendMessage("SelectLayer", data);
    }

    //큐를 주기적으로 탐색
    private IEnumerator CheckQueue()
    {
        //1초 주기로 탐색
        int waitDataRecieve = 1;
        Debug.Log("탐색");

        while (true)
        {
            //우편함에서 데이타 꺼내기
            string data = postbox.GetData();

            //우편함에 데이타가 있는 경우
            if (!data.Equals(string.Empty))
            {
                //데이타로 UI 갱신                
                ResponseData(data);
                Debug.Log("data"+data);
                //yield break;
            }
            yield return new WaitForSeconds(waitDataRecieve);
        }
    }
}
