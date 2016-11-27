if(!(Test-Path .\packages)){
md packages
}

.\nuget pack JsonPackageReference\JsonPackageReference.nuspec -outputdirectory packages