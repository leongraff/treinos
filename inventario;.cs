
//inventario de regras do leon

//regra cabeluda da riomar
IntParaAlfa
Converte um número para formato alfanumérico. Este valor numérico está limitado a até 15 caracteres.

Sintaxe: IntParaAlfa (Num_Origem,Alfa_Destino);

Parâmetros:

Nome	Tipo	Descrição
Num_Origem	Numero	Campo/Variável que será convertido
Alfa_Destino	Alfa	Campo/Variável que receberá o resultado da conversão
Exemplo:

Definir Alfa ValfAux;

IntParaAlfa (VVlrAux,VAlfAux);
@ Se a variável VVlrAux tivesse o valor 150,50, após o uso da função IntParaAlfa a variável VAlfAux teria 150. @

Observação: Caso o parâmetro seja um número com ponto flutuante (casas decimais), as casas decimais serão ignoradas e o valor será convertido para inteiro. Por exemplo o valor 19,9999999 será convertido para 19.

Valores resultantes de operações envolvendo valores não representados de forma exata em uma variável do tipo ponto flutuante, embora sejam exibidos como determinado valor antes da operação, podem ter seu valor alterado pela função devido à remoção das casas decimais.

Por exemplo, após dividir 23.4 por 1.8, o resultado é 13, porém 23.4 e 1.8 são valores que não são representados de forma exata em uma variável do tipo ponto flutuante. Com isso, embora o resultado seja exibido como 13,o valor armazenado é 12.99999... Assim, o valor exibido é arredondado para 13, porém, ao ignorar as casas decimais o valor é alterado para 12.

Desta forma, caso não queira um valor truncado (com as casas decimais removidas), deve-se arredondar o valor antes de chamar a função IntParaAlfa.


zEspLevel = ?
===================================================
RetNomCodNiv
Retorna o Nome e o código do Local do Empregado em um determinado nível
R034FUN.NUMEMP = numero empresa
R034FUN.TIPCOL = tipo colaborador
R034FUN.NUMCAD =  numero cadastro colaborador
0 = data referencia
1 = nivel inicial
EspNivTot =  nivel final
xNomLoc = retorna o nome do local em um determinado nivel
xCodLoc = retorna o codigo do local do funcionario em um determinado nivel

=================================================
espnivtot = niveis totais na tela de entrada.......

============================================================

PosicaoAlfa(Texto_Pesquisa,Campo_pesquisa,Posicao)
Texto_Pesquisa = , ?
xNomLoc = 

===================================================

PosicaoAlfa(",", xNomLoc, PosStr);

