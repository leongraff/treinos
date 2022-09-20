
--------------------------------------------------------------------------------
Código: 1 - Descrição: ModeloGerador_Funções Globais
--------------------------------------------------------------------------------

Definir Funcao Definir_Listas();
Definir Funcao Gravar_Colab();
Definir Alfa aCodCcu;
Definir ALfa aNomFun;
Definir Alfa ETipAgr;

Funcao Definir_Listas();
   {
   
    Se (ETipAgr = "C")
       {
        Definir Lista Lst_Colab;
        Lst_Colab.DefinirCampos();
        Lst_Colab.AdicionarCampo("NumEmp",Numero);
        Lst_Colab.AdicionarCampo("CodFil",Numero);
        Lst_Colab.AdicionarCampo("CodCcu",Alfa);
        Lst_Colab.AdicionarCampo("NumCad",Numero);
        Lst_Colab.AdicionarCampo("NomFun",Alfa);
        Lst_Colab.AdicionarCampo("SalAnt",Numero);
        Lst_Colab.AdicionarCampo("FerMesAnt",Numero);
        Lst_Colab.AdicionarCampo("FerMesAtu",Numero);
        Lst_Colab.AdicionarCampo("FerMesSeg",Numero);
        Lst_Colab.AdicionarCampo("AdtPagMes",Numero);
        Lst_Colab.EfetivarCampos();
        Lst_Colab.Chave("NumEmp;Nomfun;NumCad");
       }
    Se ((ETipAgr = "D") ou (ETipAgr = "H"))
       {
        Definir Lista Lst_Ccu;
        Lst_Ccu.DefinirCampos();
        Lst_Ccu.AdicionarCampo("NumEmp",Numero);
        Lst_Ccu.AdicionarCampo("CodFil",Numero);
        Lst_Ccu.AdicionarCampo("CodCcu",Alfa);
        Lst_Ccu.AdicionarCampo("SalAnt",Numero);
        Lst_Ccu.AdicionarCampo("FerMesAnt",Numero);
        Lst_Ccu.AdicionarCampo("FerMesAtu",Numero);
        Lst_Ccu.AdicionarCampo("FerMesSeg",Numero);
        Lst_Ccu.AdicionarCampo("AdtPagMes",Numero);
        Lst_Ccu.EfetivarCampos();
        Lst_Ccu.Chave("NumEmp;CodCcu");
       }
    Se (ETipAgr = "F")
       {
        Definir Lista Lst_Fil;
        Lst_Fil.DefinirCampos();
        Lst_Fil.AdicionarCampo("NumEmp",Numero);
        Lst_Fil.AdicionarCampo("CodFil",Numero);
        Lst_Fil.AdicionarCampo("CodCcu",Alfa);
        Lst_Fil.AdicionarCampo("SalAnt",Numero);
        Lst_Fil.AdicionarCampo("FerMesAnt",Numero);
        Lst_Fil.AdicionarCampo("FerMesAtu",Numero);
        Lst_Fil.AdicionarCampo("FerMesSeg",Numero);
        Lst_Fil.AdicionarCampo("AdtPagMes",Numero);
        Lst_Fil.EfetivarCampos();
        Lst_Fil.Chave("NumEmp;CodFil");
       }
   }
   
