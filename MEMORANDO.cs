Definir Alfa xTexto;

Definir Alfa xNumCgc;
Definir Alfa xTipoLogradouro;
Definir Alfa xCodCep;
Definir Alfa xEnderecoEmpregador;
Definir Alfa xEnderecoEmpregado;
Definir Alfa xEstCiv;
Definir Alfa xEstadoCivil;
Definir Alfa xNumPis;
Definir Alfa xNumCpf;
Definir Alfa xNumCtp;
Definir Alfa xDexCtp;
Definir Alfa Cur_R038HFI;
Definir Alfa xSqlFilial;
Definir Alfa xTipLgr;
Definir Alfa xEndFil;
Definir Alfa xEndNum;
Definir Alfa xCplFil;
Definir Alfa xCodEst;
Definir Alfa xRazSoc; 
Definir Numero vNumEmp;
Definir Numero vTipCol;
Definir Numero vNumCad;
Definir Data   vDatAdmi;
Definir Cursor Cur_R074BAI;
Definir Cursor Cur_R074CID;
Definir Cursor Cur_R074PAI;
/* Informações do Empregador */

NumeroParaAlfa(R030FIL.NumCgc, xNumCgc);

xEnderecoEmpregador = "";

EstaNulo(R030FIL.EndFil, xNulo);
Se (xNulo = 0)
Inicio
  EstaNulo(R030FIL.TipLgr, xNulo);
  Se (xNulo = 0)
  Inicio
    DescItemLista("LTipLgd", R030FIL.TipLgr, xTipoLogradouro);
    xEnderecoEmpregador = xEnderecoEmpregador + xTipoLogradouro + " ";
  Fim;
  
  xEnderecoEmpregador = xEnderecoEmpregador + R030FIL.EndFil;
  
  EstaNulo(R030FIL.EndNum, xNulo);
  Se (xNulo = 0)
    xEnderecoEmpregador = xEnderecoEmpregador + " " + R030FIL.EndNum;
  
  EstaNulo(R030FIL.CplFil, xNulo);
  Se (xNulo = 0)
    xEnderecoEmpregador = xEnderecoEmpregador + ", " + R030FIL.CplFil;        
Fim;
xRazSoc = R030FIL.RazSoc;
xCodPai = R030FIL.CodPai;
xCodCid = R030FIL.CodCid;
xCodBai = R030FIL.CodBai;
xCodEst = R030FIL.CodEst;
NumeroParaAlfa(R030FIL.CodCep, xCodCep);

/*Histórico da Filial*/
vNumEmp = R034FUN.NUMEMP;
vTipCol = R034FUN.TIPCOL;
vNumCad = R034FUN.NUMCAD;
vDatAdmi = R034FUN.DATADM;
xSqlFilial = "SELECT R030FIL.RazSoc RAZSOC, R030FIL.NumCgc NUMCGC, R030FIL.CodPai CODPAI, R030FIL.CodCid CODCID, R030FIL.CodBai CODBAI, \
                     R030FIL.TipLgr TIPLGR, R030FIL.EndFil ENDFIL, R030FIL.EndNum ENDNUM, R030FIL.CplFil CPLFIL, \
                     R030FIL.CodCep CODCEP, R030FIL.CodEst CODEST \ 
                FROM R038HFI, R030FIL           \
               WHERE R038HFI.NUMEMP = :vNumEmp  \ 
                 AND R038HFI.TIPCOL = :vTipCol  \ 
                 AND R038HFI.NUMCAD = :vNumCad  \   
                 AND R038HFI.DATALT = :vDatAdmi \
                 AND R038HFI.NUMEMP = R030FIL.NUMEMP \ 
                 AND R038HFI.CODFIL = R030FIL.CODFIL";
                      
