#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["service/service.csproj", "service/"]
COPY ["Business_Logic/Business_Logic.csproj", "Business_Logic/"]
COPY ["Doctor/Doctor.csproj", "Doctor/"]
COPY ["Model/Model.csproj", "Model/"]
RUN dotnet restore "service/service.csproj"
COPY . .
WORKDIR "/src/service"
RUN dotnet build "service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service.dll"]