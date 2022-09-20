

Definir Cursor Cur_R038HCA;
Definir Numero vNumEmp;
Definir Numero vNumCad;
Definir Numero vTipCol;
Definir Data vDatAlt;

Inicio
	vNumEmp=R038HCA.NumEmp;
	vNumCad=R038HCA.NumCad;
	vTipCol=R038HCA.TipCol;
	vDatAlt=R038HCA.DatAlt;

	Cur_R038HCA.SQL "SELECT DATALT FROM R038HCA WHERE 1=2 UNION SELECT MAX(DATALT) FROM R038HCA \ 
               WHERE R038HCA.NumEmp=:vNumEmp and         \
                R038HCA.TipCol=:vTipCol and   \
                R038HCA.NumCad=:vNumCad";
               
	Cur_R038HCA.AbrirCursor();
	Se(Cur_R038HCA.Achou)
	
			vDatAlt=Cur_R038HCA.DatAlt;
			
	Cur_R038HCA.FecharCursor();
	Fim