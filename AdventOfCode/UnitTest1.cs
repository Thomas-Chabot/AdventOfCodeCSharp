using AdventOfCode.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace AdventOfCode
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public async Task TestMethod1()
    {
      var AdventOfCode = new AocWeb();
      var result = await AdventOfCode.GetProblemInput(2015, 1);
      Console.WriteLine(result);
    }
  }
}
