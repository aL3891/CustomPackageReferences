if(!(Test-Path .\packages)){
md packages
}

cd ConfigPackageReference
dotnet restore
dotnet build
..\nuget pack ConfigPackageReference.nuspec -outputdirectory ..\packages


cd ..\FilePackageReference
dotnet restore
dotnet build
..\nuget pack FilePackageReference.nuspec -outputdirectory ..\packages

cd ..\JsonPackageReference
dotnet restore
dotnet build
..\nuget pack JsonPackageReference.nuspec -outputdirectory ..\packages

cd ..\TxtPackageReference
dotnet restore
dotnet build
..\nuget pack TxtPackageReference.nuspec -outputdirectory ..\packages

cd..