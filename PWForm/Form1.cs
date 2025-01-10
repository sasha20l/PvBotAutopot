using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PWForm
{
    public partial class Form1 : Form
    {
        private bool startFlag;

        private DataTable internalDb; // ���������� ���� ������
        private const string FilePath = "data.xml";

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_QUERY_INFORMATION = 0x0400;

        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;

        static int GetProcessIdByName(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                return process.Id;
            }
            return 0;
        }

        static string ReadMemory(IntPtr hProcess, IntPtr baseAddress, uint size)
        {
            byte[] buffer = new byte[size];
            if (ReadProcessMemory(hProcess, baseAddress, buffer, size, out IntPtr bytesRead))
            {
                return Encoding.ASCII.GetString(buffer);
            }
            return string.Empty;
        }

        static int ReadIntFromMemory(IntPtr hProcess, IntPtr baseAddress, uint size)
        {
            byte[] buffer = new byte[size];
            if (ReadProcessMemory(hProcess, baseAddress, buffer, size, out IntPtr bytesRead))
            {
                if (bytesRead.ToInt32() == size)
                {
                    return BitConverter.ToInt32(buffer, 0); // ����������� 4 ����� � int
                }
            }
            return 0; // ���������� 0, ���� ������ �� �������
        }

        // ����� ��� ���������� ������ � XML
        private void SaveData()
        {
            try
            {
                internalDb.WriteXml(FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ����� ��� �������� ������ �� XML
        private void LoadData()
        {
            string filePath = "data.xml";

            // ���������, ���������� �� ����
            if (File.Exists(filePath))
            {
                // ���������, �� ���� �� ����
                if (new FileInfo(filePath).Length > 0)
                {
                    try
                    {
                        internalDb.ReadXml(filePath);
                        UpdateListBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� �������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("���� ������ ����. ��������� ����� �������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("���� ������ �� ������. ��������� ����� �������.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Form1()
        {
            InitializeComponent();

            startFlag = false;

            // �������������� �������
            internalDb = new DataTable("MyDataTable1"); // ���������� ��� �������
            internalDb.Columns.Add("Id", typeof(int));
            internalDb.Columns.Add("typeXpMp", typeof(string));
            internalDb.Columns.Add("equalSigns", typeof(string));
            internalDb.Columns.Add("percent", typeof(string));
            internalDb.Columns.Add("button", typeof(string));

            // ����������� ������������� ��� Id
            internalDb.Columns["Id"].AutoIncrement = true;
            internalDb.Columns["Id"].AutoIncrementSeed = 1;

            // ��������� ������ �� �����
            LoadData();

            // ����������� �������
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;

            // ����������� ������� �������� �����
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string typeXpMp = comboBox1.SelectedItem?.ToString();
            string equalSigns = comboBox2.SelectedItem?.ToString();
            string percent = textBox1.Text;
            string button = comboBox3.SelectedItem?.ToString();

            // ���������, ��� ���� �� ������
            if (!string.IsNullOrWhiteSpace(typeXpMp) &&
                !string.IsNullOrWhiteSpace(equalSigns) &&
                !string.IsNullOrWhiteSpace(percent) &&
                !string.IsNullOrWhiteSpace(button))
            {
                // ��������� ������ � DataTable
                internalDb.Rows.Add(null, typeXpMp, equalSigns, percent, button);

                // ��������� ListBox
                UpdateListBox();

                // ������� ����
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox1.Clear();
                comboBox3.SelectedIndex = -1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ���������, ��� ������� ������
            if (listBox1.SelectedItem != null)
            {
                // ������� �� DataTable
                int selectedIndex = listBox1.SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < internalDb.Rows.Count)
                {
                    internalDb.Rows[selectedIndex].Delete();
                }

                // ��������� ListBox
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            string description;
            foreach (DataRow row in internalDb.Rows)
            {
                // ��������� ������ ��� ����������
                description = $"���� {row["typeXpMp"]} {row["equalSigns"]} {row["percent"]}% �� ������ ������ {row["button"]}";
                listBox1.Items.Add(description);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (startFlag == true) return;

            // �������� PID �������� elementclient.exe
            //int processId = GetProcessIdByName("ElementClient");
            int processId = GetProcessIdByName(textBox2.Text);
            if (processId == 0)
            {
                MessageBox.Show("������� �� ������.");
                return;
            }

            // ��������� �������
            IntPtr hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, processId);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("�� ������� ������� �������.");
                return;
            }

            // ����� ���� �������
            //IntPtr hWnd = FindWindow(null, "ComebackPW"); // ������� ������ ��� ����
            IntPtr hWnd = FindWindow(null, textBox3.Text);
            if (hWnd == IntPtr.Zero)
            {
                MessageBox.Show("���� �� �������.");
                return;
            }

            // ��������� ������������ ����� �������
            if (!int.TryParse(maxXpAddr.Text, System.Globalization.NumberStyles.HexNumber, null, out int maxXpConvert))
            {
                MessageBox.Show("�������� ������ maxXpAddr. ���������, ��� ������� ����������������� �����.");
                return;
            }

            if (!int.TryParse(xpAddr.Text, System.Globalization.NumberStyles.HexNumber, null, out int xpConvert))
            {
                MessageBox.Show("�������� ������ xpAddr. ���������, ��� ������� ����������������� �����.");
                return;
            }

            if (!int.TryParse(maxMpAddr.Text, System.Globalization.NumberStyles.HexNumber, null, out int maxMpConvert))
            {
                MessageBox.Show("�������� ������ maxMpAddr. ���������, ��� ������� ����������������� �����.");
                return;
            }

            if (!int.TryParse(mpAddr.Text, System.Globalization.NumberStyles.HexNumber, null, out int mpConvert))
            {
                MessageBox.Show("�������� ������ mpAddr. ���������, ��� ������� ����������������� �����.");
                return;
            }

            startFlag = true;

            List<ParserDb> parserDbList = new List<ParserDb>();

            foreach (DataRow row in internalDb.Rows)
            {
                parserDbList.Add(new ParserDb() 
                {
                    TypeXpMp = row["typeXpMp"].ToString(),
                    EqualSigns = row["equalSigns"].ToString(),
                    Percent = row["percent"].ToString(),
                    ButtonDb = row["button"].ToString(),
                });
            }
            StartProcessingAsync(parserDbList, maxXpConvert, xpConvert, maxMpConvert, mpConvert, hProcess, hWnd);
        }

        private async void StartProcessingAsync(List<ParserDb> parserDbList, int maxXpConvert, int xpConvert, int maxMpConvert, int mpConvert, IntPtr hProcess, IntPtr hWnd)
        {
            float maxValue = 0;
            float value = 0;
            float percentNow;

            float percentUser;

            while (startFlag)
            {
                
                foreach (ParserDb parserDb in parserDbList)
                {
                    percentUser = Convert.ToInt32(parserDb.Percent);

                    if (parserDb.TypeXpMp == "��")
                    {
                        maxValue = ReadIntFromMemory(hProcess, maxXpConvert, 4); // ������ 4 ����� ��� int
                        value = ReadIntFromMemory(hProcess, xpConvert, 4);
                        percentNow = (value / maxValue)*100;
                    }
                    else if (parserDb.TypeXpMp == "��")
                    {
                        maxValue = ReadIntFromMemory(hProcess, maxMpConvert, 4); // ������ 4 ����� ��� int
                        value = ReadIntFromMemory(hProcess, mpConvert, 4);
                        percentNow = (value / maxValue) * 100;
                    }
                    else return;

                    switch (parserDb.EqualSigns)
                    {
                        case "<":
                            if( percentNow < percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                        case ">":
                            if (percentNow > percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                        case "<=":
                            if (percentNow <= percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                        case ">=":
                            if (percentNow >= percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                        case "<>":
                            if (percentNow != percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                        case "=":
                            if (percentNow == percentUser)
                            {
                                setProcessButton(hWnd, parserDb.ButtonDb);
                            }
                            break;
                    }
                }
                await Task.Delay(200);
            }
        }

        public void setProcessButton(IntPtr hWnd, string button)
        {
            int VK = 0;

            switch (button)
            {
                case "0":
                    VK = 0x30;
                    break;
                case "1":
                    VK = 0x31;
                    break;
                case "2":
                    VK = 0x32;
                    break;
                case "3":
                    VK = 0x33;
                    break;
                case "4":
                    VK = 0x34;
                    break;
                case "5":
                    VK = 0x35;
                    break;
                case "6":
                    VK = 0x36;
                    break;
                case "7":
                    VK = 0x37;
                    break;
                case "8":
                    VK = 0x38;
                    break;
                case "9":
                    VK = 0x39;
                    break;
                case "F1":
                    VK = 0x70;
                    break;
                case "F2":
                    VK = 0x71;
                    break;
                case "F3":
                    VK = 0x72;
                    break;
                case "F4":
                    VK = 0x73;
                    break;
                case "F5":
                    VK = 0x74;
                    break;
                case "F6":
                    VK = 0x75;
                    break;
                case "F7":
                    VK = 0x76;
                    break;
                case "F8":
                    VK = 0x77;
                    break;
                case "F9":
                    VK = 0x78;
                    break;
                case "F10":
                    VK = 0x79;
                    break;
                case "F11":
                    VK = 0x7A;
                    break;
                case "F12":
                    VK = 0x7B;
                    break;
                case "Tab":
                    VK = 0x09;
                    break;  
            }
            PostMessage(hWnd, WM_KEYDOWN, (IntPtr)VK, IntPtr.Zero);
            Thread.Sleep(200); // �������� � �������������
            PostMessage(hWnd, WM_KEYUP, (IntPtr)VK, IntPtr.Zero);
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (startFlag == false) return;
            startFlag = false;
        }
    }

    public class ParserDb
    {
        public string TypeXpMp;
        public string EqualSigns;
        public string Percent;
        public string ButtonDb;
    }
}
