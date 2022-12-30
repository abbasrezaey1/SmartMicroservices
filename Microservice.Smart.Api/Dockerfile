#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5072
EXPOSE 7072

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservice.Smart.Api/Microservice.Smart.Api.csproj", "Microservice.Smart.Api/"]
COPY ["Microservice.Smart.Services.GoogleMapInfo/Microservice.Smart.Services.GoogleMapInfo.csproj", "Microservice.Smart.Services.GoogleMapInfo/"]
RUN dotnet restore "Microservice.Smart.Api/Microservice.Smart.Api.csproj"
COPY . .
WORKDIR "/src/Microservice.Smart.Api"
RUN dotnet build "Microservice.Smart.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Smart.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Smart.Api.dll"]