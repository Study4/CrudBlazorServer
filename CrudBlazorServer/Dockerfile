FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY [".", "CrudBlazorServer/"]
RUN dotnet restore "CrudBlazorServer/CrudBlazorServer.csproj"
COPY . .
WORKDIR "/src/CrudBlazorServer"
RUN dotnet build "CrudBlazorServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CrudBlazorServer.csproj" -c Release -o /app

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=DevTest
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CrudBlazorServer.dll"]