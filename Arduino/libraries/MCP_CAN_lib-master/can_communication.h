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
Header das funções relacionadas com a comunicação via rede can
********************************************************
*/
#ifndef _CAN_COM_H_
#define _CAN_COM_H_

#include <Arduino.h>
#include <mcp_can.h>
#include <SPI.h>

#define MCP_DELAY 10 //tempo entre cada dado enviado

/*
Input:
	int dado: o dado que se deseja passar pela rede
	MPC_CAN: Módulo can que será utilzado
	int: ID do sensor responsável por mandar a mensagem
Output: 
	true se a mensagem foi enviada com sucesso
*/

bool MandarDados (int dado, MCP_CAN canPort, int id);
void ReceberDados (char mensagem[128], unsigned char buf[8], float &valor);
bool InicializarModulo (MCP_CAN canPort);

#endif
