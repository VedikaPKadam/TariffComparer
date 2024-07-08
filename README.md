# Electricity Tariff Comparer

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Docker Usage](#docker-usage)

## Overview

Electricity Tariff Comparer is a web application that allows users to compare different electricity tariffs based on their consumption. The application uses a mock service to simulate tariff data and provides a RESTful API for tariff comparison.

## Features

- Compare electricity tariffs based on consumption
- RESTful API for easy integration
- Docker support for containerized deployment
- Unit and integration tests included

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started) (for containerization)
- [Visual Studio or VS Code](https://visualstudio.microsoft.com/) (optional, for development)

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/VedikaPKadam/TariffComparer.git
   cd TariffComparer
2. Restore the .NET dependencies:
dotnet restore

3. Build the solution:
dotnet build

## Usage
1. Run the application:
dotnet run --project ElectricityTariffComparer

## Running Tests
dotnet test

## Docker Usage
1.Building docker image
docker build -t electricity-tariff-comparer:latest .
2.Running docker container
docker run -d -p 80:80 --name electricity-tariff-comparer electricity-tariff-comparer:latest

Once the container is running, you can access the application at 'http://localhost'