SQL_Criar(Cur_R038HFI);
SQL_UsarAbrangencia(Cur_R038HFI,0);
SQL_USARSQLSENIOR2(Cur_R038HFI,0);
SQL_DefinirComando(Cur_R038HFI, xSqlFilial);
SQL_DefinirInteiro(Cur_R038HFI, "vNumEmp", vNumEmp);
SQL_DefinirInteiro(Cur_R038HFI, "vTipCol", vTipCol);
SQL_DefinirInteiro(Cur_R038HFI, "vNumCad", vNumCad);    
SQL_DefinirData(Cur_R038HFI, "vDatAdmi", vDatAdmi);
SQL_AbrirCursor(Cur_R038HFI);
Se(SQL_EOF(Cur_R038HFI) = 0)
Inicio
  SQL_RetornarAlfa(Cur_R038HFI, "RAZSOC", xRazSoc);
  SQL_RetornarAlfa(Cur_R038HFI, "NUMCGC", xNumCgc);
  SQL_RetornarInteiro(Cur_R038HFI, "CODPAI", xCodPai);
  SQL_RetornarInteiro(Cur_R038HFI, "CODCID", xCodCid);
  SQL_RetornarInteiro(Cur_R038HFI, "CODBAI", xCodBai);
  SQL_RetornarAlfa(Cur_R038HFI, "TIPLGR", xTipLgr);
  SQL_RetornarAlfa(Cur_R038HFI, "ENDFIL", xEndFil);
  SQL_RetornarAlfa(Cur_R038HFI, "ENDNUM", xEndNum);
  SQL_RetornarAlfa(Cur_R038HFI, "CPLFIL", xCplFil);                                           
  xEnderecoEmpregador = xTipLgr +  " " + xEndFil + " " + xEndNum + ", " +  xCplFil;
  SQL_RetornarAlfa(Cur_R038HFI, "CODCEP", xCodCep);
  SQL_RetornarAlfa(Cur_R038HFI, "CODEST", xCodEst);
Fim; 

SQL_FecharCursor(Cur_R038HFI);    
SQL_Destruir(Cur_R038HFI); 

Se (xCodCid > 0)
Inicio
  Se (xCodBai > 0)
  Inicio
    Cur_R074BAI.SQL "SELECT NOMBAI FROM R074BAI WHERE CODCID = :xCodCid AND CODBAI = :xCodBai";
    Cur_R074BAI.AbrirCursor();
    Se (Cur_R074BAI.Achou)
      xEnderecoEmpregador = xEnderecoEmpregador + ", " + Cur_R074BAI.NomBai;  
    Cur_R074BAI.FecharCursor();
  Fim;

  Cur_R074CID.SQL "SELECT NOMCID FROM R074CID WHERE CODCID = :xCodCid";
  Cur_R074CID.AbrirCursor();
  Se (Cur_R074CID.Achou)
  Inicio
    xEnderecoEmpregador = xEnderecoEmpregador + ", " + Cur_R074CID.NomCid;
    EstaNulo(xCodEst, xNulo);    
    Se (xEstaNulo = 0)
      xEnderecoEmpregador = xEnderecoEmpregador + "/" + xCodEst;  
  Fim;
  Cur_R074CID.FecharCursor();
Fim;

Se (xCodPai > 0)
Inicio
  Cur_R074PAI.SQL "SELECT NOMPAI FROM R074PAI WHERE CODPAI = :xCodPai";
  Cur_R074PAI.AbrirCursor();
  Se (Cur_R074PAI.Achou)
    xEnderecoEmpregador = xEnderecoEmpregador + ", " + Cur_R074PAI.NomPai;  
  Cur_R074PAI.FecharCursor();
Fim;

EstaNulo(xCodCep, xNulo);
Se (xNulo = 0)
Inicio
  xEnderecoEmpregador = xEnderecoEmpregador + ", " + xCodCep;
Fim;

/* Informações do Empregado */

IntParaAlfa(R034FUN.EstCiv, xEstCiv);
DescItemLista("LEstCiv", xEstCiv, xEstadoCivil);

xEnderecoEmpregado = "";