Funcao Gravar_Colab();
   {
    Se (ETipAgr = "C")
       {
        Lst_Colab.SetarChave();
        Lst_Colab.NumEmp = nNumEmp;
        Lst_Colab.NomFun = aNomFun;
        Lst_Colab.NumCad = nNumCad;
        Se (Lst_Colab.VaiParaChave())
           {
            Lst_Colab.Editar();
            Lst_Colab.SalAnt = Lst_Colab.SalAnt + nSalAnt;
            Lst_Colab.FerMesAnt = Lst_Colab.FerMesAnt + nFerMesAnt;
            Lst_Colab.FerMesAtu = Lst_Colab.FerMesAtu + nFerMesAtu;
            Lst_Colab.FerMesSeg = Lst_Colab.FerMesSeg + nFerMesSeg;
            Lst_Colab.AdtPagMes = Lst_Colab.AdtPagMes + nAdtPagMes;
           }
        Senao
           {
            Lst_Colab.Adicionar();
            Lst_Colab.NumEmp = nNumEmp;
            Lst_Colab.CodCcu = aCodCcu;
            Lst_Colab.NumCad = nNumCad;
            Lst_Colab.NomFun = aNomFun;
            Lst_Colab.SalAnt = nSalAnt;
            Lst_Colab.FerMesAnt = nFerMesAnt;
            Lst_Colab.FerMesAtu = nFerMesAtu;
            Lst_Colab.FerMesSeg = nFerMesSeg;
            Lst_Colab.AdtPagMes = nAdtPagMes;
           }
        Lst_Colab.Gravar();
       } 
    Se ((ETipAgr = "D") ou (ETipAgr = "H"))
       {
        Lst_Ccu.SetarChave();
        Lst_Ccu.NumEmp = nNumEmp;
        Lst_Ccu.CodCcu = aCodCcu;
        Se (Lst_Ccu.VaiParaChave())
           {
            Lst_Ccu.Editar();
            Lst_Ccu.SalAnt = Lst_Ccu.SalAnt + nSalAnt;
            Lst_Ccu.FerMesAnt = Lst_Ccu.FerMesAnt + nFerMesAnt;
            Lst_Ccu.FerMesAtu = Lst_Ccu.FerMesAtu + nFerMesAtu;
            Lst_Ccu.FerMesSeg = Lst_Ccu.FerMesSeg + nFerMesSeg;
            Lst_Ccu.AdtPagMes = Lst_Ccu.AdtPagMes + nAdtPagMes;
           }
        Senao
           {
            Lst_Ccu.Adicionar();
            Lst_Ccu.NumEmp = nNumEmp;
            Lst_Ccu.CodCcu = aCodCcu;
            Lst_Ccu.SalAnt = nSalAnt;
            Lst_Ccu.FerMesAnt = nFerMesAnt;
            Lst_Ccu.FerMesAtu = nFerMesAtu;
            Lst_Ccu.FerMesSeg = nFerMesSeg;
            Lst_Ccu.AdtPagMes = nAdtPagMes;
           }
        Lst_Ccu.Gravar();
       } 
    Se (ETipAgr = "F")
       {
        Lst_Fil.SetarChave();
        Lst_Fil.NumEmp = nNumEmp;
        Lst_Fil.CodFil = nCodFil;
        Se (Lst_Fil.VaiParaChave())
           {
            Lst_Fil.Editar();
            Lst_Fil.SalAnt = Lst_Fil.SalAnt + nSalAnt;
            Lst_Fil.FerMesAnt = Lst_Fil.FerMesAnt + nFerMesAnt;
            Lst_Fil.FerMesAtu = Lst_Fil.FerMesAtu + nFerMesAtu;
            Lst_Fil.FerMesSeg = Lst_Fil.FerMesSeg + nFerMesSeg;
            Lst_Fil.AdtPagMes = Lst_Fil.AdtPagMes + nAdtPagMes;
           }
        Senao
           {
            Lst_Fil.Adicionar();
            Lst_Fil.NumEmp = nNumEmp;
            Lst_Fil.CodFil = nCodFil;
            Lst_Fil.SalAnt = nSalAnt;
            Lst_Fil.FerMesAnt = nFerMesAnt;
            Lst_Fil.FerMesAtu = nFerMesAtu;
            Lst_Fil.FerMesSeg = nFerMesSeg;
            Lst_Fil.AdtPagMes = nAdtPagMes;
           }
        Lst_Fil.Gravar();
       } 
   }   

--------------------------------------------------------------------------------
Código: 2 - Descrição: ModeloGerador_Inicialização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 3 - Descrição: ModeloGerador_Pré-Seleção
--------------------------------------------------------------------------------

Definir Alfa VDatStr;
Definir Alfa VAlfAux;
ConverteDataBanco (EData, VDatStr);
IntParaAlfa (PerRef,VAlfAux);
VAlfAux = VDatStr;

--------------------------------------------------------------------------------
Código: 4 - Descrição: ModeloGerador_Seleção
--------------------------------------------------------------------------------

Definir_Listas();

--------------------------------------------------------------------------------
Código: 5 - Descrição: ModeloGerador_Finalização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 6 - Descrição: ModeloGerador_Imprimir Página
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 7 - Descrição: Detalhe_1_Depois Imprimir
--------------------------------------------------------------------------------

Definir Cursor C_Pes;
Definir Alfa ETipAgr;
Definir Alfa aNumCad;
Definir Alfa aNomFun;

FTotSalAnt = 0;
FTotFerMesAtu = 0; 
FTotAdtPagMes = 0;
FTotFerMesSeg = 0; 
FTotSalAtu = 0;

