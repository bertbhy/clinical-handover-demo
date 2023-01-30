FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080 1433

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["clinical-handover-webapi.csproj", "./"]
RUN dotnet restore "clinical-handover-webapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "clinical-handover-webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "clinical-handover-webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clinical-handover-webapi.dll"]
