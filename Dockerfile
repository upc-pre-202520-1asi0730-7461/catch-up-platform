FROM mcr.microsoft.com/dotnet/sdk:9.0 AS builder
WORKDIR /app
COPY CatchUpPlatform.API/*.csproj CatchUpPlatform.API/
RUN dotnet restore ./CatchUpPlatform.API
COPY . .
RUN dotnet publish ./CatchUpPlatform.API -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=builder /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "CatchUpPlatform.API.dll"]