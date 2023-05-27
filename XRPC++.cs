using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XRPCLib;

namespace XRPCPlusPlus
{
    public static class XRPCExtensions
    {
        private static byte[] myBuff = new byte[0x20];
        private static uint outInt;
        private static uint uTemp32;
        private static UInt16 uTemp16;
        private static UInt64 uTemp64;
        private static Int16 Temp16;
        private static Int32 Temp32;
        private static Int64 Temp64;

        public static sbyte ReadSByte(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 1, myBuff, out outInt);
            return (sbyte)myBuff[0];
        }

        public static bool ReadBool(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 1, myBuff, out outInt);
            return myBuff[0] != 0;
        }

        public static short ReadInt16(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 2, myBuff, out outInt);
            Array.Reverse(myBuff,0,2);
            return BitConverter.ToInt16(myBuff, 0);
        }

        public static int ReadInt32(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 4, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 4);
            return BitConverter.ToInt32(myBuff, 0);
        }

        public static long ReadInt64(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 8, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 8);
            return BitConverter.ToInt64(myBuff, 0);
        }

        public static byte ReadByte(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 1, myBuff, out outInt);
            return myBuff[0];
        }

        public static ushort ReadUInt16(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 2, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 2);
            return BitConverter.ToUInt16(myBuff, 0);
        }

        public static uint ReadUInt32(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 4, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 4);
            return BitConverter.ToUInt32(myBuff, 0);
        }

        public static ulong ReadUInt64(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 8, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 8);
            return BitConverter.ToUInt64(myBuff, 0);
        }

        public static float ReadFloat(this XRPC xpc, uint Offset)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, 4, myBuff, out outInt);
            Array.Reverse(myBuff, 0, 4);
            return BitConverter.ToSingle(myBuff, 0);
        }

        public static string ReadString(this XRPC xpc, uint Offset, byte[] readBuffer)
        {
            xpc.xbCon.DebugTarget.GetMemory(Offset, (uint)readBuffer.Length, readBuffer, out outInt);
            return new string(System.Text.Encoding.ASCII.GetChars(readBuffer)).Split('\0')[0];
        }

        public static string ReadString(this XRPC xpc, uint Offset)
        {
            return ReadString(xpc, Offset, myBuff);
        }

        public static void WriteSByte(this XRPC xpc, uint Offset, sbyte input)
        {
            myBuff[0] = (byte)input;
            xpc.xbCon.DebugTarget.SetMemory(Offset, 1, myBuff, out outInt);
        }

        public static void WriteBool(this XRPC xpc, uint Offset, bool input)
        {
            myBuff[0] = input ? (byte)1 : (byte)0;
            xpc.xbCon.DebugTarget.SetMemory(Offset, 1, myBuff, out outInt);
        }

        public static void WriteInt16(this XRPC xpc, uint Offset, short input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 2);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 2, myBuff, out outInt);
        }

        public static void WriteInt32(this XRPC xpc, uint Offset, int input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 4);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 4, myBuff, out outInt);
        }

        public static void WriteInt64(this XRPC xpc, uint Offset, long input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 8);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 8, myBuff, out outInt);
        }

        public static void WriteByte(this XRPC xpc, uint Offset, byte input)
        {
            myBuff[0] = input;
            xpc.xbCon.DebugTarget.SetMemory(Offset, 1, myBuff, out outInt);
        }

        public static void WriteUInt16(this XRPC xpc, uint Offset, ushort input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 2);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 2, myBuff, out outInt);
        }

        public static void WriteUInt32(this XRPC xpc, uint Offset, uint input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 4);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 4, myBuff, out outInt);
        }

        public static void WriteUInt64(this XRPC xpc, uint Offset, ulong input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 8);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 8, myBuff, out outInt);
        }

        public static void WriteFloat(this XRPC xpc, uint Offset, float input)
        {
            BitConverter.GetBytes(input).CopyTo(myBuff, 0);
            Array.Reverse(myBuff, 0, 4);
            xpc.xbCon.DebugTarget.SetMemory(Offset, 4, myBuff, out outInt);
        }

        public static void XOR_Uint16(this XRPC xpc, uint Offset, ushort input)
        {
            uTemp16 = xpc.ReadUInt16(Offset);
            uTemp16 ^= input;
            xpc.WriteUInt16(Offset, input);
        }

        public static void XOR_UInt32(this XRPC xpc, uint Offset, uint input)
        {
            uTemp32 = xpc.ReadUInt32(Offset);
            uTemp32 ^= input;
            xpc.WriteUInt32(Offset, uTemp32);
        }

        public static void XOR_UInt64(this XRPC xpc, uint Offset, ulong input)
        {
            uTemp64 = xpc.ReadUInt64(Offset);
            uTemp64 ^= input;
            xpc.WriteUInt64(Offset, uTemp64);
        }

        public static void XOR_Int16(this XRPC xpc, uint Offset, Int16 input)
        {
            Temp16 = xpc.ReadInt16(Offset);
            Temp16 ^= input;
            xpc.WriteInt16(Offset, Temp16);
        }

        public static void XOR_Int32(this XRPC xpc, uint Offset, int input)
        {
            Temp32 = xpc.ReadInt32(Offset);
            Temp32 ^= input;
            xpc.WriteInt32(Offset, Temp32);
        }

        public static void XOR_Int64(this XRPC xpc, uint Offset, long input)
        {
            Temp64 = xpc.ReadInt64(Offset);
            Temp64 ^= input;
            xpc.WriteInt64(Offset, Temp64);
        }

        public static void AND_UInt16(this XRPC xpc, uint Offset, ushort input)
        {
            uTemp16 = xpc.ReadUInt16(Offset);
            uTemp16 &= input;
            xpc.WriteUInt16(Offset, uTemp16);
        }

        public static void AND_UInt32(this XRPC xpc, uint Offset, uint input)
        {
            uTemp32 = xpc.ReadUInt32(Offset);
            uTemp32 &= input;
            xpc.WriteUInt32(Offset, uTemp32);
        }

        public static void AND_UInt64(this XRPC xpc, uint Offset, ulong input)
        {
            uTemp64 = xpc.ReadUInt64(Offset);
            uTemp64 &= input;
            xpc.WriteUInt64(Offset, uTemp64);
        }

        public static void AND_Int16(this XRPC xpc, uint Offset, short input)
        {
            Temp16 = xpc.ReadInt16(Offset);
            Temp16 &= input;
            xpc.WriteInt16(Offset, Temp16);
        }

        public static void AND_Int32(this XRPC xpc, uint Offset, int input)
        {
            Temp32 = xpc.ReadInt32(Offset);
            Temp32 &= input;
            xpc.WriteInt32(Offset, Temp32);
        }

        public static void AND_Int64(this XRPC xpc, uint Offset, long input)
        {
            Temp64 = xpc.ReadInt64(Offset);
            Temp64 &= input;
            xpc.WriteInt64(Offset, Temp64);
        }

        public static void OR_UInt16(this XRPC xpc, uint Offset, ushort input)
        {
            uTemp16 = xpc.ReadUInt16(Offset);
            uTemp16 |= input;
            xpc.WriteUInt16(Offset, uTemp16);
        }

        public static void OR_UInt32(this XRPC xpc, uint Offset, uint input)
        {
            uTemp32 = xpc.ReadUInt32(Offset);
            uTemp32 |= input;
            xpc.WriteUInt32(Offset, uTemp32);
        }

        public static void OR_UInt64(this XRPC xpc, uint Offset, ulong input)
        {
            uTemp64 = xpc.ReadUInt64(Offset);
            uTemp64 |= input;
            xpc.WriteUInt64(Offset, uTemp64);
        }

        public static void OR_Int16(this XRPC xpc, uint Offset, short input)
        {
            Temp16 = xpc.ReadInt16(Offset);
            Temp16 |= input;
            xpc.WriteInt16(Offset, Temp16);
        }

        public static void OR_Int32(this XRPC xpc, uint Offset, int input)
        {
            Temp32 = xpc.ReadInt32(Offset);
            Temp32 |= input;
            xpc.WriteInt32(Offset, Temp32);
        }

        public static void OR_Int64(this XRPC xpc, uint Offset, long input)
        {
            Temp64 = xpc.ReadInt64(Offset);
            Temp64 |= input;
            xpc.WriteInt64(Offset, Temp64);
        }
    }
}