Se (ETipAgr = "C")
   {
    nTemReg = Lst_Colab.Primeiro();
    
    Enquanto (nTemReg = 1)
       {
        FNumEmp = Lst_Colab.NumEmp;
        FCodFil = Lst_Colab.CodFil;
        aCodCcu = Lst_Colab.CodCcu;
        @AlteraControle("DCodCcu","Descrição",aCodCcu);@
        FNumCad = Lst_Colab.NumCad;
        IntParaAlfa(FNumCad,aNumCad);
        AlteraControle("DNumCad","Descrição",aNumCad);
        aNomFun = Lst_Colab.NomFun;
        AlteraControle("DNomFun","Descrição",aNomFun);
        FSalAnt = Lst_Colab.SalAnt;
        FSalAnt = FSalAnt + Lst_Colab.FerMesAnt;
        FFerMesAnt = Lst_Colab.FerMesAnt;
        FFerMesAtu = Lst_Colab.FerMesAtu;
        FFerMesSeg = Lst_Colab.FerMesSeg;
        FAdtPagMes = Lst_Colab.AdtPagMes;
        
        FSalAtu = FSalAnt + FFerMesAtu + FFerMesSeg - FAdtPagMes; 
        
        ListaSecao("Adic_DetCol");

        FTotSalAnt = FTotSalAnt + FSalAnt;
        FTotFerMesAtu = FTotFerMesAtu + FFerMesAtu; 
        FTotAdtPagMes = FTotAdtPagMes + FAdtPagMes;
        FTotFerMesSeg = FTotFerMesSeg + FFerMesSeg; 
        FTotSalAtu = FTotSalAtu + FSalAtu; 

        nTemReg = Lst_Colab.Proximo();
       } 
    Lst_Colab.Limpar();

    Se ((FTotSalAnt + FTotFerMesAtu + FTotAdtPagMes + FTotFerMesSeg + FTotSalAtu) > 0)
       { 
        ListaSecao("Adic_TotEmp");
       }    
   }    
Se ((ETipAgr = "D") ou (ETipAgr = "H"))
   {
    nTemReg = Lst_Ccu.Primeiro();
    
    Enquanto (nTemReg = 1)
       {
        FNumEmp = Lst_Ccu.NumEmp;
        FCodFil = Lst_Ccu.CodFil;
        aCodCcu = Lst_Ccu.CodCcu;
        AlteraControle("DNumCad","Descrição",aCodCcu);
        C_Pes.Sql "SELECT NOMCCU FROM R018CCU \
                    WHERE NUMEMP = :FNumEmp \
                      AND CODCCU = :aCodCcu ";
        C_Pes.AbrirCursor();
        Se (C_Pes.Achou)
           {                
            aNomFun = C_Pes.NomCcu;
           }
        C_Pes.FecharCursor();    
        AlteraControle("DNomFun","Descrição",aNomFun);
        FSalAnt = Lst_Ccu.SalAnt;
        FSalAnt = FSalAnt + Lst_Ccu.FerMesAnt;
        FFerMesAnt = Lst_Ccu.FerMesAnt;
        FFerMesAtu = Lst_Ccu.FerMesAtu;
        FFerMesSeg = Lst_Ccu.FerMesSeg;
        FAdtPagMes = Lst_Ccu.AdtPagMes;

        FSalAtu = FSalAnt + FFerMesAtu + FFerMesSeg - FAdtPagMes; 
        
        ListaSecao("Adic_DetCol");

        FTotSalAnt = FTotSalAnt + FSalAnt;
        FTotFerMesAtu = FTotFerMesAtu + FFerMesAtu; 
        FTotAdtPagMes = FTotAdtPagMes + FAdtPagMes;
        FTotFerMesSeg = FTotFerMesSeg + FFerMesSeg; 
        FTotSalAtu = FTotSalAtu + FSalAtu; 

        nTemReg = Lst_Ccu.Proximo();
       }
    Lst_Ccu.Limpar(); 

    Se ((FTotSalAnt + FTotFerMesAtu + FTotAdtPagMes + FTotFerMesSeg + FTotSalAtu) > 0)
       { 
        ListaSecao("Adic_TotEmp");
       }    
   } 
   
