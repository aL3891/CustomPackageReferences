using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Linq;

namespace ProjectAny
{
    public abstract class ProjectAnyTask : Task
    {

        public string TargetFramework { get; set; }
        public string ProjectPath { get; set; }


        [Output]
        public ITaskItem[] PackageReferences { get; set; }

        public override bool Execute()
        {
            List<TaskItem> res = new List<TaskItem>();
            foreach (var pr in GetPackages(ProjectPath, TargetFramework))
            {
                var t = new TaskItem(pr.Name);
                t.SetMetadata("Version", pr.Version);
                res.Add(t);
            }

            PackageReferences = res.Cast<ITaskItem>().ToArray();
            return true;
        }

        public abstract IEnumerable<PackageReference> GetPackages(string projectPath, string targetFramework);
    }
}
