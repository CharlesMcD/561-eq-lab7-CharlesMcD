set -ev
dotnet restore
cd webapp.unittests
dotnet test
dotnet publish -o /publish
