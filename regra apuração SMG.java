@ -- Se for Aprendiz, cancela -- @
Se(R034FUN.TipCon = 6) // traz tempo de contrato
  Cancel(1);


Se(CodHor = 11) // traz codigo do horario
{
  Se(HorSit[105] <= 20)  @Se houver menos de 20 minutos saida intermediária;@  
  //Retorna a quantidade de horas da situação informada entre colchetes.
  {
    HorSit[001] = HorSit[001] + HorSit[105];
    HorSit[105] = 0;
  }
}

@ -- Verifica Marcações -- @
Definir Cursor Cur_R070ACC;  // tabela de registro de acesso
Definir Data dDatPro; // variavel que recebe a data de processamento
Definir Numero xHorAcc[12]; // horacc?

dDatPro = DatPro; // data do processamento
xInt1 = 0; // variaveis que controlam a quantidade de batidas?
xInt2 = 0;
xInt3 = 0;
xsit15 = 0;


xNumEmp = R034FUN.NumEmp; //numero empresa
xTipCol = R034FUN.TipCol; // tipo de colaborador 
xNumcad = R034FUN.NumCad; // numero de cadastro

xCont = 1; // contagem para o loop
xAuxCont = 0;
xDif = 0;

Cur_R070ACC.Sql " SELECT HORACC FROM R070ACC \
                   WHERE NUMEMP = :XNUMEMP \ 
                     AND TIPCOL = :XTIPCOL \
                     AND NUMCAD = :XNUMCAD \
                     AND DATACC = :DDATPRO \   
                     ORDER BY HORACC "
                                               @DATACC >> DATAPU@
Cur_R070ACC.AbrirCursor();
Enquanto(Cur_R070ACC.Achou)
{ // hora de acesso na data de processamento, pega a quantidade de marcações existentes no dia
  xHorAcc[xCont] = Cur_R070ACC.HorAcc; //hora do acesso [contagem do loop]
  xCont++;  
  
  Cur_R070ACC.Proximo();  
}
Cur_R070ACC.FecharCursor();  

xCont++;  

@ -- Verificar se tem quantidade impar de batidas, para transformar as situações em "Marcações Inválidas" -- @
xAuxCont = (xCont / 2);  
TruncarValor(xAuxCont);  
xDif = (xCont / 2) - xAuxCont;  


Se((xDif < 1) e (xDif <> 0))
{
  /*HorSit[999] = HorSit[1] + HorSit[15] + HorSit[101] + HorSit[103] + HorSit[105] + HorSit[301] + HorSit[303];
  
  HorSit[15] = 0;
  HorSit[103] = 0;
  HorSit[105] = 0;
  HorSit[101] = 0;

  HorSit[1] = 0;
  HorSit[301] = 0;
  HorSit[303] = 0;  
  */
  Cancel(1);
}
@Fim Marcações Inválidas@


Se(xCont <= 4) @ -- Se houver menos de 4 marcações, não gerará a regra -- @
{ 
  Cancel(1);
}

xInt1 = (xHorAcc[3] - xHorAcc[2]);

@ -- Se houver 5 marcações ou mais -- @
Se(xHorAcc[5] <> 0)
{
xInt2 = (xHorAcc[5] - xHorAcc[4]);
}

@ -- Se houver 7 marcações ou mais -- @
Se(xHorAcc[7] <> 0)
{
  xInt3 = (xHorAcc[7] - xHorAcc[6]);
}


@ -- Primeiro intervalo de Marcações -- @
Se((xInt1 >= 15) e (xInt1 < 30))
{
  HorSit[1] = HorSit[1] + 15;
  
    HorSit[15] = xInt1 - 15;
  
}
Senao Se (xInt1 < 15)
{
  HorSit[1] = HorSit[1] + xInt1;
  HorSit[105] = HorSit[105] - xInt1;
}

@ -- Segundo intervalo de Marcações -- @
Se((xInt2 >= 15) e (xInt2 < 30))
{
  HorSit[1] = HorSit[1] + 15;
  xsit15 =  xInt2 - 15;
  HorSit[15] = xsit15 + HorSit[15];

}                   
Senao Se ((xInt2 < 15) e (xInt2 <> 0))
{
  HorSit[1] = HorSit[1] + xInt2;
  Se(HorSit[105] <> 0)
  {
    HorSit[105] = HorSit[105] - 15;
  }
  Se((HorSit[101] <> 0) e (HorSit[105] = 0))
  {
    HorSit[101] = xInt2 - 15;
  } 
}

@ -- Terceiro intervalo de Marcações -- @
Se((xInt3 >= 15) e (xInt3 < 30))
{
  HorSit[1] = HorSit[1] + 15;
  xsit15 =  xInt3 - 15;
  HorSit[15] = xsit15 + HorSit[15];

}
Senao Se ((xInt3 < 15)  e (xInt3 <> 0))
{
  HorSit[1] = HorSit[1] + xInt3;
  HorSit[105] = HorSit[105] - xInt3;
}


Se(HorSit[1] > 528)
{
  @HorSit[303] = Horsit[1] - 528;@
  HorSit[1] = 528;
}

















 /*   
Se((Horsit[520] <> 0) ou (Horsit[521] <> 0))
{
  xValor = 0;
  xQtdBhr = 0;
  RetBHRDat(R034FUN.NumEmp,R034FUN.tipcol,R034FUN.numcad,2,DatPro,xQtdBhr);

  Se((xQtdBhr + Horsit[520] + (Horsit[521] * 1.4666)) > 1440)
  {
    Se(HorSit[520] <> 0)
    {
      xValor = (xQtdBhr + Horsit[520] + (Horsit[521] * 1.4666)) - 1440;
      ArredondarValor(xValor, 0);  
      HorSit[301]  = xValor;
      HorSit[520] = HorSit[520] - HorSit[301];
    }
    Se(HorSit[521] <> 0)
    {
      xValor = ((xQtdBhr + Horsit[520] + (Horsit[521] * 1.4666)) - 1440) / 1.4666;
      ArredondarValor(xValor, 0);
      HorSit[301]  = xValor;
      HorSit[521] = HorSit[521] - HorSit[301];

    }
  }
}  */