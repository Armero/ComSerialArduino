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

#ifndef _INT_COM_H_
#define _INT_COM_H_
#include <Arduino.h>

typedef enum tipoSensores {HALL = 0x300, TEMP_DIR = 0x100, TEMP_CEN = 0x500, TEMP_ESQ = 0x400, HOR_BAR = 0x200} TIPOSENSORES;

void EnviarDadosInterface (int sensor, int valor, int decimal);
#endif