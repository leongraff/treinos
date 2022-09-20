
--------------------------------------------------------------------------------
Código: 1 - Descrição: ModeloGerador_Funções Globais
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 2 - Descrição: ModeloGerador_Inicialização
--------------------------------------------------------------------------------

Definir Alfa xImprimiu_1;
Definir Alfa xImprimiu_2;

xImprimiu_1 = "N";
xImprimiu_2 = "N";

--------------------------------------------------------------------------------
Código: 3 - Descrição: ModeloGerador_Pré-Seleção
--------------------------------------------------------------------------------

Definir Alfa AuxSQL;
Definir Alfa AuxRelac;
Definir Alfa AuxSQLHist;
Definir Alfa AuxSQLAbr;
Definir Alfa xDatRef;
Definir numero intmes;
Definir data vdiafimcmp;
Definir numero flag_cabmes;
Definir Alfa EAbrFil;
Definir Alfa EAbrTsa;
Definir Data xCmpDatRef;

Se   ((ENPerIni > EDatRef) ou (EnPerIni=0) ou (EDatRef=0))
     Inicio
         Mensagem(Retorna,"Data Final Não Pode Ser Maior Que Data Inicial e ambas não podem ser iguais a 00/00/0000.[&Ok]");
         Cancel(1);
     Fim;

RetDifDat(2,ENPerIni,EDatRef,intmes );
intmes = intmes + 1;
Se   (intmes > 12)
     Inicio
         Mensagem(Retorna,"Período Máximo na Consulta é de 12 Meses.[&Ok]");
         Cancel(1);
     Fim; 

@------ Monta o último dia da competência final para buscar informações do cadastro (salário/cargo,etc) -------@
xCmpDatRef = EDatRef;
RetornaMesData(EDatRef,AuxMes);
RetornaAnoData(EDatRef,AuxAno);
BusQtdDiasMes(AuxMes,AuxAno,AuxDias);
MontaData(AuxDias,AuxMes,AuxAno,vDiaFimCmp);
ConverteDataBanco(vDiaFimCmp, xDatRef);

DatRef = vDiaFimCmp;
EDatRef = vDiaFimCmp;



@------ Valores extenso meses ------@
Definir data vDataAux;
Definir alfa vMes1;
Definir alfa vMes2;
Definir alfa vMes3;
Definir alfa vMes4;
Definir alfa vMes5;
Definir alfa vMes6;
Definir alfa vMes7;
Definir alfa vMes8;
Definir alfa vMes9;
Definir alfa vMes10;
Definir alfa vMes11;
Definir alfa vMes12;

vQtd = 1;
RetornaMesData(ENPerIni,vMesAux);
vMesAux = vMesAux - 1;
Se   (vQtd > intmes)
     vMes1 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes1);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes2 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes2);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes3 = " ";
senao
     inicio
          Se   (vMesaux >= 12)
               vMesaux = 1;

          senao
               vMesaux = vMesaux + 1;
          ExtensoMes(vMesaux,vMes3);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes4 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes4);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes5 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes5);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes6 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes6);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes7 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes7);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes8 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes8);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes9 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes9);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes10 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes10);
     fim;

vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes11 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes11);
     fim;


vQtd = vQtd + 1;
Se   (vQtd > intmes)
     vMes12 = " ";
senao
     inicio
         Se   (vMesaux >= 12)
              vMesaux = 1;
         senao
              vMesaux = vMesaux + 1;
         ExtensoMes(vMesaux,vMes12);
     fim;

/* Variável utilizada para determinar a impressão
   dos cabeçalhos dos meses. Consistência esta na 
   regra Depois_de_Imprimir da Seção Cabeçalho */
flag_cabmes = 0;



@ ---- Relacionamento com o Historico de Local ( FIXO )---- @
MontarSqlHistorico( "R038HLO", EDatRef, AuxSQLHist );
AuxSQL = AuxRelac + AuxSQLHist; 
InsClauSQLWhere( "Detalhe_1", AuxSQL );
AuxRelac = " AND ";


@ ---------- Relacionamento com o Histórico de Filial ( DINÂMICO ) ---------- @
Se ( EAbrFil <> "" )
   {
      @ Monta a restrição para campo de abrangência @
      MontaAbrangencia("R038HFI.CodFil", EAbrFil, AuxSQLAbr);

      AuxSQL = AuxRelac + " R038HFI.NUMEMP = R034FUN.NUMEMP "
              + " AND R038HFI.TIPCOL = R034FUN.TIPCOL "
              + " AND R038HFI.NUMCAD = R034FUN.NUMCAD "
              + " AND R038HFI.DATALT = (SELECT MAX (DATALT) FROM R038HFI TAB2 WHERE "
              + "(TAB2.NUMEMP = R038HFI.NUMEMP) AND "
              + "(TAB2.TIPCOL = R038HFI.TIPCOL) AND "
              + "(TAB2.NUMCAD = R038HFI.NUMCAD) AND "
              + "(TAB2.NUMEMP = TAB2.EMPATU) AND "
              + "(TAB2.NUMCAD = TAB2.CADATU) AND "
              + "(TAB2.DATALT <= " + xDatRef + ")) "
              + " AND " + AuxSQLAbr;
      InsClauSqlWhere( "Detalhe_1", AuxSQL );
      AuxRelac = " AND ";
   };


@ ---- Relacionamento com o Histórico de Salário ( DINÂMICO )---- @
Se (EAbrTsa <> "")
   {
      @ Monta a restrição para data de alteração @
      MontarSqlHistoricoSeq( "R038HSA", EDatRef, AuxSQLHist );

      @ Monta a restrição para campo de abrangência @
      MontaAbrangencia( "R038HSA.TipSal", EAbrTsa, AuxSQLAbr );

      AuxSQL = AuxRelac + " R038HSA.NUMEMP = R034FUN.NUMEMP "
              + " AND R038HSA.TIPCOL = R034FUN.TIPCOL "
              + " AND R038HSA.NUMCAD = R034FUN.NUMCAD "
              + " AND " + AuxSQLHist
              + " AND " + AuxSQLAbr;
      InsClauSqlWhere( "Detalhe_1", AuxSQL );
      AuxRelac = " AND ";
   };


