#!/bin/sh

./clean.sh

dotnet clean src/Wizards.sln

dotnet restore src/Wizards.sln

dotnet build src/Wizards.sln \
    --no-restore \
    --configuration Release

dotnet test src/Wizards.sln \
    --no-restore \
    --no-build \
    --verbosity normal

dotnet publish src/Wizards.SolutionGenerator.Executable/Wizards.SolutionGenerator.Executable.csproj \
    --no-restore \
    --no-build \
    --configuration Release \
    --output dist/dotnet-solution-generator
