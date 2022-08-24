FROM mcr.microsoft.com/dotnet/sdk:6.0 AS backend-build
COPY ["GameProject/GameProject.csproj", "GameProject/GameProject.csproj"]
RUN dotnet restore "GameProject/GameProject.csproj"
COPY GameProject GameProject
RUN dotnet publish "GameProject/GameProject.csproj" -c Release -o /app

FROM node:16 AS frontend-build
COPY frontend/package.json frontend/package.json
COPY frontend/package-lock.json frontend/package-lock.json
WORKDIR /frontend
RUN npm install
COPY /frontend .
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=frontend-build /frontend/build wwwroot/
COPY --from=backend-build /app .
ENTRYPOINT dotnet GameProject.dll