Definir Alfa xNomLoc;
Definir Alfa xCodLoc;
Definir Alfa EDesNiv;
Definir Alfa xLocalAtual;
Definir Numero zEspLevel;

RetNomCodNiv(R034FUN.NUMEMP, R034FUN.TIPCOL, R034FUN.NUMCAD, 0, 1, EspNivTot, xNomLoc, xCodLoc);

Se (zEspLevel > 0)
Inicio
  Se (EDesNiv <> "C")
  Inicio
    PosicaoAlfa(",", xNomLoc, PosStr);
    Enquanto (PosStr > 0)
    Inicio
      DeletarAlfa (xNomLoc, 1, PosStr);
      PosicaoAlfa(",", xNomLoc, PosStr);
    Fim;
  Fim;
  xLocalAtual = xCodLoc + "  " + xNomLoc;
Fim;
Senao
  xLocalAtual = "Total dos Colaboradores";

ValStr = xLocalAtual;
Cancel(2);