@ -------- Relacionamento Histórico Situação (DINÂMICO) -------- @
Definir Alfa EAbrSit;
Se (EAbrSit <> "")
   {
      Definir Alfa AuxAFA;
      Definir Alfa DataZero;
      ConverteDataBanco( 0, DataZero );
      
      @ Monta a restrição para campo de abrangência @
      MontaAbrangencia( "R038AFA.SITAFA", EAbrSit, AuxSQLAbr );

/*
      Este comando SQL seleciona todos os afastamentos que terminam depois do período 
      indicado e/ou não tem previsão de término e, inciaram antes da data final informada.          
*/      

      AuxAFA = " SELECT 1 FROM R038AFA WHERE"
              + " R038AFA.NUMEMP = R034FUN.NUMEMP"
              + " AND R038AFA.TIPCOL = R034FUN.TIPCOL"
              + " AND R038AFA.NUMCAD = R034FUN.NUMCAD"
              + " AND (R038AFA.DATTER >= " + xDatRef + " OR R038AFA.DATTER = " + DataZero + ")"
              + " AND R038AFA.DATAFA = (SELECT MAX(R038AFA.DATAFA) FROM R038AFA, R010SIT"
              + " WHERE R038AFA.NUMEMP = R034FUN.NUMEMP"
              + " AND R038AFA.TIPCOL = R034FUN.TIPCOL"
              + " AND R038AFA.NUMCAD = R034FUN.NUMCAD"
              + " AND R038AFA.DATAFA <= " + xDatRef
              + " AND R038AFA.SITAFA = R010SIT.CODSIT"
              + " AND R010SIT.TIPSIT <> 15)";

      @ TESTA SE EXISTE SITUAÇÃO TIPO "1" NA ABRANGÊNCIA E, SE ELA É ÚNICA @
      Sit1NaAbr (EAbrSit, xOutSit, xSit1);
      Se ( xSit1 > 0 )
      {
        @ Se encontrar situação tipo "1", deve desconsiderar os registros encontrados em AuxAFA @
        AuxSQL = " NOT EXISTS ( " + AuxAFA;

        Se ( xOutSit > 0 )
          @ Se existirem outras situações informadas, leva em consideração @
          AuxSQL = AuxSQL + ") OR EXISTS (" + AuxAFA + " AND " + AuxSQLAbr;
      }
      Senao
        @ Se não encontrar situação tipo "1", seleciona somente os encontrados em AuxAFA @
        AuxSQL = " EXISTS (" + AuxAFA + " AND " + AuxSQLAbr;

      AuxSQL = AuxRelac + "(" + AuxSQL + "))";
      InsSqlWhereSimples("Detalhe_1", AuxSQL);
      AuxRelac = " AND ";
   };

@ ---------- Relacionamento Histórico Centro de Custo ( DINÂMICO ) ---------- @
Definir alfa EAbrCCu;
Se  ( EAbrCCu <> "" )
  {
     @ Monta a restrição para data de alteração @
     MontarSqlHistorico( "R038HCC", EDatRef, AuxSQLHist );

     @ Monta a restrição para campo de abrangência @
     MontaAbrangencia( "R038HCC.CodCCu", EAbrCCu, AuxSQLAbr );

     AuxSQL = AuxRelac + " R038HCC.NUMEMP = R034FUN.NUMEMP "
          + " AND R038HCC.TIPCOL = R034FUN.TIPCOL "
          + " AND R038HCC.NUMCAD = R034FUN.NUMCAD "
          + " AND " + AuxSQLHist
          + " AND " + AuxSQLAbr;
     InsClauSqlWhere( "Detalhe_1", AuxSQL );
     AuxRelac = " AND ";
  };

@ - Tratamento para Demitidos - @
Se (ELisDem = 'N')
Inicio
  AuxSQL = AuxRelac + " NOT EXISTS (SELECT 1 FROM R038AFA WHERE"
    + " R038AFA.NUMEMP = R034FUN.NUMEMP"
    + " AND R038AFA.TIPCOL = R034FUN.TIPCOL"
    + " AND R038AFA.NUMCAD = R034FUN.NUMCAD"
    + " AND R038AFA.DATAFA = (SELECT MAX(R038AFA.DATAFA) FROM R038AFA, R010SIT"
    + " WHERE R038AFA.NUMEMP = R034FUN.NUMEMP"
    + " AND R038AFA.TIPCOL = R034FUN.TIPCOL"
    + " AND R038AFA.NUMCAD = R034FUN.NUMCAD"
    + " AND R038AFA.DATAFA <= " + xDatRef
    + " AND R038AFA.SITAFA = R010SIT.CODSIT"
    + " AND R010SIT.TIPSIT = 7))";

  InsSQLWhereSimples("Detalhe_1",AuxSQL);
  AuxRelac = " AND ";
Fim;

@ ---- Relacionamento com o Historico de Vínculo ( DINÂMICO )---- @
Definir Alfa EAbrVin;
Se (EAbrVin <> "")
inicio
  @ Monta a restrição para data de alteração @
  MontarSqlHistorico( "R038HVI", EDatRef, AuxSQLHist );

  @ Monta a restrição para campo de abrangência @
  MontaAbrangencia( "R038HVI.CodVin", EAbrVin, AuxSQLAbr );

  AuxSql = AuxRelac + " R038HVI.NUMEMP = R034FUN.NUMEMP "
           + " AND R038HVI.TIPCOL = R034FUN.TIPCOL "
           + " AND R038HVI.NUMCAD = R034FUN.NUMCAD "
           + " AND " + AuxSQLHist
           + " AND " + AuxSQLAbr;
  InsClauSqlWhere( "Detalhe_1", AuxSQL );
  AuxRelac = " AND ";
fim;


@ ---- Relacionamento com o Histórico de Cargo ---- @
MontarSqlHistorico( "R038HCA", EDatRef, AuxSQLHist );
AuxSql =AuxRelac + AuxSQLHist;
InsClauSqlWhere( "Detalhe_1", AuxSql);

--------------------------------------------------------------------------------
Código: 4 - Descrição: ModeloGerador_Seleção
--------------------------------------------------------------------------------

Definir Numero mesinireq;
Definir Numero anoinireq;
Definir Numero mesfimreq;
Definir Numero anofimreq;
Definir Numero xNumEmp;
Definir Numero FlagEventos; /* Utilizado em Detalhe_1 */
Definir Numero Codigo_TabEve;
Definir Alfa xdeseve;
Definir Cursor c030emp;


