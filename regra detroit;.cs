
--------------------------------------------------------------------------------
Código: 1 - Descrição: ModeloGerador_Funções Globais
--------------------------------------------------------------------------------

Definir Funcao ConsiderarAfastamentos();

Funcao ConsiderarAfastamentos();
inicio
  Definir Numero xNumEmp;
  Definir Numero xTipCol;
  Definir Numero xNumCad;
  Definir Numero xDiaAfa;
  Definir Numero xPrazo1;
  Definir Numero xPrazo2;
  Definir Data xDatAfa;
  Definir Data xDatAdm;
  Definir Cursor Cur_R038AFA;
  Definir Alfa EConAfa;
  Definir Numero xDatAfaJus;
  
  
  @--- Mostra os controles pra mostrar os valores ---@ 
  AlteraControle("FPrazo1","Imprimir","Verdadeiro");
  AlteraControle("FPrazo2","Imprimir","Verdadeiro");
  
  
  @--- Considera Afastamentos ---@
  Se (EConAfa = "S")
  Inicio
   
    xNumEmp = R034FUN.NumEmp;
    xTipCol = R034FUN.TipCol;
    xNumCad = R034FUN.NumCad;
    xDatAdm = R034FUN.DatAdm;
    xDatAfa = EDatFim;
    xPrazo1 = 0;
    xPrazo2 = 0;
    xDiaAfa = 0;
    
    @--- Verifica se o colaborador possui afastamentos por Auxilio-Doença ou Acidente de Trabalho ---@
    Cur_R038AFA.SQL "SELECT R038AFA.DATAFA, \
                            R038AFA.DATTER, \ 
                            R038AFA.DIAJUS \
                     FROM R038AFA, \
                          R010SIT \
                     WHERE R038AFA.NUMEMP = :xNumEmp \
                       AND R038AFA.TIPCOL = :xTipCol \
                       AND R038AFA.NUMCAD = :xNumCad \
                       AND R038AFA.DATAFA >= :xDatAdm \
                       AND R038AFA.DATAFA <= :xDatAfa \
                       AND R038AFA.SITAFA = R010SIT.CODSIT ";      @ --- Alterado Ch.20817 --- AND (((R010SIT.TIPSIT = 3) OR (R010SIT.TIPSIT = 4)) OR ((R038AFA.SITAFA = 32) OR (R038AFA.SITAFA = 33))) @
      @ Alteração feita de acordo com o pedido de Rosemeri 04/02/2020    @
    Cur_R038AFA.AbrirCursor();
  
    @--- Enquando achou afastamentos ---@
    Enquanto (Cur_R038AFA.Achou) 
    Inicio
      xDatAfaJus = Cur_R038AFA.DiaJus + Cur_R038AFA.DatAfa;
      @--- Se o Afastamento ja estiver terminado ---@
      Se (Cur_R038AFA.DatTer > 0) 
      Inicio
        @--- Mostra os controles pra mostrar os valores ---@ 
        AlteraControle("FPrazo1","Imprimir","Verdadeiro");
        AlteraControle("FPrazo2","Imprimir","Verdadeiro");
        xPrazo1 = 0;
        xPrazo2 = 0;
      
        @--- Calcula quantos dias o colaborador ficou afastado ---@ 
        xDiaAfa = (Cur_R038AFA.DatTer - Cur_R038AFA.DatAfa) + 1;
        xDiaAfa = xDiaAfa - Cur_R038AFA.DiaJus;
      
        @--- Verifica se o afastamento ocorreu no primeiro periodo do contrato ou no segundo ---@
        Se (xDatAfaJus <= (FPrazo1))
          xPrazo1 = xPrazo1;@+ xDiaAfa;         @
        Senao 
        Se ((xDatAfaJus > (FPrazo1)) e (xDatAfaJus <= (FPrazo2))) 
          xPrazo2 = xPrazo2;@ + xDiaAfa;@
            
        @--- Soma os dias afastados com os prazos cadastaados na ficha complementar ---@  
        FPrazo1 = FPrazo1 + xPrazo1;
        @--- Os Afastamentos do primeiro periodo afetam a data final da prorrogação do contrato ---@
        FPrazo2 = FPrazo2 + xPrazo1; @--- Calcula a data de INICIO da prorrogação ---@
        FPrazo2 = FPrazo2 + xPrazo2; @--- Calcula a data de FIM da prorrogação ---@  
  
      Fim;
      @--- Se o Afastamento ainda estiver em andamento ---@
      Senao 
      Inicio
          AlteraControle("FPrazo1","Imprimir","Falso");
          AlteraControle("FPrazo2","Imprimir","Falso"); 
       /* @--- Se o afastamento ainda está em andamento esconde os controles do termido e e prorrogação do contrato ---@
        Se (xDatAfaJus <= (R034FUN.DatAdm + (xDurCon - 1)))
        Inicio
          AlteraControle("FPrazo1","Imprimir","Falso");
          AlteraControle("FPrazo2","Imprimir","Falso");         
        Fim;  
  
        @--- Se o Afastamento for na prorrogação do contrato ---@
        Senao Se ((xDatAfaJus > (R034FUN.DatAdm + (xDurCon - 1))) e (xDatAfaJus <= (R034FUN.DatAdm + ((xDurCon - 1) + xProCon)))) 
          AlteraControle("FPrazo2","Imprimir","Falso");
                                                            */
      Fim;
  
      Cur_R038AFA.Proximo();
    Fim;
  Fim;
  
  @--- Atribui a Duração do Contrato ---@
  FDurCon = xDurCon;
  
  @--- Atribui a Prorrogação do Contrato ---@
  FProCon = xProCon;
