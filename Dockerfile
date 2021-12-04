FROM mcr.microsoft.com/dotnet/sdk:6.0 as builder
WORKDIR /app/

COPY **/HelpYourCity.API.csproj /app/HelpYourCity.API/
COPY **/HelpYourCity.Core.csproj /app/HelpYourCity.Core/
COPY **/HelpYourCity.Persistence.csproj /app/HelpYourCity.Persistence/
COPY *.sln /app/

RUN dotnet restore

COPY ./ /app

RUN dotnet publish --output "/app/bin" -c release 

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app/bin

COPY --from=builder /app/bin /app/bin

CMD ["dotnet", "HelpYourCity.API.dll"]