xmesreq = 0;
xanoreq = 0;

RetornaMesData(ENPerIni, mesinireq);
RetornaAnoData(ENPerIni, anoinireq);
RetornaMesData(EDatRef, mesfimreq);
RetornaAnoData(EDatRef, anofimreq);
MesReq = mesinireq;
AnoReq = anoinireq;
AcumulaEventosFicFin (r034fun.NumEmp, r034fun.TipCol, R034FUN.NumCad, ENTipCal, ENPerIni, EDatRef, 0);
Se (FimEve = 0)
  Cancel(1);

/* Cursor utilizado para retorna a tabela de eventos da empresa
   que sera utilizado na regra de impressão da seção FTotRef */  
xNumEmp = EmpAtu;
c030emp.SQL "SELECT TABEVE \ 
             FROM R030EMP \ 
             WHERE NUMEMP = :xNumEmp";
c030emp.AbrirCursor();
Se (c030emp.Achou)
  Codigo_TabEve = c030emp.TabEve;
c030emp.FecharCursor();

--------------------------------------------------------------------------------
Código: 5 - Descrição: ModeloGerador_Finalização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 6 - Descrição: ModeloGerador_Imprimir Página
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 7 - Descrição: Detalhe_1_Depois Imprimir
--------------------------------------------------------------------------------

Definir Numero xcodeve;
Definir Numero x;
Definir Numero xperini;
Definir Numero mescmp;
Definir Numero xintmes;
Definir Alfa EAbrEve;
Definir Alfa EAbrNat; 
Definir Alfa deseveant;
Definir Alfa EListarRef;
Definir Alfa xImprimiu_1;
Definir Alfa xImprimiu_2;
/* Tratamento da impressão das seções Adicionais de 
   cabeçalho dos meses ADICIONAL_11 e 12 */
Definir Numero impevecol;

xImprimiu_1 = "N";
xImprimiu_2 = "N";

Se (FlagEventos = 0)  
  Cancel(1);  /* Nao contem nenhum evento */

ListaSecao("Adicional_10");

PosEve = 0;
x = 0;
tipeveant = 0;
codeveant = 0;
deseveant = "";

Enquanto (x < FimEve)   
Inicio
  /* Tratamento da impressão das seções Adicionais de 
    cabeçalho dos meses ADICIONAL_11 e 12 */
  ImpEveCol = 1;
  
  BuscaProxEvento();

  /* Se se o evento esta na abrangencia */
  VerNumAbr(RelFicCod, EAbrEve, xRetorno);
  Se (xRetorno = 0)
    VaPara PrxCmp;
    
  VerNumAbr(RelFicNat, EAbrNat, xRetorno);
  Se (xRetorno = 0)
    VaPara PrxCmp;

  RetornaMesData(ENPerIni, xPerIni);
  RetornaMesData(RelFicCmp, xMesCmp);

  /* Verifica codigo do evento */
  Se ((RelFicCod <> codeveant) e (codeveant <> 0))
  Inicio          
    ListaSecao ("Adicional_2");

    Se (EListarRef = "S") 
      ListaSecao("Adicional_7");  @ Referencias @

    FAValMe1 = 0; 
    FAValMe2 = 0;
    FAValMe3 = 0; 
    FAValMe4 = 0;
    FAValMe5 = 0;
    FAValMe6 = 0;
    FAValMe7 = 0;
    FAValMe8 = 0;
    FAValMe9 = 0;
    FAValMe10 = 0;
    FAValMe11 = 0;
    FAValMe12 = 0; 
    
    FRefEve1 = 0;
    FRefEve2 = 0;
    FRefEve3 = 0;
    FRefEve4 = 0;
    FRefEve5 = 0;
    FRefEve6 = 0;
    FRefEve7 = 0;
    FRefEve8 = 0;
    FRefEve9 = 0;
    FRefEve10 = 0;
    FRefEve11 = 0;
    FRefEve12 = 0;
  Fim; 
  
  Se (RelFicTip <> tipeveant)
  Inicio
    Se (tipeveant <> 0)
      ListaSecao ("Adicional_5");

    /* Tratamento da impressão das seções Adicionais de 
       cabeçalho dos meses ADICIONAL_11 e 12 */
    ImpEveCol = 0;
    ListaSecao ("Adicional_1");
    ImpEveCol = 1;
  Fim; 
  
  TipEveAnt = RelFicTip;   
  CodEveAnt = RelFicCod;
  DesEveAnt = RelFicDes;
  FACodEve = codeveant;
  
  Se (xperini = xmescmp)
  Inicio            
    FAValMe1 = RelFicVal;
    FRefEve1 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;    

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe2 = RelFicVal;
    FRefEve2 = RelFicRef;
    VaPara PrxCmp;
  Fim; 
  Senao
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe3 = RelFicVal;
    FRefEve3 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe4 = RelFicVal;
    FRefEve4 = RelFicRef;
    VaPara PrxCmp;   
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
      xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe5 = RelFicVal;
    FRefEve5 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe6 = RelFicVal;
    FRefEve6 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe7 = RelFicVal; 
    FRefEve7 = RelFicRef;
    VaPara PrxCmp;
  Fim; 
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe8 = RelFicVal;
    FRefEve8 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe9 = RelFicVal;
    FRefEve9 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe10 = RelFicVal;
    FRefEve10 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xperini = xperini + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe11 = RelFicVal;
    FRefEve11 = RelFicRef;
    VaPara PrxCmp; 
  Fim;
  Senao 
    xPerIni = xPerIni + 1;       

  Se (xperini = 13)
    xperini = 1;
  
  Se (xPerIni = xmescmp)
  Inicio            
    FAValMe12 = RelFicVal;
    FRefEve12 = RelFicRef;
    VaPara PrxCmp;
  Fim;
  Senao 
    xPerIni = xPerIni + 1;       
  Se (xperini = 13)
    xperini = 1;
  
  PrxCmp: 
  x = x + 1;
Fim;
ListaSecao("Adicional_2");

Se (EListarRef = "S") 
  ListaSecao("Adicional_7"); /* Referências */

ListaSecao ("Adicional_5");

