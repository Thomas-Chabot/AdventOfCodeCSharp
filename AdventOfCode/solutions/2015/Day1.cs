using AdventOfCode.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
  [TestClass]
  public partial class Solutions
  {
    [TestMethod, TestCategory("2015"), TestCategory("Day1"), TestCategory("Part1")]
    public async Task Y2015_D1_P1()
    {
      var result = await AdventOfCode.SolveProblem(2015, 1, 1, (input) =>
      {
        return Run_2015_D1_P1(input, (floor, index) => false);
      });

      Assert.IsTrue(result);
    }

    [TestMethod, TestCategory("2015"), TestCategory("Day1"), TestCategory("Part1")]
    public async Task Y2015_D1_P2()
    {
      var result = await AdventOfCode.SolveProblem(2015, 1, 2, (input) =>
      {
        var stepNumber = 0;
        Run_2015_D1_P1(input, (floor, stepIndex) =>
        {
          if (floor == -1)
          {
            stepNumber = stepIndex;
            return true;
          }
          return false;
        });
        return stepNumber.ToString();
      });

      Assert.IsTrue(result);
    }

    private string Run_2015_D1_P1(string input, Func<int, int, bool> onEachStep)
    {
      var floor = 0;
      var characters = input.ToCharArray();
      var index = 0;

      while (index < characters.Length)
      {
        var character = characters[index];
        index++;


        if (character == ')')
        {
          floor--;
        }
        else if (character == '(')
        {
          floor++;
        }

        var stepResult = onEachStep(floor, index);
        if (stepResult)
        {
          break;
        }
      }

      return floor.ToString();
    }
  }
}
