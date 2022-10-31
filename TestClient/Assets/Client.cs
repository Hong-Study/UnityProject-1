using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    ClientInterface clientInterface;

    void Start()
    {
        clientInterface = new ClientInterface();
        clientInterface.Start();

        if (clientInterface.isRead())
            clientInterface.Read();
    }
}
