FROM mcr.microsoft.com/mssql/server:2022-latest

# Variables de entorno necesarias para SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=TuPasswordSegura

# Crear directorio de la app
RUN mkdir -p /app

# Copiar la app ya publicada localmente
COPY ./publish /app

# Copiar el script de inicio
COPY ./start.sh /start.sh
RUN chmod +x /start.sh

# Exponer los puertos para SQL Server y la app web
EXPOSE 1433 80

# Usar el script para arrancar SQL Server + la app
ENTRYPOINT ["/start.sh"]

