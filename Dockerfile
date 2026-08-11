FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src
COPY BookStore.slnx .

COPY BookStore.API/BookStore.API.csproj BookStore.API/
COPY BookStore.Application/BookStore.Application.csproj BookStore.Application/
COPY BookStore.Domain/BookStore.Domain.csproj BookStore.Domain/
COPY BookStore.Infrastructure/BookStore.Infrastructure.csproj BookStore.Infrastructure/

RUN dotnet restore BookStore.slnx

COPY . .

RUN dotnet build BookStore.API/BookStore.API.csproj -c Release --no-restore

RUN dotnet publish BookStore.API/BookStore.API.csproj -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "BookStore.API.dll"]