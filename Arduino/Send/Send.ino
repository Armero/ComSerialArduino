/*
Universidade Federal do Rio de Janeiro (UFRJ)
Escola Politécnica
Departamento de Engenharia Eletrônica e de Computação (DEL)
Projeto Integrado 2018.1

REDE CAN PARA CARROS DE FÓRMULA SAE
********************************************************

Grupo:
Daywson Chermont
Felipe Cláudio
Yan Nascimento
********************************************************

*| Descrição |*
Código do programa principal para Rede CAN.
********************************************************

*/

#include <OneWire.h> /*Biblioteca utilizada pelo sensor DS18B20.*/
#include <DallasTemperature.h> /*Biblioteca utilizada pelo sensor DS18B20.*/
#include <can_communication.h>
#include <RedeCAN_Hall.h>
#include <RedeCAN_LM35.h>
#include <RedeCAN_TPS.h>
 

/*DEFINIÇÕES DA PORTAS UTILIZADAS NO ARDUINO*/
int LM35_PORTA = 0;//PORTA ANALÓGICA - Constante para definir a porta analógica a ser utilizada.
int TPS_PORTA = 3;//PORTA ANALÓGICA - Constante para definir a porta analógica a ser utilizada.
int HALL_PORTA = 3;//PORTA DIGITAL - Constante para definir a porta analógica a ser utilizada.
int DS18B20_PORTA = 5;//PORTA DIGITAL - Constante para definir a porta digital a ser utilizada.
int HALL_INTERRUPT = 1; //PORTA DE INTERRUPÇÃO - Utiliza para fazer a contagem do número de vcs q o imã para pelo sensor hall

volatile float hallCiclos = 0; //SENSOR HALL - Contador de ciclos.
volatile float hallAux = 0; // SENSOR HALL - Utilizado para salvar o RPM após o contator ser zerado.
float tempDs18b20 = 0;//SENSOR DS18B20 - Variável utilizada para salvar a temperatura obtida pelo sensor.

const int MAIN_DELAY = 10; /*Delay definido para o MC2515.*/

MCP_CAN CAN0(10);     // Set CS to pin 10
String texto;
char dado[8];
byte data2 [8];

/*Tipos utilizados pelo sensor DS18B20*/
OneWire oneWire(DS18B20_PORTA);
DallasTemperature sensors(&oneWire);
DeviceAddress ds18b20;  


void setup() {
  Serial.begin(115200);
  
  sensors.begin(); /*Função utilizada pelo sensor DS18B20.*/
  sensors.getAddress(ds18b20,0); 
  
  pinMode(HALL_PORTA,LOW); //SENSOR HALL - Configura a Porta Digital para nível baixo
  attachInterrupt(1,magnet_detect, CHANGE); //SENSOR HALL - Utiliza para contagem de vez que o imã passa pelo sensor. 

/* || INÍCIO DO BLOCO DO MÓDULO MC2515 ||*/ 
  
  InicializarModulo(CAN0);

/* || FIM DO BLOCO DO MÓDULO MC2515 ||*/ 
  
  Serial.print("Universidade Federal do Rio de Janeiro - UFRJ\n");
  Serial.print("Escola Politécnica\n");
  Serial.print("Departamento de Engenharia Eletrônica e de Computação - DEL\n");
  Serial.print("Projeto integrado - 20018.1\n");
  Serial.print("Rede CAN para Carros de Formula SAE\n");
  Serial.print("Grupo:Daywson Chermont, Felipe Cláudio e Yan Nascimento\n\n");
}

void loop() {

  float lm35_porta = analogRead(LM35_PORTA);
  float tps_porta = analogRead(TPS_PORTA);
  
  Serial.print("CICLOS: "); /*DEBUG*/
  Serial.print(hallCiclos,0);
  
  /*SENSOR LM35 - TEMPERATURA*/
  Serial.print("LM35: Temperatura: ");
  float lm35 = lm35Temperature(lm35_porta);
  Serial.print(lm35,2);
  Serial.print(" °C                ");  
  
  /*THROTTLE POSITION SENSOR (TPS)*/
  Serial.print("Borboleta: ");
  float tps = tpsAcelerador(tps_porta);
  Serial.print(tps,0);
  Serial.print(" % Aberta              ");
  
  /*SENSOR HALL - RPM E VELOCIDADE*/
  Serial.print("RPM = ");
    if (hallCiclos >= HALL_CICLOS){
      hallAux = hallRotacao(hallCiclos);
      Serial.print(hallAux,0);
      Serial.print("                 ");
      hallCiclos = 0; //Sensor Hall - Zerando o contador
    }
    else{
      Serial.print(hallAux,0); //Para evitar que o print do RPM não dependa da rotação do objeto.
      Serial.print("                 ");
    }      
    
  /*SENSOR DS18B20 - TEMPERATURA DA ÁGUA*/
  sensors.requestTemperatures();
  tempDs18b20 = sensors.getTempC(ds18b20);
  Serial.print("DS18B20 - Temperatura: ");
  Serial.print(tempDs18b20);
  Serial.print(" ºC     \n\n");

/* || INÍCIO DO BLOCO DO MÓDULO MC2515 ||*/ 
  // send data:  ID = 0x100, Standard CAN Frame, Data length = 8 bytes, 'data' = array of data bytes to send
  
  MandarDados (lm35, CAN0, 0x100);
  MandarDados (tps, CAN0, 0x200);
  MandarDados (hallAux, CAN0, 0x300);
  MandarDados (tempDs18b20, CAN0, 0x400);

/* || FIM DO BLOCO DO MÓDULO MC2515 ||*/ 
}

//Sensor Hall - Função para o contator
void magnet_detect(){
    hallCiclos++;  
 }

/*********************************************************************************************************
  END FILE
*********************************************************************************************************/

