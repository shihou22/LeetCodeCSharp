using System.Diagnostics.Tracing;
using System.Collections.Generic;
using System;

namespace Unique_Morse_Code_Words
{
  class Solution
  {
    static void Main(string[] args)
    {
      Solution solution = new Solution();
      Console.WriteLine(solution.UniqueMorseRepresentations(new string[] { "gin", "zen", "gig", "msg" })); //2
                                                                                                           //   Console.WriteLine(solution.UniqueMorseRepresentations(new string[]{"gin", "zen", "gig", "msg"})); //
      Console.WriteLine("Hello World!");
    }
    public int UniqueMorseRepresentations(string[] words)
    {
      String[] map = new String[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

      HashSet<string> wk = new HashSet<string>();
      foreach (var item in words)
      {
        String res = "";
        foreach (var c in item)
        {
          res += map[c - 'a'];
        }
        wk.Add(res);
      }
      return wk.Count;
    }

    public int UniqueMorseRepresentationsMap(string[] words)
    {
      Dictionary<char, string> map = new Dictionary<char, string>();
      map.Add('a', ".-");
      map.Add('b', "-...");
      map.Add('c', "-.-.");
      map.Add('d', "-..");
      map.Add('e', ".");
      map.Add('f', "..-.");
      map.Add('g', "--.");
      map.Add('h', "....");
      map.Add('i', "..");
      map.Add('j', ".---");
      map.Add('k', "-.-");
      map.Add('l', ".-..");
      map.Add('m', "--");
      map.Add('n', "-.");
      map.Add('o', "---");
      map.Add('p', ".--.");
      map.Add('q', "--.-");
      map.Add('r', ".-.");
      map.Add('s', "...");
      map.Add('t', "-");
      map.Add('u', "..-");
      map.Add('v', "...-");
      map.Add('w', ".--");
      map.Add('x', "-..-");
      map.Add('y', "-.--");
      map.Add('z', "--..");
      HashSet<string> wk = new HashSet<string>();
      foreach (var item in words)
      {
        String res = "";
        foreach (var c in item)
        {
          res += map[c];
        }
        wk.Add(res);
      }
      return wk.Count;
    }
  }
}