Se (ETipAgr = "F")
   {
    nTemReg = Lst_Fil.Primeiro();
    
    Enquanto (nTemReg = 1)
       {
        FNumEmp = Lst_Fil.NumEmp;
        FCodFil = Lst_Fil.CodFil;
        ConverteMascara(1,FCodFil,aNumCad,"zz9");
        AlteraControle("DNumCad","Descrição",aNumCad);
        aCodCcu = Lst_Fil.CodCcu;
        AlteraControle("DNumCad","Descrição",aCodCcu);
        C_Pes.Sql "SELECT NOMFIL FROM R030FIL \
                    WHERE NUMEMP = :FNumEmp \
                      AND CODFIL = :FCodFil ";
        C_Pes.AbrirCursor();
        Se (C_Pes.Achou)
           {                
            aNomFun = C_Pes.NomFil;
           }
        C_Pes.FecharCursor();    
        AlteraControle("DNomFun","Descrição",aNomFun);
        FSalAnt = Lst_Fil.SalAnt;
        FSalAnt = FSalAnt + Lst_Fil.FerMesAnt;
        FFerMesAnt = Lst_Fil.FerMesAnt;
        FFerMesAtu = Lst_Fil.FerMesAtu;
        FFerMesSeg = Lst_Fil.FerMesSeg;
        FAdtPagMes = Lst_Fil.AdtPagMes;

        FSalAtu = FSalAnt + FFerMesAtu + FFerMesSeg - FAdtPagMes; 
        
        ListaSecao("Adic_DetCol");

        FTotSalAnt = FTotSalAnt + FSalAnt;
        FTotFerMesAtu = FTotFerMesAtu + FFerMesAtu; 
        FTotAdtPagMes = FTotAdtPagMes + FAdtPagMes;
        FTotFerMesSeg = FTotFerMesSeg + FFerMesSeg; 
        FTotSalAtu = FTotSalAtu + FSalAtu; 

        nTemReg = Lst_Fil.Proximo();
       }
    Lst_Fil.Limpar(); 

    Se ((FTotSalAnt + FTotFerMesAtu + FTotAdtPagMes + FTotFerMesSeg + FTotSalAtu) > 0)
       { 
        ListaSecao("Adic_TotEmp");
       }    
   }         

--------------------------------------------------------------------------------
Código: 8 - Descrição: Detalhe_1_Antes Imprimir
--------------------------------------------------------------------------------

Definir funcao Gravar_Colab();
Definir Alfa aComando;
Definir Alfa aPesq;
Definir Alfa EAbrEmp;
Definir Alfa aAbrEmp;
Definir ALfa aCodCcu;
Definir ALfa aNomFun;
Definir Alfa ETipAgr;
Definir Alfa aCabSel;
Definir Alfa aTotSel;
Definir Alfa aCabLin;
Definir Alfa EAbrCcu;
Definir Alfa aAbrCcu;
Definir Alfa EAbrCol;
Definir Alfa aAbrCol;

dCmpRef = ECmpRef;
dFimCmp = ECmpRef;
UltimoDia(dFimCMp);
DesmontaData(dCmpRef,nDia,nMes,nAno);
nMes--;
Se (nMes = 0)
   {
    nMes = 12;
    nAno--;
   } 
MontaData(nDia,nMes,nAno,dIniAnt);
dFimAnt = dIniAnt;
UltimoDia(dFimAnt);

DesmontaData(dCmpRef,nDia,nMes,nAno);
nMes++;
Se (nMes > 12)
   {
    nMes = 1;
    nAno++;
   } 
MontaData(nDia,nMes,nAno,dIniSeg);
dFimSeg = dIniSeg;
UltimoDia(dFimSeg);

nNumEmp = R030Emp.NumEmp;
nTotVal = 0;

Se (EAbrCcu <> "")
   {
    MontaAbrangencia ("R038HCC.CODCCU",EAbrCcu,aAbrCcu);
    Se (aAbrCcu <> "()")
       {
        aAbrCcu = " AND " + aAbrCcu;
        TrocaString(aAbrCcu,"R038HCC.CODCCU","HCC.CODCCU",aAbrCcu);
       }
   }


Se (EAbrCol <> "")
   {
    MontaAbrangencia ("R034FUN.NUMCAD",EAbrCol,aAbrCol);
    Se (aAbrCcu <> "()")
       {
        aAbrCol = " AND " + aAbrCol;
        TrocaString(aAbrCol,"R034FUN.NUMCAD","FUN.NUMCAD",aAbrCol);
       }
   }


aCabSel =  "SELECT T1.NUMEMP,T1.CODFIL,T1.CODCCU,T1.NUMCAD,T1.NOMFUN,SUM(T1.VLRPROANT) VLRPROANT,SUM(T1.VLRDESANT) VLRDESANT,SUM(T1.VLRADTANT) VLRADTANT, \
                   SUM(T1.VLRPROMESANT) VLRPROMESANT,SUM(T1.VLRDESMESANT) VLRDESMESANT,SUM(T1.VLRPROMESATU) VLRPROMESATU,SUM(T1.VLRDESMESATU) VLRDESMESATU, \
                   SUM(T1.VLRADTATU) VLRADTATU, SUM(T1.VLRPROMESSEG) VLRPROMESSEG,SUM(T1.VLRDESMESSEG) VLRDESMESSEG ";
