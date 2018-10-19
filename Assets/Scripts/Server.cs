using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class Server : MonoBehaviour
{

    [SerializeField] int port = 5005;
    OSCReciever reciever;

    void Start()
    {
        reciever = new OSCReciever();
        reciever.Open(port);
        Debug.Log("Waiting messages・・・");
    }

    void Update()
    {
        if (reciever.hasWaitingMessages())
        {
            OSCMessage msg = reciever.getNextMessage();
            Debug.Log(string.Format("Message received: {0} {1}", msg.Address, DataToString(msg.Data)));
        }
    }

    string DataToString(List<object> data)
    {
        string buffer = "";

        for (int i = 0; i < data.Count; i++)
        {
            buffer += data[i] + " ";
        }

        return buffer;
    }
}
