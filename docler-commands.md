
# Stop a Docker Container
docker stop <container_name_or_id>

# Remove a Docker Container
docker rm <container_name_or_id>

# Remove a Image Container
docker rmi <image_name_or_id>

# Build & Run

## Build image:
* docker-compose -f docker-compose-prod.yml build

## Run setup:
* docker-compose -f docker-compose-prod.yml up -d

## Verify the Running Containers
* docker ps

# Docker Hub

## Build
* docker-compose -f docker-compose-prod.yml build
* docker tag local-docker-coreapi 779911/dockeraspcoreapi.prod:v1.0.0
* docker tag 779911/dockeraspcoreapi_prod:v1.0.0 779911/dockeraspcoreapi.prod:v1.0.0
* docker push 779911/dockeraspcoreapi.prod:v1.0.0
* dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\Docker.AspCoreApi.pfx -p Test123
* dotnet dev-certs https --trust
* dotnet dev-certs https --clean
* docker-compose -f docker-compose-prod.yml down
* docker-compose -f docker-compose-prod.yml build
* docker-compose -f docker-compose-prod.yml up -d




## Pull
* docker pull your_dockerhub_username/dockeraspcoreapi:latest
* docker tag dockeraspcoreapi:latest your_dockerhub_username/dockeraspcoreapi:v1.0
* docker pull mcr.microsoft.com/mssql/server:2019-latest

## Build the production image:
* docker build -t your_dockerhub_username/sqlserver-app:latest .

## Run the image locally
* docker run -d -p 1433:1433 your_dockerhub_username/sqlserver-app:latest

## Push to Hub
* docker login
* docker push your_dockerhub_username/sqlserver-app:latest