aTotSel =  "GROUP BY T1.NUMEMP,T1.CODFIL,T1.CODCCU,T1.NUMCAD,T1.NOMFUN ";                   
   
aCabLin = "SELECT FEM.NUMEMP,HFI.CODFIL,HCC.CODCCU,FEM.NUMCAD,FUN.NOMFUN, ";

aComando = aCabSel + 
            " FROM ( " + aCabLin + 
                  "        (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \  
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (1,2)) VLRPROANT, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (3)) VLRDESANT, \ 
                           (SELECT SUM(VER.VALEVE) FROM R046VER VER, R044CAL CAL, R008EVC EVC \
                             WHERE VER.NUMEMP = FEM.NUMEMP \
                               AND VER.TIPCOL = FEM.TIPCOL \
                               AND VER.NUMCAD = FEM.NUMCAD \
                               AND VER.TABEVE = EVC.CODTAB \
                               AND VER.CODEVE = EVC.CODEVE \
                               AND EVC.CRTEVE = '42C' \
                               AND VER.NUMEMP = CAL.NUMEMP \
                               AND VER.CODCAL = CAL.CODCAL \
                               AND CAL.PERREF = :dIniAnt) VLRADTANT, \
                               (0) VLRPROMESANT,(0) VLRDESMESANT,(0) VLRPROMESATU,(0) VLRDESMESATU,(0) VLRADTATU, (0) VLRPROMESSEG,(0) VLRDESMESSEG \
                      FROM R040FEM FEM, R038HFI HFI, R038HCC HCC, R034FUN FUN \
                     WHERE FEM.NUMEMP = :nNumEmp \
                       AND FEM.DATPAG <= :dFimAnt \
                       AND FEM.INIFER >= :dIniAnt \
                       AND FEM.INIFER <= :dFimAnt \
                       AND FEM.NUMEMP = HFI.NUMEMP \
                       AND FEM.TIPCOL = HFI.TIPCOL \
                       AND FEM.NUMCAD = HFI.NUMCAD \
                       AND HFI.DATALT = (SELECT MAX(A.DATALT) FROM R038HFI A \
                                          WHERE A.NUMEMP = HFI.NUMEMP \
                                            AND A.TIPCOL = HFI.TIPCOL \
                                            AND A.NUMCAD = HFI.NUMCAD \
                                            AND A.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = HCC.NUMEMP \
                       AND FEM.TIPCOL = HCC.TIPCOL \
                       AND FEM.NUMCAD = HCC.NUMCAD " + aAbrCcu +
                     " AND HCC.DATALT = (SELECT MAX(B.DATALT) FROM R038HCC B \
                                          WHERE B.NUMEMP = HCC.NUMEMP \
                                            AND B.TIPCOL = HCC.TIPCOL \
                                            AND B.NUMCAD = HCC.NUMCAD \
                                            AND B.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = FUN.NUMEMP \
                       AND FEM.TIPCOL = FUN.TIPCOL \
                       AND FEM.NUMCAD = FUN.NUMCAD " + aAbrCol + 
                     " AND FUN.TIPCON NOT IN (5) \
                     UNION " + aCabLin + 
                    "      (0) VLRPROANT, (0) VLRDESANT,(0) VLRADTANT, \              
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \  
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (1,2)) VLRPROMESANT, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (3)) VLRDESMESANT,(0) VLRPROMESATU,(0) VLRDESMESATU,(0) VLRADTATU, (0) VLRPROMESSEG,(0) VLRDESMESSEG \
                      FROM R040FEM FEM, R038HFI HFI, R038HCC HCC, R034FUN FUN \
                     WHERE FEM.NUMEMP = :nNumEmp \
                       AND FEM.DATPAG >= :dIniAnt \
                       AND FEM.DATPAG <= :dFimAnt \
                       AND FEM.INIFER >= :dCmpRef \
                       AND FEM.INIFER <= :dFimCmp \
                       AND FEM.NUMEMP = HFI.NUMEMP \
                       AND FEM.TIPCOL = HFI.TIPCOL \
                       AND FEM.NUMCAD = HFI.NUMCAD \
                       AND HFI.DATALT = (SELECT MAX(A.DATALT) FROM R038HFI A \
                                          WHERE A.NUMEMP = HFI.NUMEMP \
                                            AND A.TIPCOL = HFI.TIPCOL \
                                            AND A.NUMCAD = HFI.NUMCAD \
                                            AND A.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = HCC.NUMEMP \
                       AND FEM.TIPCOL = HCC.TIPCOL \
                       AND FEM.NUMCAD = HCC.NUMCAD " + aAbrCcu +
                     " AND HCC.DATALT = (SELECT MAX(B.DATALT) FROM R038HCC B \
                                          WHERE B.NUMEMP = HCC.NUMEMP \
                                            AND B.TIPCOL = HCC.TIPCOL \
                                            AND B.NUMCAD = HCC.NUMCAD \
                                            AND B.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = FUN.NUMEMP \
                       AND FEM.TIPCOL = FUN.TIPCOL \
                       AND FEM.NUMCAD = FUN.NUMCAD " + aAbrCol + 
                     " AND FUN.TIPCON NOT IN (5) \
                     UNION " + aCabLin + 
                    "      (0) VLRPROANT, (0) VLRDESANT,(0) VLRADTANT,(0) VLRPROMESANT,(0) VLRDESMESANT, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \  
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (1,2)) VLRPROMESATU, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (3)) VLRDESMESATU,(0) VLRADTATU, (0) VLRPROMESSEG,(0) VLRDESMESSEG \
                      FROM R040FEM FEM, R038HFI HFI, R038HCC HCC, R034FUN FUN \
                     WHERE FEM.NUMEMP = :nNumEmp \
                       AND FEM.DATPAG >= :dCmpRef \
                       AND FEM.DATPAG <= :dFimCmp \
                       AND FEM.INIFER >= :dCmpRef \
                       AND FEM.INIFER <= :dFimCmp \
                       AND FEM.NUMEMP = HFI.NUMEMP \
                       AND FEM.TIPCOL = HFI.TIPCOL \
                       AND FEM.NUMCAD = HFI.NUMCAD \
                       AND HFI.DATALT = (SELECT MAX(A.DATALT) FROM R038HFI A \
                                          WHERE A.NUMEMP = HFI.NUMEMP \
                                            AND A.TIPCOL = HFI.TIPCOL \
                                            AND A.NUMCAD = HFI.NUMCAD \
                                            AND A.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = HCC.NUMEMP \
                       AND FEM.TIPCOL = HCC.TIPCOL \
                       AND FEM.NUMCAD = HCC.NUMCAD " + aAbrCcu +
                     " AND HCC.DATALT = (SELECT MAX(B.DATALT) FROM R038HCC B \
                                          WHERE B.NUMEMP = HCC.NUMEMP \
                                            AND B.TIPCOL = HCC.TIPCOL \
                                            AND B.NUMCAD = HCC.NUMCAD \
                                            AND B.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = FUN.NUMEMP \
                       AND FEM.TIPCOL = FUN.TIPCOL \
                       AND FEM.NUMCAD = FUN.NUMCAD " + aAbrCol + 
                     " AND FUN.TIPCON NOT IN (5) \
                     UNION " + aCabLin + 
                    "      (0) VLRPROANT, (0) VLRDESANT,(0) VLRADTANT,(0) VLRPROMESANT,(0) VLRDESMESANT, \
                           (0) VLRPROMESATU,(0) VLRDESMESATU,(FEM.VALEVE) VLRADTATU, (0) VLRPROMESSEG,(0) VLRDESMESSEG \
                      FROM R046VER FEM, R044CAL CAL, R038HFI HFI, R038HCC HCC, R034FUN FUN, R008EVC EVC \
                     WHERE FEM.NUMEMP = :nNumEmp \ 
                       AND FEM.NUMEMP = CAL.NUMEMP \
                       AND FEM.CODCAL = CAL.CODCAL \
                       AND CAL.PERREF = :dCmpRef \
                       AND FEM.TABEVE = EVC.CODTAB \
                       AND FEM.CODEVE = EVC.CODEVE \
                       AND EVC.CRTEVE = '42C' \
                       AND FEM.NUMEMP = HFI.NUMEMP \
                       AND FEM.TIPCOL = HFI.TIPCOL \
                       AND FEM.NUMCAD = HFI.NUMCAD \
                       AND HFI.DATALT = (SELECT MAX(A.DATALT) FROM R038HFI A \
                                          WHERE A.NUMEMP = HFI.NUMEMP \
                                            AND A.TIPCOL = HFI.TIPCOL \
                                            AND A.NUMCAD = HFI.NUMCAD \
                                            AND A.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = HCC.NUMEMP \
                       AND FEM.TIPCOL = HCC.TIPCOL \
                       AND FEM.NUMCAD = HCC.NUMCAD " + aAbrCcu +
                     " AND HCC.DATALT = (SELECT MAX(B.DATALT) FROM R038HCC B \
                                          WHERE B.NUMEMP = HCC.NUMEMP \
                                            AND B.TIPCOL = HCC.TIPCOL \
                                            AND B.NUMCAD = HCC.NUMCAD \
                                            AND B.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = FUN.NUMEMP \
                       AND FEM.TIPCOL = FUN.TIPCOL \
                       AND FEM.NUMCAD = FUN.NUMCAD " + aAbrCol + 
                     " AND FUN.TIPCON NOT IN (5) \
                     UNION " + aCabLin + 
                    "      (0) VLRPROANT, (0) VLRDESANT,(0) VLRADTANT,(0) VLRPROMESANT,(0) VLRDESMESANT, \
                           (0) VLRPROMESATU,(0) VLRDESMESATU,(0) VLRADTATU, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \  
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (1,2)) VLRPROMESSEG, \
                           (SELECT SUM(FEV.VALEVE) FROM R040FEV FEV, R008EVC EVC \
                             WHERE FEV.NUMEMP = FEM.NUMEMP \
                               AND FEV.TIPCOL = FEM.TIPCOL \
                               AND FEV.NUMCAD = FEM.NUMCAD \
                               AND FEV.INIPER = FEM.INIPER \
                               AND FEV.INIFER = FEM.INIFER \
                               AND FEV.TABEVE = EVC.CODTAB \
                               AND FEV.CODEVE = EVC.CODEVE \
                               AND EVC.TIPEVE IN (3))  VLRDESMESSEG \
                      FROM R040FEM FEM, R038HFI HFI, R038HCC HCC, R034FUN FUN \
                     WHERE FEM.NUMEMP = :nNumEmp \
                       AND FEM.DATPAG >= :dCmpRef \
                       AND FEM.DATPAG <= :dFimCmp \
                       AND FEM.INIFER >= :dIniSeg \
                       AND FEM.INIFER <= :dFimSeg \
                       AND FEM.NUMEMP = HFI.NUMEMP \
                       AND FEM.TIPCOL = HFI.TIPCOL \
                       AND FEM.NUMCAD = HFI.NUMCAD \
                       AND HFI.DATALT = (SELECT MAX(A.DATALT) FROM R038HFI A \
                                          WHERE A.NUMEMP = HFI.NUMEMP \
                                            AND A.TIPCOL = HFI.TIPCOL \
                                            AND A.NUMCAD = HFI.NUMCAD \
                                            AND A.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = HCC.NUMEMP \
                       AND FEM.TIPCOL = HCC.TIPCOL \
                       AND FEM.NUMCAD = HCC.NUMCAD " + aAbrCcu +
                     " AND HCC.DATALT = (SELECT MAX(B.DATALT) FROM R038HCC B \
                                          WHERE B.NUMEMP = HCC.NUMEMP \
                                            AND B.TIPCOL = HCC.TIPCOL \
                                            AND B.NUMCAD = HCC.NUMCAD \
                                            AND B.DATALT <= :dFimCmp) \
                       AND FEM.NUMEMP = FUN.NUMEMP \
                       AND FEM.TIPCOL = FUN.TIPCOL \
                       AND FEM.NUMCAD = FUN.NUMCAD " + aAbrCol + 
                     " AND FUN.TIPCON NOT IN (5)) T1 " + aTotSel;
SQL_Criar(aPesq);
SQL_UsarAbrangencia(aPesq,0);
SQL_UsarSqlSenior2(aPesq,0);
SQL_DefinirComando(aPesq,aComando);
SQL_DefinirInteiro(aPesq,"nNumEmp",nNumEmp);
SQL_DefinirData(aPesq,"dIniAnt",dIniAnt);
SQL_DefinirData(aPesq,"dFimAnt",dFimAnt);
SQL_DefinirData(aPesq,"dCmpRef",dCmpRef);
SQL_DefinirData(aPesq,"dFimCmp",dFimCmp);
SQL_DefinirData(aPesq,"dIniSeg",dIniSeg);
SQL_DefinirData(aPesq,"dFimSeg",dFimSeg);
SQL_AbrirCursor(aPesq);
Enquanto (SQL_EOF(aPesq) = 0)
   {
    SQL_RetornarInteiro(aPesq,"NumEmp",nNumEmp);
    SQL_RetornarInteiro(aPesq,"CodFil",nCodFil);
    SQL_RetornarAlfa(aPesq,"CodCcu",aCodCcu);
    Se (ETipAgr = "C")
       {
        SQL_RetornarInteiro(aPesq,"NumCad",nNumCad);
        SQL_RetornarAlfa(aPesq,"NomFun",aNomFun);
       } 
    SQL_RetornarFlutuante(aPesq,"VLRPROANT",nVlrProAnt);
    SQL_RetornarFlutuante(aPesq,"VLRDESANT",nVlrDesAnt);
    SQL_RetornarFlutuante(aPesq,"VLRADTANT",nVlrAdtAnt);
    nSalAnt = nVlrProAnt - nVlrDesAnt - nVlrAdtAnt;
    SQL_RetornarFlutuante(aPesq,"VLRPROMESANT",nVlrProMesAnt);
    SQL_RetornarFlutuante(aPesq,"VLRDESMESANT",nVlrDesMesAnt);
    nFerMesAnt = nVlrProMesAnt - nVlrDesMesAnt;
    SQL_RetornarFlutuante(aPesq,"VLRPROMESATU",nVlrProMesAtu);
    SQL_RetornarFlutuante(aPesq,"VLRDESMESATU",nVlrDesMesAtu);
    nFerMesAtu = nVlrProMesAtu - nVlrDesMesAtu;
    SQL_RetornarFlutuante(aPesq,"VLRPROMESSEG",nVlrProMesSeg);
    SQL_RetornarFlutuante(aPesq,"VLRDESMESSEG",nVlrDesMesSeg);
    nFerMesSeg = nVlrProMesSeg - nVlrDesMesSeg;
    SQL_RetornarFlutuante(aPesq,"VLRADTATU",nAdtPagMes);
 
    Se ((nSalAnt + nFerMesAnt + nFerMesAtu + nFerMesSeg + nAdtPagMes) > 0)
       { 
        Gravar_Colab();
        nTotVal = nTotVal + nSalAnt + nFerMesAnt + nFerMesAtu + nFerMesSeg + nAdtPagMes;
       }   
    SQL_Proximo(aPesq);
   }
SQL_FecharCursor(aPesq);
SQL_Destruir(aPesq);

Se (nTotVal <= 0)
   {
    Cancel(1);
   } 

--------------------------------------------------------------------------------
Código: 9 - Descrição: Desenho008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 10 - Descrição: Desenho007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 11 - Descrição: Desenho005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 12 - Descrição: Desenho004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 13 - Descrição: Desenho002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 14 - Descrição: Cadastro001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 15 - Descrição: Cadastro002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 16 - Descrição: Descricao001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 17 - Descrição: Descricao002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 18 - Descrição: Descricao003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 19 - Descrição: Descricao004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 20 - Descrição: Descricao006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 21 - Descrição: Descricao007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 22 - Descrição: Descricao008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 23 - Descrição: Descricao009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 24 - Descrição: Descricao010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 25 - Descrição: Descricao011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 26 - Descrição: Imagem001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 27 - Descrição: Descricao014_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa aAux;
ConverteMascara(3,ECmpRef,aAux,"MM/YYYY");
ValStr = "Competência: " + aAux;
Cancel(2);

--------------------------------------------------------------------------------
Código: 28 - Descrição: Cadastro003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 29 - Descrição: Adic_DetCol_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 30 - Descrição: Adic_DetCol_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 31 - Descrição: Desenho010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 32 - Descrição: Desenho009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 33 - Descrição: Desenho006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 34 - Descrição: Desenho003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 35 - Descrição: Desenho001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 36 - Descrição: DNomFun_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 37 - Descrição: FSalAnt_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 38 - Descrição: FFerMesAnt_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 39 - Descrição: FFerMesAtu_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 40 - Descrição: FAdtPagMes_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 41 - Descrição: FSalAtu_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 42 - Descrição: FFerMesSeg_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 43 - Descrição: dNumCad_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 44 - Descrição: Descricao012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 45 - Descrição: Descricao013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 46 - Descrição: Adic_TotEmp_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 47 - Descrição: Adic_TotEmp_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 48 - Descrição: Descricao015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 49 - Descrição: FTotSalAnt_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 50 - Descrição: FTotFerMesAtu_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 51 - Descrição: FTotAdtPagMes_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 52 - Descrição: FTotFerMesSeg_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 53 - Descrição: FTotSalAtu_Na Impressão
--------------------------------------------------------------------------------
