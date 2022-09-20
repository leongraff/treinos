Definir Data xDatIni;
Definir Data xDatFim;
Definir Data xDatAfa;
Definir Data xDatAfa;

MontaData (1, 1, 2021, xDatIni);
MontaData (31, 12, 2021, xDatFim);
xDatAfa = R034FUN.DATAFA;
xDatAdm = R034FUN.DATADM;
xCodFil = R034FUN.CODFIL;

xDiaA = 0;
xMesA = 0;
xDiaD = 0;
xMesD = 0;
xMeses = 0;
xMesesAux = 0;

@=== ALTERADA A DATA PARA 2021 CONFORME CHAMADO 37850 =========================@
@=== SE FOR DE OUTRA FILIAL OU DATA ADMISSÃO MAIOR QUE 2019, CANCELA ==========@
Se ((xDatAdm > xDatFim) ou ((xCodFil <> 5) e (xCodFil <> 7)))
{
  ValEvt = 0;
  RefEvt = 0;
}

@=== SENAO, FAZ O PAGAMENTO ===================================================@
Senao
INICIO
  RetSitEmp (R034FUN.NumEmp, R034FUN.TipCol, R034FUN.NumCad, xDatFim);
  xSitAfa = SitEmp;
  
  @=== Se colaborador não for desligado =======================================@
  Se (xSitAfa <> 7)
  INICIO
    @=== Se Admissão menor que data inicial ===@
    Se (xDatAdm <= xDatIni)
    {
      ValEvt = ValEvt;
      RefEvt = 12;
    }
    @=== Se Admissão maior que data inicial ===@
    Senao
    Se (xDatAdm > xDatIni)
    {
      DesMontaData (xDatAdm, xDiaA, xMesA, xLixo);
      
      @=== Se for admitido após dia 15, não paga o mês ===@
      Se (xDiaA > 15)
      {
        xMeses = 12 - xMesA;
      }
      @=== Se for admitido antes do dia 15, paga o mês ===@
      Senao
      Se (xDiaA <= 15)
      {
        xMeses = (12 - xMesA) + 1;
      }
      
      ValEvt = ValEvt / 12 * xMeses;
      RefEvt = xMeses;
    }
  FIM;
  @=== Se colaborador for desligado ===========================================@
  Se (xSitAfa = 7)
  INICIO
    DesMontaData (xDatAfa, xDiaD, xMesD, xLixo);
    DesMontaData (xDatAdm, xDiaA, xMesA, xLixo);
    
    @=== Se Admissão menor que data inicial ===@
    Se (xDatAdm <= xDatIni)
    {
      @=== SE DESLIGAMENTO FOI EM 2019 ===@
      Se (xDatAfa <= xDatFim)
      {
        Se (xDatAfa >= xDatIni)
        {
          @=== Se demissão maior que dia 15, paga o mês ===@
          Se (xDiaD > 15)
          {
            xMeses = xMesD;
          }
          @=== Se demissão menor que dia 15, não paga o mês ===@
          Senao
          Se (xDiaD <= 15)
          {
            xMeses = xMesD - 1;
          }
        }
        Senao
        Se (xDatAfa < xDatIni)
        {
          xMeses = 0;
        }
      }
      @=== SE DESLIGAMENTO FOI EM 2020 ===@
      Senao
      Se (xDatAfa > xDatFim)
      {
        xMeses = 12;
      }
      
       @=== SE DESLIGAMENTO FOI EM 2021 ===@
      Senao
      Se (xDatAfa > xDatFim)
      {
        xMeses = 12;
      }
      
      ValEvt = ValEvt / 12 * xMeses;
      RefEvt = xMeses;
    } 
    @=== Senão, Admissão maior que data inicial ===@
    Senao
    Se (xDatAdm > xDatIni)
    {
      @=== SE DESLIGAMENTO FOI EM 2019 ===@
      Se (xDatAfa <= xDatFim)
      {
        @=== Se demissão maior que dia 15, paga o mês ===@
        Se (xDiaD > 15)
        {
          xMesesAux = xMesD;
        }
        @=== Se demissão menor que dia 15, não paga o mês ===@
        Senao
        Se (xDiaD <= 15)
        {
          xMesesAux = xMesD - 1;
        }
      }
      @=== SE DESLIGAMENTO FOI EM 2020 ===@
      Senao
      Se (xDatAfa > xDatFim)
      {
        xMesesAux = 12;
      }
      
      @=== SE DESLIGAMENTO FOI EM 2021 ===@
      Senao
      Se (xDatAfa > xDatFim)
      {
        xMesesAux = 12;
      }
      
      @=== Se for admitido após dia 15, não paga o mês ===@
      Se (xDiaA > 15)
      {
        xMeses = xMesesAux - xMesA;
      }
      @=== Se for admitido antes do dia 15, paga o mês ===@
      Senao
      Se (xDiaA <= 15)
      {
        xMeses = (xMesesAux - xMesA) + 1;
      }
      
      ValEvt = ValEvt / 12 * xMeses;
      RefEvt = xMeses;
    } 
  FIM;
FIM;