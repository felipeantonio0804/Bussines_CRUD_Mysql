@echo off
set MySQL_USER="root"
set MySQL_PASS="felipemisterio"
set MySQL_DATABASE="almacen"


:Menu
	cls
	color a
	echo Seleccione una opcion.
	echo 1. EJECUCION SCRIPT MODELO
	echo 2. CONCURRENCIA
	echo 3. SALIR

	set /p opcion=
	if %opcion%==1 goto :modelo
	if %opcion%==2 goto :concurrencia
	if %opcion%==3 goto exit
	if %opcion% GTR 3 echo Error
	goto :Menu

:modelo
	cls 
	color a
	mysql -u%MySQL_USER% -p%MySQL_PASS% <.\Sistema_201122936.sql
	echo TERMINO DE EJECUTAR EL SCRIPT
	Pause>Nul
	goto :Menu

:concurrencia
	cls 
	color a
	
	mysql -u%MySQL_USER% -p%MySQL_PASS% <.\Ejecucion_201122936.sql
	
	echo INDIQUE UN USUARIO DEL 1 AL 4.
	set /p opcion=
	if %opcion%==1 goto :usuario1
	if %opcion%==2 goto :usuario2
	if %opcion%==3 goto :usuario3
	if %opcion%==4 goto :usuario4
	if %opcion% GTR 3 echo Error
	goto :Menu
	
	:usuario1
		mysql -u%MySQL_USER% -p%MySQL_PASS% -D%MySQL_DATABASE% -e"CALL USUARIO1();"
		echo TERMINO EJECUTAR USUARIO 1
		Pause>Nul
		goto :Menu
	:usuario2
		mysql -u%MySQL_USER% -p%MySQL_PASS% -D%MySQL_DATABASE% -e"CALL USUARIO2();"
		echo TERMINO EJECUTAR USUARIO 2
		Pause>Nul
		goto :Menu
	:usuario3
		mysql -u%MySQL_USER% -p%MySQL_PASS% -D%MySQL_DATABASE% -e"CALL USUARIO3();"
		echo TERMINO EJECUTAR USUARIO 3
		Pause>Nul
		goto :Menu
	:usuario4
		mysql -u%MySQL_USER% -p%MySQL_PASS% -D%MySQL_DATABASE% -e"CALL USUARIO4();"
		echo TERMINO EJECUTAR USUARIO 4
		Pause>Nul
		goto :Menu	
	
