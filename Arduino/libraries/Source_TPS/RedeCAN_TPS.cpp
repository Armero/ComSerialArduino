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
Código do Throttle Position Sensor (TPS) para Arduino.

****************************************************************************************************************
*|Observações|* 

O valor de resistência do TPS utilizado varia entre: 1.5kohm e 2.6kohm.
 
Embora a tensão de referência no TPS seja 5V, observou-se os seguintes valores de tensão:
 
Borboleta totalmente fechada = 4.5V (Constante definida no header)
Borboleta totalmente aberta = 2.75V (Constante definida no header)
 
Aconselha-se a fazer uma aferição desses valores caso o código seja utilizado com outro corpo de aceleração.
****************************************************************************************************************
*/

#include "RedeCAN_TPS.h"

float tpsAcelerador(float tps){

	float percTps = 0; //Percentual de abertura da borboleta.
	float voltage = (TPS_VOLTAGE_MAX - TPS_VOLTAGE_MIN);
  
	float tpsValue = (tps* TPS_FATOR_AD) - TPS_VOLTAGE_MIN; // read the input on analog pin A0:
	/*Valor recebido pelo e convertido para volts e refereciado em relação a voltagem mínima.*/

	percTps = 100*(1 - ((tpsValue)/(voltage))); //Função de transferência
	
	if (percTps < 0)
		return (0); //Indica que a borboleta está fechada (Não fazer isso caso esteja usando num motor de verdade).
  
	/*A subtração acima foi necessária para inverter a ordem de amostragem da percetagem de abertura. 
	 * Se essa operação não fosse feita 100% indicaria borboleta totalmente fechada, não sendo muito intuitivo para o usuário.
	*/
  
	return(percTps);
}
