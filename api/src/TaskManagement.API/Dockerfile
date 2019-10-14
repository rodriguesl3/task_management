FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/TaskManagement.API/TaskManagement.API.csproj", "src/TaskManagement.API/"]
RUN dotnet restore "src/TaskManagement.API/TaskManagement.API.csproj"
COPY . .
WORKDIR "/src/src/TaskManagement.API"
RUN dotnet build "TaskManagement.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaskManagement.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaskManagement.API.dll"]
