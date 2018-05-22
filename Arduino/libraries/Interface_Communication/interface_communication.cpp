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
Funções relacionadas com a comunicação com a interface
********************************************************
*/
#include <interface_communication.h>

void EnviarDadosInterface (int sensor, int valor, int decimal)
{
	int idSensor = -1;
	
	switch ((TIPOSENSORES) sensor)
	{
		case (HALL):
			idSensor = 0;
		break;
		case (TEMP_DIR):
			idSensor = 1;
		break;
		case (TEMP_CEN):
			idSensor = 2;
		break;
		case (TEMP_ESQ):
			idSensor = 3;
		break;
		case (HOR_BAR):
			idSensor = 4;
		break;
		default:
			idSensor = -1;
	}
	
    char dado[100];
    sprintf(dado, "%lu;%u;%d,%d", millis(), idSensor, valor, decimal);
    Serial.println(dado);
    Serial.flush();
    delay(10);
}