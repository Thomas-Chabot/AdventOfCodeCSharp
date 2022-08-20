using AdventOfCode.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
  public partial class Solutions
  {
    static AocWeb AdventOfCode;

    [TestInitialize]
    public void SetupTest()
    {
      AdventOfCode = new AocWeb();
    }
  }
}
