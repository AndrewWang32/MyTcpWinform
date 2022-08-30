using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
// using System.Drawing;
// using System.Linq;
using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
using System.Windows.Forms;
// using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Homework_Andrew
{
    public partial class Form_Client : Form
    {
        string ip = "";
        string port = "";
        string fileName = "";
        string filePath = "";
        bool connection = false;

        public Form_Client()
        {
            InitializeComponent();
        }

        private void Form_Client_Load(object sender, EventArgs e)
        {
            textBox_IP.Text = "127.0.0.1";
            textBox_Port.Text = "5566";
            textBox_fileName.Text = "C:\\Users\\rosati\\Desktop\\OK.txt";
            textBox_filePath.Text = "C:\\Users\\rosati\\Desktop\\Andrew";
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            ip = textBox_IP.Text;
            port = textBox_Port.Text;
            int numPort = int.Parse(port);
            fileName = textBox_fileName.Text;
            filePath = textBox_filePath.Text;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, numPort); // 1.設定 IP:Port 2.連線至伺服器
            connection = true;
            NetworkStream stream = new NetworkStream(socket);
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter(stream);
            
            sw.WriteLine(fileName); // 將資料寫入緩衝
            sw.Flush(); // 刷新緩衝並將資料上傳到伺服器

            while (true)
            {
                string line = "";
                line = sr.ReadLine();
                txtResult.Text = line;
                if (line == "Finished")
                {
                    break;
                }
                else if(line == "error")
                {
                    MessageBox.Show("File does not exist.");
                    break;
                }
                else if (line == "File Downloading...")
                {
                    bool f = true;
                    string data = "";
                    string buffer = "";
                    while (f)
                    {
                        buffer = sr.ReadLine();
                        if (buffer != "Download Complete!")
                        {
                            data += buffer+"\n";
                        }
                        else
                        {
                            f = false;
                        }
                    }
                    Name = getFileName(fileName);
                    FileStreamWriteFile(filePath, Name, data);
                }
                else
                {
                    if (connection == false)
                    {
                        sw.Close();
                        sr.Close();
                        socket.Close();
                        break;
                    }
                }
            }
            sw.Close();
            sr.Close();
            socket.Close();
        }

        private void FileStreamWriteFile(string filepath, string name, string data)
        {
            char[] charDataValue;
            byte[] byDataValue;
            byte[] byDataValueBuffer;
            MessageBox.Show("File Downloading to Path : " + filepath + "\\" + name);
            FileStream fsFile = new FileStream(filepath+"\\"+name, FileMode.Create, FileAccess.Write);
            charDataValue = data.ToCharArray();
            byDataValue = new byte[charDataValue.Length*2];

            //將字符數組轉換成字節數組
            Encoder ec = Encoding.UTF8.GetEncoder();
            ec.GetBytes(charDataValue, 0, charDataValue.Length, byDataValue, 0, true);
            //將指針設定起始位置
            fsFile.Seek(0, SeekOrigin.Begin);
            //寫入文件
            fsFile.Write(byDataValue, 0, byDataValue.Length);
            fsFile.Close();
        }

        private string getFileName(string filename)
        {
            int len = 0; 
            string name = "";
            len = filename.Length;
            char[] nameReverse = new char[len];
            nameReverse = filename.ToCharArray();
            Array.Reverse(nameReverse);
            
            char[] buffer = new char[len];
            for (int i=0; i < len; i++)
            {
                char c = nameReverse[i];
                if(c == '\\')
                {
                    break;
                }
                else
                {
                    buffer[i] = nameReverse[i];
                    string b = buffer[i].ToString();
                }
            }
            Array.Reverse(buffer);
            name = new string(buffer);
            name = name.Replace("\0", string.Empty);
            
            return name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.textBox_filePath.Text = path.SelectedPath;
        }

        private void Form_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.Beep();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            connection = false;
        }
    }
}
