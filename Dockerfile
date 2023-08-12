FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAPI.csproj", "."]
RUN dotnet restore "./WebAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

FROM build AS migrate
RUN dotnet ef database update --project "WebAPI.csproj"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /wait-for-it.sh /wait-for-it.sh
ENTRYPOINT ["/wait-for-it.sh", "database:5432",  "--", "dotnet", "WebAPI.dll"]
CMD ["dotnet", "WebAPI.dll"]