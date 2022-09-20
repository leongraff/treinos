 Atualiza EMAIL dos colaboradores @

definir alfa wnumcpf;
definir alfa wemacom;
definir data ddatzer;
definir data ddatmax;
ddatzer = 0;
montadata(1,6,2080,ddatmax);
definir numero nnumcpf;

Definir cursor c_pes;
c_pes.sql "SELECT * FROM USU_VCODPES WHERE USU_VCODPES.DATNAS>:ddatzer AND \
                                           USU_VCODPES.DATNAS<:ddatmax AND \ 
                                           USU_VCODPES.EMAIL IS NOT NULL";
c_pes.abrircursor();
enquanto (c_pes.achou)
 {
  nCodPes = c_pes.codpes;
  wnumcpf = c_pes.numcpf;
  wemacom = c_pes.email; 
  tiraespacos (wnumcpf,wnumcpf);
  AlfaPuro(wnumcpf,0,0);
  alfaparaint(wnumcpf,nnumcpf);
  tiraespacos(wemacom,wemacom);
  se ((wemacom <> "") e (wemacom <> " "))
   {
    execsql "update usu_tcodpes set usu_emacom=:wemacom \
                              where usu_codpes=:ncodpes and \
                                    usu_numcpf=:nnumcpf";
    definir cursor c_fun;
    c_fun.sql "select r034fun.numemp,r034fun.tipcol,r034fun.numcad,r034fun.codpes \
                 from r034fun, r034cpl where r034fun.numemp=r034cpl.numemp and \
                                             r034fun.tipcol=r034cpl.tipcol and \
                                             r034fun.numcad=r034cpl.numcad and \
                                             r034fun.numcpf=:nnumcpf       and \
                                             r034fun.codpes=:ncodpes       and \
                                             r034fun.sitafa<>7";
    c_fun.abrircursor();
    se (c_fun.achou)
     {
      definir alfa acodpes;
      znumemp = c_fun.numemp;
      ztipcol = c_fun.tipcol;
      znumcad = c_fun.numcad;
      intparaalfa(ncodpes,acodpes);
      execsql "update r034cpl set emacom=:wemacom where numemp=:znumemp and \
                                                        tipcol=:ztipcol and \
                                                        numcad=:znumcad and \
                                                        emacom<>:wemacom ";
      ncodusu = RetCodUsuPorColab(znumemp,ztipcol,znumcad);
      se (ncodusu > 0)
       {
        Definir Alfa xResult;
        se (ncodpes > 0)
         {
          yret = SegEntLe(ncodusu,xResult);
          se (yret > 0)
           {
            SegUsuSetaEmail(xresult,wemacom);
            SegEntGrava(xResult);
           }; 
         }; 
       };   
     };
    c_fun.fecharcursor();
   };
  c_pes.proximo();
 };
c_pes.fecharcursor();

@       @