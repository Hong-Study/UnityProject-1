using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    ClientInterface clientInterface;

    void Start()
    {
        clientInterface = new ClientInterface();
        for (int i = 0; i < 10; i++)
        {
            clientInterface.Start();
        }

        //if (clientInterface.isRead())
        //    clientInterface.Read();
    }
}
