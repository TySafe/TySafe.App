FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TySafe.Api.Gateway/TySafe.Api.Gateway.csproj", "TySafe.Api.Gateway/"]
RUN dotnet restore "TySafe.Api.Gateway/TySafe.Api.Gateway.csproj"
COPY . .
WORKDIR "/src/TySafe.Api.Gateway"
RUN dotnet build "TySafe.Api.Gateway.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "TySafe.Api.Gateway.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TySafe.Api.Gateway.dll"]
