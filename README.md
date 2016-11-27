# Custom package references

Going back to msbuild for .net core has been a controversial decision, in large part because alot of people are very fond of projet.json. 
Msbuild however is a very flexible platform so its possible to have the project.json cake and eat it too (atleast in part), perhaps with some extras.

Just install the JsonPackageReference package and add a projet.json file and you're almost up and running. Hopefully this extra step an be eliminated, but right now you have to paste the
following into your project file.

    <Import Project="$(NuGetPackageRoot)jsonpackagereference\1.0.0\build\JsonPackageReference.targets" Condition="Exists('$(NuGetPackageRoot)jsonpackagereference\1.0.0\build\JsonPackageReference.targets')" />

This line can be found in the obj\<project>.csproj.nuget.g.targets, msbuild currently ignores these targets during restore

Right now only project.json is supported and target specific package references are not supported but in the future other ways to define references could be implemented such as

packages.config
packages.xaml
references as files/items
yaml
plain text files



If you have an idea for another way to define packages, please submit an issue!