FAValMe1 = 0;
FAValMe2 = 0;
FAValMe3 = 0; 
FAValMe4 = 0;
FAValMe5 = 0;
FAValMe6 = 0;
FAValMe7 = 0;
FAValMe8 = 0;
FAValMe9 = 0;
FAValMe10 = 0;
FAValMe11 = 0;
FAValMe12 = 0; 

FRefEve1 =  0;
FRefEve2 =  0;
FRefEve3 =  0;
FRefEve4 =  0;
FRefEve5 =  0;
FRefEve6 =  0;
FRefEve7 =  0;
FRefEve8 =  0;
FRefEve9 =  0;
FRefEve10 = 0;         
FRefEve11 = 0;
FRefEve12 = 0;

/* Somatório dos Eventos (Adicional 1) por tipo (Check para último listado) */
FATotEv1 = 0;
FATotGe1 = 0;
FATotRef = 0;

Se (tipeveant = 1)
Inicio
  totpro1 = total001;  
  totpro2 = total002;  
  totpro3 = total003;  
  totpro4 = total004;  
  totpro5 = total005;  
  totpro6 = total006;  
  totpro7 = total007;  
  totpro8 = total008;  
  totpro9 = total009;  
  totpro10 = total010;  
  totpro11 = total011;  
  totpro12 = total012;  
Fim; 

Se (tipeveant = 2)
Inicio
  totvan1 = total001;  
  totvan2 = total002;  
  totvan3 = total003;  
  totvan4 = total004;  
  totvan5 = total005;  
  totvan6 = total006;  
  totvan7 = total007;  
  totvan8 = total008;  
  totvan9 = total009;  
  totvan10 = total010;  
  totvan11 = total011;  
  totvan12 = total012;  
Fim; 

Se (tipeveant = 3)
Inicio
  totdes1 = total001;  
  totdes2 = total002;  
  totdes3 = total003;  
  totdes4 = total004;  
  totdes5 = total005;  
  totdes6 = total006;  
  totdes7 = total007;  
  totdes8 = total008;  
  totdes9 = total009;  
  totdes10 = total010;  
  totdes11 = total011;  
  totdes12 = total012;  
Fim; 

xIntMes = IntMes;

/* Calculos para somatorio Salario Bruto geral */
CarregarInfoFicFin(R034FUN.NumEmp, R034FUN.TipCol, R034FUN.NumCad, ENTipCal, ENPerIni, xIntMes);
x = 1;
Enquanto (x <= xIntMes)
Inicio  
  xSalBas = InfSalEmp[x];

  Se (x = 1)
    FASalBas1 = xSalBas;
  Se (x = 2)
    FASalBas2 = xSalBas;
  Se (x = 3)
    FASalBas3 = xSalBas;
  Se (x = 4)
    FASalBas4 = xSalBas;
  Se (x = 5)
    FASalBas5 = xSalBas;
  Se (x = 6)
    FASalBas6 = xSalBas;
  Se (x = 7)
    FASalBas7 = xSalBas;
  Se (x = 8)
    FASalBas8 = xSalBas;
  Se (x = 9)
    FASalBas9 = xSalBas;
  Se (x = 10)
    FASalBas10 = xSalBas;
  Se (x = 11)
    FASalBas11 = xSalBas;
  Se (x = 12)
    FASalBas12 = xSalBas; 

  x = x + 1;
Fim;

FATotBas = (FASalBas1 + FASalBas2 + FASalBas3 + FASalBas4 + FASalBas5 + FASalBas6 + 
            FASalBas7 + FASalBas8 + FASalBas9 + FASalBas10 + FASalBas11 + FASalBas12);

/* Calculos para somatorio Salario Liquido Geral */
x = 1;
Enquanto (x <= xIntMes)
Inicio  
  Se (x = 1)
    FASalLiq1 = ((TotPro1 + TotVan1) - TotDes1);
  Se (x = 2)
    FASalLiq2 = ((TotPro2 + TotVan2) - TotDes2);
  Se (x = 3)
    FASalLiq3 = ((TotPro3 + TotVan3) - TotDes3);
  Se (x = 4)
    FASalLiq4 = ((TotPro4 + TotVan4) - TotDes4);
  Se (x = 5)
    FASalLiq5 = ((TotPro5 + TotVan5) - TotDes5);
  Se (x = 6)
    FASalLiq6 = ((TotPro6 + TotVan6) - TotDes6);
  Se (x = 7)
    FASalLiq7 = ((TotPro7 + TotVan7) - TotDes7);
  Se (x = 8)
    FASalLiq8 = ((TotPro8 + TotVan8) - TotDes8);
  Se (x = 9)
    FASalLiq9 = ((TotPro9 + TotVan9) - TotDes9);
  Se (x = 10)
    FASalLiq10 = ((TotPro10 + TotVan10) - TotDes10);
  Se (x = 11)
    FASalLiq11 = ((TotPro11 + TotVan11) - TotDes11);
  Se (x = 12)
    FASalLiq12 = ((TotPro12 + TotVan12) - TotDes12);

  x = x + 1;
Fim;

FATotLiq = (FASalLiq1 + FASalLiq2 + FASalLiq3 + FASalLiq4 + FASalLiq5 + FASalLiq6 + 
            FASalLiq7 + FASalLiq8 + FASalLiq9 + FASalLiq10 + FASalLiq11 + FASalLiq12);

ListaSecao ("Adicional_8");

/* Tratamento da impressão das seções Adicionais de 
   cabeçalho dos meses ADICIONAL_11 e 12 */
ImpEveCol = 0;

--------------------------------------------------------------------------------
Código: 8 - Descrição: Detalhe_1_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa EAbrEve;
Definir Alfa vCarRed;
Definir Alfa vCarEmp;
Definir Alfa xDesSal;
Definir Alfa xDesCon;
Definir Alfa xDesSit;
Definir Alfa stipsal;
Definir Alfa stipcon;
Definir Alfa vNumCid;
Definir Alfa EAbrNat;
Definir Alfa xDatRef;
Definir Numero ssitafa;
Definir Data vDiaFimCmp;
Definir Cursor c010sit;
Definir Cursor Cur_24Car;
Definir Cursor Cur_34CPL;
Definir Cursor cR046INF;
Definir Data xCmpDatRef;

vNumEMp = R034Fun.NumEmp;
vTipCol = R034Fun.TipCol;
vNumCad = R034FUN.NumCad;

