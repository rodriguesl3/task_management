FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/TaskManagement.ExternalService/TaskManagement.ExternalService.csproj", "src/TaskManagement.ExternalService/"]
RUN dotnet restore "src/TaskManagement.ExternalService/TaskManagement.ExternalService.csproj"
COPY . .
WORKDIR "/src/src/TaskManagement.ExternalService"
RUN dotnet build "TaskManagement.ExternalService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaskManagement.ExternalService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaskManagement.ExternalService.dll"]
