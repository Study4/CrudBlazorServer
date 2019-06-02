FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY [".", "CrudBlazor.FrontServerSite/"]
RUN dotnet restore "CrudBlazor.FrontServerSite/CrudBlazor.FrontServerSite.csproj"
COPY . .
WORKDIR "/src/CrudBlazor.FrontServerSite"
RUN dotnet build "CrudBlazor.FrontServerSite.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CrudBlazor.FrontServerSite.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=DevTest
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CrudBlazor.FrontServerSite.dll"]



# FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview5
# ARG source
# ENV ASPNETCORE_ENVIRONMENT=DevTest
# WORKDIR /app
# EXPOSE 80 443
# COPY ${source:-bin/Debug/netcoreapp3.0/publish} .
# ENTRYPOINT ["dotnet", "CrudBlazor.FrontServerSite.dll"]