Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Alfa xNomLoc;
Definir Alfa xCodLoc;
Definir Cursor Cur_R034FUN;

Inicio  
    xNumEmp = R034FUN.NumEmp;
    xTipCol = R034FUN.TipCol;
    xNumCad = R034FUN.NumCad;

    Cur_R034FUN "SELECT * FROM R034FUN WHERE R034FUN.NumEmp=:xNumEmp AND   \
                                             R034FUN.TipCol=:xTipCol AND   \
                                             R034FUN.NumCad=:xNumCad"; 
    Cur_R034FUN.AbrirCursor();
RetNomCodNiv(xNumEmp,xTipCol,xNumCad,0,1,4,xNomLoc,xCodLoc);
    Se(Cur_R034FUN.Achou)
    Formula001 = xCodLoc
Cur_R034FUN.FecharCursor();
Fim