Fim;

--------------------------------------------------------------------------------
Código: 2 - Descrição: ModeloGerador_Inicialização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 3 - Descrição: ModeloGerador_Pré-Seleção
--------------------------------------------------------------------------------

Definir Alfa AuxSQL;
Definir Alfa AuxRelac;
Definir Alfa xDatRef;
Definir Alfa AuxSQLHist;
Definir Alfa AuxSQLAbr;
Definir Alfa EAbrSit;
Definir Alfa EAbrFil;
Definir Data EDatRef;


DatRef = EDatFim;
EDatRef = DatRef;
ConverteDataBanco( EDatRef, xDatRef );
AuxRelac = "";


@ -------------- Limitando Tipo de Colaborador (FIXO)--------------- @
AuxSQL = "R034FUN.TIPCOL = 1";
InsClauSQLWhere ("Detalhe_1", AuxSQL);
AuxRelac = " AND ";


@ -------------- Relacionamento com Histórico de Filial (DINÂMICO)--------------- @
@ Não pode ser utilizado o comando MontarSQLHistórico, motivo: transferencia de filial @
Se (EAbrFil <> "")
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
              + " AND "+AuxSQLAbr;
};
Senao
{
      AuxSQL = AuxRelac + " R038HFI.NUMEMP = R034FUN.NUMEMP "
              + " AND R038HFI.TIPCOL = R034FUN.TIPCOL "
              + " AND R038HFI.NUMCAD = R034FUN.NUMCAD "
              + " AND R038HFI.DATALT = (SELECT MAX (DATALT) FROM R038HFI TAB2 WHERE "
              + "(TAB2.NUMEMP = R038HFI.NUMEMP) AND "
              + "(TAB2.TIPCOL = R038HFI.TIPCOL) AND "
              + "(TAB2.NUMCAD = R038HFI.NUMCAD) AND "
              + "(TAB2.NUMEMP = TAB2.EMPATU) AND "
              + "(TAB2.NUMCAD = TAB2.CADATU) AND "
              + "(TAB2.DATALT <= " + xDatRef + ")) ";
}   
InsClauSqlWhere("Detalhe_1", AuxSQL);
AuxRelac = " AND ";


@ -------------- Relacionamento Histórico Local (FIXO) -------------- @
MontarSqlHistorico ("R038HLO", EDatRef, AuxSQLHist);
AuxSQL = AuxRelac + AuxSQLHist;
InsClauSqlWhere("Detalhe_1",AuxSQL);
AuxRelac = " AND ";


@ -------------- Relacionamento Histórico Cargo (FIXO) -------------- @
MontarSqlHistorico ("R038HCA", EDatRef, AuxSQLHist);
AuxSQL = AuxRelac + AuxSQLHist;
InsClauSqlWhere("Detalhe_1",AuxSQL);
AuxRelac = " AND ";

@ ------- Relacionamento Histórico Vínculo (FIXO) ------- @
MontarSQLHistorico("R038HVI", EDatRef, AuxSQL);
AuxSQL = AuxRelac + AuxSQL;
InsClauSQLWhere ("Detalhe_1", AuxSQL);
AuxRelac = " AND ";


@ -------- Relacionamento Histórico Situação (DINÂMICO) -------- @
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

