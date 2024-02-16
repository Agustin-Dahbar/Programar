Git es el sistema control de versiones más usado en el mundo. GIT nos permitirá tener un historial completo de todo el código que hemos ido desarrollando. 

<!-- ROLLBACK -->
Si el código se ve perjudicado por algo, podremos hacer un ROLLBACK hasta la anterior versión del proyecto.



<!-- Primeros comandos a iniciar -->
git config --global user.name "Agustin Dahbar"

git-config --global user.email agustindahbarpp@hotmail.com

git config --global core.editor "code --wait"

git config --global -e


<!-- core.autocrlf -->
git config --global core.autocrlf true

Supongamos que hay dos developers trabajando en el mismo repositorio. 
Uno en Windows y otro en Mac. 
En windows cada vez que agregamos un salto de línea, se agregarán dos carácteres especiales para poder marcar esa línea como un salto de línea, en este caso se usarán los carácteres Carriage Return (CR) & Line Feed (LF), pero en caso de LINUX/MAC solo se agregará un carácter, será Line Feed. 
Si el dev de windows desea subir código deberá eliminar el Carriage Return, y si por el contrario quiere descargar código del repositorio, deberá agregar el carácter Carriage Return, para eso deberemos modificar la configuración de GIT y darle a la propiedad Core.Autocrlf un valor de TRUE. 
Los usuarios de LINUX/MAC no están usando ese carácter, entonces al subir ellos el código, git no debería realizar ninguna acción sobre el código, pero si por alguna razón el usuario debido al editor de texto que el está utilizando o porque introdujo el carácter especial Carriage Return GIT debe eliminarla y no dejar subir el carácter, para esto la propiedad core.autocrlf debe tener el valor INPUT.



git -h <!--Te da una ayuda sobre que se puede hacer.-->


con la palabra 'clear' limpiamos la consola de bash.
<!-- FIN CONFIGURACIÓN -->



<!-- COMANDOS BÁSICOS DE BASH -->
cd /c/Users/Agustin
<!-- cambiamos el directorio -->

mkdir miweb
<!-- Creamos un repositorio -->

cd miweb
<!-- Nos paramos sobre el nuevo repositorio -->


pwd     <!--Mostrará donde estamos ubicados: -->
        /c/Users/Agustin/miweb


git init
<!-- Inicializamos el repositorio y se crea la carpeta oculta .git -->

ls 
<!-- No se verá .git -->

ls -a
<!-- Logrará que se vean los repositorios ocultos -->

cd .git
<!-- Nos paramos sobre el nuevo repositorio oculto y al hacerle un ls nos saldrán nuevas opciones que al hacerlo sobre "miweb" -->

ls 
./  ../  HEAD  config  description  hooks/  info/  objects/  refs/
<!-- Estos son TODOS LOS ARCHIVOS que se utilizan en GIT para poder gestionar nuestros proyectos. Aquí es donde se almacenarán las distintas versiones de nuestro código, las distintas ramas, los commits, todo. GIT se encuentra optimizado para ocupar el menor espacio en nuestro disco duro. -->

cd ..
<!-- Retrocedemos a la carpeta anterior seleccionada como cd. -->

code . 
<!-- Abriremos en VSCODE la carpeta en la que estamos parados en el cd. -->

En vscode agregamos un .txt (hola.txt) escribimos "chanchito feliz" al hacer esto -->

git status
<!-- en git bash, esto nos demustra el estado actual de nuestro repositorio, indicando que no hay commits aún, y hay "untracked files" es decir, archivos que git no sigue. Por defecto, GIT no sigue todos los archivos que coloquemos en nuestro proyecto, debemos seleccionarlos mediante "GIT ADD", esto los añadira a la etapa "STAGE" -->


git add .md
<!-- Esto agregará los archivos que tengar terminación 'md' -->

git add .
<!-- esto agregará todos los archivos de la carpeta en la que nos encontremos "hola.txt" en este caso -->


<!-- Ejecutamos un  -->
git add hola.txt 
<!-- y hacemos un  -->
git status
<!-- se nos devolverá un mensaje diferente  -->
On branch master

No commits yet

Changes to be committed:
  (use "git rm --cached <file>..." to unstage)
        new file:   hola.txt

<!-- Se nos indica que hay cambios listos para ser comprometidos, ya en la etapa "Stage" -->


