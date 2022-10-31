using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;
using System;

public class ClientInterface
{
	private TcpClient socketConnection;
	private static int displayId = 0;
	private PacketManager packetManager = new PacketManager(displayId);
	StreamWriter writer;
	StreamReader reader;
	NetworkStream stream;

	public void Start()
    {
		ConnectToTcpServer();
	}

	public bool isRead()
    {
		return stream.DataAvailable;
    }
	public void Read()
    {
		string data = reader.ReadLine();
		Debug.Log(data);
    }

	private void ConnectToTcpServer()
	{
		try
		{
			socketConnection = new TcpClient("203.241.228.47", 5000);
			stream = socketConnection.GetStream();
			writer = new StreamWriter(stream);
			reader = new StreamReader(stream);

			Debug.Log("Success Login");

			SendMessage("HelloWorld");
			
		}
		catch (Exception e)
		{
			Debug.Log("On client connect exception " + e);
		}
	}

	/// Send message to server using socket connection. 	
	private void SendMessage(string data)
	{
		if (socketConnection == null)
		{
			return;
		}
		try
		{	
			if (stream.CanWrite)
			{
				// Write byte array to socketConnection stream.                 
				writer.WriteLine(data);
				writer.Flush();

				Debug.Log("Success Send");

				data = reader.ReadLine();
				Debug.Log(data);
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("Socket exception: " + socketException);
		}
	}
}
