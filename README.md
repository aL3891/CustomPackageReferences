# Custom package references

Going back to msbuild for .net core has been a controversial decision, in large part because alot of people are very fond of projet.json. 
Msbuild however is a very flexible platform so its possible to have the project.json cake and eat it too (atleast in part), perhaps with some extras.

Just install the ``JsonPackageReference`` package and add a projet.json file and you're almost up and running. Hopefully this extra step an be eliminated, but right now you have to paste the
following into your project file.

    <Import Project="$(USERPROFILE)\.nuget\packages\JsonPackageReference\0.0.9-beta4\JsonPackageReference.targets" Condition="Exists('$(USERPROFILE)\.nuget\packages\JsonPackageReference\0.0.9-beta4\JsonPackageReference.targets')" />

This line can be found in the ``obj\<project>.csproj.nuget.g.targets``, msbuild currently ignores these targets during restore with is why it has to be manually added to the main project file. This also has to be done when updating versions.

Note also that there is no connection to visual studio, this should work just as well from the commandline and on linux/mac (though this is not tested atm, please file bugs if you find them)

## Whats the catch?

There are still some bumps in the experience. First, dotnet restore has to be run twice initially, once to get the JsonPackageReference package and then once again to restore your package. Visual studio will also not detect changes in the project.json file so after a package is added, you must manually do a dotnet restore in order for the changes to get picked up. Finally, due to what is probably a bug in the vs2017 rc, you may have to reload you project before intellisense starts working on for your new packages

Right now only the following project types are supported 

* Project.json 
* Packages.config
* References as files/items
* Plain text files

Target specific package references are also not supported. 
In the future other ways to define references could be implemented such as

* Xaml
* Yaml

If you have an idea for another way to define packages, please submit an issue!

