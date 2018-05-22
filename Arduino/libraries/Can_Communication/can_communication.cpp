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
Funções relacionadas com a comunicação via rede can
********************************************************
*/
#include <can_communication.h>


//Input:
//int dado: o dado que se deseja passar pela rede
//MPC_CAN
//Retorna true se a mensagem foi enviada com sucesso
bool MandarDados (int dado, MCP_CAN canPort, int port)
{
    char charFloat[8];
    String stringFloat;
    byte byteDados [8];
    sprintf(charFloat, "%d", dado);
    stringFloat = charFloat;
    stringFloat.getBytes(byteDados, 8);
    bool dadoEnviado = false;

    byte sndStat = canPort.sendMsgBuf(port, 0, 8, byteDados);
	
	#if DEBUG_ENABLE
		for (int i = 0; i < 8; i++)
		{
			Serial.print ("Dado: ");
			Serial.println (dado);
			Serial.print ("Buffer ");
			Serial.print (i);
			Serial.print (" :");
			Serial.println (buffer[i]);
		}		
	#endif
		if(sndStat == CAN_OK){
		  Serial.println("Message Sent Successfully!");
		  dadoEnviado = true;
		} else {
		  Serial.println("Error Sending Message...");
		}
	
    delay(10);
    return (dadoEnviado);
}


void ReceberDados (char mensagem[128], unsigned char buf[8], float &valor)
{
    sprintf(mensagem, "%s", buf);
    String strTeste = mensagem;
    valor = strTeste.toFloat();
}


bool InicializarModulo (MCP_CAN canPort)
{
  if(canPort.begin(MCP_ANY, CAN_500KBPS, MCP_8MHZ) == CAN_OK) 
	  Serial.println("MCP2515 Initialized Successfully!");
  else 
	  Serial.println("Error Initializing MCP2515...");

  canPort.setMode(MCP_NORMAL); 
}
	