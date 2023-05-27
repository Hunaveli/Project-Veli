namespace JRPC_Client
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Windows.Forms;
    using XDevkit;

    public class JRPC
    {
        public bool activeConnection;
        private uint Byte = 4;
        private uint ByteArray = 7;
        private TcpClient client;
        private uint Float = 3;
        private uint FloatArray = 6;
        private uint Int = 1;
        private uint IntArray = 5;
        private BinaryReader JRPC_BReader;
        private StreamReader JRPC_Reader;
        private StreamWriter JRPC_Writer;
        private byte[] myBuff = new byte[0x100];
        private uint outInt;
        private uint String = 2;
        private short Temp16;
        private int Temp32;
        private long Temp64;
        private uint Uint64 = 8;
        private ushort uTemp16;
        private uint uTemp32;
        private ulong uTemp64;
        private uint Void;
        public IXboxConsole xbConsole;
        private uint xbConsolenection;
        public bool xbdmConnection;
        public IXboxManager xbManager;

        public void AND_Int16(uint Offset, short input)
        {
            this.Temp16 = this.ReadInt16(Offset);
            this.Temp16 = (short) (this.Temp16 & input);
            this.WriteInt16(Offset, this.Temp16);
        }

        public void AND_Int32(uint Offset, int input)
        {
            this.Temp32 = this.ReadInt32(Offset);
            this.Temp32 &= input;
            this.WriteInt32(Offset, this.Temp32);
        }

        public void AND_Int64(uint Offset, long input)
        {
            this.Temp64 = this.ReadInt64(Offset);
            this.Temp64 &= input;
            this.WriteInt64(Offset, this.Temp64);
        }

        public void AND_UInt16(uint Offset, ushort input)
        {
            this.uTemp16 = this.ReadUInt16(Offset);
            this.uTemp16 = (ushort) (this.uTemp16 & input);
            this.WriteUInt16(Offset, this.uTemp16);
        }

        public void AND_UInt32(uint Offset, uint input)
        {
            this.uTemp32 = this.ReadUInt32(Offset);
            this.uTemp32 &= input;
            this.WriteUInt32(Offset, this.uTemp32);
        }

        public void AND_UInt64(uint Offset, ulong input)
        {
            this.uTemp64 = this.ReadUInt64(Offset);
            this.uTemp64 &= input;
            this.WriteUInt64(Offset, this.uTemp64);
        }

        public byte CallByte(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return 0;
            }
            this.SendCMD(Offset, this.Byte, Arguments);
            return Convert.ToByte(this.Recv());
        }

        public byte[] CallByteArray(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return new byte[8];
            }
            this.SendCMD(Offset, this.ByteArray, Arguments);
            string str = this.Recv();
            int index = 0;
            string s = "";
            byte[] buffer = new byte[8];
            foreach (char ch in str)
            {
                if (ch == ';')
                {
                    return buffer;
                }
                if (ch != ',')
                {
                    s = s + ch.ToString();
                }
                else
                {
                    buffer[index] = byte.Parse(s);
                    index++;
                    s = "";
                }
            }
            return buffer;
        }

        public float CallFloat(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return 0f;
            }
            this.SendCMD(Offset, this.Float, Arguments);
            return float.Parse(this.Recv(), NumberStyles.Float);
        }

        public float[] CallFloatArray(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return new float[8];
            }
            this.SendCMD(Offset, this.FloatArray, Arguments);
            string str = this.Recv();
            int index = 0;
            string s = "";
            float[] numArray = new float[8];
            foreach (char ch in str)
            {
                if (ch == ';')
                {
                    return numArray;
                }
                if (ch != ',')
                {
                    s = s + ch.ToString();
                }
                else
                {
                    numArray[index] = float.Parse(s, NumberStyles.Float);
                    index++;
                    s = "";
                }
            }
            return numArray;
        }

        public string CallString(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return "";
            }
            this.SendCMD(Offset, this.String, Arguments);
            return this.Recv();
        }

        private void CallStruct(string Commands)
        {
            this.Send(Commands, true);
        }

        public uint CallUInt(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return 0;
            }
            this.SendCMD(Offset, this.Int, Arguments);
            return uint.Parse(this.Recv(), NumberStyles.HexNumber);
        }

        public ulong CallUInt64(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return 0L;
            }
            this.SendCMD(Offset, this.Int, Arguments);
            return ulong.Parse(this.Recv(), NumberStyles.HexNumber);
        }

        public uint[] CallUIntArray(uint Offset, params object[] Arguments)
        {
            if (!this.activeConnection)
            {
                return new uint[8];
            }
            this.SendCMD(Offset, this.IntArray, Arguments);
            string str = this.Recv();
            int index = 0;
            string s = "";
            uint[] numArray = new uint[8];
            foreach (char ch in str)
            {
                if (ch == ';')
                {
                    return numArray;
                }
                if (ch != ',')
                {
                    s = s + ch.ToString();
                }
                else
                {
                    numArray[index] = uint.Parse(s, NumberStyles.HexNumber);
                    index++;
                    s = "";
                }
            }
            return numArray;
        }

        public void CallVoid(uint Offset, params object[] Arguments)
        {
            if (this.activeConnection)
            {
                this.SendCMD(Offset, this.Void, Arguments);
                this.Recv();
            }
        }

        public void Connect(string Console = "", bool ShowPopupMessages = false)
        {
            string[] strArray = Console.Split(new char[] { '.' });
            if (!this.xbdmConnection)
            {
                string str;
                string str2;
                this.xbManager = new XboxManager();
                this.xbConsole = this.xbManager.OpenConsole((Console == "") ? this.xbManager.DefaultConsole : Console);
                try
                {
                    this.xbConsolenection = this.xbConsole.OpenConnection(null);
                }
                catch (Exception)
                {
                    return;
                }
                if (this.xbConsole.DebugTarget.IsDebuggerConnected(out str, out str2))
                {
                    this.xbdmConnection = true;
                }
                else
                {
                    this.xbConsole.DebugTarget.ConnectAsDebugger("JRPC", XboxDebugConnectFlags.Force);
                    if (!this.xbConsole.DebugTarget.IsDebuggerConnected(out str, out str2))
                    {
                        MessageBox.Show("tried to connect to " + ((Console == "") ? this.xbManager.DefaultConsole : Console) + " and failed :(");
                    }
                    else
                    {
                        this.xbdmConnection = true;
                    }
                }
            }
            if (this.xbdmConnection)
            {
                this.client = new TcpClient((Console == "") ? this.XboxIP() : Console, 0x581);
                this.client.NoDelay = true;
                this.client.LingerState.Enabled = true;
                this.client.LingerState.LingerTime = 5;
                this.client.SendBufferSize = 0x2134;
                this.client.ReceiveBufferSize = 0x3e8;
                this.JRPC_BReader = new BinaryReader(this.client.GetStream());
                this.JRPC_Reader = new StreamReader(this.client.GetStream());
                this.JRPC_Writer = new StreamWriter(this.client.GetStream());
                if (this.Recv() != "JRPC2 connected")
                {
                    this.activeConnection = false;
                    if (ShowPopupMessages)
                    {
                        MessageBox.Show("JRPC Couldn't Connect!\n\nPlease Try Again!");
                    }
                }
                else
                {
                    this.activeConnection = true;
                    if (ShowPopupMessages)
                    {
                        MessageBox.Show("JRPC Connected to " + this.xbManager.DefaultConsole);
                    }
                }
            }
            else
            {
                this.activeConnection = false;
                if (ShowPopupMessages)
                {
                    MessageBox.Show("JRPC Couldn't Connect!\n\nPlease Try Again!");
                }
            }
        }

        public string ConsoleType()
        {
            if (!this.activeConnection)
            {
                return "Unknown";
            }
            this.ResetStruct();
            this.SpawnEndian((uint) 0x11);
            this.CallStruct(@"A\0\T\17\A\0\");
            return this.Recv();
        }

       
	public string CPUKey()
        {
            if (!this.activeConnection)
            {
                return "";
            }
            this.CallStruct(@"A\0\T\10\A\0\");
            return this.Recv();
        }


        public string GetKernalVersion()
        {
            if (!this.activeConnection)
            {
                return "";
            }
            this.CallStruct(@"A\0\T\13\A\0\");
            return this.Recv();
        }
        public byte[] GetMemory(uint address, uint length)
        {
            uint g;
            byte[] data = new byte[length];
            this.xbConsole.DebugTarget.GetMemory(address, length, data, out g);
            this.xbConsole.DebugTarget.InvalidateMemoryCache(true, address, length);
            return data;
        }
        /*public byte[] GetMemory(uint Offset, uint length)
        {
            uint num2;
            byte[] data = new byte[length];
            if (length < 450)
            {
                this.CallStruct(string.Concat(new object[] { @"A\", Offset.ToString("X8"), @"\T\19\A\1\", this.Int, @"\", length, @"\" }));
                string str = this.Recv();
                for (int i = 0; i < length; i++)
                {
                    data[i] = byte.Parse(str[i * 2] + str[(i * 2) + 1], NumberStyles.HexNumber);
                }
                return data;
            }
            this.xbConsole.DebugTarget.GetMemory(Offset, length, data, out num2);
            return data;
        }*/

        public uint getTemperature(Temperature temperature)
        {
            if (!this.activeConnection)
            {
                return 0;
            }
            this.CallStruct(string.Concat(new object[] { @"A\0\T\15\A\1\", this.Int, @"\", temperature, @"\" }));
            return uint.Parse(this.Recv(), NumberStyles.HexNumber);
        }

        private byte[] IntArrayToByte(int[] iArray)
        {
            byte[] buffer = new byte[iArray.Length * 4];
            int index = 0;
            for (int i = 0; index < iArray.Length; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    buffer[i + j] = BitConverter.GetBytes(iArray[index])[j];
                }
                index++;
            }
            return buffer;
        }

        public void NOP(uint Offset)
        {
            this.WriteUInt32(Offset, 0x60000000);
        }

        public byte[] ObjectToBytes(object obj, int Size)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, obj);
            byte[] buffer = serializationStream.ToArray();
            byte[] buffer2 = buffer;
            for (int i = 0; i < buffer.Length; i += Size)
            {
                int index = i;
                for (int j = Size - 1; index < (i + Size); j -= 2)
                {
                    if (index >= buffer.Length)
                    {
                        break;
                    }
                    buffer[index] = buffer2[index + j];
                    index++;
                }
            }
            return buffer;
        }

        public void OR_Int16(uint Offset, short input)
        {
            this.Temp16 = this.ReadInt16(Offset);
            this.Temp16 = (short) (this.Temp16 | input);
            this.WriteInt16(Offset, this.Temp16);
        }

        public void OR_Int32(uint Offset, int input)
        {
            this.Temp32 = this.ReadInt32(Offset);
            this.Temp32 |= input;
            this.WriteInt32(Offset, this.Temp32);
        }

        public void OR_Int64(uint Offset, long input)
        {
            this.Temp64 = this.ReadInt64(Offset);
            this.Temp64 |= input;
            this.WriteInt64(Offset, this.Temp64);
        }

        public void OR_UInt16(uint Offset, ushort input)
        {
            this.uTemp16 = this.ReadUInt16(Offset);
            this.uTemp16 = (ushort) (this.uTemp16 | input);
            this.WriteUInt16(Offset, this.uTemp16);
        }

        public void OR_UInt32(uint Offset, uint input)
        {
            this.uTemp32 = this.ReadUInt32(Offset);
            this.uTemp32 |= input;
            this.WriteUInt32(Offset, this.uTemp32);
        }

        public void OR_UInt64(uint Offset, ulong input)
        {
            this.uTemp64 = this.ReadUInt64(Offset);
            this.uTemp64 |= input;
            this.WriteUInt64(Offset, this.uTemp64);
        }

        public bool ReadBool(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 1);
            return (this.myBuff[0] != 0);
        }

        public byte ReadByte(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 1);
            return this.myBuff[0];
        }

        public float ReadFloat(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 4);
            Array.Reverse(this.myBuff, 0, 4);
            return BitConverter.ToSingle(this.myBuff, 0);
        }

        public short ReadInt16(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 2);
            Array.Reverse(this.myBuff, 0, 2);
            return BitConverter.ToInt16(this.myBuff, 0);
        }

        public int ReadInt32(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 4);
            Array.Reverse(this.myBuff, 0, 4);
            return BitConverter.ToInt32(this.myBuff, 0);
        }

        public long ReadInt64(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 8);
            Array.Reverse(this.myBuff, 0, 8);
            return BitConverter.ToInt64(this.myBuff, 0);
        }

        public sbyte ReadSByte(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 1);
            return (sbyte) this.myBuff[0];
        }

        public string ReadString(uint offset, uint length)
        {
            byte[] memory = this.GetMemory(offset, length);
            return new string(Encoding.ASCII.GetChars(memory)).Split(new char[1])[0];
        }

        public ushort ReadUInt16(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 2);
            Array.Reverse(this.myBuff, 0, 2);
            return BitConverter.ToUInt16(this.myBuff, 0);
        }

        public uint ReadUInt32(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 4);
            Array.Reverse(this.myBuff, 0, 4);
            return BitConverter.ToUInt32(this.myBuff, 0);
        }

        public ulong ReadUInt64(uint Offset)
        {
            this.myBuff = this.GetMemory(Offset, 8);
            Array.Reverse(this.myBuff, 0, 8);
            return BitConverter.ToUInt64(this.myBuff, 0);
        }

        public void RebootConsole()
        {
            if (this.activeConnection)
            {
                this.CallStruct(@"A\0\T\11\A\0\");
            }
        }

        private string Recv()
        {
            this.JRPC_Reader.DiscardBufferedData();
            return this.JRPC_Reader.ReadLine();
        }

        private JRPCstruct ResetStruct()
        {
            return new JRPCstruct { Offset = 0, NumOfArgs = 0, Type = 0, ArgType = new uint[12], intArg = new uint[12], floatArg = new float[12], byteArg = new byte[12], LongArg = new ulong[12], ArraySize = new uint[12], intArray = new uint[12, 8], floatArray = new float[12, 8], byteArray = new byte[12, 8], stringArg = new char[12, 0x100] };
        }

        public uint ResolveFunction(string ModuleName, uint Ordinal)
        {
            if (!this.activeConnection)
            {
                return 0;
            }
            JRPCstruct j = this.ResetStruct();
            j.Type = this.SpawnEndian((uint) 9);
            j.ArgType[0] = this.SpawnEndian(this.String);
            j.stringArg = this.StringToChar(j, 0, ModuleName);
            j.ArgType[1] = this.SpawnEndian(this.Int);
            j.intArg[1] = this.SpawnEndian(Ordinal);
            string commands = string.Concat(new object[] { @"A\0\T\9\A\2\", this.String.ToString(), "/", ModuleName.Length, @"\", this.StringToByteString(ModuleName), @"\", this.Int.ToString(), @"\", Ordinal.ToString(), @"\" });
            this.CallStruct(commands);
            return uint.Parse(this.Recv(), NumberStyles.HexNumber);
        }

        private void Send(string Message, bool Check = false)
        {
            string str = "";
            if (Message.Length < 900)
            {
                this.Send2(Message + "\r\n");
            }
            else
            {
                string[] strArray = SplitByLength(Message, 800);
                for (int i = 0; i < strArray.Length; i++)
                {
                    this.Send2(strArray[i]);
                    str = str + strArray[i];
                }
                this.Send2("\r\n");
            }
            if (Check)
            {
                if (this.Recv() != Message)
                {
                    this.Send2("Bye\r\n");
                    throw new ArgumentException("Error: Arguments did not send to console correctly!");
                }
                this.Send2("Good\r\n");
            }
        }

        private void Send2(string Message)
        {
            this.JRPC_Writer.Write(Message);
            this.JRPC_Writer.Flush();
        }

        private void SendCMD(uint Offset, uint Type, params object[] Arguments)
        {
            string commands = string.Concat(new object[] { @"A\", Offset.ToString("X8"), @"\T\", Type, @"\A\", Arguments.Length, @"\" });
            int num = 0;
            foreach (object obj2 in Arguments)
            {
                bool flag = false;
                if (obj2 is uint)
                {
                    object obj3 = commands;
                    commands = string.Concat(new object[] { obj3, this.Int.ToString(), @"\", this.UIntToInt((uint) obj2), @"\" });
                    flag = true;
                }
                if (((obj2 is int) || (obj2 is bool)) || (obj2 is byte))
                {
                    if (obj2 is bool)
                    {
                        object obj4 = commands;
                        commands = string.Concat(new object[] { obj4, this.Int.ToString(), "/", Convert.ToInt32((bool) obj2), @"\" });
                    }
                    else
                    {
                        string str3 = commands;
                        commands = str3 + this.Int.ToString() + @"\" + ((obj2 is byte) ? Convert.ToByte(obj2).ToString() : Convert.ToInt32(obj2).ToString()) + @"\";
                    }
                    flag = true;
                }
                else if ((obj2 is int[]) || (obj2 is uint[]))
                {
                    byte[] buffer = this.IntArrayToByte((int[]) obj2);
                    object obj5 = commands;
                    commands = string.Concat(new object[] { obj5, this.ByteArray.ToString(), "/", buffer.Length, @"\" });
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        commands = commands + buffer[i].ToString("X2");
                    }
                    commands = commands + @"\";
                    flag = true;
                }
                else if (obj2 is string)
                {
                    string str2 = (string) obj2;
                    object obj6 = commands;
                    commands = string.Concat(new object[] { obj6, this.ByteArray.ToString(), "/", str2.Length, @"\", this.StringToByteString((string) obj2), @"\" });
                    flag = true;
                }
                else if (obj2 is float)
                {
                    float num3 = (float) obj2;
                    string str4 = commands;
                    commands = str4 + this.Float.ToString() + @"\" + num3.ToString() + @"\";
                    flag = true;
                }
                else if (obj2 is float[])
                {
                    float[] numArray = (float[]) obj2;
                    string str5 = commands;
                    string[] strArray3 = new string[] { str5, this.ByteArray.ToString(), "/", (numArray.Length * 4).ToString(), @"\" };
                    commands = string.Concat(strArray3);
                    for (int j = 0; j < numArray.Length; j++)
                    {
                        byte[] bytes = BitConverter.GetBytes(numArray[j]);
                        Array.Reverse(bytes);
                        for (int k = 0; k < 4; k++)
                        {
                            commands = commands + bytes[k].ToString("X2");
                        }
                    }
                    commands = commands + @"\";
                    flag = true;
                }
                else if (obj2 is byte[])
                {
                    byte[] buffer3 = (byte[]) obj2;
                    object obj7 = commands;
                    commands = string.Concat(new object[] { obj7, this.ByteArray.ToString(), "/", buffer3.Length, @"\" });
                    for (int m = 0; m < buffer3.Length; m++)
                    {
                        commands = commands + buffer3[m].ToString("X2");
                    }
                    commands = commands + @"\";
                    flag = true;
                }
                if (!flag)
                {
                    string str6 = commands;
                    commands = str6 + this.Uint64.ToString() + @"\" + Convert.ToInt64(obj2).ToString() + @"\";
                }
                num++;
            }
            this.CallStruct(commands);
        }

        public void SetLeds(LEDState Top_Left, LEDState Top_Right, LEDState Bottom_Left, LEDState Bottom_Right)
        {
            if (this.activeConnection)
            {
                this.CallStruct(string.Concat(new object[] { 
                    @"A\0\T\14\A\4\", this.Int, @"\", Top_Left, this.Int, @"\", Top_Right, this.Int, @"\", Bottom_Left, this.Int, @"\", Top_Left, this.Int, @"\", Bottom_Right, 
                    @"\"
                 }));
                this.Recv();
            }
        }

        public void SetMemory(uint Offset, byte[] Data)
        {
            uint num;
            this.xbConsole.DebugTarget.SetMemory(Offset, (uint) Data.Length, Data, out num);
        }

        private int SpawnEndian(int Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private float SpawnEndian(float Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        private uint SpawnEndian(uint Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        private ulong SpawnEndian(ulong Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        public static string[] SplitByLength(string String, int maxLength)
        {
            int num = (String.Length / maxLength) + 1;
            string[] strArray = new string[num];
            if ((maxLength - String.Length) > 0)
            {
                strArray[0] = String;
                return strArray;
            }
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < maxLength; j++)
                {
                    string[] strArray2;
                    IntPtr ptr;
                    if (num2 >= String.Length)
                    {
                        break;
                    }
                    (strArray2 = strArray)[(int) (ptr = (IntPtr) i)] = strArray2[(int) ptr] + String[num2];
                    num2++;
                }
            }
            return strArray;
        }

        private string StringToByteString(string String)
        {
            string str = "";
            for (int i = 0; i < String.Length; i++)
            {
                str = str + ((byte) String[i]).ToString("X2");
            }
            return str;
        }

        private char[,] StringToChar(JRPCstruct J, int type, string String)
        {
            char[,] stringArg = J.stringArg;
            for (int i = 0; i < String.Length; i++)
            {
                stringArg[type, i] = String.ToCharArray()[i];
            }
            stringArg[type, String.Length] = '\0';
            return stringArg;
        }

        private byte[] StructToByte(JRPCstruct str)
        {
            int cb = Marshal.SizeOf(str);
            byte[] destination = new byte[cb];
            IntPtr ptr = Marshal.AllocHGlobal(cb);
            Marshal.StructureToPtr(str, ptr, false);
            Marshal.Copy(ptr, destination, 0, cb);
            Marshal.FreeHGlobal(ptr);
            return destination;
        }

        private string StructToString(JRPCstruct JRPC)
        {
            byte[] buffer = this.StructToByte(JRPC);
            string str = "";
            string oldValue = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0)
                {
                    if (i >= (buffer.Length - 1))
                    {
                        oldValue = oldValue + "0;";
                    }
                    else
                    {
                        oldValue = oldValue + "0,";
                    }
                }
                else
                {
                    oldValue = "";
                }
                if (i >= (buffer.Length - 1))
                {
                    str = str + buffer[i] + ";";
                }
                else
                {
                    str = str + buffer[i] + ",";
                }
            }
            return str.Replace(oldValue, "NULL;");
        }

        private int UIntToInt(uint Value)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(Value), 0);
        }

        public void WriteBool(uint Offset, bool input)
        {
            this.myBuff[0] = input ? ((byte) 1) : ((byte) 0);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteByte(uint Offset, byte input)
        {
            this.myBuff[0] = input;
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteFloat(uint Offset, float input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 4);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteInt16(uint Offset, short input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 2);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteInt32(uint Offset, int input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 4);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteInt64(uint Offset, long input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 8);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteSByte(uint Offset, sbyte input)
        {
            this.myBuff[0] = (byte) input;
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteString(uint offset, string String)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(String + "\0");
            this.SetMemory(offset, bytes);
        }

        public void WriteUInt16(uint Offset, ushort input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 2);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteUInt32(uint Offset, uint input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 4);
            this.SetMemory(Offset, this.myBuff);
        }

        public void WriteUInt64(uint Offset, ulong input)
        {
            BitConverter.GetBytes(input).CopyTo(this.myBuff, 0);
            Array.Reverse(this.myBuff, 0, 8);
            this.SetMemory(Offset, this.myBuff);
        }

        public uint XamGetCurrentTitleId()
        {
            if (!this.activeConnection)
            {
                return 0;
            }
            this.CallStruct(@"A\0\T\16\A\0\");
            return uint.Parse(this.Recv(), NumberStyles.HexNumber);
        }

        public string XboxIP()
        {
            if (!this.xbdmConnection)
            {
                return "10.0.0.0";
            }
            byte[] array = new byte[4];
            BitConverter.GetBytes(this.xbConsole.IPAddress).CopyTo(array, 0);
            Array.Reverse(array);
            return new IPAddress(array).ToString();
        }

        public void XNotify(string Text)
        {
            this.CallStruct(string.Concat(new object[] { @"A\0\T\12\A\1\", this.String, "/", Text.Length, @"\", this.StringToByteString(Text), @"\" }));
            this.Recv();
        }

        public void XOR_Int16(uint Offset, short input)
        {
            this.Temp16 = this.ReadInt16(Offset);
            this.Temp16 = (short) (this.Temp16 ^ input);
            this.WriteInt16(Offset, this.Temp16);
        }

        public void XOR_Int32(uint Offset, int input)
        {
            this.Temp32 = this.ReadInt32(Offset);
            this.Temp32 ^= input;
            this.WriteInt32(Offset, this.Temp32);
        }

        public void XOR_Int64(uint Offset, long input)
        {
            this.Temp64 = this.ReadInt64(Offset);
            this.Temp64 ^= input;
            this.WriteInt64(Offset, this.Temp64);
        }

        public void XOR_Uint16(uint Offset, ushort input)
        {
            this.uTemp16 = this.ReadUInt16(Offset);
            this.uTemp16 = (ushort) (this.uTemp16 ^ input);
            this.WriteUInt16(Offset, input);
        }

        public void XOR_UInt32(uint Offset, uint input)
        {
            this.uTemp32 = this.ReadUInt32(Offset);
            this.uTemp32 ^= input;
            this.WriteUInt32(Offset, this.uTemp32);
        }

        public void XOR_UInt64(uint Offset, ulong input)
        {
            this.uTemp64 = this.ReadUInt64(Offset);
            this.uTemp64 ^= input;
            this.WriteUInt64(Offset, this.uTemp64);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct JRPCstruct
        {
            public uint Offset;
            public uint NumOfArgs;
            public uint Type;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public uint[] ArgType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public uint[] intArg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public float[] floatArg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public byte[] byteArg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public ulong[] LongArg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public uint[] ArraySize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x60)]
            public uint[,] intArray;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x60)]
            public float[,] floatArray;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x60)]
            public byte[,] byteArray;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0xc00)]
            public char[,] stringArg;
        }

        public enum LEDState
        {
            GREEN = 0x80,
            OFF = 0,
            ORANGE = 0x88,
            RED = 8
        }

        public enum Temperature
        {
            CPU,
            GPU,
            EDRAM,
            MotherBoard
        }
    }
}

