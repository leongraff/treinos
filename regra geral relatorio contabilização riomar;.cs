

--------------------------------------------------------------------------------
Código: 1 - Descrição: ModeloGerador_Funções Globais
--------------------------------------------------------------------------------

Definir Funcao AlternarCorLinhas();
Definir Funcao ListarCabecalho();
Definir Funcao DefineListas();
Definir Funcao GravaLstTotalCLCs();
Definir Funcao ExcluiInvalidosLstTotalCLCs();
Definir Alfa NomeSecao;
Definir Alfa EAltCor;
Definir Numero EAjuPrv;
Definir Alfa GlobalNomCta;
Definir Alfa GlobalTipLto;
Definir Numero GlobalValClc;             
Definir Numero GlobalCodClc;
Definir Alfa GlobalConCtb;
Definir Numero GlobalConRed;
Definir Alfa GlobalParCtb;
Definir Numero GlobalParRed;
Definir Numero GlobalHisPad;
Definir Numero GlobalClcPdb;  
Definir Numero xCorAtual;

@- Alterna cor de uma seção (NomeSecao) -@
Funcao AlternarCorLinhas();
Inicio
  Se (EAltCor = "S")
  Inicio
    Se (xCorAtual = 0)
    Inicio
      AlteraControle(NomeSecao, "Cor", "Prata");
      xCorAtual = 1;
    Fim
    Senao
    Inicio
      AlteraControle(NomeSecao, "Cor", "Branco");
      xCorAtual = 0;
    Fim
  Fim;
Fim;

@- Lista cabeçalho conforme ordenação selecionada -@
Funcao ListarCabecalho();
Inicio
  ProximaPagina(NomeSecao, xRetorno);
  Se (xRetorno = 1)
  Inicio
    SaltarPagina();
    Se (xOrdenacao = 1)
      ListaSecao("CabecalhoColaborador");
    Senao
    Se (xOrdenacao = 2)
      ListaSecao("CabecalhoCusto");
    Senao
    Se (xOrdenacao = 3)
      ListaSecao("CabecalhoLocal");
    Senao
    Se (xOrdenacao = 4)
      ListaSecao("CabecalhoRateio");
    Senao
    Se (xOrdenacao = 5)
      ListaSecao("CabecalhoNatDes");      
  Fim;
Fim;

@- Lista com o TOTAL DOS CLCS -@
Funcao DefineListas();
Inicio
  Definir Lista LstTotalCLCs;
  LstTotalCLCs.DefinirCampos();
  LstTotalCLCs.AdicionarCampo("CodClc", Numero);
  LstTotalCLCs.AdicionarCampo("TipLto", Alfa);
  LstTotalCLCs.AdicionarCampo("NomCta", Alfa);
  LstTotalCLCs.AdicionarCampo("ValClc", Numero);
  LstTotalCLCs.EfetivarCampos();
  
  Se (EAjuPrv = 1)
    LstTotalCLCs.Chave("CodClc");
  Senao
    LstTotalCLCs.Chave("CodClc;TipLto");   
Fim;

@- Função que armazena CLCs na lista LstTotalCLCs. -@ 
@- Ela verifica se o CLC já existe na lista e faz a conta para acertar o valor (débito/crédito) -@
Funcao GravaLstTotalCLCs();
Inicio
  Definir Numero xVal;
  LstTotalCLCs.SetarChave();
  LstTotalCLCs.CodClc = GlobalCodClc;
  
  Se (EAjuPrv = 2)
    LstTotalCLCs.TipLto = GlobalTipLto;
    
  Se (LstTotalCLCs.VaiParaChave())
  Inicio
    LstTotalCLCs.Editar();
    @- Se o tipo do lançamento for igual, soma o valor -@
    Se (LstTotalCLCs.TipLto = GlobalTipLto)
      LstTotalCLCs.ValClc = LstTotalCLCs.ValClc + GlobalValClc;
    Senao
    Inicio
      xVal = LstTotalCLCs.ValClc - GlobalValClc;      
      
      @- Se a diferença entre o que já existe gravado for positiva, grava o valor encontrado -@
      Se (xVal >= 0)
        LstTotalCLCs.ValClc = xVal; 
      Senao
      @- Senão, altera tipo e conta do lançamento, que fica com o novo valor - o valor que já existia -@
      Inicio
        LstTotalCLCs.TipLto = GlobalTipLto;
        LstTotalCLCs.NomCta = GlobalNomCta;
        LstTotalCLCs.ValClc = GlobalValClc - LstTotalCLCs.ValClc;    
      Fim;
    Fim;       
  Fim;             
  Senao
  Inicio 
    LstTotalCLCs.Adicionar();
    LstTotalCLCs.CodClc = GlobalCodClc;  
    LstTotalCLCs.TipLto = GlobalTipLto;
    LstTotalCLCs.NomCta = GlobalNomCta;
    LstTotalCLCs.ValClc = GlobalValClc;                
  Fim;
  LstTotalCLCs.Gravar(); 
Fim;

@- Exclui da lista LstTotalCLCs os CLCs que possuem valor igual a 0 -@
Funcao ExcluiInvalidosLstTotalCLCs();
Inicio
  Definir Numero Tem;
  Tem = LstTotalCLCs.Primeiro();
  Enquanto (Tem = 1)
  Inicio
    Se (LstTotalCLCs.ValClc = 0)
    Inicio
      LstTotalCLCs.Excluir();
      Se (LstTotalCLCs.FDA = 1)
        Tem = 0;
      Senao
        Tem = 1;
    Fim;
    Senao
      Tem = LstTotalCLCs.Proximo();
  Fim;
Fim;

@- Define lista que possui os CLCs por totais -@
se (xOrdPorTotais = cVerdadeiro)
inicio
  Definir Funcao DefineListasClcsPorTotal();
  Definir Funcao GravaListasClcsPorTotal();
  
  Funcao DefineListasClcsPorTotal();
  Inicio
    Definir Lista LstClcsPorTotal;
    LstClcsPorTotal.DefinirCampos();
    LstClcsPorTotal.AdicionarCampo("CodClc", Numero);
    LstClcsPorTotal.AdicionarCampo("TipLto", Alfa);
    LstClcsPorTotal.AdicionarCampo("NomCta", Alfa);
    LstClcsPorTotal.AdicionarCampo("ValClc", Numero);    
    LstClcsPorTotal.AdicionarCampo("ConCtb", Alfa);
    LstClcsPorTotal.AdicionarCampo("ConRed", Numero);
    LstClcsPorTotal.AdicionarCampo("ParCtb", Alfa);
    LstClcsPorTotal.AdicionarCampo("ParRed", Numero);
    LstClcsPorTotal.AdicionarCampo("HisPad", Numero);
    LstClcsPorTotal.AdicionarCampo("ClcPdb", Numero);        
    LstClcsPorTotal.EfetivarCampos();
    
    Se (EAjuPrv = 1)
      LstClcsPorTotal.Chave("CodClc");
    Senao
      LstClcsPorTotal.Chave("CodClc;TipLto");
  Fim;
              
  Funcao GravaListasClcsPorTotal();
  Inicio
    Definir Numero xVal;
    LstClcsPorTotal.SetarChave();
    LstClcsPorTotal.CodClc = GlobalCodClc;
    
    Se (EAjuPrv = 2)
      LstClcsPorTotal.TipLto = GlobalTipLto;
    
    Se (LstClcsPorTotal.VaiParaChave())
    Inicio
      LstClcsPorTotal.Editar();
      @- Se o tipo do lançamento for igual, soma o valor -@
      Se (LstClcsPorTotal.TipLto = GlobalTipLto)
        LstClcsPorTotal.ValClc = LstClcsPorTotal.ValClc + GlobalValClc;
      Senao
      Inicio
        xVal = LstClcsPorTotal.ValClc - GlobalValClc;
        
        @- Se a diferença entre o que já existe gravado for positiva, grava o valor encontrado -@
        Se (xVal >= 0)
          LstClcsPorTotal.ValClc = xVal; 
        Senao
        @- Senão, altera tipo e conta do lançamento, que fica com o novo valor - o valor que já existia -@
        Inicio
          LstClcsPorTotal.TipLto = GlobalTipLto;
          LstClcsPorTotal.ValClc = GlobalValClc - LstClcsPorTotal.ValClc;    
        Fim; 
      Fim;       
    Fim;             
    Senao
    Inicio 
      LstClcsPorTotal.Adicionar();
      LstClcsPorTotal.CodClc = GlobalCodClc;  
      LstClcsPorTotal.TipLto = GlobalTipLto;
      LstClcsPorTotal.NomCta = GlobalNomCta;
      LstClcsPorTotal.ValClc = GlobalValClc;
      LstClcsPorTotal.ConCtb = GlobalConCtb;
      LstClcsPorTotal.ConRed = GlobalConRed;
      LstClcsPorTotal.ParCtb = GlobalParCtb;
      LstClcsPorTotal.ParRed = GlobalParRed;
      LstClcsPorTotal.HisPad = GlobalHisPad;
      LstClcsPorTotal.ClcPdb = GlobalClcPdb;                                    
    Fim;
    LstClcsPorTotal.Gravar(); 
  fim;
fim;


@ Defini a lista que sera usada para totalizar clc's @
@ Somente quando a empresa utilizar totalização contabil por empresa @

Definir Funcao DefineListasClcsTotalEmpresa();