RetSitEmp (vNumEmp, vTipCol, vNumCad, vDiaFimCmp);

@ - Validacao para verificar se o colaborador tem no minimo um evento - @
x = 0;
PosEve = 0;
TipEveAnt = 0;
CodEveAnt = 0;
FlagEventos = 0; /* 0 = Nao tem nenhum evento, 1 = Tem 1 ou mais eventos (Imprimir) */

Enquanto ((x < FimEve) e (FlagEventos = 0))   
Inicio
  BuscaProxEvento();

  /* Se se o evento esta na abrangencia */
  VerNumAbr(RelFicCod, EAbrEve, xRetCodEve);
  Se (xRetCodEve = 1)
  Inicio
    FlagEventos = 1;
    VerNumAbr(RelFicNat, EAbrNat, xRetNatEve);
    Se (xRetNatEve = 0) 
      FlagEventos = 0;
  Fim; 

  x = x + 1;
Fim;
Se (FlagEventos = 0 ) 
  Cancel(1);

@ - Busca informações dos históricos / Complementar do Colaborador - @
@ - Salario - @
RetSalEmp(vNumEmp, vTipCol, vNumCad, vDiaFimCmp);
FASalBas = 0;
FTipSal = 0;
@- Busca o salário base utilizado no último cálculo de folha na competência informada na tela de entrada. -@
@- Se não encontrar valor, utiliza a variável de sistema -@
cR046INF.Sql "SELECT R046INF.SALEMP, R046INF.TIPSAL, R044CAL.DATPAG \
              FROM R046INF, R044CAL WHERE \
                R046INF.NUMEMP = :vNumEmp \
                AND R046INF.TIPCOL = :vTipCol \
                AND R046INF.NUMCAD = :vNumCad \ 
                AND R046INF.CODCAL = R044CAL.CODCAL \
                AND R044CAL.NUMEMP = :vNumEmp \
                AND R044CAL.TIPCAL IN (11, 21, 22, 23, 41, 42) \
                AND R044CAL.PERREF = :xCmpDatRef \
              ORDER BY R044CAL.DATPAG DESC";                              
cR046INF.AbrirCursor();
Enquanto ((cR046INF.Achou) e (FASalBas = 0))
Inicio
  FASalBas = cR046INF.SALEMP;
  FTipSal = cR046INF.TIPSAL;
  
  cR046INF.Proximo();
Fim;
cR046INF.FecharCursor();

Se (FASalBas = 0)
Inicio
  FASalBas = SalEmp;
  FTipSal = TipSalEmp;
Fim;  

sTipSal = Formatar(FTipSal, "%2.0f");
DescItemLista ("LTipSal", sTipSal, xDesSal);

@ - Cargo - @
RetCarEmp(vNumEmp, vTipCol, vNumCad, vDiaFimCmp);
vEstCarEmp = EstCarEmp;
vCarEmp = CarEmp;
vCarRed = "";
Cur_24Car.SQL "SELECT TITRED \
               FROM R024CAR \
               WHERE ESTCAR = :vEstCarEmp AND \
                     CODCAR = :vCarEmp ";
Cur_24Car.AbrirCursor();
Se (Cur_24Car.Achou)
  vCarRed = Cur_24Car.TitRed;
Cur_24Car.FecharCursor();

@ - Situação - @
RetSitEmp(vNumEmp, vTipCol, vNumCad, vDiaFimCmp);
FTipSit = SitEmp;
ssitafa = SitEmp;
/* Retorna a descrição da situação e a imprime no relatório */
c010sit.SQL "SELECT DESSIT \ 
             FROM R010SIT \
             WHERE CODSIT = :ssitafa";
c010sit.AbrirCursor();
Se (c010sit.Achou)
  xDesSit = c010sit.DesSit;
Senao
  xDesSit = " ";
c010sit.FecharCursor();

@ - Tipo de Contrato - @
stipcon = formatar (R034FUN.TIPCON,"%2.0f");
DescItemLista ("LTipCon", stipcon, xDesCon);

@ - Complementar - @
vNumCid = "";
Cur_34CPL.SQL "SELECT NUMCID \ 
               FROM R034CPL \
               WHERE NUMEMP = :vNumEmp AND \
                     TIPCOL = :vTipCol AND \
                     NumCad = :vNumCad ";
Cur_34CPL.AbrirCursor();
Se (Cur_34CPL.Achou)
  vNumCid = Cur_34CPL.NumCid;
Cur_34CPL.FecharCursor();

@ Para domésticos, se for informado o nro do INSS, deve ser mostrado no local do Nro do PIS @
AlteraControle("Cadastro016","Imprimir","Falso");
AlteraControle("Cadastro010","Imprimir","Verdadeiro");
AlteraControle("Descricao074","Descrição","PIS:");

Se (R034FUN.TipCon = 12)
Inicio
  Se (R034FUN.NumIns <> 0)
  Inicio
    AlteraControle("Cadastro016","Imprimir","Verdadeiro");
    AlteraControle("Cadastro010","Imprimir","Falso");
    AlteraControle("Descricao074","Descrição","INSS:");
  Fim;
Fim;

--------------------------------------------------------------------------------
Código: 9 - Descrição: Cadastro014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 10 - Descrição: Cadastro001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 11 - Descrição: Especial002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 12 - Descrição: FASalBas_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 13 - Descrição: Descricao073_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 14 - Descrição: DesSal_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa xDesSal;

ValStr = xDesSal;
Cancel(2);

--------------------------------------------------------------------------------
Código: 15 - Descrição: Descricao015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 16 - Descrição: Descricao048_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 17 - Descrição: FTipSal_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 18 - Descrição: Descricao071_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 19 - Descrição: Cadastro002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 20 - Descrição: Descricao020_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 21 - Descrição: Descricao023_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa vNumCid;

ValStr = vNumCid;
Cancel(2);

--------------------------------------------------------------------------------
Código: 22 - Descrição: Descricao074_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 23 - Descrição: Descricao075_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 24 - Descrição: Descricao076_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 25 - Descrição: Cadastro017_Na Impressão
--------------------------------------------------------------------------------

