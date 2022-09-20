@==============================================================================@
@=== Regra de apuração converte as situações de H.E conforme tabela abaixo: ===@
@=== Até 31 H.E 55% (421 diurna e 422 Noturna)                              ===@
@=== de 31:01 a 46 60% (413 diurna e 414 Noturna)                           ===@
@=== de 46:01 acima 100% (303 diurna e 304 Noturna)                         ===@
@==============================================================================@
@=== Duas condições para a regra funcionar adequadamente:                   ===@
@=== 1- A situação de H.E em dia "normal" (exceção de DSRS e Feriados) deve ===@
@===    ser a situação 421 e 422 H.E 55%                                    ===@
@=== 2- Caso seja feito qualquer ajuste do ponto, que influêncie as H.E,    ===@
@===    todos os dias posteriores devem ser reapurados                      ===@
@==============================================================================@
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Numero xQtdHor;

Definir Data xDatAnt;
Definir Data xIniApu;

Definir Cursor Cur_R066SIT;
Definir Cursor Cur_R038HSI;

xNumEmp = R034FUN.NumEmp;
xTipCol = R034FUN.TipCol;
xNumCad = R034FUN.NumCad;
xDatAnt = DatPro - 1;
xIniApu = IniApu;
xQtdHor = 0;
xCodSin = 0;

@ -- Verifica qual é o sindicato do colaborador -- @
Cur_R038HSI.Sql " SELECT CODSIN, DATALT FROM R038HSI \
                   WHERE NUMEMP = :XNUMEMP \
                     AND TIPCOL = :XTIPCOL \
                     AND NUMCAD = :XNUMCAD \
                     ORDER BY DATALT DESC "
                     
Cur_R038HSI.AbrirCursor();
Se(Cur_R038HSI.Achou)
{
  xCodSin = Cur_R038HSI.CodSin;
}
Cur_R038HSI.FecharCursor();

