using System.Linq;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;

namespace Simplify_Path
{
  class Program
  {
    static void Main(string[] args)
    {
      Program program = new Program();
      Console.WriteLine(program.SimplifyPath("/home/"));//"/home"
      Console.WriteLine(program.SimplifyPath("/../"));//"/"
      Console.WriteLine(program.SimplifyPath("/home//foo/"));//"/home/foo"
      Console.WriteLine(program.SimplifyPath("/a/./b/../../c/"));//"/c"
      Console.WriteLine(program.SimplifyPath("/a/../../b/../c//.//"));//"/c"
      Console.WriteLine(program.SimplifyPath("/a//b////c/d//././/.."));//"/a/b/c"
      Console.WriteLine("Hello World!");
    }
    public string SimplifyPath(string path)
    {
      if (path == "" || path[0] != '/')
        return "";
      var wk = path.Split("/");
      Stack<string> memo = new Stack<string>();
      foreach (var item in wk)
      {
        if (item == "")
          continue;
        if (item == "..")
        {
          if (memo.Count > 0)
            memo.Pop();
        }
        else if (item == ".")
        {
          //   memo.Pop();
        }
        else
        {
          memo.Push(item);
        }
      }
      return "/" + string.Join("/", memo.Reverse());
    }
  }
}