Se (TipSitEmp <> 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 26 - Descrição: Descricao011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 27 - Descrição: Descricao072_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 28 - Descrição: Descricao070_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 29 - Descrição: Descricao050_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 30 - Descrição: FTipSit_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 31 - Descrição: DesSit_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa xDesSit;

ValStr = xDesSit;
Cancel(2);

--------------------------------------------------------------------------------
Código: 32 - Descrição: Descricao077_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 33 - Descrição: Cadastro018_Na Impressão
--------------------------------------------------------------------------------

Se (TipSitEmp <> 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 34 - Descrição: LDDesCab_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 35 - Descrição: Cadastro008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 36 - Descrição: LDDes002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 37 - Descrição: Cadastro015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 38 - Descrição: LDDes001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 39 - Descrição: LDTipCol_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 40 - Descrição: Cadastro007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 41 - Descrição: Cadastro006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 42 - Descrição: Descricao013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 43 - Descrição: Cadastro004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 44 - Descrição: Descricao038_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 45 - Descrição: Cadastro013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 46 - Descrição: DesCon_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa xDesCon;

ValStr = xDesCon;
Cancel(2);

--------------------------------------------------------------------------------
Código: 47 - Descrição: Cadastro012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 48 - Descrição: Descricao049_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 49 - Descrição: Cadastro003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 50 - Descrição: Cadastro010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 51 - Descrição: Descricao021_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa vCarRed;

ValStr = vCarRed;
Cancel(2);

--------------------------------------------------------------------------------
Código: 52 - Descrição: Cadastro016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 53 - Descrição: Cadastro009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 54 - Descrição: Cadastro005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 55 - Descrição: Subtitulo_1_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 56 - Descrição: Subtitulo_1_Antes Imprimir
--------------------------------------------------------------------------------

Se ((EspnivTot = 0 ) e (EspNivQue = 0))
  cancel(1);

--------------------------------------------------------------------------------
Código: 57 - Descrição: Especial001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 58 - Descrição: Adicional_2_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 59 - Descrição: Adicional_2_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa ENSomTot;

Se (ENSomTot = "S")
  Cancel(1);

--------------------------------------------------------------------------------
Código: 60 - Descrição: Descricao008_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa EListarRef;

Se (EListarRef = "N")
  Cancel (1);

--------------------------------------------------------------------------------
Código: 61 - Descrição: Descricao024_Na Impressão
--------------------------------------------------------------------------------

Se (EListarRef = "N")
  Cancel (1);

--------------------------------------------------------------------------------
Código: 62 - Descrição: FAValMe4_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 3)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 63 - Descrição: FAValMe3_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 2)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 64 - Descrição: FAValMe5_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 4)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 65 - Descrição: FAValMe6_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 5)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 66 - Descrição: FAValMe7_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 6)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 67 - Descrição: FAValMe8_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 68 - Descrição: FAValMe9_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 8)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 69 - Descrição: FAValMe10_Na Impressão
--------------------------------------------------------------------------------

Se   (IntMes <= 9)
     Cancel(1);
















--------------------------------------------------------------------------------
Código: 70 - Descrição: FAValMe11_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 10)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 71 - Descrição: FAValMe12_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 11)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 72 - Descrição: FACodEv_Na Impressão
--------------------------------------------------------------------------------

Se (codeveant = 0)
  Cancel(1);
Senao
  FACodEv = codeveant;

--------------------------------------------------------------------------------
Código: 73 - Descrição: Descricao012_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa DesEveAnt;

ValStr = DesEveAnt;
Cancel(2);

--------------------------------------------------------------------------------
Código: 74 - Descrição: FAValMe1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 75 - Descrição: FAValMe2_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes = 1)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 76 - Descrição: FATotEv1_Na Impressão
--------------------------------------------------------------------------------

FATotEv1 = FAValMe1 + FAValMe2 + FAValMe3 + FAValMe4 + FAValMe5 + FAValMe6 + 
           FAValMe7 + FAValMe8 + FAValMe9 + FAValMe10 + FAValMe11 + FAValMe12; 

FATotGe1 = FATotGe1 + FATotEv1;

--------------------------------------------------------------------------------
Código: 77 - Descrição: FAMedEv1_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa ECalcMed;

Se (ECalcMed = "N")
  Cancel(1);
Senao
  FAMedEv1 = (FATotEv1 / IntMes);

--------------------------------------------------------------------------------
Código: 78 - Descrição: Adicional_1_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 79 - Descrição: Adicional_1_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa ENSomTot;

FATotEv1 = 0;
FATotGe1 = 0;
FATotRef = 0;

Se (TipEveAnt = 1)
Inicio
  TotPro1 = Total001;  
  TotPro2 = Total002;  
  TotPro3 = Total003;  
  TotPro4 = Total004;  
  TotPro5 = Total005;  
  TotPro6 = Total006;  
  TotPro7 = Total007;  
  TotPro8 = Total008;  
  TotPro9 = Total009;  
  TotPro10 = Total010;  
  TotPro11 = Total011;  
  TotPro12 = Total012;  
Fim; 
Se (TipEveAnt = 2)
Inicio
  TotVan1 = Total001;  
  TotVan2 = Total002;  
  TotVan3 = Total003;  
  TotVan4 = Total004;  
  TotVan5 = Total005;  
  TotVan6 = Total006;  
  TotVan7 = Total007;  
  TotVan8 = Total008;  
  TotVan9 = Total009;  
  TotVan10 = Total010;  
  TotVan11 = Total011;  
  TotVan12 = Total012;  
Fim; 
Se (TipEveAnt = 3)
Inicio
  TotDes1 = Total001;  
  TotDes2 = Total002;  
  TotDes3 = Total003;  
  TotDes4 = Total004;  
  TotDes5 = Total005;  
  TotDes6 = Total006;  
  TotDes7 = Total007;  
  TotDes8 = Total008;  
  TotDes9 = Total009;  
  TotDes10 = Total010;  
  TotDes11 = Total011;  
  TotDes12 = Total012;    
Fim;

Se (ENSomTot = "S")
  Cancel(1);

--------------------------------------------------------------------------------
Código: 80 - Descrição: DENatTip_Na Impressão
--------------------------------------------------------------------------------

Se (RelFicTip = 1)
  ValStr = "Proventos";
Se (RelFicTip = 2)
  ValStr = "Vantagens";
Se (RelFicTip = 3)
  ValStr = "Descontos";
Se ((RelFicTip = 4) ou (RelFicTip = 5) ou (RelFicTip = 6))
  ValStr = "Outros";

Cancel(2);

