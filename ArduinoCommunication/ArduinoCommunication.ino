
char *valor = new char [10];
int timer;
//String spc;

void setup()
{

  Serial.begin  (9600);
  timer     =250;
}

void loop()
{
  
  for (int i = 0; i < 10; i++)
  {
    sprintf(valor, "%d\n", i);
    Serial.write(valor);
    Serial.flush();
  }
  //Serial.println  ( d3+spc+d4+spc+d5+spc+d6 );
  delay           (timer);
}
