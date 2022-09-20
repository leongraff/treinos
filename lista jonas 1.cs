Definir Lista Lst;
Lst.DefinirCampos();
Lst.AdicionarCampo("Empresa", numero);
Lst.AdicionarCampo("Tipo", alfa);
Lst.AdicionarCampo("Cadastro", numero);
Lst.AdicionarCampo("Nome", alfa, 100);
Lst.AdicionarCampo("Salario", numero);
Lst.AdicionarCampo("Afastamento", data);
Lst.EfetivarCampos();
Definir Cursor Cur;
Lst.Chave("Nome");
Cur.SQL "select NumEmp,TipCol,NumCad,ValSal,DatAfa,NomFun from R034FUN"
Cur.AbrirCursor();
enquanto(Cur.Achou)
Lst.Adicionar();
Lst.Empresa = Cur.NumEmp;
Se(Cur.TipCol = 1)
Lst.Tipo = "Colaborador";
senao 
Se (Cur.TipCol = 2) 
    Lst.Tipo = "Parceiro";
senao
Se (Cur.TipCol = 3) 
    Lst.Tipo = "Terceiro";
senao
Lst.Tipo = "<desconhecido>";
Lst.Cadastro = Cur.NumCad;
Lst.Nome = Cur.NomFun;
Lst.Afastamento = Cur.DatAfa;
Lst.Salario = Cur.ValSal;
Lst.Gravar();
Cur.Proximo(); 