Funcao DefineListasClcsTotalEmpresa();
Inicio
  Definir Lista LstClcsTotalEmpresa;
  LstClcsTotalEmpresa.DefinirCampos();
  LstClcsTotalEmpresa.AdicionarCampo("CodClc", Numero);
  LstClcsTotalEmpresa.AdicionarCampo("TipLto", Alfa);
  LstClcsTotalEmpresa.AdicionarCampo("NomCta", Alfa);
  LstClcsTotalEmpresa.AdicionarCampo("ValClc", Numero);
  LstClcsTotalEmpresa.EfetivarCampos();
  
  Se (EAjuPrv = 1)
    LstClcsTotalEmpresa.Chave("CodClc");
  Senao
    LstClcsTotalEmpresa.Chave("CodClc;TipLto");
Fim;

Definir Funcao GravaListasClcsTotalEmpresa();

Funcao GravaListasClcsTotalEmpresa();
Inicio
  Definir Numero xVal;
  LstClcsTotalEmpresa.SetarChave();
  LstClcsTotalEmpresa.CodClc = GlobalCodClc;
  
  Se (EAjuPrv = 2)
    LstClcsTotalEmpresa.TipLto = GlobalTipLto;
    
  Se (LstClcsTotalEmpresa.VaiParaChave())
  Inicio
    LstClcsTotalEmpresa.Editar();
    @- Se o tipo do lançamento for igual, soma o valor -@
    Se (LstClcsTotalEmpresa.TipLto = GlobalTipLto)
      LstClcsTotalEmpresa.ValClc = LstClcsTotalEmpresa.ValClc + GlobalValClc;
    Senao
    Inicio
      xVal = LstClcsTotalEmpresa.ValClc - GlobalValClc;
      
      @- Se a diferença entre o que já existe gravado for positiva, grava o valor encontrado -@
      Se (xVal >= 0)
        LstClcsTotalEmpresa.ValClc = xVal; 
      Senao
      @- Senão, altera tipo e conta do lançamento, que fica com o novo valor - o valor que já existia -@
      Inicio
        LstClcsTotalEmpresa.TipLto = GlobalTipLto;
        LstClcsTotalEmpresa.NomCta = GlobalNomCta;
        LstClcsTotalEmpresa.ValClc = GlobalValClc - LstClcsTotalEmpresa.ValClc;    
      Fim;
    Fim;       
  Fim;             
  Senao
  Inicio 
    LstClcsTotalEmpresa.Adicionar();
    LstClcsTotalEmpresa.CodClc = GlobalCodClc;  
    LstClcsTotalEmpresa.TipLto = GlobalTipLto;
    LstClcsTotalEmpresa.NomCta = GlobalNomCta;
    LstClcsTotalEmpresa.ValClc = GlobalValClc;                
  Fim;
  LstClcsTotalEmpresa.Gravar(); 
fim;

--------------------------------------------------------------------------------
Código: 2 - Descrição: ModeloGerador_Inicialização
--------------------------------------------------------------------------------

Definir Numero xCorAtual;
xCorAtual = 0;
Definir Data EDatIni;
Definir Data EDatFim;

@- Cria listas utilizadas no modelo -@
DefineListas();
se (xOrdPorTotais = cVerdadeiro)
  DefineListasClcsPorTotal();

--------------------------------------------------------------------------------
Código: 3 - Descrição: ModeloGerador_Pré-Seleção
--------------------------------------------------------------------------------

Definir Alfa AuxSQL;
Definir Alfa AuxSQLHist;
Definir Alfa AuxSQLAbr;          
Definir Alfa AuxRelac;
Definir Alfa StrDatIni;
Definir Alfa StrDatFim;                                 
Definir Cursor Cur_R048CTB;
Definir Alfa xClau;    
Definir Alfa EAbrEmp;              
Definir Alfa EAbrCadCtb;
Definir Alfa EAbrTco;
Definir Alfa EAbrVin;
Definir Alfa EAbrRat;
Definir Alfa EAbrCal;
Definir Alfa xInserir;
Definir Alfa Ordenacao;
Definir Alfa xCursorSQL;
Definir Alfa xComando;
Definir Alfa xMensagem;
Definir Alfa xSeparador;
Definir Lista LstDefEmpresas;
Definir Alfa xTotCtb;  
Definir Alfa xConRat;
Definir Alfa xUsaNat;
Definir Alfa xParDob;
Definir Numero xRelacVinTipCon;

Se ((EDatIni = 0) ou (EDatFim = 0) ou (EDatIni > EDatFim))
Inicio
  Mensagem(Retorna, "A data inicial deve ser menor que a data final e ambas devem ser diferentes de '00/00/0000'[Ok]");
  Cancel(1);
Fim;

xRelacVinTipCon = 0;

@- Cria e carrega lista que armazena os assinalamentos das empresas que serão listadas -@
LstDefEmpresas.DefinirCampos();
LstDefEmpresas.AdicionarCampo("NumEmp", Numero);
LstDefEmpresas.AdicionarCampo("TotCtb", Alfa);
LstDefEmpresas.AdicionarCampo("IntSap", Numero);  
LstDefEmpresas.AdicionarCampo("OriCon", Numero);
LstDefEmpresas.AdicionarCampo("ConRat", Alfa);
LstDefEmpresas.AdicionarCampo("UsaNat", Alfa);
LstDefEmpresas.AdicionarCampo("ParDob", Alfa);  
LstDefEmpresas.EfetivarCampos();
LstDefEmpresas.Chave("NumEmp"); 
Se (EAbrEmp <> "")
Inicio
  MontaAbrangencia("R030EMP.NUMEMP", EAbrEmp, AuxSQLAbr); 
  xComando = "SELECT R030EMP.NUMEMP, R030EMP.TOTCTB, R030EMP.INTSAP, R048DEF.ORICON, R048DEF.CONRAT, R048DEF.USANAT, R048DEF.PARDOB FROM R030EMP, R048DEF WHERE "
          + AuxSQLAbr
          + " AND NOT EXISTS (SELECT 1 FROM R048DEE DEE WHERE DEE.NUMEMP = R030EMP.NUMEMP)"
          + " UNION ALL"
          + " SELECT R030EMP.NUMEMP, R030EMP.TOTCTB, R030EMP.INTSAP, R048DEE.ORICON, R048DEE.CONRAT, R048DEE.USANAT, R048DEE.PARDOB FROM R030EMP, R048DEE WHERE "
          + AuxSQLAbr
          + " AND R048DEE.NUMEMP = R030EMP.NUMEMP"
          + " ORDER BY 1";
  SQL_Criar(xCursorSQL);
  SQL_DefinirComando(xCursorSQL, xComando);
  SQL_AbrirCursor(xCursorSQL);
  Enquanto (SQL_EOF(xCursorSQL) = 0)
  Inicio
    SQL_RetornarInteiro(xCursorSQL, "NUMEMP", xNumEmp);
    SQL_RetornarAlfa(xCursorSQL, "TOTCTB", xTotCtb);
    SQL_RetornarInteiro(xCursorSQL, "INTSAP", xIntSap);
    SQL_RetornarInteiro(xCursorSQL, "ORICON", xOriCon);
    SQL_RetornarAlfa(xCursorSQL, "CONRAT", xConRat);
    SQL_RetornarAlfa(xCursorSQL, "USANAT", xUsaNat);
    SQL_RetornarAlfa(xCursorSQL, "PARDOB", xParDob);
    
    LstDefEmpresas.Adicionar();
    LstDefEmpresas.NumEmp = xNumEmp;
    LstDefEmpresas.TotCtb = xTotCtb;
    LstDefEmpresas.IntSap = xIntSap;
    LstDefEmpresas.OriCon = xOriCon;
    LstDefEmpresas.ConRat = xConRat;
    LstDefEmpresas.UsaNat = xUsaNat;
    LstDefEmpresas.ParDob = xParDob; 
    LstDefEmpresas.Gravar();                
  
    SQL_Proximo(xCursorSQL);
  Fim;
  SQL_FecharCursor(xCursorSQL);
  SQL_Destruir(xCursorSQL);
Fim;

xMensagem = "";
xSeparador = "";
xTem = LstDefEmpresas.Primeiro();
Enquanto (xTem = cVerdadeiro)
Inicio    
  Se ((LstDefEmpresas.ConRat <> "N") e (LstDefEmpresas.ConRat <> "S"))
  Inicio
    xMensagem = xMensagem + xSeparador + Formatar(LstDefEmpresas.NumEmp, "%0.0f");
    xSeparador = ", ";
  Fim;
  xTem = LstDefEmpresas.Proximo();
Fim;  
Se (xMensagem <> "")
Inicio
  xMensagem = "O assinalamento \"Considerar Rateios\" não está definido para a(s) seguinte(s) empresa(s): " + xMensagem + ". Verifique em Empresas > Contábil > Definições.";
  Mensagem(Retorna, xMensagem);
Fim;

OrdenacaoSelecionada("Lancamentos", Ordenacao);
Se ((Ordenacao = "C. Custo/Totais") ou (Ordenacao = "Local/Totais"))
Inicio
  xOrdPorTotais = cVerdadeiro;
  
  xMensagem = "";
  xSeparador = "";
  @- Descobre qual deveria ser o assinalamento correto para a origem das contas -@
  Se (Ordenacao = "C. Custo/Totais")
    xOriCon = 1;
  Senao
    xOriCon = 2;   
  xTem = LstDefEmpresas.Primeiro();
  Enquanto (xTem = cVerdadeiro)
  Inicio
    Se (LstDefEmpresas.OriCon <> xOriCon)
    Inicio
      xMensagem = xMensagem + xSeparador + Formatar(LstDefEmpresas.NumEmp, "%0.0f");
      xSeparador = ", ";
    Fim;    
    xTem = LstDefEmpresas.Proximo();
  Fim;    
  Se (xMensagem <> "")
  Inicio
    xMensagem = "A ordenação \"" + Ordenacao + "\" não é compatível com a origem das contas da(s) seguinte(s) empresa(s): " + xMensagem + ". As informações poderão ser demonstradas de forma incorreta.";
    Mensagem(Retorna, xMensagem);
  Fim;
