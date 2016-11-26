using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectAny;

namespace ProjectAnyTests
{
    [TestClass]
    public class ProjectJsonTaskTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var res = new ProjectJsonImporter().GetPackages(@"D:\Documents\GitHubVisualStudio\msbuild-projectAnything\ProjectAnyTests", "");
        }
    }
}
