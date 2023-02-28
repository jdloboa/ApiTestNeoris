#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api_Test/Api_Test.csproj", "Api_Test/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["DTO/DTO.csproj", "DTO/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "Api_Test/Api_Test.csproj"
COPY . .
WORKDIR "/src/Api_Test"
RUN dotnet build "Api_Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api_Test.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api_Test.dll"]