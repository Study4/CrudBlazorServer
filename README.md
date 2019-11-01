# CrudBlazorServer
CRUD Front-End use BlazorServer mode

## 目標

- .NET Core 3.0
- ASP.NET Core Blazor ( BlazorServer mode ) CRUD Sample
    - Docker Support ( Dockerfile )
- Support gPRC , this call [CrudGrpcAspNetCore](https://github.com/Study4/CrudGrpcAspNetCore) , need this project
    - only implement GetAll
- DockerFile support dotnet build and build docker image
- Dcoker-Compose Support
    - Docker-Compose support Web API ( need download Web API docker image , is auto )
    - Dcoker-Compose support SQL Server Linux Container
    - not Support GrpcService

## Issue

- Docker not use SSL

## How use
### dotnet
need LocalDB

dotnet build
dotnet run

go to https://localhost:4001/api/values

### docker 
need install docker 

docker-compose build
docker-compose up

go to https://localhost:4001