--------------------------------------------------------------------------------
Código: 4 - Descrição: ModeloGerador_Seleção
--------------------------------------------------------------------------------

Definir Cursor Cur_r034CPL;
Definir Numero xDurCon;
Definir Numero xProCon;
Definir Numero vNumEmp;
Definir Numero vTipCol;
Definir Numero vNumCad;
Definir Alfa   ETipAbr;

vNumEmp = R034FUN.NumEmp;
vTipCol = R034FUN.TipCol;
vNumCad = R034FUN.NumCad;

@-------- Busca dados complementares -------------@
xDurCon = 0;
xProCon = 0;

se (ETipAbr = 'T') @ --- Se for abrangência pela data de término do contrato --- @
  inicio
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
    
    Cur_R034CPL.AbrirCursor();
    
    Se (Cur_R034CPL.Achou)
    Inicio
      xDurCon = Cur_R034CPL.DurCon;
      xProCon = Cur_R034CPL.ProCon; 
    Fim;
    Cur_R034CPL.FecharCursor();
    
    Se (xDurCon = 0)
      Cancel (2);
    
    Se (R034FUN.DatAdm > EDatFim)
      Cancel (2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
    
    ConsiderarAfastamentos();
    
    Se (ETipLis <> ' ')
    Inicio
      Se (ETipLis = 'P')
      Inicio
        Se ((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim))
          Cancel (2); 
      Fim;           
    
      Senao Se (ETipLis = 'S')
      Inicio
        Se ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim))
          Cancel (2);                
        Se (FPrazo2 = 0)
          Cancel (2);
      Fim;               
    
      Senao Se (ETipLis = 'A')  
      Inicio
        Se (((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim)) e 
            ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim)))
          Cancel (2);            
      Fim;           
    Fim;  
fim;
senao  @ --- Senão, se for pela data de admissão --- @
  inicio
    xDurCon = R034FUN.DatAdm;
    
    se ((xDurCon < EDatIni) ou (xDurCon > EDatFim))
      Cancel(2);  
      
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
                           
    Cur_R034CPL.AbrirCursor();
    se (Cur_R034CPL.Achou)
      inicio
        xDurCon = Cur_R034CPL.DurCon;
        xProCon = Cur_R034CPL.ProCon; 
      fim;
    senao
      inicio
        xDurCon = 0;
        xProCon = 0;
      fim;
    Cur_R034CPL.FecharCursor();

    se (xDurCon = 0)
      Cancel(2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
  
  ConsiderarAfastamentos();
    
  fim;      

--------------------------------------------------------------------------------
Código: 5 - Descrição: ModeloGerador_Finalização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 6 - Descrição: ModeloGerador_Imprimir Página
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 7 - Descrição: Cabecalho_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 8 - Descrição: Cabecalho_Antes Imprimir
--------------------------------------------------------------------------------

FPerIni = EDatIni;
FPerFim = EDatFim;

--------------------------------------------------------------------------------
Código: 9 - Descrição: Desenho001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 10 - Descrição: Sistema001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 11 - Descrição: Descricao010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 12 - Descrição: Descricao009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 13 - Descrição: Sistema003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 14 - Descrição: Descricao002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 15 - Descrição: Descricao001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 16 - Descrição: Sistema002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 17 - Descrição: Descricao003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 18 - Descrição: Descricao008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 19 - Descrição: Descricao007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 20 - Descrição: Descricao014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 21 - Descrição: Descricao015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 22 - Descrição: Descricao016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 23 - Descrição: Descricao006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 24 - Descrição: Descricao019_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 25 - Descrição: Descricao004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 26 - Descrição: FPerIni_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 27 - Descrição: FPerFim_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 28 - Descrição: Descricao017_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 29 - Descrição: Descricao018_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 30 - Descrição: Descricao013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 31 - Descrição: Descricao005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 32 - Descrição: Descricao011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 33 - Descrição: Descricao012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 34 - Descrição: Descricao020_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 35 - Descrição: Descricao022_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 36 - Descrição: Descricao024_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 37 - Descrição: Descricao026_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 38 - Descrição: Detalhe_1_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 39 - Descrição: Detalhe_1_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 40 - Descrição: Desenho002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 41 - Descrição: Cadastro010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 42 - Descrição: Cadastro011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 43 - Descrição: Cadastro003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 44 - Descrição: Cadastro002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 45 - Descrição: FTotDia_Na Impressão
--------------------------------------------------------------------------------

Definir Data xDatHoj;

DataHoje(xdathoj);
Se (R034fun.DatAdm <= xDatHoj)
  FTotDia = (xDatHoj - R034FUN.DatAdm);  
Senao
   FTotDia = 0;

--------------------------------------------------------------------------------
Código: 46 - Descrição: FDurCon_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 47 - Descrição: FPrazo1_Na Impressão
--------------------------------------------------------------------------------

Definir FUncao ConsiderarAfastamentos(); 
Definir Cursor Cur_r034CPL;
Definir Numero xDurCon;
Definir Numero xProCon;
Definir Numero vNumEmp;
Definir Numero vTipCol;
Definir Numero vNumCad;
Definir Alfa   ETipAbr;

vNumEmp = R034FUN.NumEmp;
vTipCol = R034FUN.TipCol;
vNumCad = R034FUN.NumCad;

@-------- Busca dados complementares -------------@
xDurCon = 0;
xProCon = 0;

se (ETipAbr = 'T') @ --- Se for abrangência pela data de término do contrato --- @
  inicio
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
    
    Cur_R034CPL.AbrirCursor();
    
    Se (Cur_R034CPL.Achou)
    Inicio
      xDurCon = Cur_R034CPL.DurCon;
      xProCon = Cur_R034CPL.ProCon; 
    Fim;
    Cur_R034CPL.FecharCursor();
    
    Se (xDurCon = 0)
      Cancel (2);
    
    Se (R034FUN.DatAdm > EDatFim)
      Cancel (2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
    
    ConsiderarAfastamentos();
    
    Se (ETipLis <> ' ')
    Inicio
      Se (ETipLis = 'P')
      Inicio
        Se ((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim))
          Cancel (2); 
      Fim;           
    
      Senao Se (ETipLis = 'S')
      Inicio
        Se ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim))
          Cancel (2);                
        Se (FPrazo2 = 0)
          Cancel (2);
      Fim;               
    
      Senao Se (ETipLis = 'A')  
      Inicio
        Se (((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim)) e 
            ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim)))
          Cancel (2);            
      Fim;           
    Fim;  
