using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace CustomPackageReferences
{

    public class ConfigPackageReferenceTask : CustomPackageReferenceTask
    {
        public override IEnumerable<PackageReference> GetPackages(string projectPath, string targetFramework)
        {
            var path = Path.Combine(projectPath, "packages.config");
            if (!File.Exists(path))
            {
                File.WriteAllText(path,
@"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
</packages>
");
            }

            var xml = XElement.Load(path);
            return xml.Elements("package").Select(x => new PackageReference { Name = x.Attribute("id").Value, Version = x.Attribute("version").Value });
        }
    }
}