Fim;
Senao
  xOrdPorTotais = cFalso;

ConverteDataBanco(EDatIni, StrDatIni);
ConverteDataBanco(EDatFim, StrDatFim);
AuxRelac = " ";

@- Filtra período de contabilização -@
AuxSQL = AuxRelac + " R048CTB.DATLAN >= " + StrDatIni + " AND R048CTB.DATLAN <= " + StrDatFim;
InsClauSqlWhere("Lancamentos", AuxSQL);
AuxRelac = " AND ";
xInserir = AuxRelac + xInserir + AuxSQL;

/* MNTGEP-16583 - Listar relatório com filtro de cálculo. */
@- Cálculo -@
Se (EAbrCal <> "")
Inicio
  MontaAbrangencia("R048CTB.CODCAL", EAbrCal, AuxSQLAbr);
  AuxSQL = AuxRelac + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
Fim;

@- Filial -@
Definir Alfa EAbrFil;
Se (EAbrFil <> "")
Inicio
  MontaAbrangencia("R048CTB.CODFIL", EAbrFil, AuxSQLAbr);
  AuxSQL = AuxRelac + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
Fim;

@- Tipo colaborador -@
Definir Alfa EAbrTip;
Se (EAbrTip <> "")
Inicio
  MontaAbrangencia("R048CTB.TIPCOL", EAbrTip, AuxSQLAbr);
  AuxSQL = AuxRelac + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
Fim;

@- Colaborador -@
Definir Alfa EAbrCadCtb;
Se (EAbrCadCtb <> "")
Inicio
  MontaAbrangencia("R048CTB.NUMCAD", EAbrCadCtb, AuxSQLAbr);
  AuxSQL = AuxRelac + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
Fim;

@- Tipo de contrato (relacionamento dinâmico com a R034FUN) -@
Definir Alfa EAbrTco;
Se (EAbrTco <> "")
Inicio
  MontaAbrangencia("R034FUN.TIPCON", EAbrTco, AuxSQLAbr); 
  AuxSql = AuxRelac + " R034FUN.NUMEMP = R048CTB.NUMEMP "
           + " AND R034FUN.TIPCOL = R048CTB.TIPCOL "
           + " AND R034FUN.NUMCAD = R048CTB.NUMCAD "
           + " AND " + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
  xRelacVinTipCon = 1;
Fim;

@- Vínculo (relacionamento dinâmico com a R038HVI) -@
Definir Alfa EAbrVin;
Se (EAbrVin <> "")
Inicio
  MontarSqlHistorico("R038HVI", EDatFim, AuxSQLHist);
  MontaAbrangencia("R038HVI.CODVIN", EAbrVin, AuxSQLAbr);
  AuxSql = AuxRelac + " R038HVI.NUMEMP = R048CTB.NUMEMP "
           + " AND R038HVI.TIPCOL = R048CTB.TIPCOL "
           + " AND R038HVI.NUMCAD = R048CTB.NUMCAD "
           + " AND " + AuxSQLHist
           + " AND " + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
  Se (xRelacVinTipCon > 0)
    xRelacVinTipCon = 3;
  senao
    xRelacVinTipCon = 2;  
Fim;

@- Rateio -@
Definir Alfa EAbrRat;
Se (EAbrRat <> "")
Inicio
  MontaAbrangencia("R048CTB.CODRAT", EAbrRat, AuxSQLAbr); 
  AuxSQL = AuxRelac + AuxSQLAbr;
  InsClauSqlWhere("Lancamentos", AuxSQL);
  AuxRelac = " AND ";
  xInserir = xInserir + AuxSQL;
Fim;

xClau = "";

Definir Alfa EOpcCtb;
Definir Alfa EAbrLoc;
Definir Alfa EAbrCcu;
Definir Alfa EAbrTipClc;
Definir Alfa EAbrClc;
Definir Alfa EAbrLot;
Definir Alfa xSQLVinTipCon;
                     
