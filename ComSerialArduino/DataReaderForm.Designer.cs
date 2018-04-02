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
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM7";
            // 
            // BtConnect
            // 
            this.BtConnect.Location = new System.Drawing.Point(49, 489);
            this.BtConnect.Name = "BtConnect";
            this.BtConnect.Size = new System.Drawing.Size(154, 24);
            this.BtConnect.TabIndex = 0;
            this.BtConnect.Text = "Conectar";
            this.BtConnect.UseVisualStyleBackColor = true;
            this.BtConnect.Click += new System.EventHandler(this.BtConnect_OnClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(308, 490);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // timerCOM
            // 
            this.timerCOM.Interval = 1000;
            // 
            // SpeedSensor
            // 
            this.SpeedSensor.BackColor = System.Drawing.Color.Transparent;
            this.SpeedSensor.DialColor = System.Drawing.Color.LightSkyBlue;
            this.SpeedSensor.DialText = null;
            this.SpeedSensor.Glossiness = 11.36364F;
            this.SpeedSensor.Location = new System.Drawing.Point(362, 139);
            this.SpeedSensor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SpeedSensor.MaxValue = 200F;
            this.SpeedSensor.MinValue = 0F;
            this.SpeedSensor.Name = "SpeedSensor";
            this.SpeedSensor.RecommendedValue = 0F;
            this.SpeedSensor.Size = new System.Drawing.Size(200, 185);
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
            this.thermoDisplay1.IndicatorColor = System.Drawing.Color.DarkBlue;
            this.thermoDisplay1.LabelFont = new System.Drawing.Font("Courier New", 7F);
            this.thermoDisplay1.LabelFontColor = System.Drawing.Color.Black;
            this.thermoDisplay1.Location = new System.Drawing.Point(101, 117);
            this.thermoDisplay1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.thermoDisplay1.Marking = NextUI.Display.ThermoPanel.Marking.BOTH;
            this.thermoDisplay1.Name = "thermoDisplay1";
            this.thermoDisplay1.Number = 0;
            this.thermoDisplay1.Size = new System.Drawing.Size(102, 240);
            this.thermoDisplay1.TabIndex = 3;
            // 
            // DataReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.Controls.Add(this.thermoDisplay1);
            this.Controls.Add(this.SpeedSensor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtConnect);
            this.Name = "DataReaderForm";
            this.Text = "Arduino Data Reader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button BtConnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timerCOM;
        private AquaControls.AquaGauge SpeedSensor;
        private NextUI.Display.ThermoDisplay thermoDisplay1;
    }
}

