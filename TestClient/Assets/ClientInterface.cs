using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;
using System;
using System.Net;

public class ClientInterface
{
	//private TcpClient socketConnection;
	private Socket socket;
	private string m_Ip = "127.0.0.1";
	private int m_Port = 5000;
	private IPEndPoint m_IpEndPoint;
	private bool isConnected = false;
	PacketManager pk = new PacketManager();
	//private static int displayId = 0;
	//StreamWriter writer;
	//StreamReader reader;
	//NetworkStream stream;

	public void Start()
    {
		ConnectToTcpServer();
	}

	//public bool isRead()
 //   {
	//	return stream.DataAvailable;
 //   }
	//public void Read()
 //   {
	//	string data = reader.ReadLine();
	//	Debug.Log(data);
 //   }

	private void ConnectToTcpServer()
	{
		try
		{
			//socketConnection = new TcpClient("203.241.228.47", 5000);
			//stream = socketConnection.GetStream();
			//writer = new StreamWriter(stream);
			//reader = new StreamReader(stream);

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress ipAddress = IPAddress.Parse(m_Ip);
			m_IpEndPoint = new IPEndPoint(ipAddress, m_Port);

			socket.Connect(m_IpEndPoint);
			isConnected = true;

			Debug.Log("Success Login");
			
			SendMessage("testString");
			socket.Close();
		}
		catch (Exception e)
		{
			Debug.Log("On client connect exception " + e);
		}
	}

	/// Send message to server using socket connection. 	
	private void SendMessage(string data)
	{
		if (!isConnected)
		{
			return;
		}
		try
		{	
			if (isConnected)
			{
				Debug.Log("Input Data : " + data);
				byte[] datas = pk.Serialized(data);
				socket.Send(datas);

				Debug.Log("Success Send");
				//data = reader.ReadLine();
				//Debug.Log(data);
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
}
