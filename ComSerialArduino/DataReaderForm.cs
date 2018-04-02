using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using NextUI.Collection;
using System.Drawing;

namespace ComSerialArduino
{
    public partial class DataReaderForm : Form
    {
        private string RxString;
        private string[] tempString;
        private List<ArduinoData> ardData = new List<ArduinoData>();
        private int numElements  = 0;

        public DataReaderForm()
        {
            InitializeComponent();
            InitializeThermometers();
            timerCOM.Enabled = true;
            UpdateComList();
            serialPort1.DataReceived += SerialPort1_OnDataReceived;
            timerCOM.Tick += TimerCOM_OnTick;
            this.FormClosed += DataReaderForm_OnFormClosed;
        }

        //Updates list of COM ports available
        private void UpdateComList()
        {
            int i;
            bool diffCount; //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            diffCount = false;

            //se a quantidade de portas mudou
            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBox1.Items[i++].Equals(s) == false)
                    {
                        diffCount = true;
                    }
                }
            }
            else
            {
                diffCount = true;
            }

            //Se não foi detectado diferença
            if (diffCount == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            comboBox1.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            comboBox1.SelectedIndex = 0;

        }
        //Calls UpdateComList
        private void TimerCOM_OnTick(object sender, EventArgs e)
        {
            UpdateComList();
        }
        //Connects to Com Port
        private void BtConnect_OnClick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    serialPort1.Open();
                }
                catch
                {
                    return;

                }
                if (serialPort1.IsOpen)
                {
                    BtConnect.Text = "Desconectar";
                    comboBox1.Enabled = false;
                }
            }
            else
            {

                try
                {
                    serialPort1.Close();
                    comboBox1.Enabled = true;
                    BtConnect.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }
        }
        //Closes connections
        private void DataReaderForm_OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
                serialPort1.Close();
        }
        //Receives data from serial port
        private void SerialPort1_OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadLine();              //le o dado disponível na serial
            this.Invoke(new EventHandler (OnDataFormatting));   //chama outra thread para escrever o dado no text box
        }
        //Formats data received
        private void OnDataFormatting(object sender, EventArgs arg)
        {
            tempString = RxString.Split(';');
            int i = 0;
            foreach (string s in tempString)
            {
                tempString[i++] = s.Replace("\r", "");
            }
            ardData.Add( new ArduinoData()
            {
                Time =  tempString[0],
                IdSensor = tempString[1],
                Value = tempString[2]
            });

            this.Invoke(new EventHandler(OnDataOutputting));
        }
        //Shows data in the window
        private void OnDataOutputting (object sender, EventArgs arg)
        {
            int id = Int32.Parse(ardData[numElements].IdSensor);
            switch (id)
            {
                case 0:
                    SpeedSensor.Value = Single.Parse(ardData[numElements].Value);
                    SpeedSensor.DialText = SpeedSensor.Value.ToString();
                    break;
                case 1:
                    thermoDisplay1.Number = (int) Math.Round (Single.Parse(ardData[numElements].Value));
                break;
            
                
            }

            numElements++;
        }

        private Timer _timer = new Timer();
        private void InitializeThermometers()
        {
            for (int tempMark = 0; tempMark < 200; tempMark += 10)
            {
                this.thermoDisplay1.Label.Add(new MeterLabel(tempMark, tempMark.ToString()));
            }
        }
    }

}