fim;
senao  @ --- Senão, se for pela data de admissão --- @
  inicio
    xDurCon = R034FUN.DatAdm;
    
    se ((xDurCon < EDatIni) ou (xDurCon > EDatFim))
      Cancel(2);  
      
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
                           
    Cur_R034CPL.AbrirCursor();
    se (Cur_R034CPL.Achou)
      inicio
        xDurCon = Cur_R034CPL.DurCon;
        xProCon = Cur_R034CPL.ProCon; 
      fim;
    senao
      inicio
        xDurCon = 0;
        xProCon = 0;
      fim;
    Cur_R034CPL.FecharCursor();

    se (xDurCon = 0)
      Cancel(2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
  
  ConsiderarAfastamentos();
    
  fim;

--------------------------------------------------------------------------------
Código: 48 - Descrição: FProCon_Na Impressão
--------------------------------------------------------------------------------

FProCon = R034CPL.ProCon;

--------------------------------------------------------------------------------
Código: 49 - Descrição: Cadastro001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 50 - Descrição: Cadastro004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 51 - Descrição: Especial002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 52 - Descrição: Cadastro012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 53 - Descrição: Cadastro013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 54 - Descrição: Cadastro006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 55 - Descrição: Cadastro005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 56 - Descrição: Formula001_Na Impressão
--------------------------------------------------------------------------------

Definir Numero xConvHoje;

DataHoje(xConvHoje);
RetVinEmp(R034FUN.NumEmp, R034FUN.TipCol, R034FUN.NumCad, xConvHoje);

Formula001 = CodVinEmp;

--------------------------------------------------------------------------------
Código: 57 - Descrição: Cadastro008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 58 - Descrição: Cadastro009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 59 - Descrição: Cadastro014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 60 - Descrição: Descricao021_Na Impressão
--------------------------------------------------------------------------------

Se (R034CPL.Procon > 0){
  AlteraControle ("Descricao021", "Imprimir", "Falso");
}Senao
  AlteraControle ("Descricao021", "Imprimir", "Verdadeiro");

--------------------------------------------------------------------------------
Código: 61 - Descrição: Descricao023_Na Impressão
--------------------------------------------------------------------------------

Se (R034CPL.Procon = 0){
  AlteraControle ("Descricao023", "Imprimir", "Falso");
}Senao
  AlteraControle ("Descricao023", "Imprimir", "Verdadeiro");

--------------------------------------------------------------------------------
Código: 62 - Descrição: Desenho003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 63 - Descrição: Desenho004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 64 - Descrição: Desenho005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 65 - Descrição: Desenho006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 66 - Descrição: Desenho007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 67 - Descrição: Desenho008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 68 - Descrição: Desenho009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 69 - Descrição: Desenho010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 70 - Descrição: Desenho011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 71 - Descrição: Desenho012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 72 - Descrição: Desenho013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 73 - Descrição: Desenho014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 74 - Descrição: Desenho015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 75 - Descrição: Descricao025_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 76 - Descrição: Desenho016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 77 - Descrição: FPrazo2_Na Impressão
--------------------------------------------------------------------------------

Definir FUncao ConsiderarAfastamentos(); 
Definir Cursor Cur_r034CPL;
Definir Numero xDurCon;
Definir Numero xProCon;
Definir Numero vNumEmp;
Definir Numero vTipCol;
Definir Numero vNumCad;
Definir Alfa   ETipAbr;

vNumEmp = R034FUN.NumEmp;
vTipCol = R034FUN.TipCol;
vNumCad = R034FUN.NumCad;

@-------- Busca dados complementares -------------@
xDurCon = 0;
xProCon = 0;

se (ETipAbr = 'T') @ --- Se for abrangência pela data de término do contrato --- @
  inicio
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
    
    Cur_R034CPL.AbrirCursor();
    
    Se (Cur_R034CPL.Achou)
    Inicio
      xDurCon = Cur_R034CPL.DurCon;
      xProCon = Cur_R034CPL.ProCon; 
    Fim;
    Cur_R034CPL.FecharCursor();
    
    Se (xDurCon = 0)
      Cancel (2);
    
    Se (R034FUN.DatAdm > EDatFim)
      Cancel (2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
    
    ConsiderarAfastamentos();
    
    Se (ETipLis <> ' ')
    Inicio
      Se (ETipLis = 'P')
      Inicio
        Se ((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim))
          Cancel (2); 
      Fim;           
    
      Senao Se (ETipLis = 'S')
      Inicio
        Se ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim))
          Cancel (2);                
        Se (FPrazo2 = 0)
          Cancel (2);
      Fim;               
    
      Senao Se (ETipLis = 'A')  
      Inicio
        Se (((FPrazo1 < EDatIni) ou (FPrazo1 > EDatFim)) e 
            ((FPrazo2 < EDatIni) ou (FPrazo2 > EDatFim)))
          Cancel (2);            
      Fim;           
    Fim;  
