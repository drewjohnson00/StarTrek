FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 57303
EXPOSE 44345

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY StarTrekApi/StarTrekApi.csproj StarTrekApi/
RUN dotnet restore StarTrekApi/StarTrekApi.csproj
COPY . .
WORKDIR /src/StarTrekApi
RUN dotnet build StarTrekApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StarTrekApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StarTrekApi.dll"]
