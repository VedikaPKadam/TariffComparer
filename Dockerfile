# Use the .NET SDK 6.0 for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Expose ports 80 and 443 for HTTP and HTTPS traffic
EXPOSE 80
EXPOSE 443

# Copy the solution file and project files
COPY Electricity_Tariff_Comparer.sln .
COPY Electricity_Tariff_Comparer/Electricity_Tariff_Comparer.csproj Electricity_Tariff_Comparer/
COPY Electricity_Tariff_Comparer.Test/Electricity_Tariff_Comparer.Test.csproj Electricity_Tariff_Comparer.Test/

# Restore dependencies
RUN dotnet restore

# Copy the full solution over and build it
COPY . .
RUN dotnet build --no-restore

# Run the unit tests in a separate stage
FROM build AS testrunner
WORKDIR /app/Electricity_Tariff_Comparer.Test
CMD ["dotnet", "test", "--logger:trx"]

# Run the unit tests
FROM build AS test
WORKDIR /app/Electricity_Tariff_Comparer.Test
RUN dotnet test --logger:trx

# Publish the API
FROM build AS publish
WORKDIR /app/Electricity_Tariff_Comparer
RUN dotnet publish -c Release -o out --no-restore

# Use the .NET ASP.NET 6.0 runtime for running the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/Electricity_Tariff_Comparer/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Electricity_Tariff_Comparer.dll"]