<!-- Agregaremos otro archivo en la carpeta "miweb" en la que se está parada con el cd -->

git status
<!-- Se nos devuelve  -->
On branch master

No commits yet

Changes to be committed:
  (use "git rm --cached <file>..." to unstage)
        new file:   hola.txt

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        archivo2.txt

<!-- Indicando que hay un archivo en la etapa Stage listo para ser comprometido y que hay otro que no esta siendo seguido por GIT. -->


git add archivo2.txt
<!-- Agregamos al archivo 2 a la etapa Stage -->

git status y ya aparece en la fila "Changes to be comitted"


<!-- Se pueden agregar mas de un archivo a la vez separandolos por espacios: -->
git add archivo1.txt archivo2.txt archivo3.txt



<!-- QUE PASA SI MODIFICAMOS UN ARCHIVO EN ETAPA "STAGE"??-->
<!-- Seguirá en esa etapa y se usará la versión anterior no la usada, al ejecutar git status aparecerá una advertencia de esto. -->
<!-- Para sobreescribir el valor agregar con "git add" nuevamente. -->

Lo que estamos agregando no son los archivos, si no los cambios realizados en ellos.

<!-- En este momento ya estamos listos para comprometer el trabajo, es decir, realizar el commit.
Para eso existen dos formas, la primera y la recomendada: git commit -m "Commit Inicial" -->

git commit -m "Primer Commit"
<!-- [master (root-commit) e20c4f3] Primer Commit
 2 files changed, 2 insertions(+)
 create mode 100644 archivo2.txt
 create mode 100644 hola.txt
 -->

git status
<!-- On branch master
nothing to commit, working tree clean -->


<!-- Segunda manera de hacer un commit -->
git commit
<!-- se abrirá un archivo en visual studio code en donde deberemos agregar el nombre del commit, guardar y cerralo, se realizará el commit como podremos comprobar en el bash. -->


<!-- BORRAR ARCHIVOS DE LA CARPETA cd -->
ls
<!-- Veremos los dos archivos: archivo2.txt hola.txt -->

rm archivo2.txt
<!-- lo borramos, con git status comprobamos esto. Sin embargo seguirá en la etapa de "Stage", debemos añadir este cambio para que desaparezca. Lo haremos en el siguiente comando. -->

git add archivo2.txt
<!-- Añadimos los cambios de archivo 2 para que se capitalice la eliminación del mismo. -->

<!-- Ahora realizaremos el commit de las modificaciones recien realizadas (la eliminación del archivo) -->
git commit -m "Eliminacion de archivo2.txt"
<!-- [master 0a1ab39] Eliminacion de archivo2.txt
 1 file changed, 2 deletions(-)
 delete mode 100644 archivo2.txt -->

ls
<!-- Para ver los archivos dentro del repositorio y comprobamos que la eliminación fue correcta al solo aparecer "hola.txt" -->


<!-- Tambien podemos elimiar un archivo del repositorio con -->
git rm archivo2.txt


<!-- Si quisiesemos sacar algun archivo de "Stage" es decir del "git add" podriamos usar el comando: -->
git restore --staged new.txt


<!-- ELIMINAR && RECUPERAR ARCHIVO -->
<!-- Eliminaremos un archivo para recuperarlo: -->
rm new.txt

<!-- Con este comando podemos recuperar un archivo eliminado -->
git restore new.txt


<!-- MOVER ARCHIVOS O CAMBIAR SUS NOMBRES -->
mv archivo2.txt nuevoNombre.txt
<!-- al hacer un git status se nos muestran dos cosas deleted: archivo2.txt y el nuevo untracked file "nuevoNombre.txt" -->
<!-- Para continuar con ambas le hacemos un git add a ambos nombres, al anterior eliminado para que se actualice su delete y le sacamos el untracked al archivo con el nuevo nombre y le damos un "Staged" -->
Al hacer otro git status saldrá:
    deleted:    hola.txt
    renamed:    archivo2.txt -> nuevoNombre.txt

<!-- Haremos un commit con los datos modificados -->
$ git commit -m "Cambio de nombre"
% [master eec9d4c] Cambio de nombre
%  2 files changed, 4 deletions(-)
%  delete mode 100644 hola.txt
%  rename archivo2.txt => nuevoNombre.txt (100%)


git mv new.txt neww.txt
% Cambio de nombre nuevamente

