if(!(Test-Path .\packages)){
md packages
}

.\nuget pack ConfigPackageReference\ConfigPackageReference.nuspec -outputdirectory packages
.\nuget pack FilePackageReference\FilePackageReference.nuspec -outputdirectory packages
.\nuget pack JsonPackageReference\JsonPackageReference.nuspec -outputdirectory packages
.\nuget pack TxtPackageReference\TxtPackageReference.nuspec -outputdirectory packages
.\nuget pack XamlPackageReference\XamlPackageReference.nuspec -outputdirectory packages