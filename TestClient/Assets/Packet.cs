using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class socket_data
{
    public int msg;
    public short size;
    public short type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)] public char[] data;
}

public class PacketManager
{
    public byte[] Serialized(string data)
    {
        socket_data s_data = new socket_data();
        s_data.data = new char[100];
        s_data.msg = 1;
        s_data.size = (short)(Marshal.SizeOf(typeof(socket_data)));
        s_data.type = 5;
        
        int len = data.Length;
        for(int idx = 0; idx < len; idx++)
            s_data.data[idx] = data[idx];
        
        Debug.Log("size : " + s_data.size + " data : " + len);

        byte[] packet = new byte[1];
        StructToBytes(s_data, ref packet);

        return packet;
    }

    public static void StructToBytes(object obj, ref byte[] packet)
    {
        int size = Marshal.SizeOf(obj);
        packet = new byte[size];
        IntPtr buffer = Marshal.AllocHGlobal(size + 1);
        Marshal.StructureToPtr(obj, buffer, false);
        Marshal.Copy(buffer, packet, 0, size);
        Marshal.FreeHGlobal(buffer);
    }

    public static void BytesToStructure(byte[] bValue, ref object obj, Type t)
    {
        int size = Marshal.SizeOf(t);
        IntPtr buffer = Marshal.AllocHGlobal(size);
        Marshal.Copy(bValue, 0, buffer, size);
        obj = Marshal.PtrToStructure(buffer, t);
        Marshal.FreeHGlobal(buffer);
    }
} 