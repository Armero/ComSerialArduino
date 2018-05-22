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
Header do sensor LM35.
********************************************************
*/

//Constantes do sensor LM35
#define	LM35_DELAY					250
#define LM35_CELSIUS_BASE			0.4887585532746823069403714565 	//Conversão Digital-Analógico

#ifndef	HEADER_LM35_H
#define	HEADER_LM35_H

float 
lm35Temperature(float lm35);

#endif