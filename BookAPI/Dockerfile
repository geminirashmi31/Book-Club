FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["BookAPI/BookAPI.csproj", "BookAPI/"]
RUN dotnet restore "BookAPI/BookAPI.csproj"
COPY . .
WORKDIR "/src/BookAPI"
RUN dotnet build "BookAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookAPI.dll"]