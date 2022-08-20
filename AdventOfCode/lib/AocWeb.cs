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

    public async Task<string> GetProblemInput(int year, int day)
    {
      var response = await _httpClient.GetAsync($"https://adventofcode.com/{year}/day/{day}/input");
      return await response.Content.ReadAsStringAsync();
    }

    public async Task<Boolean> SubmitResult(int year, int day, string result)
    {

    }
  }
}
