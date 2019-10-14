using System.Collections.Generic;
using System;
using System.Text;

namespace Shortest_Completing_Word
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      string[] words = { "step", "steps", "stripe", "stepple" };
      Console.WriteLine(program.ShortestCompletingWord("1s3 PSt", words));
      Console.WriteLine("Hello World!");
    }
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
      char[] baseA = new char[26];
      foreach (var item in licensePlate)
      {
        var wk = char.ToLower(item);
        if (wk - 'a' < 0)
          continue;
        baseA[wk - 'a']++;
      }

      string ret = "";
      foreach (var word in words)
      {
        char[] wkA = new char[26];
        foreach (var item in word)
        {
          var wk = char.ToLower(item);
          if (wk - 'a' < 0)
            continue;
          wkA[wk - 'a']++;
        }
        bool IsCheck = true;
        for (int i = 0; i < baseA.Length; i++)
        {
          if (baseA[i] != 0 && wkA[i] < baseA[i])
          {
            IsCheck = false;
            break;
          }
        }
        if (IsCheck && (ret.Length > word.Length || ret.Length == 0))
        {
          ret = word;
        }
      }
      return ret;
    }
    public string ShortestCompletingWordMap(string licensePlate, string[] words)
    {
      Dictionary<char, int> baseDic = new Dictionary<char, int>();
      foreach (var item in licensePlate)
      {
        var wk = char.ToLower(item);
        if (wk - 'a' < 0)
          continue;
        baseDic.TryAdd(wk, 0);
        baseDic[wk]++;
      }

      string ret = "";
      foreach (var word in words)
      {
        Dictionary<char, int> wDic = new Dictionary<char, int>();
        foreach (var item in word)
        {
          var wk = char.ToLower(item);
          wDic.TryAdd(wk, 0);
          wDic[wk]++;
        }
        bool IsCheck = true;
        foreach (var item in baseDic)
        {
          if (!wDic.ContainsKey(item.Key))
          {
            IsCheck = false;
            break;
          }
          if (wDic[item.Key] < item.Value)
            IsCheck = false;
        }
        if (IsCheck && (ret.Length > word.Length || ret.Length == 0))
        {
          ret = word;
        }
      }
      return ret;
    }
  }
}
