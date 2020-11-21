FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EmployeeWebApplication/*.csproj ./EmployeeWebApplication/
COPY EmployeeWebApplication.Tests/*.csproj ./EmployeeWebApplication.Tests/
RUN dotnet restore

# copy everything else and build app
COPY EmployeeWebApplication/. ./EmployeeWebApplication/
WORKDIR /app/EmployeeWebApplication
RUN dotnet publish -c Release -o out

# copy everything else and build tests
COPY EmployeeWebApplication.Tests/. ./EmployeeWebApplication.Tests/
WORKDIR /app/EmployeeWebApplication.Tests
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/EmployeeWebApplication/out ./
ENTRYPOINT ["dotnet", "EmployeeWebApplication.dll"]
EXPOSE 80
