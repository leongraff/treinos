@-->Jardel Cunha@
@--Versao 2.0.0 - 28/07/2022@
Definir Funcao BuscaDefinicoesPensao(numero fNumEmp, numero fTipCol, numero fNumCad, numero fCodDep);
Definir Funcao CalculaPensaoTotal(numero end fPenCalTot);
Definir Funcao CalculaLiquidoFolha(numero end fCalLiqFol);
Definir Funcao BuscaPensaoTotalPaga(numero end fPenTotPag);
Definir Funcao BuscaPensaoPagaDependete(numero fCodDep, numero end fValPenAcuDep);
Definir Funcao CalcPenQueSeraPaga(numero fLiqFol, numero fPenTot, numero fValPenAcu, numero fValPagDep, numero end fValEvt);
Definir Funcao Debug(numero fValorDebug);


Definir Alfa xTipLim;
Definir Data xPerref;
Definir Data xiniApu;
Definir Data xfimpen;
Definir Data xfimper;
Definir Data xDatZer;

xNumEmp = R034FUN.NumEmp;
xTipCol = R034FUN.TipCol;
xNumCad = R034FUN.NumCad;
xCodDep = R036DEP.CodDep;

CalculaPensaoTotal(xPenCalTot);
CalculaLiquidoFolha(xLiqFol);
BuscaPensaoTotalPaga(xValPenAcu);
BuscaPensaoPagaDependete(xCodDep, xValPenAcuDep); 
CalcPenQueSeraPaga(xLiqFol, xPenCalTot, xValPenAcu, xValPenAcuDep, xValEvt);
@ Debug(xValEvt);  @


valevt = xValEvt; 

Funcao CalcPenQueSeraPaga(numero fLiqFol, numero fPenTot, numero fValPenAcu, numero fValPagDep, numero end fValEvt);{
    fValEvt = 0;
    fValPenDevDep = ValEvt - fValPagDep;
    fPenTotDevDep = fPenTot - fValPenAcu;
    
    se(fLiqFol > fPenTotDevDep)
        fLiqFol =  fPenTotDevDep;

    fValEvt = (fLiqFol / fPenTotDevDep) * fValPenDevDep;
    
    se (fValEvt < 0)
      fValEvt = 0;
    
}

Funcao BuscaPensaoPagaDependete(numero fCodDep, numero end fValPenAcuDep); {
    Definir Cursor CUR_R036PJP;
    
    Definir Data fPerRef;
    Definir Data fFimPer;
      
    fPerRef = PerRef;
    fFimPer = FimCmp;
    fValPenAcuDep = 0;  
    
    CUR_R036PJP.SQL "SELECT R036PJP.VALPEN FROM R036PJP WHERE  1 = 2 UNION ALL\
                     SELECT SUM(R036PJP.VALPEN) FROM R036PJP, R044CAL \
                      WHERE R036PJP.NUMEMP = :XNUMEMP \
                        AND R036PJP.TIPCOL = :XTIPCOL \
                        AND R036PJP.NUMCAD = :XNUMCAD \
                        AND R036PJP.CODDEP = :FCODDEP \
                        AND R036PJP.CODCAL = R044CAL.CODCAL \
                        AND R036PJP.NUMEMP = R044CAL.NUMEMP \
                        AND R044CAL.TIPCAL IN (21,22,23)    \
                        AND R044CAL.INICMP >= :FPERREF AND FIMCMP < :FFIMPER"; 
  
    CUR_R036PJP.AbrirCursor();
    Se(CUR_R036PJP.Achou){
        fValPenAcuDep = CUR_R036PJP.ValPen;     
    }
    CUR_R036PJP.FecharCursor();     
}

Funcao BuscaPensaoTotalPaga(numero end fPenTotPag); {
    Definir Cursor CUR_R036PJP;
    
    Definir Data fPerRef;
    Definir Data fFimPer;
    
    fPerRef = PerRef;
    fFimPer = FimCmp;    
    fPenTotPag = 0;

    CUR_R036PJP.SQL "SELECT R036PJP.VALPEN FROM R036PJP WHERE  1 = 2 UNION ALL\
                     SELECT SUM(R036PJP.VALPEN) FROM R036PJP, R044CAL \
                      WHERE R036PJP.NUMEMP = :XNUMEMP \
                        AND R036PJP.TIPCOL = :XTIPCOL \
                        AND R036PJP.NUMCAD = :XNUMCAD \
                        AND R036PJP.CODCAL = R044CAL.CODCAL \
                        AND R036PJP.NUMEMP = R044CAL.NUMEMP \
                        AND R044CAL.TIPCAL IN (21,22,23)    \
                        AND R044CAL.INICMP >= :FPERREF AND FIMCMP < :FFIMPER"; 
  
    CUR_R036PJP.AbrirCursor();
    Se(CUR_R036PJP.Achou){
        fPenTotPag = CUR_R036PJP.ValPen;     
    }
    CUR_R036PJP.FecharCursor();

}

Funcao CalculaLiquidoFolha(numero end fCalLiqFol);{

    CodEvt = 3;
    BusEvt = 1;
    fRenBru = ValEv2;
    
    CodEvt = 302;
    BusEvt = 1;
    fINSRet = ValEv2; 
    
    CodEvt = 304;
    BusEvt = 1;
    fIRFRet = ValEv2;
    
    CodEvt = 600;
    BusEvt = 1;
    fDasRet = ValEv2;    
    
    fCalLiqFol = fRenBru - fINSRet - fIRFRet - fDasRet;
}

Funcao BuscaDefinicoesPensao(numero fNumEmp, numero fTipCol, numero fNumCad,  numero fCodDep); {
    Definir Cursor CUR_R036PJU;
    
    CUR_R036PJU.SQL "SELECT * \
                       FROM R036PJU \
                      WHERE NUMEMP = :fNumEmp AND TIPCOL = :fTipCol \
                        AND NUMCAD = :fNumCad AND CODDEP = :fCodDep";
    CUR_R036PJU.AbrirCursor();
    se(CUR_R036PJU.achou){
        xLimMax = CUR_R036PJU.USU_valmin;
        xLimMin = CUR_R036PJU.USU_valmax;
        xPerPen = CUR_R036PJU.PerPen;
        xValpen = CUR_R036PJU.Valpen;
        xBasPju = CUR_R036PJU.BasPju;
    }
    CUR_R036PJU.FecharCursor();
}

Funcao CalculaPensaoTotal(numero end fPenCalTot);{
    Definir Cursor CUR_R036DEP;    

    fPenCalTot = 0;
    CUR_R036DEP.SQL"SELECT CodDep \
                      FROM R036DEP \
                     WHERE NUMEMP = :xNumemp AND TIPCOL = :xTipCol \
                       AND NUMCAD = :xNumCad and PenJud = 'S' ";
    CUR_R036DEP.AbrirCursor();
    enquanto(CUR_R036DEP.achou){
        xCodDepCur = CUR_R036DEP.CodDep;
        BuscaDefinicoesPensao(xNumemp, xTipCol, xNumCad, xCodDepCur);
        
        Se (xBasPju = 'R'){
            fPenCalTot = xPenCalTot + (xPerPen / 100) * AcuCal[9015];            
        }
        senao {
            fPenCalTot = xPenCalTot + xValpen;
        }

        CUR_R036DEP.proximo();
    }
    CUR_R036DEP.FecharCursor();
} 

Funcao Debug(numero fValorDebug);{
    Definir Alfa fAlfaDebug;
    
    intParaAlfa(fValorDebug, fAlfaDebug);
    Mensagem(Retorna, fAlfaDebug);
}