# VP
Test Services Rest avec Signature et authentification

<h2> Les controllers </h2>
Les deux Web Services sont divisée sur deux controlleurs :

 * User Controler ( api/authenticate )
 * ConfidentialController (api/confidential)

 Le system de signature et authentification est OAUTH avec ASp.NET Identity

<h2>Pour Tester</h2>

* Lien premier ws [GET]:  http://khghwebservicetest.azurewebsites.net/api/authenticate  
* Paramétres : email & password 
* Retour : "False" si le format de mail n'est pas valide,Sinon "True".

<br></br>
* Pour le deuxiéme ws authentifié il faut avant appeler le webservice qui génerera le token selon l'email et le password 
* Lien [POST] :   http://khghwebservicetest.azurewebsites.net/Token 
* Paramétres [Body] [  x-www-form-urlencoded ] : 

{

"userName " : "[Le mail utilisé dans le premier ws]"

"  password " :  "[Le password utilisé dans le premier ws]"

"  grant_type " : "  password "

}

* Retour : Objet avec l'access token ainsi que ses details


<br></br>
* Lien deuxième ws [GET] :    http://khghwebservicetest.azurewebsites.net/api/confidentials
* Paramétres : email  
* Autorisation : Bearer + [Le token récupéré précedemment]
* Retour : "True" si le mail passé en paramétre coresspond à l'email utilisé lors de la géneration du token , Sinon "False"


