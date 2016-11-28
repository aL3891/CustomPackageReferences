using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomPackageReferences
{

    public class TxtPackageReferenceTask : CustomPackageReferenceTask
    {
        public override IEnumerable<PackageReference> GetPackages(string projectPath, string targetFramework)
        {
            var path = Path.Combine(projectPath, "project.txt");
            if (!File.Exists(path))
            {
                File.WriteAllText(path, @"");
            }

            return File.ReadAllLines(path).Select(l => l.Split(' ')).Select(p => new PackageReference { Name = p[0], Version = p[1] });
        }
    }
}
