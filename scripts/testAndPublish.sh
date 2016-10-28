set -ev
dotnet restore
dotnet test ./webapp.unittests
dotnet publish ./webapp -o ./publish


 