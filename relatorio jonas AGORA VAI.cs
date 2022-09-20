Definir Alfa deseveant;
Definir Numero xcodeve;
Definir Numero x;
Definir Alfa DERelFicRef1;
Definir Alfa DERelFicRef2;
Definir Alfa DERelFicRef3;
Definir Alfa DERelFicRef4;
Definir Alfa DERelFicRef5;
Definir Alfa DERelFicRef6;
Definir Alfa DERelFicRef7;
Definir Numero DERelFicVal1;
Definir Numero DERelFicVal2;
Definir Numero DERelFicVal3;
Definir Numero DERelFicVal4;
Definir Numero DERelFicVal5;
Definir Numero DERelFicVal6;
Definir Numero DERelFicVal7;
Definir Numero CORelFicCod1;
Definir Numero CORelFicCod2;
Definir Numero CORelFicCod3;
Definir Numero CORelFicCod4;
Definir Numero CORelFicCod5;
Definir Numero CORelFicCod6;
Definir Numero CORelFicCod7;

Definir Alfa pNumCad;
Definir Alfa AuxSQLAbr;
Definir Numero mesinireq;
Definir Numero anoinireq;
Definir Numero mesfimreq;
Definir Numero anofimreq;
Definir Numero xNumEmp;
Definir Numero xTipCol;
Definir Numero xNumCad;
Definir Cursor Cur_R034FUN;
Definir Alfa Enumcad;   



Inicio

AcumulaEventosFicFin (R034FUN.NumEmp,R034FUN.TipCol, R034FUN.NumCad, 1, ENPerIni, EDatRef, 0);
      Se (FimEve = 0)  
         Cancel(1);    

Fim;
   
PosEve = 0;
x = 0;
tipeveant = 0;
codeveant = 0;
deseveant = "";
    ListaSecao("Adicional_2");
      DERelFicVal1 = 0;
      DERelFicVal2 = 0;
      DERelFicVal3 = 0;
      DERelFicVal4 = 0;
      DERelFicVal5 = 0;
      DERelFicVal6 = 0;
      DERelFicVal7 = 0;
    
      DERelFicRef1 = "";
      DERelFicRef2 = "";
      DERelFicRef3 = "";
      DERelFicRef4 = "";
      DERelFicRef5 = "";
      DERelFicRef6 = "";
      DERelFicRef7 = "";

      CORelFicCod1 = 0;
      CORelFicCod2 = 0;
      CORelFicCod3 = 0;
      CORelFicCod4 = 0;
      CORelFicCod5 = 0;
      CORelFicCod6 = 0;
      CORelFicCod7 = 0;
  
Enquanto (x < FimEve)
  Inicio
      BuscaProxEvento();
   
      CodEveAnt = RelFicCod;
      DesEveAnt = RelFicDes;
      FACodEve = codeveant;     
    
      Se((CORelFicCod1 = 0) e (DERelFicRef1 = "")){
      CORelFicCod1 = RelFicCod;
      DERelFicRef1 = RelFicDes;          
      DERelFicVal1 = RelFicVal;
      VaPara PxmCmp;    
      }   
      Se((CORelFicCod2 = 0) e (DERelFicRef2 = "")){
      CORelFicCod2 = RelFicCod;
      DERelFicRef2 = RelFicDes;
      DERelFicVal2 = RelFicVal;                  
      VaPara PxmCmp;    
      }
      Se((CORelFicCod3 = 0) e (DERelFicRef3 = "")){
      CORelFicCod3 = RelFicCod;
      DERelFicRef3 = RelFicDes; 
      DERelFicVal3 = RelFicVal;
      VaPara PxmCmp;
      }
      Se((CORelFicCod4 = 0) e (DERelFicRef4 = "")){
      CORelFicCod4 = RelFicCod;
      DERelFicRef4 = RelFicDes;
      DERelFicVal4 = RelFicVal;          
      VaPara PxmCmp;    
      }
  
      Se((CORelFicCod5 = 0) e (DERelFicRef5 = "")){
        CORelFicCod5 = RelFicCod;
        DERelFicRef5 = RelFicDes;
        DERelFicVal5 = RelFicVal;          
        VaPara PxmCmp;    
      }

      Se((CORelFicCod6 = 0) e (DERelFicRef6 = "")){
      CORelFicCod6 = RelFicCod;
      DERelFicRef6 = RelFicDes;
      DERelFicVal6 = RelFicVal;          
      VaPara PxmCmp;    
      }

      Se((CORelFicCod7 = 0) e (DERelFicRef7 = "")){
      CORelFicCod7 = RelFicCod;
      DERelFicRef7 = RelFicDes;  
      DERelFicVal7 = RelFicVal;        
      VaPara PxmCmp;    
      }

      PxmCmp:
      x = x + 1;

Fim;