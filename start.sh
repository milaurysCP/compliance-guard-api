#!/bin/bash
dotnet restore
dotnet build --configuration Release
dotnet run --configuration Release --urls http://0.0.0.0:8080
