# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BRQ_B3.Api/BRQ_B3.Api.csproj", "src/BRQ_B3.Api/"]
COPY ["src/BRQ_B3.Business/BRQ_B3.Business.csproj", "src/BRQ_B3.Business/"]
COPY ["src/BRQ_B3.Data/BRQ_B3.Data.csproj", "src/BRQ_B3.Data/"]
RUN dotnet restore "./src/BRQ_B3.Api/BRQ_B3.Api.csproj"
COPY . .
WORKDIR "/src/src/BRQ_B3.Api"
RUN dotnet build "./BRQ_B3.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BRQ_B3.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BRQ_B3.Api.dll"]