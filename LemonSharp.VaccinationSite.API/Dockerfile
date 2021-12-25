FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY LemonSharp.VaccinationSite.Infrastructure/LemonSharp.VaccinationSite.Infrastructure.csproj LemonSharp.VaccinationSite.Infrastructure/
COPY LemonSharp.VaccinationSite.Domain/LemonSharp.VaccinationSite.Domain.csproj LemonSharp.VaccinationSite.Domain/
COPY LemonSharp.VaccinationSite.Application/LemonSharp.VaccinationSite.Application.csproj LemonSharp.VaccinationSite.Application/
COPY LemonSharp.VaccinationSite.Query/LemonSharp.VaccinationSite.Query.csproj LemonSharp.VaccinationSite.Query/
COPY LemonSharp.VaccinationSite.API/LemonSharp.VaccinationSite.API.csproj LemonSharp.VaccinationSite.API/
RUN dotnet restore LemonSharp.VaccinationSite.API/LemonSharp.VaccinationSite.API.csproj

# copy everything and build
COPY . .

WORKDIR /app/LemonSharp.VaccinationSite.API
RUN dotnet publish -c Release -o out

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build-env /app/LemonSharp.VaccinationSite.API/out .
ENTRYPOINT ["dotnet", "LemonSharp.VaccinationSite.API.dll"]