# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
# Expose port 80 for the container
EXPOSE 80
# Ensure ASP.NET Core binds to port 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
