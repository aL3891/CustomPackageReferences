using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomPackageReferences
{

    public class FilePackageReferenceTask : CustomPackageReferenceTask
    {
        public override IEnumerable<PackageReference> GetPackages(string projectPath, string targetFramework)
        {
            var jsonPath = Path.Combine(projectPath, "project.json");
            if (!File.Exists(jsonPath)) {
                File.WriteAllText(jsonPath, 
@"{
  ""dependencies"": {
  }
}");
            }

            var json = JToken.Parse(File.ReadAllText(jsonPath));
            var deps = json["dependencies"];
            
            return deps.Children().OfType<JProperty>().Select(c => new PackageReference
            {
                Name = c.Name,
                Version = c.First.Type == JTokenType.Object ? c.Value.Value<string>("version") : (string)((JValue)c.Value).Value
            });
        }
    }
}
