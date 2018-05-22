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
Código de temperatura LM35 para Arduino.
********************************************************

Código baseado no modelo usado pelo site .....

O sensor LM35 é usado para medir a temperatura do ar na entrada e saída do sidepod.
*/

#include "RedeCAN_LM35.h"

float lm35Temperature(float lm35){
	return (lm35 * LM35_CELSIUS_BASE);
}
