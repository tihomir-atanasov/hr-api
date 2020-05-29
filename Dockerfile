# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# copy everything
COPY ./ /src/api/
RUN ls -la /src/api/* 

#restore packages
WORKDIR /src/api
RUN dotnet restore /src/api/Demo.HR.API/Demo.HR.API.csproj

# build and publish api to /api
WORKDIR /src/api
RUN dotnet publish -c release -o /api --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /api
COPY --from=build /api ./

# Normal Entrypoint
ENTRYPOINT ["dotnet", "Demo.HR.API.dll"]

# Heroku Entrypoint
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet Demo.HR.API.dll