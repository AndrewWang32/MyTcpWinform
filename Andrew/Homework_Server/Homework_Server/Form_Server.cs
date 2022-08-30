// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
// using System.Drawing;
// using System.Linq;
using System.Text;
// using System.Threading.Tasks;
// using System.Windows.Forms;
// using System.IO;
using System.Net;
using System.Net.Sockets;
// using System.Web;
// using System.Net.Security;
// using static System.Windows.Forms.AxHost;

namespace Homework_Server
{
    public partial class Form_Server : Form
    {
        string txtPort = "5566";
        string txtIP = "127.0.0.1";
        private static byte[] result = new byte[256];
        bool a = true;

        private delegate void delUpdateUI(string sMessage);
        private delegate void delUpdateIP(string ip, string port);

        Socket m_server;
        
        public Form_Server()
        {
            InitializeComponent();
        }

        private void Form_Server_Load(object sender, EventArgs e)
        {
            try
            {
                int nPort = Convert.ToInt32(txtPort); // 設定 Port
                IPAddress localAddr = IPAddress.Parse(txtIP); // 設定 IP

                UpdateStatus("Server is wait fo connection.");
                m_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_server.Bind(new IPEndPoint(localAddr, nPort));
                m_server.Listen(10);    //設定最多10個排隊連線請求
                Thread m_thrListening = new Thread(ListenClientConnect);
                m_thrListening.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
        }


        private void ListenClientConnect()
        {
            while (a)
            {
                Socket clientSocket = m_server.Accept();
                UpdateStatus("Server is connect to Client.");
                IPAddress cilentIP = IPAddress.Parse(((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString());
                string clientPort = ((IPEndPoint)clientSocket.RemoteEndPoint).Port.ToString();
                string strClientIP = cilentIP.ToString();
                UpdateClient(strClientIP, clientPort);

                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        private static byte[] GetStringFromClient(byte[] data)
        {
            byte[] result;
            bool FlagGetString = false;
            byte d = 10;
            int i = 0, j = 0;
            foreach (byte byteTmp in data)
            {
                FlagGetString = true;
                if (byteTmp == d)
                {
                    FlagGetString = false;
                    i -= 1;
                    break;
                }
                if (FlagGetString == true)
                {
                    i++;
                }
            }
            result = new byte[i];
            for (j=0;j<i;j++)
            {
                result[j] = data[j];
            }
            return result;
        }

        private void ReceiveMessage(object clientSocket)
        {
            byte[] result = new byte[256];
            bool currentConnection = true;
            Socket myClientSocket = (Socket)clientSocket;
            while (a)
            {
                try
                {
                    currentConnection = true;
                    //通過clientSocket接收資料
                    myClientSocket.Receive(result);//接收返回資料
                    byte[] byteTmp = GetStringFromClient(result);//去除多餘位元組
                    string stringData = Encoding.UTF8.GetString(byteTmp);//轉換為字串

                    int len = stringData.Length;//計算字串長度
                    UpdateSize(len.ToString());//更新字串資料長度
                    ProcessFile(stringData, myClientSocket);
                    currentConnection = IsSocketConnected(myClientSocket);//檢查是否維持連線
                    if (currentConnection == false)
                    {
                        UpdateStatus("Server is wait fo connection.");
                        //UpdateClient("", "");
                        //UdpateFilename("");
                        //UpdateSize("");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    UpdateStatus("Server is wait fo connection.");
                    // UpdateClient("", "");
                    // UdpateFilename("");
                    // UpdateSize("");
                    //myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }

        private void ProcessFile(string path, Socket client)
        {
            UdpateFilename(path);
            if (path == null || path.Length == 0)
            {
                throw new ArgumentNullException("FileName");
            }

            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                UdpateFilename(path);
                UpdateStatus("File does not exist.");
                Thread.Sleep(300);
                string string4 = String.Format("error{0}", Environment.NewLine);
                client.Send(Encoding.ASCII.GetBytes(string4));
            }
            else
            {
                if (File.Exists(path))
                {
                    // 開始處理檔案
                    UdpateFilename(fileInfo.FullName);
                    UpdateStatus(path + " exiest!");
                    UpdateStatus("Sending " + path + " to the host.");

                    // 建立 preBuffer data.
                    string string1 = String.Format("File Downloading...{0}", Environment.NewLine);
                    byte[] preBuf = Encoding.ASCII.GetBytes(string1);

                    // 建立 postBuffer data.
                    string string2 = String.Format("{0}Download Complete!{1}", Environment.NewLine, Environment.NewLine);
                    byte[] postBuf = Encoding.ASCII.GetBytes(string2);

                    //傳送檔案
                    Console.WriteLine("Sending {0} with buffers to the host.{1}", path, Environment.NewLine);
                    client.SendFile(path, preBuf, postBuf, TransmitFileOptions.UseDefaultWorkerThread);

                    string string3 = String.Format("Finished{0}", Environment.NewLine);
                    client.Send(Encoding.ASCII.GetBytes(string3));
                    UpdateStatus(string3);
                }
            }
        }

        private void UpdateClient(string ip, string port)
        {
            if (this.InvokeRequired)
            {
                delUpdateIP del = new delUpdateIP(UpdateClient);
                this.Invoke(del, ip, port);
            }
            else
            {
                textBoxClientIP.Text = ip;
                textBoxClientPort.Text = txtPort;
            }
        }

        private void UpdateStatus(string sStatus)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(UpdateStatus);
                this.Invoke(del, sStatus);
            }
            else
            {
                txtStatus.Text = sStatus;
            }
        }

        private void UpdateSize(string sSize)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(UpdateSize);
                this.Invoke(del, sSize);
            }
            else
            {
                txtDataSize.Text = sSize;
            }
        }

        private void UdpateFilename(string sReceiveData)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(UdpateFilename);
                this.Invoke(del, sReceiveData);
            }
            else
            {
                textBoxRcvFileName.Text = sReceiveData;
            }
        }

        static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            a = false;
            System.Environment.Exit(0);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
