FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG GHPAT
ARG VERSION
WORKDIR /src
COPY ["Texnokaktus.ProgOlymp.UserService/Texnokaktus.ProgOlymp.UserService.csproj", "Texnokaktus.ProgOlymp.UserService/"]
COPY ["Texnokaktus.ProgOlymp.UserService.DataAccess/Texnokaktus.ProgOlymp.UserService.DataAccess.csproj", "Texnokaktus.ProgOlymp.UserService.DataAccess/"]
COPY ["Texnokaktus.ProgOlymp.UserService.Logic/Texnokaktus.ProgOlymp.UserService.Logic.csproj", "Texnokaktus.ProgOlymp.UserService.Logic/"]
COPY ["Texnokaktus.ProgOlymp.UserService.Domain/Texnokaktus.ProgOlymp.UserService.Domain.csproj", "Texnokaktus.ProgOlymp.UserService.Domain/"]
COPY ["Texnokaktus.ProgOlymp.UserService.Infrastructure/Texnokaktus.ProgOlymp.UserService.Infrastructure.csproj", "Texnokaktus.ProgOlymp.UserService.Infrastructure/"]
COPY ["modules/Common.Contracts/Texnokaktus.ProgOlymp.Common.Contracts/Texnokaktus.ProgOlymp.Common.Contracts.csproj", "modules/Common.Contracts/Texnokaktus.ProgOlymp.Common.Contracts/"]
RUN dotnet nuget add source --username kav128 --password $GHPAT --store-password-in-clear-text --name "GitHub Texnokaktus-Progolymp" https://nuget.pkg.github.com/Texnokaktus-ProgOlymp/index.json
RUN dotnet restore "Texnokaktus.ProgOlymp.UserService/Texnokaktus.ProgOlymp.UserService.csproj"
COPY . .
WORKDIR "/src/Texnokaktus.ProgOlymp.UserService"
RUN dotnet build "Texnokaktus.ProgOlymp.UserService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Texnokaktus.ProgOlymp.UserService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false /p:Version=$VERSION

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Texnokaktus.ProgOlymp.UserService.dll"]
