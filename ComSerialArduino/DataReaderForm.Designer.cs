namespace ComSerialArduino
{
    partial class DataReaderForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BtConnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timerCOM = new System.Windows.Forms.Timer(this.components);
            this.SpeedSensor = new AquaControls.AquaGauge();
            this.thermoDisplay1 = new NextUI.Display.ThermoDisplay();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.thermoDisplay3 = new NextUI.Display.ThermoDisplay();
            this.BaudRateList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBarValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM7";
            // 
            // BtConnect
            // 
            this.BtConnect.Location = new System.Drawing.Point(55, 611);
            this.BtConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtConnect.Name = "BtConnect";
            this.BtConnect.Size = new System.Drawing.Size(173, 30);
            this.BtConnect.TabIndex = 0;
            this.BtConnect.Text = "Conectar";
            this.BtConnect.UseVisualStyleBackColor = true;
            this.BtConnect.Click += new System.EventHandler(this.BtConnect_OnClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(328, 611);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Select a Value";
            // 
            // timerCOM
            // 
            this.timerCOM.Interval = 1000;
            // 
            // SpeedSensor
            // 
            this.SpeedSensor.AutoSize = true;
            this.SpeedSensor.BackColor = System.Drawing.Color.Transparent;
            this.SpeedSensor.DialColor = System.Drawing.Color.LightBlue;
            this.SpeedSensor.DialText = null;
            this.SpeedSensor.Glossiness = 11.36364F;
            this.SpeedSensor.Location = new System.Drawing.Point(386, 145);
            this.SpeedSensor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpeedSensor.MaxValue = 6000F;
            this.SpeedSensor.MinValue = 0F;
            this.SpeedSensor.Name = "SpeedSensor";
            this.SpeedSensor.RecommendedValue = 0F;
            this.SpeedSensor.Size = new System.Drawing.Size(225, 225);
            this.SpeedSensor.TabIndex = 2;
            this.SpeedSensor.ThresholdPercent = 0F;
            this.SpeedSensor.Value = 0F;
            // 
            // thermoDisplay1
            // 
            this.thermoDisplay1.Alignment = NextUI.Display.ThermoPanel.Alignment.left;
            this.thermoDisplay1.BackGrdColor = System.Drawing.Color.LightGray;
            this.thermoDisplay1.BackGroundImage = null;
            this.thermoDisplay1.Flip = NextUI.Display.ThermoPanel.Flip.right;
            this.thermoDisplay1.IndicatorColor = System.Drawing.Color.Blue;
            this.thermoDisplay1.LabelFont = new System.Drawing.Font("Courier New", 7F);
            this.thermoDisplay1.LabelFontColor = System.Drawing.Color.Black;
            this.thermoDisplay1.Location = new System.Drawing.Point(183, 114);
            this.thermoDisplay1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thermoDisplay1.Marking = NextUI.Display.ThermoPanel.Marking.BOTH;
            this.thermoDisplay1.Name = "thermoDisplay1";
            this.thermoDisplay1.Number = 0;
            this.thermoDisplay1.Size = new System.Drawing.Size(115, 300);
            this.thermoDisplay1.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(71, 471);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(518, 52);
            this.progressBar1.TabIndex = 7;
            // 
            // thermoDisplay3
            // 
            this.thermoDisplay3.Alignment = NextUI.Display.ThermoPanel.Alignment.left;
            this.thermoDisplay3.BackGrdColor = System.Drawing.Color.LightGray;
            this.thermoDisplay3.BackGroundImage = null;
            this.thermoDisplay3.Flip = NextUI.Display.ThermoPanel.Flip.right;
            this.thermoDisplay3.IndicatorColor = System.Drawing.Color.Blue;
            this.thermoDisplay3.LabelFont = new System.Drawing.Font("Courier New", 7F);
            this.thermoDisplay3.LabelFontColor = System.Drawing.Color.Black;
            this.thermoDisplay3.Location = new System.Drawing.Point(37, 112);
            this.thermoDisplay3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thermoDisplay3.Marking = NextUI.Display.ThermoPanel.Marking.BOTH;
            this.thermoDisplay3.Name = "thermoDisplay3";
            this.thermoDisplay3.Number = 0;
            this.thermoDisplay3.Size = new System.Drawing.Size(115, 300);
            this.thermoDisplay3.TabIndex = 10;
            // 
            // BaudRateList
            // 
            this.BaudRateList.FormattingEnabled = true;
            this.BaudRateList.Location = new System.Drawing.Point(478, 611);
            this.BaudRateList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BaudRateList.Name = "BaudRateList";
            this.BaudRateList.Size = new System.Drawing.Size(110, 28);
            this.BaudRateList.TabIndex = 16;
            this.BaudRateList.Text = "Select a value";
            this.BaudRateList.SelectedIndexChanged += new System.EventHandler(this.BaudRateList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "BAUD RATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "SERIAL PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "TACHOMETER-RPM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "TPS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "LM35";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "DS18B20";
            // 
            // progressBarValue
            // 
            this.progressBarValue.Location = new System.Drawing.Point(449, 429);
            this.progressBarValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBarValue.Name = "progressBarValue";
            this.progressBarValue.Size = new System.Drawing.Size(112, 26);
            this.progressBarValue.TabIndex = 27;
            // 
            // DataReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 688);
            this.Controls.Add(this.progressBarValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BaudRateList);
            this.Controls.Add(this.thermoDisplay3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.thermoDisplay1);
            this.Controls.Add(this.SpeedSensor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtConnect);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataReaderForm";
            this.Text = "Arduino Data Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button BtConnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timerCOM;
        private AquaControls.AquaGauge SpeedSensor;
        private NextUI.Display.ThermoDisplay thermoDisplay1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private NextUI.Display.ThermoDisplay thermoDisplay3;
        private System.Windows.Forms.ComboBox BaudRateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox progressBarValue;
    }
}

