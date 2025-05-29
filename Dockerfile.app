FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

COPY ./Examen1.UI/publish .

ENTRYPOINT ["sh", "-c", "sleep 15 && dotnet Examen1.UI.dll"]


