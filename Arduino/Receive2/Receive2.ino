// CAN Receive Example

#include "can_communication.h"
#include "interface_communication.h"

long unsigned int rxId;
unsigned char len = 0;
unsigned char rxBuf[8];
char msgString[128];                        // Array to store serial string
float valor;
bool estadoVentoinha;

#define PORTA_VENTOINHA 4

#define CAN0_INT 2                              // Set INT to pin 2
MCP_CAN CAN0(10);                               // Set CS to pin 10

void ControlarTemperatura(int valor, bool &estadoVentoinha, unsigned porta)
{
  const float minTemp = 28;
  const float maxTemp = 32;

  if ((valor < minTemp) && (estadoVentoinha == true) )
  {
    Serial.println("Desliga Ventoinha");
    digitalWrite(porta, LOW);
    estadoVentoinha = false;
  }
  if ((valor > maxTemp) && (estadoVentoinha == false) )
  {
    Serial.println("Liga a Ventoinha");
    digitalWrite(porta, HIGH);
    estadoVentoinha = true;
  } 
}

void setup()
{
  Serial.begin(115200);
  
  // Initialize MCP2515 running at 16MHz with a baudrate of 500kb/s and the masks and filters disabled.
  InicializarModulo(CAN0);
  CAN0.setMode(MCP_NORMAL);                     // Set operation mode to normal so the MCP2515 sends acks to received data.
  pinMode(CAN0_INT, INPUT);                            // Configuring pin for /INT input
  pinMode (PORTA_VENTOINHA, OUTPUT);
}

void loop()
{
  if(!digitalRead(CAN0_INT))                         // If CAN0_INT pin is low, read receive buffer
  {
    CAN0.readMsgBuf(&rxId, &len, rxBuf);      // Read data: len = data length, buf = data byte(s)
    if((rxId & 0x80000000) == 0x80000000)     // Determine if ID is standard (11 bits) or extended (29 bits)
      sprintf(msgString, "Extended ID: 0x%.8lX  DLC: %1d  Data:", (rxId & 0x1FFFFFFF), len);
    else
      sprintf(msgString, "Standard ID: 0x%.3lX       DLC: %1d  Data:", rxId, len);
  
    if((rxId & 0x40000000) == 0x40000000){    // Determine if message is a remote request frame.
      sprintf(msgString, " REMOTE REQUEST FRAME");
    } else {
        ReceberDados(msgString, rxBuf, valor);
        EnviarDadosInterface (rxId, (int)valor , 0);
        if ( (rxId == TEMP_DIR) || (rxId == TEMP_CEN) || (rxId == TEMP_DIR))
          ControlarTemperatura ((int)valor, estadoVentoinha, PORTA_VENTOINHA);  
    }
    //Serial.println();
  }
}

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/
