using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomPackageReferences
{
    [TestClass]
    public class ProjectJsonTaskTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var res = new JsonPackageReferenceTask().GetPackages(@"D:\Documents\GitHubVisualStudio\msbuild-projectAnything\ProjectAnyTests", "");
        }
    }
}
