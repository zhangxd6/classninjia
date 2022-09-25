FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
COPY . ./src
WORKDIR /src
RUN dotnet build -o /app  
RUN dotnet publish -o /publish  

FROM mcr.microsoft.com/dotnet/aspnet as base
COPY --from=build  /publish /app
WORKDIR /app
EXPOSE 80

# HEALTHCHECK CMD curl --fail http://localhost || exit 1  
CMD ["./course"]
