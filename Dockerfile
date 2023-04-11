#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Doctor_service/Doctor_service.csproj", "Doctor_service/"]
COPY ["Doctor_Business_Logic/Doctor_Business_Logic.csproj", "Doctor_Business_Logic/"]
COPY ["Doctor_EntityApi/Doctor_fluient_API.csproj", "Doctor_EntityApi/"]
COPY ["Doctor_Model/Doctor_Model.csproj", "Doctor_Model/"]
RUN dotnet restore "Doctor_service/Doctor_service.csproj"
COPY . .
WORKDIR "/src/Doctor_service"
RUN dotnet build "Doctor_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Doctor_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Doctor_service.dll"]