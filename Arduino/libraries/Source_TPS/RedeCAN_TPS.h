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
Header do TPS.
********************************************************
*/

//Constantes do sensor TPS

#define TPS_VOLTAGE_MAX				4.5 	//Unidade em Volts
#define TPS_VOLTAGE_MIN				2.75 	//Unidade em Volts
#define TPS_DELAY					250
#define TPS_FATOR_AD				0.004887585532746823069403714565 	//Conversão Digital-Analógico

#ifndef	_TPS_H
#define	_TPS_H

float 
tpsAcelerador(float tps);

#endif