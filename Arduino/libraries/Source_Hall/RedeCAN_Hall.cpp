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
Código do sensor Hall para Arduino.

*******************************************************************************************
Codigo baseado no exemplo do site Arduino Playground

http://playground.arduino.cc/Main/ReadingRPM

M44 ------- Arduino
Red wire ------------------ 5.0V
Black wire ------------------ GND
Blue wire ------------------ Sinal (Qualquer entrada Digital do Arduino)

Nenhuma biblioteca adicional foi utilizada

*/

#include "RedeCAN_Hall.h"
#include "Arduino.h"

volatile float hallRpm = 0;
volatile float hallRpmAux = 0;
float hallEndTime = 0;
const float pi = HALL_PI;
const float raio = HALL_RAIO_RODA;

float
hallRotacao(float hallCiclos){

   hallRpm = 2*(30*1000/(millis() - hallEndTime)*hallCiclos);
   hallEndTime = millis();
   
   return(hallRpm);
}


