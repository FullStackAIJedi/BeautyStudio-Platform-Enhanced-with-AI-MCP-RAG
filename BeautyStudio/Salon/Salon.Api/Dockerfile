FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Salon/Salon.Api/Salon.Api.csproj", "Salon/Salon.Api/"]
COPY ["Salon/Salon.Application/Salon.Application.csproj", "Salon/Salon.Application/"]
COPY ["Salon/Salon.Infrastructure/Salon.Infrastructure.csproj", "Salon/Salon.Infrastructure/"]
COPY ["Salon/Salon.Domain/Salon.Domain.csproj", "Salon/Salon.Domain/"]
RUN dotnet restore "Salon/Salon.Api/Salon.Api.csproj"
COPY . .
WORKDIR "/src/Salon/Salon.Api"
RUN dotnet build "Salon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Salon.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Salon.Api.dll"]