EstaNulo(R034CPL.EndRua, xNulo);
Se (xNulo = 0)
Inicio
  EstaNulo(R034CPL.TipLgr, xNulo);
  Se (xNulo = 0)
  Inicio
    DescItemLista("LTipLgd", R034CPL.TipLgr, xTipoLogradouro);
    xEnderecoEmpregado = xEnderecoEmpregado + xTipoLogradouro + " ";
  Fim;

  xEnderecoEmpregado = xEnderecoEmpregado + R034CPL.EndRua;
  
  EstaNulo(R034CPL.EndNum, xNulo);
  Se (xNulo = 0)
    xEnderecoEmpregado = xEnderecoEmpregado + " " + R034CPL.EndNum;
  
  EstaNulo(R034CPL.EndCpl, xNulo);
  Se (xNulo = 0)
    xEnderecoEmpregado = xEnderecoEmpregado + ", " + R034CPL.EndCpl;        
Fim;

xCodPai = R034CPL.CodPai;
xCodCid = R034CPL.CodCid;
xCodBai = R034CPL.CodBai;

Se (xCodCid > 0)
Inicio
  Se (xCodBai > 0)
  Inicio
    Cur_R074BAI.SQL "SELECT NOMBAI FROM R074BAI WHERE CODCID = :xCodCid AND CODBAI = :xCodBai";
    Cur_R074BAI.AbrirCursor();
    Se (Cur_R074BAI.Achou)
      xEnderecoEmpregado = xEnderecoEmpregado + ", " + Cur_R074BAI.NomBai;
    Cur_R074BAI.FecharCursor();
  Fim;

  Cur_R074CID.SQL "SELECT NOMCID FROM R074CID WHERE CODCID = :xCodCid";
  Cur_R074CID.AbrirCursor();
  Se (Cur_R074CID.Achou)
  Inicio
    xEnderecoEmpregado = xEnderecoEmpregado + ", " + Cur_R074CID.NomCid;
    Se (R030FIL.CodEst <> "")
      xEnderecoEmpregado = xEnderecoEmpregado + "/" + R034CPL.CodEst;  
  Fim;
  Cur_R074CID.FecharCursor();
Fim;

Se (xCodPai > 0)
Inicio
  Cur_R074PAI.SQL "SELECT NOMPAI FROM R074PAI WHERE CODPAI = :xCodPai";
  Cur_R074PAI.AbrirCursor();
  Se (Cur_R074PAI.Achou)
    xEnderecoEmpregado = xEnderecoEmpregado + ", " + Cur_R074PAI.NomPai;  
  Cur_R074PAI.FecharCursor();
Fim;

NumeroParaAlfa(R034CPL.EndCep, xCodCep); 
EstaNulo(xCodCep, xNulo);
Se (xNulo = 0)
Inicio
  ConverteMascara(5, R034CPL.EndCep, xCodCep, "99999-999");
  xEnderecoEmpregado = xEnderecoEmpregado + ", " + xCodCep;
Fim;

NumeroParaAlfa(R034FUN.NumPis, xNumPis);
ConverteMascara(5, R034FUN.NumPis, xNumPis, "999.99999.99.9");

NumeroParaAlfa(R034FUN.NumCpf, xNumCpf);
ConverteMascara(5, R034FUN.NumCpf, xNumCpf, "999.999.999-99");

NumeroParaAlfa(R034FUN.NumCtp, xNumCtp);
ConverteMascara(3, R034FUN.DexCtp, xDexCtp, "DD/MM/YYYY");

xTexto = "          Por este instrumento particular, de um lado " + xRazSoc + ", pessoa jurídica de direito privado, " + 
         "inscrita no CNPJ/MF sob o nº " + xNumCgc + ", estabelecida no(a) " + xEnderecoEmpregador + ", doravante denominada Empregadora, e, " + 
         "de outro, " + R034FUN.NomFun + ", " + R023NAC.DesNac + ", " + xEstadoCivil + ", " + xEnderecoEmpregado +
         ", portador(a) da CTPS " + xNumCtp + " " + R034FUN.SerCtp + " " + R034FUN.EstCtp + " " + xDexCtp +
         ", cadastrado(a) no PIS sob o nº " + xNumPis + " e inscrito(a) no CPF sob o nº " + xNumCpf + 
         ", doravante denominado(a) Empregado(a), ajustam entre si o presente contrato de trabalho, nos termos e condições que seguem.";

ValStr = xTexto;
Cancel(2);