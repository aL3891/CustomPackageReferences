using Microsoft.Build.Framework;
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
        public ITaskItem[] PackageReferenceFiles { get; set; }

        public override IEnumerable<PackageReference> GetPackages(string projectPath, string targetFramework)
        {
            return PackageReferenceFiles?.Select(p => new PackageReference { Name = Path.GetFileNameWithoutExtension(p.ItemSpec), Version = File.ReadAllText(p.ItemSpec) });
        }
    }
}
