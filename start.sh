#!/bin/bash

# Inicia SQL Server en segundo plano
/opt/mssql/bin/sqlservr &

# Espera que SQL arranque
echo "Esperando que SQL Server esté listo..."
sleep 20

# Ejecuta tu app ASP.NET Core
dotnet /app/Examen1.UI.dll