--------------------------------------------------------------------------------
Código: 81 - Descrição: Adicional_5_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 82 - Descrição: Adicional_5_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 83 - Descrição: Total001_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes1 <> " ") e (Total001 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

--------------------------------------------------------------------------------
Código: 84 - Descrição: Descricao001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 85 - Descrição: Descricao002_Na Impressão
--------------------------------------------------------------------------------

Se (TipEveAnt = 1)
  ValStr = "Proventos";
Se (TipEveAnt = 2)
  ValStr = "Vantagens";
Se (TipEveAnt = 3)
  ValStr = "Descontos";
Se ((TipEveAnt = 4) ou (TipEveAnt = 5) ou (TipEveAnt = 6))
  ValStr = "Outros";
  
Cancel(2);

--------------------------------------------------------------------------------
Código: 86 - Descrição: Total002_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes2 <> " ") e (Total002 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 1)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 87 - Descrição: Total003_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes3 <> " ") e (Total003 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 2)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 88 - Descrição: Total004_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes4 <> " ") e (Total004 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 3)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 89 - Descrição: Total005_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes5 <> " ") e (Total005 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 4)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 90 - Descrição: Total006_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes6 <> " ") e (Total006 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 5)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 91 - Descrição: Total009_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes9 <> " ") e (Total009 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 8)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 92 - Descrição: Total008_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes8 <> " ") e (Total008 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 93 - Descrição: Total007_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes7 <> " ") e (Total007 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 6)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 94 - Descrição: Total010_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes10 <> " ") e (Total010 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 9)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 95 - Descrição: Total011_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes11 <> " ") e (Total011 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 10)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 96 - Descrição: Total012_Na Impressão
--------------------------------------------------------------------------------

Se ((vMes12 <> " ") e (Total012 <= 0))
Inicio
  ValStr = "0,00";
  Cancel(2);
Fim;

Se (IntMes = 11)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 97 - Descrição: FMedTot_Na Impressão
--------------------------------------------------------------------------------

Se (ECalcMed = "N")
  Cancel(1);

FMedTot = (FATotGe1 / IntMes);

--------------------------------------------------------------------------------
Código: 98 - Descrição: FATotGe1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 99 - Descrição: Cabecalho_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 100 - Descrição: Cabecalho_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa EnTitRel[50];

Se (EnTitRel = "")
  AlteraControle("DTitulo", "Descrição", "Relação Ficha Financeira");
Senao
  AlteraControle("DTitulo", "Descrição", ENTitRel);

FAIniCmp = EnPerIni;
FAFimCmp = EDatRef;

--------------------------------------------------------------------------------
Código: 101 - Descrição: DTitulo_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 102 - Descrição: Sistema001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 103 - Descrição: Descricao004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 104 - Descrição: Sistema003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 105 - Descrição: Descricao006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 106 - Descrição: Sistema002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 107 - Descrição: Descricao022_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 108 - Descrição: FAFimCmp_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 109 - Descrição: FAIniCmp_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 110 - Descrição: a_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 111 - Descrição: Adicional_8_Depois Imprimir
--------------------------------------------------------------------------------

Totpro1 = 0;
TotPro2 = 0;
TotPro3 = 0;
TotPro4 = 0;
TotPro5 = 0;
TotPro6 = 0;
TotPro7 = 0;
TotPro8 = 0;
TotPro9 = 0;
TotPro10 = 0;
TotPro11 = 0;
TotPro12 = 0;

Totvan1 = 0;
TotVan2 = 0;
TotVan3 = 0;
TotVan4 = 0;
TotVan5 = 0;
TotVan6 = 0;
TotVan7 = 0;
TotVan8 = 0;
TotVan9 = 0;
TotVan10 = 0;
TotVan11 = 0;
TotVan12 = 0;

Totdes1 = 0; 
TotDes2 = 0;
TotDes3 = 0;
TotDes4 = 0;
TotDes5 = 0;
TotDes6 = 0;
TotDes7 = 0;
TotDes8 = 0;  
TotDes9 = 0; 
TotDes10 = 0;
TotDes11 = 0;
TotDes12 = 0;

--------------------------------------------------------------------------------
Código: 112 - Descrição: Adicional_8_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 113 - Descrição: Descricao003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 114 - Descrição: Descricao005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 115 - Descrição: FASalBas7_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 6)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 116 - Descrição: FASalBas4_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 3)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 117 - Descrição: FASalBas5_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 4)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 118 - Descrição: FASalLiq3_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 2)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 119 - Descrição: FASalLiq4_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 3)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 120 - Descrição: FASalLiq5_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 4)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 121 - Descrição: FASalLiq2_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes = 1)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 122 - Descrição: FASalBas1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 123 - Descrição: FASalLiq1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 124 - Descrição: FASalLiq7_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 6)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 125 - Descrição: FASalLiq6_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 5)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 126 - Descrição: FASalBas8_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 127 - Descrição: FASalLiq8_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 7)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 128 - Descrição: FASalLiq12_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 11)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 129 - Descrição: FASalLiq11_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 10)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 130 - Descrição: FASalBas11_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 10)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 131 - Descrição: FASalBas12_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 11)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 132 - Descrição: FASalBas10_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 9)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 133 - Descrição: FASalLiq10_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 9)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 134 - Descrição: FASalLiq9_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 8)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 135 - Descrição: FASalBas9_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 8)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 136 - Descrição: FASalBas6_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 5)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 137 - Descrição: FASalBas2_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes = 1)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 138 - Descrição: FASalBas3_Na Impressão
--------------------------------------------------------------------------------

Se (IntMes <= 2)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 139 - Descrição: FMedLiq_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa ECalcMed;

Se (ECalcMed = "N")
  Cancel(1);

FMedLiq = (FATotLiq / IntMes);

--------------------------------------------------------------------------------
Código: 140 - Descrição: FATotBas_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 141 - Descrição: FATotLiq_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 142 - Descrição: FMedBas_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa ECalcMed;

Se (ECalcMed = "N")
  Cancel(1);

FMedBas = (FATotBas / IntMes);

--------------------------------------------------------------------------------
Código: 143 - Descrição: Rodape_Cabecalho_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 144 - Descrição: Rodape_Cabecalho_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 145 - Descrição: Sistema010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 146 - Descrição: Adicional_7_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 147 - Descrição: Adicional_7_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa ENSomTot;
Definir Numero Codigo_TabEve;

