FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildenv
WORKDIR /app
COPY . .
RUN dotnet restore ./Presentation/Presentation.csproj
RUN dotnet publish ./Presentation/Presentation.csproj --configuration Release --output Release

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=buildenv /app/Release .
EXPOSE 8080
EXPOSE 443
ENTRYPOINT ["dotnet","Presentation.dll"]