se (xOrdPorTotais = cVerdadeiro)
inicio

  AuxRelac = " AND ";
 
  se (EAbrEmp <> "")
  inicio 
    MontaAbrangencia("R048CTB.NUMEMP", EAbrEmp, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim;
  
  se (EOpcCtb <> "")
  inicio 
    MontaAbrangencia("R048CTB.OPCCTB", EOpcCtb, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim;

  se (EAbrLoc <> "")
  inicio 
    MontaAbrangencia("R048CTB.NUMLOC", EAbrLoc, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim;

  se (EAbrCcu <> "")
  inicio 
    MontaAbrangencia("R048CTB.CODCCU", EAbrCcu, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim;

  se (EAbrTipClc <> "")
  inicio 
    MontaAbrangencia("R048CLC.CODTCL", EAbrTipClc, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim;
  
  se (EAbrClc <> "")
  inicio 
    MontaAbrangencia("R048CLC.CODCLC", EAbrClc, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  fim; 
  
  Se (EAbrLot <> "")
  Inicio
    MontaAbrangencia("R048CTB.CODLOT", EAbrLot, AuxSQLAbr); 
    AuxSQLAbr = AuxRelac + AuxSQLAbr;
    xInserir = xInserir + " " + AuxSQLAbr;
  Fim;
  
  Se (xRelacVinTipCon = 1) 
    xSQLVinTipCon = ", r034fun";
  Senao
    Se (xRelacVinTipCon = 2)
      xSQLVinTipCon = ", r038hvi";
    Senao
      Se (xRelacVinTipCon = 3)
        xSQLVinTipCon = ", r034fun, r038hvi";    
    
  Cur_R048CTB.SQL "Select r048clc.nivLan from r048ctb, r048clc __inserir(:xSQLVinTipCon) \
                           where r048ctb.codclc = r048clc.codclc and \
                           r048ctb.tabeve = r048clc.tabeve __inserir(:xInserir) ";  
                
  Cur_R048CTB.AbrirCursor();
  
  enquanto(Cur_R048CTB.Achou)
  inicio
    se(Cur_R048CTB.nivLan <> "T")
      xClau = " AND R048CLC.NIVLAN <> 'T' "; 
    Cur_R048CTB.Proximo();  
  fim;
  Cur_R048CTB.FecharCursor(); 
  
  @- Filtra registros sem conta gerencial -@
  AuxSQL = AuxRelac + "R048CTB.CONGER = '0' ";
  xInserir = xInserir + " " + AuxSQL;  
fim;

@- Filtra registros sem conta gerencial -@
AuxSQL = AuxRelac + "R048CTB.CONGER = '0' " + xClau;
InsClauSqlWhere("Lancamentos", AuxSQL);
AuxRelac = " AND ";

--------------------------------------------------------------------------------
Código: 4 - Descrição: ModeloGerador_Seleção
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 5 - Descrição: ModeloGerador_Finalização
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 6 - Descrição: ModeloGerador_Imprimir Página
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 7 - Descrição: Lancamentos_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 8 - Descrição: Lancamentos_Antes Imprimir
--------------------------------------------------------------------------------

Definir Numero xVal;
Definir Alfa xNivLan;
Definir Alfa xDebCre;
Definir Alfa xNomCon;
Definir Alfa xNomConRegistro;
Definir Alfa xContaCtb;
Definir Alfa xConCtbPar;
Definir Numero xTabEve;
Definir Numero xPDCodClc;
Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave();

xTabEve = R048CTB.TabEve;
xPDCodClc = R048CTB.ClcPDb; 

Se (xDebCre = R048CTB.DebCre)
  FValLan = (FValLan + R048CTB.ValLan);
Senao
Inicio
  Se (FCodClc > 0)
  Inicio
    Se (EAjuPrv = 2)
      ListaSecao("Adicional_ValorLancamento");
  Fim;

  xVal = (FValLan - R048CTB.ValLan);
  
  Se (xVal >= 0)
    FValLan = xVal; 
  Senao
  Inicio
    @- Atualiza os valores com o registro atual -@
    FCodClc = R048CTB.CodClc;
    FNatDes = R048CTB.NatDes;
    FHisPad = R048CTB.HisPad;
    FValLan = (R048CTB.ValLan - FValLan);
    xDebCre = R048CTB.DebCre; 
    xNomCon = R048CLC.NomCon; 
    xNomConRegistro = R048CTB.NomCon;
    TiraEspacos(xNomConRegistro, xNomConRegistro); 
    
    Se (xDebCre = "D")
    Inicio
      Se (LstDefEmpresas.ConRat = "S")
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        xContaCtb = R048CTB.ConDeb;
        FContaRed = R048CTB.RedDeb;
        @- Partida dobrada é a conta inversa -@
        xConCtbPar = R048CTB.ConCre;
        FConRedPar = R048CTB.RedCre;
      Fim
      Senao
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        xContaCtb = R048CTB.ConDeP;
        FContaRed = R048CTB.RedDeP;
        @- Partida dobrada é a conta inversa -@
        xConCtbPar = R048CTB.ConCrP;
        FConRedPar = R048CTB.RedCrP;      
      Fim;
    Fim;
    Senao 
    Inicio
      Se (LstDefEmpresas.ConRat = "S")
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        xContaCtb = R048CTB.ConCre;
        FContaRed = R048CTB.RedCre;
        @- Partida dobrada é a conta inversa -@
        xConCtbPar = R048CTB.ConDeb;
        FConRedPar = R048CTB.RedDeb;
      Fim
      Senao
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        xContaCtb = R048CTB.ConCrP;
        FContaRed = R048CTB.RedCrP;
        @- Partida dobrada é a conta inversa -@
        xConCtbPar = R048CTB.ConDeP;
        FConRedPar = R048CTB.RedDeP;
      Fim;
    Fim;
  Fim;     
Fim;

UltimoRegistro("Lancamentos", xUltimoReg);

--------------------------------------------------------------------------------
Código: 9 - Descrição: Cadastro015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 10 - Descrição: Cadastro014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 11 - Descrição: Cadastro013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 12 - Descrição: Cadastro011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 13 - Descrição: Cadastro009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 14 - Descrição: Cadastro008_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 15 - Descrição: Cadastro007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 16 - Descrição: Cadastro006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 17 - Descrição: Cadastro003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 18 - Descrição: Cadastro002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 19 - Descrição: Cadastro001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 20 - Descrição: Cadastro005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 21 - Descrição: Cadastro012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 22 - Descrição: FNivLan_Na Impressão
--------------------------------------------------------------------------------

@- Esta atribuição é programada neste evento porque FNivLan está na ordenação. -@
@- Sua atribuição deve ser programada aqui. -@
@- Só utiliza O nivLan 3 quando não utilizar o clc's por totais -@
Se ((R048CTB.DefCon = 1) ou (R048CTB.DefCon = 2))
  FNivLan = 1;
Senao Se ((R048CTB.DefCon = 3) ou (R048CTB.DefCon = 4))
  FNivLan = 2;
Senao Se (xOrdPorTotais = cFalso)
  FNivLan = 3;

--------------------------------------------------------------------------------
Código: 23 - Descrição: Cadastro031_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 24 - Descrição: Cadastro017_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 25 - Descrição: Cadastro018_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 26 - Descrição: Cadastro019_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 27 - Descrição: Cadastro020_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 28 - Descrição: Cadastro034_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 29 - Descrição: Cadastro036_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 30 - Descrição: Cadastro038_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 31 - Descrição: DCodCcu_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;
Definir alfa aTipCol;
Definir alfa aNumCad;
Definir Alfa aCodCcuRat;
Definir alfa aCodOem;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  aCodCcuRat = R048CTB.CcuRat;
Senao
  aCodCcuRat = R048CTB.CodCcu;  

ConverteMascara(5,0,aCodCcuRat, "UUUUUUUUUUUUUUUUUU");

Se (R048CTB.DefCon = 1)
Inicio
  IntParaAlfa(R048CTB.TipCol, aTipCol);
  IntParaAlfa(R048CTB.NumCad, aNumCad);
  ValStr = aCodCcuRat + aTipCol + aNumCad;
fim  
Senao Se (R048CTB.DefCon = 2)
inicio
  IntParaAlfa(R048CTB.CodOem, aCodOem);
  ValStr = aCodCcuRat + aCodOem;
fim 
Senao
  ValStr = aCodCcuRat;
Cancel(2);

--------------------------------------------------------------------------------
Código: 32 - Descrição: Cadastro039_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 33 - Descrição: Cadastro040_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 34 - Descrição: Cadastro041_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 35 - Descrição: Cadastro042_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 36 - Descrição: Cadastro043_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 37 - Descrição: FNumLoc_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FNumLoc = R048CTB.LocRat;
Senao
  FNumLoc = R048CTB.NumLoc;

--------------------------------------------------------------------------------
Código: 38 - Descrição: FCodRat_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FCodRat = R048CTB.CodRat;
Senao
  FCodRat = R048CTB.RatPad;

--------------------------------------------------------------------------------
Código: 39 - Descrição: Cadastro016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 40 - Descrição: FFilCtb_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtb = R048CTB.FilCtb;
Senao
  FFilCtb = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 41 - Descrição: Cadastro035_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 42 - Descrição: DNumLoc_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;
Definir alfa aTipCol;
Definir alfa aNumCad;
Definir alfa aCodLocRat;
Definir alfa aCodOem;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  RetornaCodLoc(R048CTB.LocRat, aCodLocRat);
Senao
  RetornaCodLoc(R048CTB.NumLoc, aCodLocRat);
  
ConverteMascara(5,0,aCodLocRat, "U[32]");  

Se (R048CTB.DefCon = 1)
Inicio
  IntParaAlfa(R048CTB.TipCol, aTipCol);
  IntParaAlfa(R048CTB.NumCad, aNumCad);
  ValStr = aCodLocRat + aTipCol + aNumCad;
fim  
Senao Se (R048CTB.DefCon = 2)
inicio
  IntParaAlfa(R048CTB.CodOem, aCodOem);
  ValStr = aCodLocRat + aCodOem;
fim 
Senao
  ValStr = aCodLocRat;
Cancel(2);

--------------------------------------------------------------------------------
Código: 43 - Descrição: Cabecalho_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 44 - Descrição: Cabecalho_Antes Imprimir
--------------------------------------------------------------------------------

xCorAtual = 0;

--------------------------------------------------------------------------------
Código: 45 - Descrição: Descricao018_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 46 - Descrição: Descricao019_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 47 - Descrição: Sistema020_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 48 - Descrição: Descricao027_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 49 - Descrição: Sistema021_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 50 - Descrição: Descricao017_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 51 - Descrição: FDatFim_Na Impressão
--------------------------------------------------------------------------------

FDatFim = EDatFim;

--------------------------------------------------------------------------------
Código: 52 - Descrição: FDatIni_Na Impressão
--------------------------------------------------------------------------------

FDatIni = EDatIni;

--------------------------------------------------------------------------------
Código: 53 - Descrição: Descricao020_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 54 - Descrição: DETipVal_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa xTipCal;
Definir Alfa xDesCal;

IntParaAlfa(TipCal, xTipCal);
DescItemLista("LTipCal", xTipCal, xDesCal);

ValStr = xDesCal;
Cancel(2);

--------------------------------------------------------------------------------
Código: 55 - Descrição: Descricao007_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 56 - Descrição: Descricao022_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 57 - Descrição: Cadastro024_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 58 - Descrição: Cadastro023_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 59 - Descrição: CabecalhoCusto_Depois Imprimir
--------------------------------------------------------------------------------

xColunaNatDes = cVerdadeiro;
ListaSecao("Rotulos");

--------------------------------------------------------------------------------
Código: 60 - Descrição: CabecalhoCusto_Antes Imprimir
--------------------------------------------------------------------------------

xOrdenacao = 2;  @ Centro de Custo @

--------------------------------------------------------------------------------
Código: 61 - Descrição: Descricao002_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 62 - Descrição: Descricao001_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 63 - Descrição: DNomCcu_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Alfa xCodCCu;
Definir Alfa xNomCcu;
Definir Lista LstDefEmpresas;

xNumEmp = R048CTB.NumEmp;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = xNumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  xCodCcu = R048CTB.CcuRat;
Senao
  xCodCCu = R048CTB.CodCCu;

xNomCcu = "";
xCursor.SQL "SELECT NOMCCU FROM R018CCU WHERE NUMEMP = :xNumEmp AND CODCCU = :xCodCCu";
xCursor.AbrirCursor();
Se (xCursor.Achou)
  xNomCcu = xCursor.NomCCu;
xCursor.FecharCursor();  
ValStr = xNomCcu;
Cancel(2);

--------------------------------------------------------------------------------
Código: 64 - Descrição: DCcuRatPad_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa aCodCcuRat; @ Declaracao Criada na Conversao @
Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  aCodCcuRat = R048CTB.CcuRat;
Senao
  aCodCcuRat = R048CTB.CodCcu;  
  
ValStr = aCodCcuRat;
  
Cancel(2);

--------------------------------------------------------------------------------
Código: 65 - Descrição: FFilCtbCcu_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbCcu = R048CTB.FilCtb;
Senao
  FFilCtbCcu = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 66 - Descrição: Descricao008_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa aNumCad;
Definir Alfa aCodOem;

Se (R048CTB.DefCon = 1)
inicio
  IntParaAlfa(R048CTB.NumCad, aNumCad);
  ValStr = aNumCad;
fim  
Senao Se (R048CTB.DefCon = 2)
Inicio
  IntParaAlfa(R048CTB.CodOem, aCodOem);
  ValStr = aCodOem;
Fim
Senao  
  ValStr = "";
  
Cancel(2);

--------------------------------------------------------------------------------
Código: 67 - Descrição: Descricao023_Na Impressão
--------------------------------------------------------------------------------

Se ((R048CTB.DefCon = 1) ou (R048CTB.DefCon = 2))
  ValStr = "Contas próprias";
Senao
  ValStr = "";  

Cancel(2); 

--------------------------------------------------------------------------------
Código: 68 - Descrição: Descricao030_Na Impressão
--------------------------------------------------------------------------------

Se (R048CTB.DefCon = 1)
  ValStr = "Colaborador:";
Senao Se (R048CTB.DefCon = 2)
  ValStr = "O. Empresa:";  
Senao
  ValStr = "";  

Cancel(2);  

--------------------------------------------------------------------------------
Código: 69 - Descrição: NomFun_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Numero xCodOem;
Definir Alfa aNomFun;
Definir Alfa aNomOem;

xNumEmp = R048CTB.NumEmp;

Se (R048CTB.DefCon = 1)
Inicio
  xTipCol = R048CTB.TipCol;
  xNumCad = R048CTB.NumCad;
  
  xCursor.SQL "SELECT NOMFUN FROM R034FUN WHERE NUMEMP = :xNumEmp AND TIPCOL = :xTipCol AND NUMCAD = :xNumCad";
  xCursor.AbrirCursor();
  Se (xCursor.Achou)
    aNomFun = xCursor.NomFun;
  xCursor.FecharCursor();  
  ValStr = aNomFun;
Fim 
Senao Se (R048CTB.DefCon = 2)
Inicio
  xCodOem = R048CTB.CodOem;
  xCursor.SQL "SELECT NOMOEM FROM R032OEM WHERE CODOEM = :xCodOem";
  xCursor.AbrirCursor();
  Se (xCursor.Achou)
    aNomOem = xCursor.NomOem;
  xCursor.FecharCursor();  
  ValStr = aNomOem;
Fim
Senao
  ValStr = ""; 

Cancel(2);

--------------------------------------------------------------------------------
Código: 70 - Descrição: ValorLancamento_Depois Imprimir
--------------------------------------------------------------------------------

@- Limpa dados do lançamento listado -@
FCodClc = 0;
FNatDes = 0;
FHisPad = 0;
xDebCre = ""; 
xNomCon = "";
xNomConRegistro = "";

--------------------------------------------------------------------------------
Código: 71 - Descrição: ValorLancamento_Antes Imprimir
--------------------------------------------------------------------------------

@- Se valor do lançamento for 0, não lista. Se for menor, o modelo está errado. -@
Se (FValLan <= 0)
Inicio
  Se (FValLan < 0)
    Mensagem(Erro, "Erro no relatório: Valor do lançamento não pode ser negativo.");
    
  Cancel(1);
Fim;

ListaSecao("Adicional_ValorLancamento"); 

--------------------------------------------------------------------------------
Código: 72 - Descrição: CabecalhoRateio_Depois Imprimir
--------------------------------------------------------------------------------

xColunaNatDes = cVerdadeiro;
ListaSecao("Rotulos");

--------------------------------------------------------------------------------
Código: 73 - Descrição: CabecalhoRateio_Antes Imprimir
--------------------------------------------------------------------------------

xOrdenacao = 4;  @ Rateio @

--------------------------------------------------------------------------------
Código: 74 - Descrição: Descricao005_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 75 - Descrição: Descricao006_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 76 - Descrição: Descricao004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 77 - Descrição: DDesRat_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xCodRat;
Definir Alfa xDesRat;
Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  xCodRat = R048CTB.CodRat;
Senao
  xCodRat = R048CTB.RatPad;

xDesRat = "";
xCursor.SQL "SELECT DESRAT FROM R020RAT WHERE CODRAT = :xCodRat";
xCursor.AbrirCursor();
Se (xCursor.Achou)
  xDesRat = xCursor.DesRat;
xCursor.FecharCursor(); 
ValStr = xDesRat;
Cancel(2);

--------------------------------------------------------------------------------
Código: 78 - Descrição: FCodRatPad_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FCodRatPad = R048CTB.CodRat;
Senao
  FCodRatPad = R048CTB.RatPad;

--------------------------------------------------------------------------------
Código: 79 - Descrição: FFilCtbRat_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbRat = R048CTB.FilCtb;
Senao
  FFilCtbRat = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 80 - Descrição: DCodCcuRat_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  ValStr = R048CTB.CcuRat;
Senao
  ValStr = R048CTB.CodCcu;
Cancel(2);

--------------------------------------------------------------------------------
Código: 81 - Descrição: Rotulos_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 82 - Descrição: Rotulos_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa xImprimir;
Definir Lista LstDefEmpresas;

Se ((xColunaNatDes = cFalso) ou (LstDefEmpresas.UsaNat <> "S"))
  xImprimir = "Falso";
Senao
  xImprimir = "Verdadeiro";
  
AlteraControle("DNatureza", "Imprimir", xImprimir);  

--------------------------------------------------------------------------------
Código: 83 - Descrição: Descricao010_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 84 - Descrição: Descricao011_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 85 - Descrição: Descricao012_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 86 - Descrição: Descricao014_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 87 - Descrição: Descricao015_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 88 - Descrição: Descricao009_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 89 - Descrição: DNatureza_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 90 - Descrição: DContaPD_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 91 - Descrição: CabecalhoColaborador_Depois Imprimir
--------------------------------------------------------------------------------

xColunaNatDes = cVerdadeiro;
ListaSecao("Rotulos");

--------------------------------------------------------------------------------
Código: 92 - Descrição: CabecalhoColaborador_Antes Imprimir
--------------------------------------------------------------------------------

xOrdenacao = 1;  @ Colaborador @

--------------------------------------------------------------------------------
Código: 93 - Descrição: Descricao016_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 94 - Descrição: Cadastro027_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 95 - Descrição: DNomFun_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Alfa xNomFun;

xNumEmp = R048CTB.NumEmp;
xTipCol = R048CTB.TipCol;
xNumCad = R048CTB.NumCad;

xNomFun = "";
xCursor.SQL "SELECT NOMFUN FROM R034FUN WHERE NUMEMP = :xNumEmp AND TIPCOL = :xTipCol AND NUMCAD = :xNumCad";
xCursor.AbrirCursor();
Se (xCursor.Achou)
  xNomFun = xCursor.NomFun;
xCursor.FecharCursor();  

ValStr = xNomFun;
Cancel(2);

--------------------------------------------------------------------------------
Código: 96 - Descrição: DebitoCredito_Depois Imprimir
--------------------------------------------------------------------------------

Definir alfa ElisDif;

@- Verifica se há diferença. Se houver lista a seção que mostra esta diferença -@
FValDif = FTotCre - FTotDeb;
Se ((FValDif <> 0) e (ELisDif = "S"))
  ListaSecao("Diferenca");

@- Limpa fórmulas da seção -@
FTotCre = 0;
FTotDeb = 0;  

--------------------------------------------------------------------------------
Código: 97 - Descrição: DebitoCredito_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 98 - Descrição: Descricao025_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 99 - Descrição: FTotDeb_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 100 - Descrição: Descricao024_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 101 - Descrição: FTotCre_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 102 - Descrição: DiferencaEmpresa_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 103 - Descrição: DiferencaEmpresa_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 104 - Descrição: Descricao026_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 105 - Descrição: FValDifEmp_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 106 - Descrição: CabecalhoLocal_Depois Imprimir
--------------------------------------------------------------------------------

xColunaNatDes = cVerdadeiro;
ListaSecao("Rotulos");

--------------------------------------------------------------------------------
Código: 107 - Descrição: CabecalhoLocal_Antes Imprimir
--------------------------------------------------------------------------------

xOrdenacao = 3;  @ Local @

--------------------------------------------------------------------------------
Código: 108 - Descrição: Descricao028_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 109 - Descrição: Descricao029_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 110 - Descrição: DNomLoc_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xTabOrg;
Definir Numero xNumLoc;
Definir Alfa xNomLoc;
Definir Lista LstDefEmpresas;

xTabOrg = R048CTB.TabOrg;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  xNumLoc = R048CTB.LocRat;
Senao
  xNumLoc = R048CTB.NumLoc; 

xNomLoc = "";
xCursor.SQL "SELECT NOMLOC FROM R016ORN WHERE TABORG = :xTabOrg AND NUMLOC = :xNumLoc";
xCursor.AbrirCursor();
Se (xCursor.Achou)
  xNomLoc = xCursor.NomLoc;
xCursor.FecharCursor(); 
ValStr = xNomLoc;
Cancel(2);

--------------------------------------------------------------------------------
Código: 111 - Descrição: FFilCtbLoc_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbLoc = R048CTB.FilCtb;
Senao
  FFilCtbLoc = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 112 - Descrição: Descricao044_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Numero xCodOem;
Definir Alfa aNomFun;
Definir Alfa aNomOem;

xNumEmp = R048CTB.NumEmp;

Se (R048CTB.DefCon = 1)
Inicio
  xTipCol = R048CTB.TipCol;
  xNumCad = R048CTB.NumCad;
  
  xCursor.SQL "SELECT NOMFUN FROM R034FUN WHERE NUMEMP = :xNumEmp AND TIPCOL = :xTipCol AND NUMCAD = :xNumCad";
  xCursor.AbrirCursor();
  Se (xCursor.Achou)
    aNomFun = xCursor.NomFun;
  xCursor.FecharCursor();  
  ValStr = aNomFun;
Fim 
Senao Se (R048CTB.DefCon = 2)
Inicio
  xCodOem = R048CTB.CodOem;
  xCursor.SQL "SELECT NOMOEM FROM R032OEM WHERE CODOEM = :xCodOem";
  xCursor.AbrirCursor();
  Se (xCursor.Achou)
    aNomOem = xCursor.NomOem;
  xCursor.FecharCursor();  
  ValStr = aNomOem;
Fim
Senao
  ValStr = ""; 

Cancel(2);

--------------------------------------------------------------------------------
Código: 113 - Descrição: Descricao055_Na Impressão
--------------------------------------------------------------------------------

Definir Alfa aNumCad;
Definir Alfa aCodOem;

Se (R048CTB.DefCon = 1)
inicio
  IntParaAlfa(R048CTB.NumCad, aNumCad);
  ValStr = aNumCad;
fim  
Senao Se (R048CTB.DefCon = 2)
Inicio
  IntParaAlfa(R048CTB.CodOem, aCodOem);
  ValStr = aCodOem;
Fim
Senao  
  ValStr = "";
  
Cancel(2);

--------------------------------------------------------------------------------
Código: 114 - Descrição: Descricao056_Na Impressão
--------------------------------------------------------------------------------

Se (R048CTB.DefCon = 1)
  ValStr = "Colaborador:";
Senao Se (R048CTB.DefCon = 2)
  ValStr = "O. Empresa:";  
Senao
  ValStr = "";  

Cancel(2);  

--------------------------------------------------------------------------------
Código: 115 - Descrição: Descricao057_Na Impressão
--------------------------------------------------------------------------------

Se ((R048CTB.DefCon = 1) ou (R048CTB.DefCon = 2))
  ValStr = "Contas próprias";
Senao
  ValStr = "";  

Cancel(2); 

--------------------------------------------------------------------------------
Código: 116 - Descrição: CabecalhoEmpresa_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 117 - Descrição: CabecalhoEmpresa_Antes Imprimir
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
   
@ - Define a lista somente se for totalizar por empresa. - @
se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
  DefineListasClcsTotalEmpresa();  

@- Mostra conta reduzida, esconde conta contábil -@
Se ((LstDefEmpresas.IntSap = 0) ou (LstDefEmpresas.IntSap = 1) ou (LstDefEmpresas.IntSap = 6))
Inicio
  AlteraControle("FContaRed", "Imprimir", "Verdadeiro");
  AlteraControle("DContaCtb", "Imprimir", "Falso");
  AlteraControle("FFilContaRed", "Imprimir", "Verdadeiro");
  AlteraControle("DFilContaCtb", "Imprimir", "Falso");
Fim;
Senao @- Mostra conta contábil, esconde conta reduzida -@
Inicio
  AlteraControle("DContaCtb", "Imprimir", "Verdadeiro");
  AlteraControle("FContaRed", "Imprimir", "Falso");
  AlteraControle("DFilContaCtb", "Imprimir", "Verdadeiro");
  AlteraControle("FFilContaRed", "Imprimir", "Falso");
Fim;

@- Esconde/mostra controles de partida dobrada -@
Se (LstDefEmpresas.ParDob <> "S")
Inicio
  AlteraControle("DContaPD", "Imprimir", "Falso");
  AlteraControle("DConCtbPar", "Imprimir", "Falso");         
  AlteraControle("FConRedPar", "Imprimir", "Falso");
  AlteraControle("DFilConCtbPar", "Imprimir", "Falso");         
  AlteraControle("FFilConRedPar", "Imprimir", "Falso");  
Fim;
Senao
Inicio
  AlteraControle("DContaPD", "Imprimir", "Verdadeiro");
  @- Dependendo do assinalamento de integração com o SAPIENS mostra/esconde conta contábil/reduzida -@
  Se ((LstDefEmpresas.IntSap = 0) ou (LstDefEmpresas.IntSap = 1) ou (LstDefEmpresas.IntSap = 6))
  Inicio
    AlteraControle("FContaRed", "Imprimir", "Verdadeiro");
    AlteraControle("DContaCtb", "Imprimir", "Falso");
    AlteraControle("FFilContaRed", "Imprimir", "Verdadeiro");
    AlteraControle("DFilContaCtb", "Imprimir", "Falso");  
    
    AlteraControle("FConRedPar", "Imprimir", "Verdadeiro");
    AlteraControle("DConCtbPar", "Imprimir", "Falso");
    AlteraControle("FFilConRedPar", "Imprimir", "Verdadeiro");     
    AlteraControle("DFilConCtbPar", "Imprimir", "Falso");                   
  Fim;
  Senao
  Inicio
    AlteraControle("DContaCtb", "Imprimir", "Verdadeiro");
    AlteraControle("FContaRed", "Imprimir", "Falso");
    AlteraControle("DFilContaCtb", "Imprimir", "Verdadeiro");
    AlteraControle("FFilContaRed", "Imprimir", "Falso");
    
    AlteraControle("DConCtbPar", "Imprimir", "Verdadeiro");
    AlteraControle("FConRedPar", "Imprimir", "Falso");
    AlteraControle("DFilConCtbPar", "Imprimir", "Verdadeiro");
    AlteraControle("FFilConRedPar", "Imprimir", "Falso");       
  Fim;
Fim; 

@- Esconde/mostra controle de natureza de despesa -@
Se (LstDefEmpresas.UsaNat <> "S")
  AlteraControle("FNatDes", "Imprimir", "Falso");
Senao
  AlteraControle("FNatDes", "Imprimir", "Verdadeiro");

--------------------------------------------------------------------------------
Código: 118 - Descrição: DebitoCreditoEmpresa_Depois Imprimir
--------------------------------------------------------------------------------

@- Verifica se há diferença. Se houver lista a seção que mostra esta diferença -@
FValDifEmp = FTotCreEmp - FTotDebEmp;
Se (FValDifEmp <> 0)
  ListaSecao("DiferencaEmpresa");

@- Limpa fórmulas da seção -@
FTotCreEmp = 0;
FTotDebEmp = 0;

@- Se houver registros, lista o total dos CLCs da empresa -@
ExcluiInvalidosLstTotalCLCs();
Se (LstTotalCLCs.QtdRegistros > 0)
  ListaSecao("RotuloCLCsEmpresa");

--------------------------------------------------------------------------------
Código: 119 - Descrição: DebitoCreditoEmpresa_Antes Imprimir
--------------------------------------------------------------------------------

se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
inicio
  SaltarPagina();
  ListaSecao("Adicional_ClcTotal");
fim;  

se (xUltimoReg <> 1)
  SaltarPagina();

--------------------------------------------------------------------------------
Código: 120 - Descrição: Descricao021_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 121 - Descrição: Descricao013_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 122 - Descrição: Cadastro025_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 123 - Descrição: Descricao031_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 124 - Descrição: Cadastro026_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 125 - Descrição: FTotDebEmp_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 126 - Descrição: FTotCreEmp_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 127 - Descrição: RotuloCLCsFilialCtb_Depois Imprimir
--------------------------------------------------------------------------------

Definir Alfa xStrAux;

ExcluiInvalidosLstTotalCLCs();

Tem = LstTotalCLCs.Primeiro();
Enquanto (Tem = 1)
Inicio  
  FTotCodClc = LstTotalCLCs.CodClc;
  xStrAux = LstTotalCLCs.NomCta;
  AlteraControle("DTotNomClc", "Descrição", xStrAux); 
  xStrAux = LstTotalCLCs.TipLto;
  AlteraControle("DTotTipLto", "Descrição", xStrAux); 
  FTotValClt = LstTotalCLCs.ValClc;

  se(LstTotalCLCs.TipLto = "D")
    FTotDebClc = FTotDebClc + LstTotalCLCs.ValClc;
  senao  
    FTotCreClc = FTotCreClc + LstTotalCLCs.ValClc;
  
  ListaSecao("Adicional_TotalCLC");
  Tem = LstTotalCLCs.Proximo();    
Fim;  

ListaSecao("DebitoCredito_TotalCLC");
LstTotalCLCs.Limpar();

--------------------------------------------------------------------------------
Código: 128 - Descrição: RotuloCLCsFilialCtb_Antes Imprimir
--------------------------------------------------------------------------------

se ((LstDefEmpresas.TotCtb = "F") e (xOrdPorTotais = cVerdadeiro))
inicio
  SaltarPagina();
  ListaSecao("Adicional_ClcTotal");
fim;  

se (xOrdPorTotais = cVerdadeiro)
inicio
  LstClcsPorTotal.Limpar();
  FDifClcPorTotal = 0;
  FTotCreClcPorTotal = 0;
  FTotDebClcPorTotal = 0;
fim;   


--------------------------------------------------------------------------------
Código: 129 - Descrição: Descricao033_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 130 - Descrição: Descricao034_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 131 - Descrição: Descricao036_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 132 - Descrição: Descricao037_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 133 - Descrição: Descricao032_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 134 - Descrição: FFilCtbCtp_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbCtp = R048CTB.FilCtb;
Senao
  FFilCtbCtp = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 135 - Descrição: Adicional_TotalCLC_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 136 - Descrição: Adicional_TotalCLC_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa NomeSecao;

NomeSecao = "Adicional_TotalCLC"; 
AlternarCorLinhas();

--------------------------------------------------------------------------------
Código: 137 - Descrição: FTotCodClc_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 138 - Descrição: DTotNomClc_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 139 - Descrição: DTotTipLto_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 140 - Descrição: FTotValClt_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 141 - Descrição: DebitoCredito_TotalCLC_Depois Imprimir
--------------------------------------------------------------------------------

@- Verifica se há diferença. Se houver lista a seção que mostra esta diferença -@
FValDifCLC = FTotCreCLC - FTotDebCLC;
Se (FValDifCLC <> 0)
  ListaSecao("Diferenca_TotalCLC");
                                                 
@- Limpa fórmulas da seção -@
FTotCreCLC = 0;
FTotDebCLC = 0;                         

--------------------------------------------------------------------------------
Código: 142 - Descrição: DebitoCredito_TotalCLC_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 143 - Descrição: Descricao035_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 144 - Descrição: Descricao039_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 145 - Descrição: FTotCreCLC_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 146 - Descrição: FTotDebCLC_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 147 - Descrição: RotuloCLCsEmpresa_Depois Imprimir
--------------------------------------------------------------------------------

Definir Alfa xStrAux;

ExcluiInvalidosLstTotalCLCs();
  
@ Se tiver utilizando o assinalmento de clc's por totais e totalizando por empresa @
@ utiliza a lista exclusiva @
se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
inicio
  Tem = LstClcsTotalEmpresa.Primeiro();
  Enquanto (Tem = 1)
  Inicio
    FTotCodClc = LstClcsTotalEmpresa.CodClc;
    xStrAux = LstClcsTotalEmpresa.NomCta;
    AlteraControle("DTotNomClc", "Descrição", xStrAux); 
    xStrAux = LstClcsTotalEmpresa.TipLto;
    AlteraControle("DTotTipLto", "Descrição", xStrAux); 
    FTotValClt = LstClcsTotalEmpresa.ValClc;
   
    se(LstClcsTotalEmpresa.TipLto = "D")
      FTotDebClc = FTotDebClc + LstClcsTotalEmpresa.ValClc;
    senao  
      FTotCreClc = FTotCreClc + LstClcsTotalEmpresa.ValClc;
   
    ListaSecao("Adicional_TotalCLC");
    Tem = LstClcsTotalEmpresa.Proximo();    
  Fim;    
  ListaSecao("DebitoCredito_TotalCLC"); 
  LstClcsTotalEmpresa.Limpar();
fim senao
inicio
  Tem = LstTotalCLCs.Primeiro();
  Enquanto (Tem = 1)
  Inicio
    FTotCodClc = LstTotalCLCs.CodClc;
    xStrAux = LstTotalCLCs.NomCta;
    AlteraControle("DTotNomClc", "Descrição", xStrAux); 
    xStrAux = LstTotalCLCs.TipLto;
    AlteraControle("DTotTipLto", "Descrição", xStrAux); 
    FTotValClt = LstTotalCLCs.ValClc;
   
    se(LstTotalCLCs.TipLto = "D")
      FTotDebClc = FTotDebClc + LstTotalCLCs.ValClc;
    senao  
      FTotCreClc = FTotCreClc + LstTotalCLCs.ValClc;
   
    ListaSecao("Adicional_TotalCLC");
    Tem = LstTotalCLCs.Proximo();    
  Fim;
  
  ListaSecao("DebitoCredito_TotalCLC"); 
  LstTotalCLCs.Limpar();
fim;

--------------------------------------------------------------------------------
Código: 148 - Descrição: RotuloCLCsEmpresa_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 149 - Descrição: Descricao045_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 150 - Descrição: Descricao046_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 151 - Descrição: Descricao047_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 152 - Descrição: Descricao049_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 153 - Descrição: Descricao041_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 154 - Descrição: CabecalhoNatDes_Depois Imprimir
--------------------------------------------------------------------------------

xColunaNatDes = cVerdadeiro;
ListaSecao("Rotulos");

--------------------------------------------------------------------------------
Código: 155 - Descrição: CabecalhoNatDes_Antes Imprimir
--------------------------------------------------------------------------------

xOrdenacao = 5;  @ Natureza de Despesa @

--------------------------------------------------------------------------------
Código: 156 - Descrição: Descricao038_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 157 - Descrição: Cadastro004_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 158 - Descrição: Descricao040_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 159 - Descrição: DNomNat_Na Impressão
--------------------------------------------------------------------------------

Definir Cursor xCursor;
Definir Numero xNatDes;
Definir Alfa xNomNat;

xNatDes = R048CTB.NatDes;

xNomNat = "";
xCursor.SQL "SELECT NOMNAT FROM R048NAT WHERE NATDES = :xNatDes";
xCursor.AbrirCursor();
Se (xCursor.Achou)
  xNomNat = xCursor.NomNat;
xCursor.FecharCursor();  

ValStr = xNomNat;
Cancel(2);

--------------------------------------------------------------------------------
Código: 160 - Descrição: Descricao042_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 161 - Descrição: Descricao043_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 162 - Descrição: Cadastro033_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 163 - Descrição: DNivLan_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 164 - Descrição: Descricao048_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 165 - Descrição: FFilCtbnat_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbNat = R048CTB.FilCtb;
Senao
  FFilCtbNat = R048CTB.FilCtp;

--------------------------------------------------------------------------------
Código: 166 - Descrição: Diferenca_TotalCLC_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 167 - Descrição: Diferenca_TotalCLC_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 168 - Descrição: Descricao050_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 169 - Descrição: FValDifCLC_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 170 - Descrição: Diferenca_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 171 - Descrição: Diferenca_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 172 - Descrição: Descricao003_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 173 - Descrição: FValDif_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 174 - Descrição: Adicional_ClcTotal_Depois Imprimir
--------------------------------------------------------------------------------

@ *** -- Regra para pegar clc's nivel T por cursor -- *** @
Definir Alfa xInsSql; 
Definir Alfa xAbrFilEmp;
Definir Alfa xClau;
Definir Lista LstDefEmpresas;
Definir Cursor xBuscaCLC;
Definir Alfa xPDDebCre;
Definir Alfa xPDNomCon;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave();

se (xOrdPorTotais = cVerdadeiro)
inicio   
  xColunaNatDes = cFalso;
  ListaSecao("Rotulos");                                                           
  
  @ Verifica qual a abragencia que vai compor o sql do cursor @ 
  Definir Cursor Cur_NivLanT;               
  se (LstDefEmpresas.TotCtb = "E")
  inicio
    xFilCtb = R048CTB.NumEmp; 
    intParaAlfa(xFilCtb, xAbrFilEmp);
    xInsSql = " R048CTB.NumEmp = " + xAbrFilEmp + " AND ";
  fim
  senao
  inicio
    Se (LstDefEmpresas.ConRat = "S")
    inicio
      xFilCtb = R048CTB.FilCtb; 
      intParaAlfa(xFilCtb, xAbrFilEmp);
      xInsSql = " R048CTB.FilCtb = " + xAbrFilEmp + " AND ";
    fim;
    senao
    inicio
      xFilCtb = R048CTB.FilCtp; 
      intParaAlfa(xFilCtb, xAbrFilEmp);
      xInsSql = " R048CTB.FilCtp = " + xAbrFilEmp + " AND ";
    fim;
  fim;
  
  xNaoTemPorTotais = cVerdadeiro;
  
  Cur_NivLanT.SQL "SELECT R048CTB.CODCLC, R048CTB.CLCPDB, R048CTB.HISPAD, R048CTB.VALLAN, R048CTB.DEBCRE, R048CLC.NOMCON, \
                          R048CTB.CONDEB, R048CTB.CONCRE, R048CTB.REDDEB, R048CTB.REDCRE, \
                          R048CTB.CONDEP, R048CTB.CONCRP, R048CTB.REDDEP, R048CTB.REDCRP \
                  FROM R048CTB, R048CLC __inserir(:xSQLVinTipCon) WHERE \
                  R048CLC.TABEVE = R048CTB.TABEVE AND \
                  R048CLC.CODCLC = R048CTB.CODCLC AND \
                  __inserir(:xInsSql) \                  
                  R048CLC.NIVLAN = 'T' __inserir(:xInserir)";
                  
  Cur_NivLanT.AbrirCursor();                
  se ((Cur_NivLanT.NaoAchou) e (xNaoTemPorTotais = cVerdadeiro))
    xNaoTemPorTotais = cVerdadeiro;
  senao                                                                     
    xNaoTemPorTotais = cFalso;
  
  se (xNaoTemPorTotais = cVerdadeiro)
  inicio
    Cur_NivLanT.FecharCursor();
    cancel(1);
  fim;

  enquanto(Cur_NivLanT.Achou)
  inicio
  
    @- Grava CLC na lista utilizada para listar os totais -@
    GlobalCodClc = Cur_NivLanT.CodClc;
    GlobalTipLto = Cur_NivLanT.DebCre;
    GlobalNomCta = Cur_NivLanT.NomCon;
    GlobalValClc = Cur_NivLanT.ValLan;    
    GlobalHisPad = Cur_NivLanT.HisPad;
    GlobalClcPdb = Cur_NivLanT.ClcPdb;    
    Se (GlobalTipLto = "D")
    Inicio
      Se (LstDefEmpresas.ConRat = "S")
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        GlobalConCtb = Cur_NivLanT.ConDeb;
        GlobalConRed = Cur_NivLanT.RedDeb;
        @- Partida dobrada é a conta inversa -@
        GlobalParCtb = Cur_NivLanT.ConCre;
        GlobalParRed = Cur_NivLanT.RedCre;
      Fim
      Senao
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        GlobalConCtb = Cur_NivLanT.ConDeP;
        GlobalConRed = Cur_NivLanT.RedDeP;
        @- Partida dobrada é a conta inversa -@
        GlobalParCtb = Cur_NivLanT.ConCrP;
        GlobalParRed = Cur_NivLanT.RedCrP;      
      Fim;
    Fim;
    Senao 
    Inicio
      Se (LstDefEmpresas.ConRat = "S")
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        GlobalConCtb = Cur_NivLanT.ConCre;
        GlobalConRed = Cur_NivLanT.RedCre;
        @- Partida dobrada é a conta inversa -@
        GlobalParCtb = Cur_NivLanT.ConDeb;
        GlobalParRed = Cur_NivLanT.RedDeb;
      Fim
      Senao
      Inicio
        @- Atribui conta contábil e conta reduzida -@
        GlobalConCtb = Cur_NivLanT.ConCrP;
        GlobalConRed = Cur_NivLanT.RedCrP;
        @- Partida dobrada é a conta inversa -@
        GlobalParCtb = Cur_NivLanT.ConDeP;
        GlobalParRed = Cur_NivLanT.RedDeP;
      Fim;
    Fim;
  
    se (xClau <> "")
      GravaLstTotalCLCs();
    GravaListasClcsPorTotal();
    se (LstDefEmpresas.TotCtb = "E")
      GravaListasClcsTotalEmpresa();

    @- Tratamento para partidas dobradas -@
    Se (GlobalClcPdb > 0)
    Inicio
      @- O tipo da contrapartida é invertido -@
      Se (GlobalTipLto = "D")
        xPDDebCre = "C";
      Senao
        xPDDebCre = "D";  
    
      @- Busca o nome CLC de contrapartida -@
      xPDNomCon = "";
      xPDCodClc = GlobalClcPdb;
      xBuscaCLC.SQL "SELECT NOMCON FROM R048CLC WHERE \
                    TABEVE = :xTabEve \
                    AND CODCLC = :xPDCodClc";
      xBuscaCLC.AbrirCursor();
      Se (xBuscaCLC.Achou)
        xPDNomCon = xBuscaCLC.NomCon;
      xBuscaCLC.FecharCursor(); 
    
      @- Grava o CLC de contrapartida na lista utilizada para listar os totais -@
      GlobalCodClc = xPDCodClc;
      GlobalTipLto = xPDDebCre;
      GlobalNomCta = xPDNomCon;
      
      se (xClau <> "")
        GravaLstTotalCLCs();
      se (LstDefEmpresas.TotCtb = "E")
        GravaListasClcsTotalEmpresa();
    Fim;
    
    Cur_NivLanT.Proximo();
  fim;
  
  Cur_NivLanT.FecharCursor();
  
  ExcluiInvalidosLstTotalCLCs();
  
  Tem = LstClcsPorTotal.Primeiro();
  Enquanto (Tem = 1)
  Inicio
    xStrAux = LstClcsPorTotal.ConCtb;
    AlteraControle("DFilContaCtb", "Descrição", xStrAux);    
    FFilContaRed = LstClcsPorTotal.ConRed;
    xStrAux = LstClcsPorTotal.ParCtb;
    AlteraControle("DFilConCtbPar", "Descrição", xStrAux);    
    FFilConRedPar = LstClcsPorTotal.ParRed;    
    xStrAux = LstClcsPorTotal.NomCta;
    AlteraControle("DFilNomCon", "Descrição", xStrAux);    
    FFilValLan = LstClcsPorTotal.ValClc;
    xStrAux = LstClcsPorTotal.TipLto;
    AlteraControle("DFilDebCre", "Descrição", xStrAux);    
    FFilHisPad = LstClcsPorTotal.HisPad;   
    FFilCodClc = LstClcsPorTotal.CodClc;

    @- Controle Partida Dobrada -@
    xPDCodClc = LstClcsPorTotal.ClcPdb;
      
    se (LstClcsPorTotal.TipLto = "D")
    inicio    
      FTotDebClcPorTotal = FTotDebClcPorTotal + FFilValLan;
      se (xPDCodClc > 0)
        FTotCreClcPorTotal = FTotCreClcPorTotal + FFilValLan;      
    fim; 
    senao
    inicio
      FTotCreClcPorTotal = FTotCreClcPorTotal + FFilValLan;
      se (xPDCodClc > 0)
        FTotDebClcPorTotal = FTotDebClcPorTotal + FFilValLan;      
    fim;
      
    ListaSecao("Adicional_clcTot");
    Tem = LstClcsPorTotal.Proximo();    
  Fim;  
  
  se (xClau <> "")
  inicio
    FTotDebEmp = FTotDebEmp + FTotDebClcPorTotal; 
    FTotCreEmp = FTotCreEmp + FTotCreClcPorTotal;
  fim;

  ListaSecao("Adicional_DebCredClcPorTotal");  
fim;

--------------------------------------------------------------------------------
Código: 175 - Descrição: Adicional_ClcTotal_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 176 - Descrição: Descricao051_Na Impressão
--------------------------------------------------------------------------------

se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
  AlteraControle ("Descricao051", "Descrição", "CLC's Por Totais Empresa");

--------------------------------------------------------------------------------
Código: 177 - Descrição: FFilCtbCtpClc_Na Impressão
--------------------------------------------------------------------------------

Definir Lista LstDefEmpresas;

LstDefEmpresas.SetarChave();
LstDefEmpresas.NumEmp = R048CTB.NumEmp;
LstDefEmpresas.VaiParaChave(); 
Se (LstDefEmpresas.ConRat = "S")
  FFilCtbCtpClc = R048CTB.FilCtb;
Senao
  FFilCtbCtpClc = R048CTB.FilCtp;

Se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
  AlteraControle("FFilCtbCtpClc", "Imprimir", "Falso");

--------------------------------------------------------------------------------
Código: 178 - Descrição: Adicional_clcTot_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 179 - Descrição: Adicional_clcTot_Antes Imprimir
--------------------------------------------------------------------------------

Definir Alfa NomeSecao;

NomeSecao = "Adicional_clcTot"; 
AlternarCorLinhas();

--------------------------------------------------------------------------------
Código: 180 - Descrição: FFilContaRed_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 181 - Descrição: DFilContaCtb_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 182 - Descrição: DFilConCtbPar_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 183 - Descrição: FFilConRedPar_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 184 - Descrição: DFilNomCon_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 185 - Descrição: FFilValLan_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 186 - Descrição: DFilDebCre_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 187 - Descrição: FFilHisPad_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 188 - Descrição: FFilCodClc_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 189 - Descrição: Adicional_DebCredClcPorTotal_Depois Imprimir
--------------------------------------------------------------------------------

se (xOrdPorTotais = cVerdadeiro)
inicio
  @- Verifica se há diferença. Se houver lista a seção que mostra esta diferença -@
  FDifClcPorTotal = FTotCreClcPorTotal - FTotDebClcPorTotal;
  Se (FDifClcPorTotal <> 0)
    ListaSecao("Adicional_DifClcPorTotal");
                                                   
  @- Limpa fórmulas da seção -@
  FTotCreClcPorTotal = 0;
  FTotDebClcPorTotal = 0;  
fim; 

--------------------------------------------------------------------------------
Código: 190 - Descrição: Adicional_DebCredClcPorTotal_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 191 - Descrição: Descricao052_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 192 - Descrição: Descricao053_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 193 - Descrição: FTotCreClcPorTotal_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 194 - Descrição: FTotDebClcPorTotal_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 195 - Descrição: Adicional_DifClcPorTotal_Depois Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 196 - Descrição: Adicional_DifClcPorTotal_Antes Imprimir
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 197 - Descrição: Descricao054_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 198 - Descrição: FDifClcPorTotal_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 199 - Descrição: Adicional_ValorLancamento_Depois Imprimir
--------------------------------------------------------------------------------

@ Adicional_ValorLancamento_DepoisImprimir@

Definir Alfa NomeSecao;

@- Limpa dados do lançamento listado -@
FValLan = 0;

NomeSecao = "Lancamentos";
ListarCabecalho();

--------------------------------------------------------------------------------
Código: 200 - Descrição: Adicional_ValorLancamento_Antes Imprimir
--------------------------------------------------------------------------------

Definir Numero xTabEve;
Definir Alfa xNomCon;
Definir Alfa xNomConRegistro;
Definir Alfa xDebCre;
Definir Alfa xContaCtb;
Definir Alfa xConCtbPar;
Definir Alfa NomeSecao;
Definir Numero GlobalCodClc;
Definir Alfa GlobalTipLto;
Definir Alfa GlobalNomCta;
Definir Numero GlobalValClc;
Definir Cursor xBuscaCLC;
Definir Numero xPDCodClc;
Definir Lista LstDefEmpresas;

@- Soma valores de totalização para as seções DebitoCredito -@
Se (xDebCre = "D")
Inicio
  FTotDeb = FTotDeb + FValLan;
  FTotDebEmp = FTotDebEmp + FValLan;
Fim;
Senao
Inicio 
  FTotCre = FTotCre + FValLan;
  FTotCreEmp = FTotCreEmp + FValLan;
Fim;

@- Grava CLC na lista utilizada para listar os totais -@
GlobalCodClc = FCodClc;
GlobalTipLto = xDebCre;
GlobalNomCta = xNomCon;
GlobalValClc = FValLan;
GravaLstTotalCLCs();

@ - Somente quando for totalizar por empresa adiciona nessa lista - @
se ((LstDefEmpresas.TotCtb = "E") e (xOrdPorTotais = cVerdadeiro))
  GravaListasClcsTotalEmpresa();
    
@- Tratamento para partidas dobradas -@
Se (xPDCodClc > 0)
Inicio
  xPDNomCon = "";

  @- Busca o nome CLC de contrapartida -@
  xBuscaCLC.SQL "SELECT NOMCON FROM R048CLC WHERE \
                TABEVE = :xTabEve \
                AND CODCLC = :xPDCodClc";
  xBuscaCLC.AbrirCursor();
  Se (xBuscaCLC.Achou)
    xPDNomCon = xBuscaCLC.NomCon;
  xBuscaCLC.FecharCursor(); 
  
  @- O tipo da contrapartida é invertido -@
  Se (xDebCre = "D")
    xPDDebCre = "C";
  Senao
    xPDDebCre = "D";  
  
  @- Soma valores de totalização para as seções DebitoCredito -@
  Se (xPDDebCre = "D")
  Inicio
    FTotDeb = FTotDeb + FValLan;
    FTotDebEmp = FTotDebEmp + FValLan;
  Fim;
  Senao
  Inicio 
    FTotCre = FTotCre + FValLan;
    FTotCreEmp = FTotCreEmp + FValLan;
  Fim;
  
  @- Grava o CLC de contrapartida na lista utilizada para listar os totais -@
  GlobalCodClc = xPDCodClc;
  GlobalTipLto = xPDDebCre;
  GlobalNomCta = xPDNomCon;
  GlobalValClc = FValLan;
  GravaLstTotalCLCs();  
  
  @ - Somente quando for totalizar por empresa adiciona nessa lista - @
  se ((LstDefEmpresas.TotCtb = "E")  e (xOrdPorTotais = cVerdadeiro))
    GravaListasClcsTotalEmpresa();
Fim;

@- Seta valor para os controles Descrição -@
Se (xNomConRegistro <> "")
  AlteraControle("DNomCon", "Descrição", xNomConRegistro);
Senao
  AlteraControle("DNomCon", "Descrição", xNomCon);
AlteraControle("DDebCre", "Descrição", xDebCre);
AlteraControle("DContaCtb", "Descrição", xContaCtb);
AlteraControle("DConCtbPar", "Descrição", xConCtbPar);

NomeSecao = "Adicional_ValorLancamento"; 
AlternarCorLinhas();

--------------------------------------------------------------------------------
Código: 201 - Descrição: FContaRed_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 202 - Descrição: DContaCtb_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 203 - Descrição: DConCtbPar_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 204 - Descrição: FNatDes_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 205 - Descrição: DNomCon_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 206 - Descrição: FValLan_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 207 - Descrição: DDebCre_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 208 - Descrição: FHisPad_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 209 - Descrição: FCodClc_Na Impressão
--------------------------------------------------------------------------------


--------------------------------------------------------------------------------
Código: 210 - Descrição: FConRedPar_Na Impressão
--------------------------------------------------------------------------------