Se (ENSomTot = "S")
  Cancel(1);
Senao
Inicio
  /* Converte referências em minutos para calcular o total
     e posteriormente a média */
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve1, FRefEve1);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve2, FRefEve2);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve3, FRefEve3);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve4, FRefEve4);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve5, FRefEve5);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve6, FRefEve6);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve7, FRefEve7);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve8, FRefEve8);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve9, FRefEve9);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve10, FRefEve10);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve11, FRefEve11);
  RetRefMin(Codigo_TabEve, FACodEve, FRefEve12, FRefEve12);

  FATotRef = FRefEve1 + FRefEve2 + FRefEve3 + FRefEve4 + FRefEve5 + FRefEve6 + 
             FRefEve7 + FRefEve8 + FRefEve9 + FRefEve10 + FRefEve11 + FRefEve12; 

  FAMedRef = FATotRef / IntMes;

  /* Se for referência de hora xTotRef vai estar em minutos, tendo que ser transformado para horas */
  Se (TipHorMov = 1)
  Inicio
    /* Alterar a máscara para hora centesimal ou normal */
    Se (CentesimalTime = 1)
    Inicio
      AlteraControle("FRefEve1", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve2", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve3", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve4", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve5", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve6", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve7", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve8", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve9", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve10", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve11", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FRefEve12", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FATotRef", "Edição Campo", "#C#zzzzzhh:mm");
      AlteraControle("FAMedRef", "Edição Campo", "#C#zzzzzhh:mm");
    Fim; 
    Senao
    Inicio
      AlteraControle("FRefEve1", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve2", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve3", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve4", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve5", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve6", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve7", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve8", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve9", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve10", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve11", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FRefEve12", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FATotRef", "Edição Campo", "zzzzzhh:mm");
      AlteraControle("FAMedRef", "Edição Campo", "zzzzzhh:mm");
    Fim;  
  Fim;
  Senao
  Inicio
    AlteraControle("FRefEve1", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve2", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve3", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve4", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve5", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve6", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve7", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve8", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve9", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve10", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve11", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FRefEve12", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FATotRef", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
    AlteraControle("FAMedRef", "Edição Campo", "#-2#ZZZ.ZZZ.ZZ9,99");
  Fim;       
Fim;

--------------------------------------------------------------------------------
Código: 148 - Descrição: FRefEve6_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe6 = 0) e (FRefEve6 = 0) e (IntMes <= 5))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 149 - Descrição: FRefEve7_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe7 = 0) e (FRefEve7 = 0) e (IntMes <= 6))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 150 - Descrição: FRefEve8_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe8 = 0) e (FRefEve8 = 0) e (IntMes <= 7))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 151 - Descrição: FRefEve9_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe9 = 0) e (FRefEve9 = 0) e (IntMes <= 8))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 152 - Descrição: FRefEve10_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe10 = 0) e (FRefEve10 = 0) e (IntMes <= 9))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 153 - Descrição: FRefEve11_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe11 = 0) e (FRefEve11 = 0) e (IntMes <= 10))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 154 - Descrição: FRefEve12_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe12 = 0) e (FRefEve12 = 0) e (IntMes <= 11))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 155 - Descrição: Descricao018_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 156 - Descrição: FRefEve3_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe3 = 0) e (FRefEve3 = 0) e (IntMes <= 2))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 157 - Descrição: FRefEve5_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe5 = 0) e (FRefEve5 = 0) e (IntMes <= 4))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 158 - Descrição: FRefEve4_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe4 = 0) e (FRefEve4 = 0) e (IntMes <= 3))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 159 - Descrição: FRefEve1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 160 - Descrição: FRefEve2_Na Impressão
--------------------------------------------------------------------------------

Se ((FAValMe2 = 0) e (FRefEve2 = 0) e (IntMes = 1))
  Cancel(1);

--------------------------------------------------------------------------------
Código: 161 - Descrição: FAMedRef_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa ECalcMed;

Se (ECalcMed = "N")
  Cancel(1);

--------------------------------------------------------------------------------
Código: 162 - Descrição: FATotRef_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 163 - Descrição: Adicional_10_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 164 - Descrição: Adicional_10_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa xImprimiu_1;
Definir Alfa ENSomTot;
Definir Alfa vMes1;
Definir Alfa vMes2;
Definir Alfa vMes3;
Definir Alfa vMes4;
Definir Alfa vMes5;
Definir Alfa vMes6;
Definir Alfa vMes7;
Definir Alfa vMes8;
Definir Alfa vMes9;
Definir Alfa vMes10;
Definir Alfa vMes11;
Definir Alfa vMes12;


AlteraControle("DEMes1", "Descrição", vMes1);
AlteraControle("DEMes2", "Descrição", vMes2);
AlteraControle("DEMes3", "Descrição", vMes3);
AlteraControle("DEMes4", "Descrição", vMes4);
AlteraControle("DEMes5", "Descrição", vMes5);
AlteraControle("DEMes6", "Descrição", vMes6);
AlteraControle("DEMes7", "Descrição", vMes7);
AlteraControle("DEMes8", "Descrição", vMes8);
AlteraControle("DEMes9", "Descrição", vMes9);
AlteraControle("DEMes10", "Descrição", vMes10);
AlteraControle("DEMes11", "Descrição", vMes11);
AlteraControle("DEMes12", "Descrição", vMes12);

Se ((ENSomTot = "S") e (xImprimiu_1 = "S"))
  Cancel(1);

xImprimiu_1 = "S";

--------------------------------------------------------------------------------
Código: 165 - Descrição: DEMes5_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 166 - Descrição: DEMes6_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 167 - Descrição: DEMes7_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 168 - Descrição: DEMes8_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 169 - Descrição: DEMes9_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 170 - Descrição: DEMes10_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 171 - Descrição: DEMes11_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 172 - Descrição: DEMes2_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 173 - Descrição: DEMes3_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 174 - Descrição: DEMes12_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 175 - Descrição: Descricao010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 176 - Descrição: DEMes1_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 177 - Descrição: Descricao016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 178 - Descrição: DEMes4_Na Impressão
--------------------------------------------------------------------------------
