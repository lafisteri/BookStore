FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY Core/*.csproj ./Core/
COPY DataLayer/*.csproj ./DataLayer/
COPY BusinessLayer/*.csproj ./BusinessLayer/
COPY PresentationLayer/*.csproj ./PresentationLayer/

RUN dotnet restore

COPY . .
WORKDIR /src/PresentationLayer
RUN dotnet build "./PresentationLayer.csproj"

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresentationLayer.dll"]