git status
% comprobamos el cambio

git commit -m "CambioDeNombre"
% Realizamos el commit para confirmar los cambios.



% IGNORAR ARCHIVOS PARA QUE NUNCA SEAN INCLUIDOS EN LOS REPOSITORIOS DE GIT
Esto se hace ya que a veces querremos tener archivos de configuración que sean específicos de nuestra PC, como variables de entorno, supongamos que estamos trabajando con UNA DB instalada en local, para que estemos trabajando en un ambiente de desarrollo, en este caso usuarios, contraseña, serán muy diferentes a producción, nosotros queremos ese archivo almacenado en la PC pero que no se suba al repositorio ya que no queremos que otras personas tengan acceso a estos datos, además queremos que esto sea configurable para que al la aplicación desplegarse a producción solo una persona tenga acceso a esas variables de entorno las cuales servirán para configurar la aplicación y que esta se conecte finalmente con la DB de producción. 
Para colocar algunas variables de configuración abriremos VSCODE y crearemos un nuevo archivo  

% Creamos un archivo .env en el repositorio de GIT. 
git status
% On branch master
% Untracked files:
%   (use "git add <file>..." to include in what will be committed)
%         .env

% Para ignorarlo, creamos otro llamado .gitignore, en el escribimos el nombre del archivo a ignorar y simplemente se ignora, con git status lo comprobamos, ya que dejo de salir el mensaje que antes salía al crearse el .env.
$ git status
<!-- On branch master
Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitignore -->

Ahora agregaremos el .gitignore con git add a "Stage" e inmediatamente le haremos el commit.
git add .gitignore
git commit m- "gitignore" 

<!-- Se agregó correctamente -->


<!-- Mejor manera de "GIT STATUS" -->
git status -s
<!-- Devolución: -->
 M .gitignore
?? archivonuevo.txt
<!-- 
M == Modified, esta en color rojo. Si le hacemos un git add a ese archivo, pasará a color verde, ya que ahora estará en "Stage"
?? == Untracked (al menos en este caso) le hacemos un git add y se modificarán los '??' por 'A' en verde. -->



<!-- COMANDOS VISTOS: -->
mkdir miweb <!--Creamos un nuevo repositorio. -->
git init <!--Inicializamos el repositorio creado. -->
git add archivo.txt <!--Agregar a git los cambios realizados en el archivo. -->
rm archivo.txt <!--Eliminar en git los úlitmos cambios realizados. -->
git status <!--Podremos ver el estado de los archivos del repositorio. --> git status -s (para tener la info reducida)
git commit -n "Nombre del commit" <!--Hacemos un commit, para eso debe haber archivos en la etapa "Stage" es decir, se le deben hacer realizado un git add a los archivos a commitear. -->
ls <!--Ver los archivos de la carpeta en cd. -->
ls -a <!--Se nos mostrarán todos los repositorios incluso los ocultos como .git -->
pwd <!--Se nos muestra el cd actual en el git bash. -->
code . <!--Para abrir el repositorio en vscode.-->





<!-- COMO VER LOS CAMBIOS REALIZADOS -->
git diff es un comando útil para ver en el bash los cambios que realizamos recientemente en los archivos. 
git diff --staged mostrará los cambios que queremos commitear. 

<!-- VER EL HISTORIAL DE CAMBIOS DE GIT -->
git log comando que se mostrará el historial de movimientos en el git.. 
git log --oneline para que se vea reducido.



<!-- RAMAS O BRANCH EN GIT -->
git branch 
<!-- este comando nos mostrará la rama en la que estamos parados actualmente, además del resto de ellas-->
git checkout -b ramab
<!-- creamos una nueva rama en caso de no existir, si existe nos moveremos hacia ella.-->

<!--  estando en esta nueva rama modificaremos un archivo, lo añadiremos con git add y lo commitearemos con git commit -m "" -->
cat messi.txt
<!-- muestra el contenido del archivo modificado y commiteado como vemos, esta actualizado, tiene las modificaciones recientes PERO, esta modificación se hizo en la nueva rama, por lo que...-->
git checkout master
<!-- si cambiamos de branch (rama) a "Master" y realizamos el mismo comando:  -->
cat messi.txt
<!-- Se mostrará la version anterior, sin la modificación, ya que se había realizado en el otro branch. Tendremos dos estados != del mismo archivo en != branch´s-->

