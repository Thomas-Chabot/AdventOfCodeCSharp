using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.lib
{
  /// <summary>
  /// This class provides the abstractions for Advent of Code: Gathering problem input, submitting solutions, etc.
  /// </summary>
  public class AocWeb
  {
    private readonly HttpClient _httpClient;

    public AocWeb()
    {
      var session = Environment.GetEnvironmentVariable("AOC_SESSION");

      // HttpClient should pass in the session cookie.
      var baseAddress = new Uri("https://adventofcode.com");
      var cookieContainer = new CookieContainer();
      cookieContainer.Add(baseAddress, new Cookie("session", session));

      var httpClientHandler = new HttpClientHandler() { CookieContainer = cookieContainer };
      _httpClient = new HttpClient(httpClientHandler) { BaseAddress = baseAddress };
    }

    /// <summary>
    /// Retrieves the input for a problem given the day & year.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public async Task<string> GetProblemInput(int year, int day)
    {
      var response = await _httpClient.GetAsync($"https://adventofcode.com/{year}/day/{day}/input");
      return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Submits the solution to a problem, given the year, day, part, and answer to submit.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <param name="part"></param>
    /// <param name="solution"></param>
    /// <returns></returns>
    public async Task<bool> SubmitSolution(int year, int day, int part, string solution)
    {
      var content = new Dictionary<string, string>()
      {
        { "level", part.ToString() },
        { "answer", solution }
      };

      var response = await _httpClient.PostAsync($"https://adventofcode.com/{year}/day/{day}/answer", new FormUrlEncodedContent(content));
      var data = await response.Content.ReadAsStringAsync();

      var successSpanIndex = data.IndexOf("<span class=\"day-success\">");
      return successSpanIndex != -1;
    }

    /// <summary>
    /// Helper method for submitting the solution for a given day/year/part.
    /// Returns a boolean indicating if the answer was correct.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="day"></param>
    /// <param name="part"></param>
    /// <param name="solver"></param>
    /// <returns></returns>
    public async Task<bool> SolveProblem(int year, int day, int part, Func<string, string> solver)
    {
      var input = await GetProblemInput(year, day);
      var solution = solver(input);
      return await SubmitSolution(year, day, part, solution);
    }
  }
}
