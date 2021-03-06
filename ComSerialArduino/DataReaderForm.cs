﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using NextUI.Collection;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace ComSerialArduino
{

    public partial class DataReaderForm : Form
    {
        private string RxString;
        private string[] tempString;
        private List<ArduinoData> ardData = new List<ArduinoData>();
        private int numElements  = 0;
        private int bRate = -1;
        private string fileName = Directory.GetCurrentDirectory() + "/data.csv";
        private const int SAVE_BUFFER_ELEMENTS = 100;
        StreamWriter file;

        public DataReaderForm()
        {
            InitializeComponent();
            InitializeThermometers();
            timerCOM.Enabled = true;
            UpdateComList();
            UpdateBaudRateList();
            serialPort1.DataReceived += SerialPort1_OnDataReceived;
            timerCOM.Tick += TimerCOM_OnTick;
            this.FormClosed += DataReaderForm_OnFormClosed;
            file = new StreamWriter(fileName, true);
        }

        //Updates list of COM ports available
        private void UpdateComList()
        {
            int i;
            bool diffCount;

            i = 0;
            diffCount = false;

            //If number of ports changed then enable Com port update
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

            //If difference was not found
            if (diffCount == false)
            {
                return;                     //retorna
            }

            comboBox1.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            comboBox1.SelectedIndex = 0;

        }
        //Calls UpdateComList after a defined time
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
                    if (bRate == -1)
                    {
                        MessageBox.Show("Select Baud Rate first");
                    }
                    else
                    {
                        serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        serialPort1.BaudRate = bRate;
                        serialPort1.Open();
                    }
                }
                catch
                {
                    return;

                }
                if (serialPort1.IsOpen)
                {
                    BtConnect.Text = "Desconectar";
                    comboBox1.Enabled = false;
                    BaudRateList.Enabled = false;
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

            if (numElements != 0)
            {
                SaveDataIntoFile(numElements);
            }

            file.Close();
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

            if (tempString[0] != "" && i == 3)
            {
                ardData.Add(new ArduinoData()
                {
                    Time = tempString[0],
                    IdSensor = tempString[1],
                    Value = tempString[2]
                });

                this.Invoke(new EventHandler(OnDataOutputting));
            }   
        }
        //Shows data in the window
        private void OnDataOutputting (object sender, EventArgs arg)
        {
            try
            {
                int id = Int32.Parse(ardData[numElements].IdSensor);
                int val = (int)Math.Round(Single.Parse(ardData[numElements].Value));
                switch (id)
                {
                    case 0:
                        SpeedSensor.Value = val;
                        SpeedSensor.DialText = SpeedSensor.Value.ToString();
                        break;
                    case 1:
                        thermoDisplay1.Number = val;
                        break;
                    case 2:
                        //thermoDisplay4.Number = val;
                        break;
                    case 3:
                        thermoDisplay3.Number = val;
                        break;
                    case 4:
                        progressBar1.Value = val;
                        progressBarValue.Text = val.ToString();
                        break;
                    default:
                        MessageBox.Show("Sensor not listed");
                        break;

                }
                numElements++;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
        }

        private Timer _timer = new Timer();

        //Generate Divisions for Thermomethers
        private void InitializeThermometers()
        {
            int MINTEMP = Int32.Parse(ConfigurationManager.AppSettings["MinTemp"]);
            int MAXTEMP = Int32.Parse(ConfigurationManager.AppSettings["MaxTemp"]);
            for (int tempMark = MINTEMP; tempMark <= MAXTEMP; tempMark += 1)
            {
                this.thermoDisplay1.Label.Add(new MeterLabel(tempMark, tempMark.ToString()));
                this.thermoDisplay3.Label.Add(new MeterLabel(tempMark, tempMark.ToString()));
                //this.thermoDisplay4.Label.Add(new MeterLabel(tempMark, tempMark.ToString()));
            }
        }
        private void UpdateBaudRateList()
        {
            string bTextTemp = ConfigurationManager.AppSettings["BaudRateList"];
            string[] bText = bTextTemp.Split(';');

            foreach (string s in bText)
            {
                BaudRateList.Items.Add(s);
            }
        }

        private void BaudRateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(BaudRateList.SelectedItem.ToString(), out bRate) == false)
            {
                bRate = -1;
            }
        }

        private void SaveDataIntoFile (int numElements)
        {
            int counter = 0;
            foreach (ArduinoData ad in this.ardData)
            {
                file.Write(ad.printData());
                counter++;
            }
        }
    }

}