fim;
senao  @ --- Senão, se for pela data de admissão --- @
  inicio
    xDurCon = R034FUN.DatAdm;
    
    se ((xDurCon < EDatIni) ou (xDurCon > EDatFim))
      Cancel(2);  
      
    Cur_R034CPL.Sql "SELECT DURCON, PROCON \ 
                     FROM R034CPL \
                     WHERE NUMEMP = :vNumEmp AND \ 
                           TIPCOL = :vTipCol AND \
                           NUMCAD = :vNumCad ";
                           
    Cur_R034CPL.AbrirCursor();
    se (Cur_R034CPL.Achou)
      inicio
        xDurCon = Cur_R034CPL.DurCon;
        xProCon = Cur_R034CPL.ProCon; 
      fim;
    senao
      inicio
        xDurCon = 0;
        xProCon = 0;
      fim;
    Cur_R034CPL.FecharCursor();

    se (xDurCon = 0)
      Cancel(2);
    
    FPrazo1 = (R034fun.DatAdm + xDurCon - 1);
    FPrazo2 = (R034fun.DatAdm + xDurCon - 1) + xProCon; 
  
  ConsiderarAfastamentos();
    
  fim;

--------------------------------------------------------------------------------
Código: 78 - Descrição: Subtitulo_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 79 - Descrição: Subtitulo_Antes Imprimir
--------------------------------------------------------------------------------

Se (EspNivTot = 0)
  Cancel(1);

--------------------------------------------------------------------------------
Código: 80 - Descrição: Cadastro007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 81 - Descrição: Especial003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 82 - Descrição: Rodape_Cabecalho_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 83 - Descrição: Rodape_Cabecalho_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 84 - Descrição: Sistema007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 85 - Descrição: Subtitulo_Empresa_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 86 - Descrição: Subtitulo_Empresa_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 87 - Descrição: Total_Geral_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 88 - Descrição: Total_Geral_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 89 - Descrição: Descricao027_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 90 - Descrição: Total001_Na Impressão
--------------------------------------------------------------------------------
