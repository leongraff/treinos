possenior## Baixar FileZilla.

### Acessar Servidor da Senior
### ftp://ftp2.senior.com.br
### User: seniorftp2
### Pass: TpR173GMza
### Porta: Em branco
==================================================<br>
 Depois de entrar no servidor:

* Acessar pasta **bases** da mesma atualização da Senior da mesma *pasta em que pegar a versao do **Senior mais atualizada**.<br>
* Pegar **ArquivosComuns.zip** na pasta tecnologia.<br>
* Pegar o **java 8.0.1.**<br>
* Pegar o Development Tools do Windows. **(.netframework)**.<br>
* Pegar o **glassfish 4.0** (instalar em C://).
* Trazer também pasta **Vetorh**.<br>


=================================================== <br>
### SOBRE JAVA
configurar base de dados
odbc 32 bits
app java config instalar 
servidor: nome do pc
porta:1433
sqlexpress





* A necessidade de ter a JDK configurada no Path é na variável do sistema.
* O diretório padrão Senior para instalação do JDK e JRE é C:\Java\jdk (ou jre).
* A instalação Java padrão para o glassfish 4.0 é Java 1.8.0_202. 
* Pode ser usado o comando %JAVAHOME%/bin no Path do sistema para alinhar o caminho já descrito no Home do sistema.
* Ajustar o diretário para o Path do glassfish em asenv.bat em glassfish/config/asenv.bat.

===================================================<br>

 Mover para C:// com o nome padrao de **midias-senior**, todos os arquivos.

 Criação do servidor do glassfish 4.0:
Executar como admininistrador prompt de comando os seguintes comandos a seguir:

* CD \glassfish40\glassfish\bin>
* Colocar o domínio no ar: asadmin.bat start-domain domain1
* Verificar se subiu:
asadmin.bat list-domains.
* Acessar os endereços http://localhost:8080 e http://localhost:4848

* Baixar o domínio do ar:
asadmin.bat stop-domain domain1

* CD \glassfish40\glassfish\config>

* Criar JAVAHOME and JAVAPATH no computer properties.
* Apontar o caminho tanto no path superior quanto inferior


* Editar o arquivo asenv.bat e alterar ou adicionar a linha:
set AS_JAVA=C:\Middleware\Java\jdk-8.0.332.9-hotspot\jre/.. (quando tem mais de um java ou quando esta migrando de uma versao para outra)


* Colocar o domínio no ar:
asadmin.bat start-domain domain1

* Seta o password(*user: admin pass: adminadmin*)
Habilita o Secure Domain e reinicia os serviços
(primeiro cria o password no canto superior esquerdo na tela e depois seta o secure administrator no canto superior esquerdo (segunda instancia).

* Logout e Login

### Instalação da Senior

* Salvar os arquivos do ftp em uma pasta com nome padrão midias-senior
* CNPJ da Senior: 80680093/0001-81
* Código do cliente: 99999

### Configurations>server-config>JVM Settings>Add JVM Option
<br>

### Fazer as alterações:

<br>

*  Quantidade máxima de memória alocada: 1/4 da reservada
* -XX:MaxPermSize=1024m
* -Xmx4096m
* -Xms4096m
* Memória curta reservada:
* -Xmn512m

* Alterar -client por -server


* Garbage collector:
* -XX:+CMSParallelRemarkEnabled

* Relação de survivor da memória curta:
-XX:SurvivorRatio=20

* Limpar a memória curta de novos objetos:
-XX:+UseParNewGC

* Coletor de lixo:
-XX:+UseConcMarkSweepGC

* TimeOut:
-Dhk2.parser.timeout=300

* ?:
* -Xrs=true

* Excluir a propriedade -XX:NewRatio=2 e Salvar as alterações.



Configurations>server-config>Thread Pools>http-thread-pool

Alterar o Max Thread Pool size para 8x a quantidade de núcleos do processador



Configurations>server-config>Network Config>Network Listeners>http-listener-1>HTTP

Alterar o Request Timeout para 3600 (?) ou maior (?)

Reiniciar os serviços: #################################################AQUI QUE DÁ O ERRO NCLS-ADMIN-00010 CLI306

se nao tiver o ronda tem que criar o serviço do glassfish asdamin create-service domain1
								  sc config domain1 displayname= "senior glassfish domain1"
admin
adminadmin
SENHA E PASSWORD DO GLASSFISH

admin
admadm 
SENHA SDE


localhost48

MIDDLEWARE É USADO EM:
Windows Access, wa.
browser access
webservice (xml)
web 5.0
e-social tem o motoresocial para se comunicar com o edocs

edocs: habilitação iss windows
cria um banco de dados
confgurar o iis((forma de hospedagem de web(apache))
instalação do edocs (senior sde, instalador é edocs servidor)

necessário atualizar glassfish após atualização do sistema

problema de estação caindo: marcar viewserverstate no banco de dados


select para pegar data no cbds:
SELECT * FROM tabLogUsuario WHERE datCadastro BETWEEN '2011-01-10' AND '2011-01-12'
SELECT * 01.ORDER BY DATAPU ASC
 and DATLAN BETWEEN '2022-09-01' AND '2022-09-30' ORDER BY DATLAN ASC
baixar a pasta certa no ftp para o sde conferindo versionamento certo.
parar glassfish, parar concentradora
central de monitoramento senior....


- concentradora tem que parar

- encerrar o processo do seniormiddleware.exe


D:\Senior\glassfish40\glassfish\domains\csmcenter
- verificar a pasta do csm center para ver se nao esta vazia (a respeito do deploy)
-  applications onde fica as aplicações do glassfish
- glassfish > domains > csm center
po

x platform 

[8:29 AM, 13/09/2022] Marcos Padilha: Bom dia, acesso ao ambiente do XPlatform
[8:30 AM, 13/09/2022] Marcos Padilha: link: https://platform.senior.com.br/
usuário: [seu-nome]@digisys-demo.com.br
senha: Digisys$9800

ValStr = vCodUsu antes de imprimir na seção para cancelar seção
Definir Alfa vCodUsu;
ValStr = vCodUsu
	Cancel(2);

	Cancel(1) é para cancelar a impressao da seção caso esteja na seção.

posical alfa
copiar alfa /\ usado para buscar e copiar uma palavra dentro da regra 	


==========================================================================

pre requisitos gerais senior
privilegio de administrador para a eecuçao do instalador
so versao homologada
instalação do sistema gerenciador de banco de dados
instalação do navegador em versao homologada
firewall - definiçao da liberaçao da porta de serviço de informaçao da instalaçao
---- configuração e liberaçao da porta do gerenciador do middleware
---- compartilhamento do diretorio raiz da instalação no servidor de aplicativos

instalação e configuração do jdk 8

configurar variaveis de ambiente
	-	propriedades do sistema>avançado>variaveis de ambiente
	-   apontar o JAVA_HOME do 1.7 apontar para o 1.8
	-   nao remover conteudo, em path acrescentar ;%JAVAHOME%\bin
	-   desabilitar atualização automatica do java
	-   painel de controle>programas>java>update>desabilitar.
	-	acessar prompt de comando java -version (versao 1.8)

instalação do servidor java ee (glassfish 4.0)
	-	glassfish é open source e homologado pela oracle (homologado pela senior)
	-	baixar o glassfish 4.0.
	-	descompactar o glassfish no diretorio correto. C:\glassfish4
	-	ja existe por padrao o domain1.
	-	portas 8080(servidor http), orb 3700, jms 7676, https 8181 ?? e 4848??
	-	quais portas estao em uso: cmd -> netstat -ano
	-	netstat -ano | find "8080" (comando para verificar se uma porta esta em uso)
	-	alterar as portas no domain1 do glassfish, se precisar
	-	glassfish4 > glassfish40 > glassfish>domains > domain1 > config - domain.xml - localizar portas para edição.
	-	cd glassfish\glassfish40>dir
	-	cd glassfish\glassfish40\bin>asadmin.bat start-domain domain1
	-   stop-domain
	-	verificar se esta rodando: porta 8080
	-	parar glassfish
	-	localizar asenv.bat -> AS_JAVA
	-	informar diretorio da variavel JAVAHOME 
		asadmin
	-	na porta 4848 (admin), localizar Common Tanetsks  -> Domain //PARA LIBERAR ACESSO AO PAINEL POR OUTRAS MÁQUINAS...
		-> Administrator password, new password, confirmdir
		 new password - "adminadmin"
		-> logout, adminadmin, common tasks, configuration, server-config, http service, http listeners, admin-listener //admin-listener que no domain.xml controla a porta de admin do glassfish...
		-> security, secure administration, enable secure admin...
	-	reiniciar dominio.
	-	configurations, server-confir, jvm settings
	-	jvm options				


	- no beto: usar sempre a primeira pasta para dar comandos de start e stop domains
	- C:\glassfish3\bin>admin.bat




				
		@ 		CONFIGS GLASSFISH JVM OPTIONS 		@		=				CONSIDERAÇÕES SOBRE FUNCIONAMENTO JVM
															=
				-client vai virar -server					=			-XX:MaxPermSize= // 1/4 da Xmx
															=
				Xmx4020m									=					-Xmx
															=
				-XX:MaxPermSize=2020m						=			memoria do glassfish xmx + maxpermsize
			32 bits nao pode passar de 2gb					=
															==-==============================================================-
adicionar	-Xmn512m (objetos de ciclo de vida curto)		=					@	configs finais glassfish	@
															=			em thread pools - > http-thread-pool
			/\ variaveis locais dos metodos					=			max thread pool size -> qnt de nucleos x 8	
															=				
															=				http-listener-1 -> request timeout = 3600
															=					tempo para deploy
			-XX:+CMSParallelRemarkEnabled - 				=
															=				@ CRIAÇAO DO DOMINIO COMO SERVIÇO	@
				-XX:SurvivorRatio=20 - 						=		
		razao entre a area do survival e da curta			=	@ cd glassfish\glassfish40\bin>asadmin create-service domain1 @
 				duraçao de memoria							=
															=
				-XX:+UseParNewGC 							=
		algoritmo q deve ser usado para limpar a memoria	=
		de curta duração destinada a novos objetos			=
															=
			-XX:+Use ConcMarkSweep							=
			marksweep - limpeza de memoria					=
															=
			-Xms utiliza o mesmo valor do Xmx				=
			para melhor performance							=
															=
				-Dhk2.parser.timeout=300					=
			timeout para carregamento de 					=
			webservices e ambientes							=
															=
															=
															=
					DELETAR:								=
															=
				-xx:NewRatio								=
															=
															=



sqljdbc4-4 -> esse arquivo aqui é o que falta quando a conexao jdbc nao funciona


o problema de atualizar pelo updatetool pode ser a forma como o senior enxerga estes parametros



listener 2  - 2 enabled - 8182
listener 1 - 1 enabled - 8082
admin-listener - 1 enabled 4848

comando para csm center asadmin --host localhost --port 4949 enable-secure-admin

comando upgrade asadmin start-domain --upgrade "SeniorGlassfish"

quando o comando da does not accept any operands
é pra nao POR OPERADORES
LEIA

// LISTA COMANDOS PADRAO PARA UPGRADE PELA UPGRADETOOL DO GLASSFISH =D

asadmin start-domain --upgrade SeniorGlassfish
asadmin start-domain
asadmin enable-secure-admmin
asadmin stop-domain
asadmin list-domains


asadmin --host host



===== X ===== X ===== X ===== X ===== X ===== X ===== X   MOTOR ESOCIAL  ===== X ===== X ===== X ===== X ===== X ===== X ===== X ===== X ===== X

Incidente
No módulo Administração de Pessoal ao acessar a tela de consulta pendências os leiautes estão com 
situação Aguardando envio automático. Ao verificar os logs do motor é retornada a seguinte mensagem: 
[# Thd=main Ctx=br.com.senior.rh.esocial.motor.uenginecontroller.EngineController ERROR #] Já existe um Motor eSocial em execução].

Causa
Esse incidente ocorre pois na tabela interna existem dois motores eSocial em execução. 

Solução
Para que a mensagem não seja apresentada, realize os passos a seguir:
1. Pare os serviços do motor ;
2. Efetue o seguinte delete via CBDS :

DELETE FROM R000LCK WHERE IDELCK = 'MOTORESOCIAL'

3. Reinicie os serviços ;
4. Aguarde uns minutos e os leiautes serão enviados. 


update r051sad set numcad=10006 where numcad=10004 and codcal=2058


============================================== senior middleware ======================================================


taskkill  -javaw.exe /im /f


C:\Senior\SeniorMiddleware.exe -svc -amgr id:senior instid:3617484 /uninstall

https://documentacao.senior.com.br/tecnologia/5.10.1/#instalador/servicos_middleware.htm%3FTocPath%3DTecnologia%7CManual%2520de%2520Instala%25C3%25A7%25C3%25A3o%7CInforma%25C3%25A7%25C3%25B5es%2520T%25C3%25A9cnicas%7C_____12


baixar glassfish
configurar glassfish - jms options - http listener - secure options - thread pool size opstion 4x numero de nucleos
criar serviço
senha de admin no serviço