@ ### Se for Sindicato 10, pagará no mês ### @
Se(xCodSin = 10)
{
@=== Busca soma das situações de H.E ===@
Cur_R066SIT.SQL "SELECT R066SIT.QtdHor                                         \
                   FROM R066SIT                                                \
                  WHERE 1 = 2                                                  \
                  UNION                                                        \
                 SELECT SUM(R066SIT.QtdHor)                                    \
                   FROM R066SIT                                                \
                  WHERE R066SIT.NumEmp = :xNumEmp                              \
                    AND R066SIT.TipCol = :xTipCol                              \
                    AND R066SIT.NumCad = :xNumCad                              \
                    AND R066SIT.DatApu >= :xIniApu                             \
                    AND R066SIT.DatApu <= :xDatAnt                             \
                    AND R066SIT.CodSit IN (421,422,413,414,303,304)";
                    
Cur_R066SIT.AbrirCursor();
Se(Cur_R066SIT.Achou){
  xQtdHor = Cur_R066SIT.QtdHor;
}
Cur_R066SIT.FecharCursor();

@=== Com a soma das situações de H.E compara com as extras do dia calcula ===@
Se(xQtdHor > 2760){ @=== Se for maior que 46 horas, considera 100% ===@
  @=== H.E Diurna ===@
  HorSit[303] = HorSit[303] + HorSit[421];
  @=== H.E Noturna ===@
  HorSit[304] = HorSit[304] + HorSit[422];
  @=== Limpa a situação de 55% ===@
  HorSit[421] = 0;
  HorSit[422] = 0;
}
@=== Se for menor que 46 horas, e maior que 31 ===@
Senao Se((xQtdHor < 2760) e (xQtdHor > 1860)) { 
  @=== Trata a 55% diurna ===@
  Se(HorSit[421] > 0){
    @=== Verifica se a soma das horas mas a situação normal ultrapassa 46 ===@
    Se((xQtdHor + HorSit[421]) > 2760){
      @=== Se for maior então considera a diferença como 60% e o resto 100% ===@
      xDif60 = 2760 - xQtdHor;
      xDif100 = HorSIt[421] - xDif60;
      
      @=== Incrementa o total de horas ===@
      xQtdHor = xQtdHor + HorSit[421];
      
      @=== Salva nas situações de H.E ===@
      HorSit[413] = HorSit[413] + xDif60;
      HorSit[303] = HorSit[303] + xDif100;
      
      @=== Limpa a 55% Diurna ===@
      HorSit[421] = 0;
    } 
    Senao {
      @=== Se não ultrapassar 46 horas é 60% ===@
      HorSit[413] = HorSit[413] + HorSit[421];
      
      @=== Incrementa o total de horas ===@
      xQtdHor = xQtdHor + HorSit[421];
      
      @=== Limpa 50% Diurna ===@
      HorSit[421] = 0;
     }     
  }  
  
  @=== Trata 55% Noturna ===@                                                     
  Se(HorSit[422] > 0){
    
    @=== Verifica se já é maior que 46 ===@
    Se(xQtdHor > 2760){
      @=== Soma tudo em 100% Noturna ===@
      HorSit[304] = HorSit[304] + HorSit[422];
      HorSit[422] = 0;
    }
    @=== Verifica se a soma das horas com as horas noturnas é maior que 46 ===@
    Senao Se((xQtdHor + HorSit[422]) > 2760){
      @=== Se for maior a diferença em 60% noturna e o excedente em 100% noturna ===@
      xDif60 = 2760 - xQtdHor;
      xDif100 = HorSit[422] - xDif60;
      
      @=== Soma o total de horas ===@
      xQtdHor = HorSit[422];
      
      @=== Salva valores nas situações corretas ===@
      HorSit[414] = HorSit[414] + xDif60;
      HorSit[304] = HorSit[304] + xDif100;
      
      @=== Limpa a 55% noturna ===@
      HorSit[422] = 0;
    }
    Senao {
      @=== Se não for maior é 60% noturna ===@
      HorSit[414] = HorSit[414] + HorSit[422];
      
      @=== Limpa 55% Noturna ===@
      HorSit[422] = 0;
    }
  }
}
@=== Se a soma das situações com o saldo do perído for maior que 31 h.e ===@
Senao Se((xQtdHor + HorSit[421] + HorSit[422]) > 1860){
  @=== Valida H.E 55 Diurna ===@
  Se(HorSit[421] > 0){
    @=== Se somado com diurna é maior que 31 horas ===@
    Se((xQtdHor + HorSit[421]) > 1860){
      @=== Separa horas 55% e 60% ===@
      xDif55 = 1860 - xQtdHor;
      xDif60 = HorSit[421] - xDif55;
      
      @=== Soma total de horas ===@
      xQtdHor = xQtdHor + HorSit[421];
      
      @=== Salva H.E ===@
      HorSit[421] = xDif55; @=== aqui não soma porque a 421 já é a padrão ===@
      HorSit[413] = HorSit[413] + xDif60;
    }
    Senao {
      @=== Se não for maior só soma na quantidade de horas ===@
      xQtdHor = xQtdHor + HorSit[421];
    }
  }
  
  @=== Valida 55 Noturna ===@
  Se(HorSit[422] > 0){
    Se(xQtdHor > 1860){
      @=== Se for maior é 60% noturna ===@
      HorSit[414] = HorSit[414] + HorSit[422];
      HorSit[422] = 0;
    }
    Senao Se((xQtdHor + HorSit[422] > 1860)){
      @=== Separa horas 55% e 60% ===@
      xDif55 = 1860 - xQtdHor;
      xDif60 = HorSit[422] - xDif55;
      
      @=== Soma total de horas ===@
      xQtdHor = xQtdHor + HorSit[422];
      
      @=== Salva H.E ===@
      HorSit[422] = xDif55; @=== aqui não soma porque a 422 já é a padrão ===@
      HorSit[414] = HorSit[414] + xDif60;
    }   @=== Não precisa de senão, se não for maior já era diurna ===@
  }
}
}
Senao
{
@==============================================================================@
@=== Regra de apuração converte as situações de H.E conforme tabela abaixo: ===@
@=== Até 31 H.E 55% (423 diurna e 424 Noturna)                              ===@
@=== de 31:01 a 46 60% (417 diurna e 418 Noturna)                           ===@
@=== de 46:01 acima 100% (403 diurna e 404 Noturna)                         ===@
@==============================================================================@
@=== Duas condições para a regra funcionar adequadamente:                   ===@
@=== 1- A situação de H.E em dia "normal" (exceção de DSRS e Feriados) deve ===@
@===    ser a situação 423 e 424 H.E 55%                                    ===@
@=== 2- Caso seja feito qualquer ajuste do ponto, que influêncie as H.E,    ===@
@===    todos os dias posteriores devem ser reapurados                      ===@
@==============================================================================@
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Numero xQtdHor;

Definir Data xDatAnt;
Definir Data xIniApu;

Definir Cursor Cur_R066SIT;

xNumEmp = R034FUN.NumEmp;
xTipCol = R034FUN.TipCol;
xNumCad = R034FUN.NumCad;
xDatAnt = DatPro - 1;
xIniApu = IniApu;
xQtdHor = 0;

@=== Busca soma das situações de H.E ===@
Cur_R066SIT.SQL "SELECT R066SIT.QtdHor                                         \
                   FROM R066SIT                                                \
                  WHERE 1 = 2                                                  \
                  UNION                                                        \
                 SELECT SUM(R066SIT.QtdHor)                                    \
                   FROM R066SIT                                                \
                  WHERE R066SIT.NumEmp = :xNumEmp                              \
                    AND R066SIT.TipCol = :xTipCol                              \
                    AND R066SIT.NumCad = :xNumCad                              \
                    AND R066SIT.DatApu >= :xIniApu                             \
                    AND R066SIT.DatApu <= :xDatAnt                             \
                    AND R066SIT.CodSit IN (423,424,417,418,403,404)";
                    
Cur_R066SIT.AbrirCursor();
Se(Cur_R066SIT.Achou){
  xQtdHor = Cur_R066SIT.QtdHor;
}
Cur_R066SIT.FecharCursor();

@=== Com a soma das situações de H.E compara com as extras do dia calcula ===@
Se(xQtdHor > 2760){ @=== Se for maior que 46 horas, considera 100% ===@
  @=== H.E Diurna ===@
  HorSit[403] = HorSit[403] + HorSit[423];
  @=== H.E Noturna ===@
  HorSit[404] = HorSit[404] + HorSit[424];
  @=== Limpa a situação de 55% ===@
  HorSit[423] = 0;
  HorSit[424] = 0;
}
@=== Se for menor que 46 horas, e maior que 31 ===@
Senao Se((xQtdHor < 2760) e (xQtdHor > 1860)) { 
  @=== Trata a 55% diurna ===@
  Se(HorSit[423] > 0){
    @=== Verifica se a soma das horas mas a situação normal ultrapassa 46 ===@
    Se((xQtdHor + HorSit[423]) > 2760){
      @=== Se for maior então considera a diferença como 60% e o resto 100% ===@
      xDif60 = 2760 - xQtdHor;
      xDif100 = HorSIt[423] - xDif60;
      
      @=== Incrementa o total de horas ===@
      xQtdHor = xQtdHor + HorSit[423];
      
      @=== Salva nas situações de H.E ===@
      HorSit[417] = HorSit[417] + xDif60;
      HorSit[403] = HorSit[403] + xDif100;
      
      @=== Limpa a 55% Diurna ===@
      HorSit[423] = 0;
    } 
    Senao {
      @=== Se não ultrapassar 46 horas é 60% ===@
      HorSit[417] = HorSit[417] + HorSit[423];
      
      @=== Incrementa o total de horas ===@
      xQtdHor = xQtdHor + HorSit[423];
      
      @=== Limpa 50% Diurna ===@
      HorSit[423] = 0;
     }     
  }  
  
  @=== Trata 55% Noturna ===@                                                     
  Se(HorSit[424] > 0){
    
    @=== Verifica se já é maior que 46 ===@
    Se(xQtdHor > 2760){
      @=== Soma tudo em 100% Noturna ===@
      HorSit[404] = HorSit[404] + HorSit[424];
      HorSit[424] = 0;
    }
    @=== Verifica se a soma das horas com as horas noturnas é maior que 46 ===@
    Senao Se((xQtdHor + HorSit[424]) > 2760){
      @=== Se for maior a diferença em 60% noturna e o excedente em 100% noturna ===@
      xDif60 = 2760 - xQtdHor;
      xDif100 = HorSit[424] - xDif60;
      
      @=== Soma o total de horas ===@
      xQtdHor = HorSit[424];
      
      @=== Salva valores nas situações corretas ===@
      HorSit[418] = HorSit[418] + xDif60;
      HorSit[404] = HorSit[404] + xDif100;
      
      @=== Limpa a 55% noturna ===@
      HorSit[424] = 0;
    }
    Senao {
      @=== Se não for maior é 60% noturna ===@
      HorSit[418] = HorSit[418] + HorSit[424];
      
      @=== Limpa 55% Noturna ===@
      HorSit[424] = 0;
    }
  }
}
@=== Se a soma das situações com o saldo do perído for maior que 31 h.e ===@
Senao Se((xQtdHor + HorSit[423] + HorSit[424]) > 1860){
  @=== Valida H.E 55 Diurna ===@
  Se(HorSit[423] > 0){
    @=== Se somado com diurna é maior que 31 horas ===@
    Se((xQtdHor + HorSit[423]) > 1280){
      @=== Separa horas 55% e 60% ===@
      xDif55 = 1860 - xQtdHor;
      xDif60 = HorSit[423] - xDif55;
      
      @=== Soma total de horas ===@
      xQtdHor = xQtdHor + HorSit[423];
      
      @=== Salva H.E ===@
      HorSit[423] = xDif55; @=== aqui não soma porque a 423 já é a padrão ===@
      HorSit[417] = HorSit[417] + xDif60;
    }
    Senao {
      @=== Se não for maior só soma na quantidade de horas ===@
      xQtdHor = xQtdHor + HorSit[423];
    }
  }
  
  @=== Valida 55 Noturna ===@
  Se(HorSit[424] > 0){
    Se(xQtdHor > 1860){
      @=== Se for maior é 60% noturna ===@
      HorSit[418] = HorSit[418] + HorSit[424];
      HorSit[424] = 0;
    }
    Senao Se((xQtdHor + HorSit[424] > 1860)){
      @=== Separa horas 55% e 60% ===@
      xDif55 = 1860 - xQtdHor;
      xDif60 = HorSit[424] - xDif55;
      
      @=== Soma total de horas ===@
      xQtdHor = xQtdHor + HorSit[424];
      
      @=== Salva H.E ===@
      HorSit[424] = xDif55; @=== aqui não soma porque a 424 já é a padrão ===@
      HorSit[418] = HorSit[418] + xDif60;
    }   @=== Não precisa de senão, se não for maior já era diurna ===@
  }
 }
}