<!-- Como podemos actualizar sobreescribir ramas con otras? Parados en la rama receptora (la que obtendrá la info de la otra) -->
git merge ramab
<!-- comando y nombre de la rama a copiarle los datos -->
<!-- ahora al hacer-->
cat messi.txt
<!-- se verá el archivo actualizado -->


<!-- Como subimos a github el repo usado en el tutorial? Creamos el repo en github y copiamos y pegamos las dos lineas de código en el bash -->
git remote add origin https://github.com/Agustin-Dahbar/miweb.git
git push -u origin main <!--En mi caso reemplazar main por "master" que es el nombre de mi rama principal-->
<!-- No me salieron las mismas opciones que a el. (La de ingresar usuario y la contraseña). -->
<!--La contraseña debera obtenerse en GitHub: --> Settings --> Developer Settings --> Personal Access Token --> Generate New Token

<!-- AGREGAMOS LA RAMA SECUNDARIO, RAMAB -->
<!-- Debemos cambiar de rama, para recordar los nombres podemos verlas con:  -->
git branch
<!-- Para cambiar de rama:  -->
git checkout ramab
<!-- ya en la rama a enviar a github:  -->
git push -u origin ramab



<!-- FLUJO DE TRABAJO A SEGUIR AL USAR GIT  --> 24:30
Computador: 
        Podremos agregar y modificar todos los archivos que queramos, pero por el simple hecho de modificar, agregar o eliminar archivos en nuestra PC, esto no significa que se vayan a agregar inmediatamente a un repositorio, para esto debemos ejecutar el comando GIT ADD, pero esto lo haremos más adelante. Cuando ejecutemos este comando, seleccionaremos los archivos que deseemos pasar a la etapa "Stage", esto para verificar todos los cambios que queremos.

Stage:
        Al estar en esta etapa, no significa que esta reflejado aún en el repositorio, solo estamos en una etapa intermedia para indicar cuales son los cambios modificados que pasarán al repositorio. Habrá momentos en esta etapa donde no querramos pasar algunos cambios al repositorio, por lo que podremos sacar esos elementos de esta etapa de Stage. Pero supongamos que ya tenemos todos los archivos y cambios que queremos comprometer y pasar al repositorio, en este caso debemos ejecutar el comando GIT COMMIT. Al ejecutarlo, pasaremos los archivos y los dejaremos en la etapa "Commit".

Commit:
        Los cambios que hayamos comprometido podremos pasarlos a un servidor que se encuentra en la nube (el último paso)

Server:
        Ya están los cambios en la nube.


27:19 a 28 NO ENTENDÍ



<!-- RUTA QUE USE DESDE UN CD EN 0 PARA PARARME EN LOS REPOS DE VISUAL STUDIO Y ASI CREAR UN REPO .GIT EN ELLOS PARA SUBIRLOS A GITHUB -->
cd c/users/Agustin/source/repos

git init
<!-- iniciamos el repo .git. ahoran nos aparecerá el nombre de la rama en celeste. -->

git add SesionesRolesPermisos
git add SesionesRolesPermisos.sln
git add packages
<!-- añadimos al repo de git todos los archivos que conformen la solución. -->

git commit -m "Agregamos los archivos al repo de git"
<!-- Hacemos un commit de los cambios recientes para poder enviarlos al repositorio de github mediante los próximos comandos. Al commit le daremos un nombre que se verá reflejado visualmente en el repo de github  -->

git remote add origin https://github.com/Agustin-Dahbar/PermisosRoles.git
<!-- Con esto generamos la conexión entre los repositorios de github y de git -->

git push -u origin master
<!-- pusheamos todos los archivos commiteados de la rama master 
git push: 
        Envía los cambios confirmados localmente al repositorio remoto.

-u: 
        Esto configura la rama local para rastrear la rama remota. Esto significa que en futuros git push o git pull, no necesitarás especificar la rama y la dirección remota, Git ya sabrá a dónde enviar o desde dónde obtener los cambios. Esto es útil si planeas trabajar con esta rama de forma regular.

origin (repo github): 
        Es el nombre asignado al repositorio remoto. Generalmente, cuando clonas un repositorio desde GitHub, el repositorio remoto se llama origin de forma predeterminada.

master (branch pusheado al repo github): 
        Es el nombre de la rama local que estás empujando al repositorio remoto. -->



