using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class SocketLib
{

    Socket client = null;
    Thread Socket_Thread = null;
    bool Socket_Thread_Flag = false;

    public SocketLib()
    {
        Socket_Thread = new Thread(new ThreadStart(Run));
        Socket_Thread_Flag = true;
    }

    private void Run()
    {
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
        //IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("172.20.10.9"), 9999);
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ipep);

        byte[] _mode = new byte[1];
        byte[] _buf = new byte[1024 * 80];

        IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
        NetworkStream recvStm = new NetworkStream(client);

        while (Socket_Thread_Flag)
        {
            try
            {
                //recvStm.Read(_buf, 0, _buf.Length);                
                client.Receive(_buf);
                string _data = Encoding.Default.GetString(_buf);
                Response(_data);

            }
            catch (Exception e)
            {
                Socket_Thread_Flag = false;
                client.Close();
                //SeverSocket.Close();
                continue;
            }

        }

    }

    ////서버에 요청
    public void Request()
    {
        Socket_Thread.Start();
    }

    //응답 받음
    public void Response(string result)
    {
        Postbox.GetInstance.PushData(result);
    }

    public void Send(string message)
    {
        Byte[] StrByte = Encoding.UTF8.GetBytes(message);
        client.Send(StrByte);
    }

    void OnApplicationQuit()
    {
        try
        {
            Socket_Thread_Flag = false;
            Socket_Thread.Abort();
            client.Close();
        }
        catch
        {
            Debug.Log("소켓과 쓰레드 종료때 오류가 발생");
        }
    }
}

