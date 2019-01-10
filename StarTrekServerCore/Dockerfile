FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 49315
EXPOSE 44328

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY StarTrekServerCore/StarTrekServerCore.csproj StarTrekServerCore/
RUN dotnet restore StarTrekServerCore/StarTrekServerCore.csproj
COPY . .
WORKDIR /src/StarTrekServerCore
RUN dotnet build StarTrekServerCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StarTrekServerCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StarTrekServerCore.dll"]
