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
Header do sensor hall
********************************************************
*/

#include "Arduino.h"

//Constantes do sensor Hall
#define HALL_PI 					3.1415
#define HALL_RAIO_RODA				0.26 	//Unidade em metros
#define HALL_DELAY					250
#define HALL_CICLOS					5

#ifndef	HEADER_HALL_H
#define	HEADER_HALL_H

float
hallRotacao(volatile float hallCiclos);

#endif