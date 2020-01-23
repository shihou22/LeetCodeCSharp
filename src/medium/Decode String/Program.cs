using System;
using System.Text;
using System.Collections.Generic;

namespace Decode_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // Console.WriteLine(program.DecodeString("3[a]2[bc]"));//aaabcbc
            // Console.WriteLine(program.DecodeString("3[a2[c]]"));//accaccacc
            // Console.WriteLine(program.DecodeString("2[abc]3[cd]ef"));//abcabccdcdcdef
            // Console.WriteLine(program.DecodeString("3[a]2[b4[F]c]"));//aaabFFFFcbFFFFc
            Console.WriteLine(program.DecodeString("3[z]2[2[y]pq4[2[jk]e1[f]]]ef"));//zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef

            Console.WriteLine("Hello World!");
        }
         private string _input;

        private string Helper(int start, out int next)
        {
            int cur = start;
            int repeat = 0;
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                if (cur >= _input.Length)
                {
                    next = cur;
                    return sb.ToString();
                }

                char c = _input[cur];
                int num = c - '0';

                if (num >= 0 && num <= 9)
                {
                    repeat *= 10;
                    repeat += num;
                    cur++;
                    continue;
                }

                if (c == '[')
                {
                    string inner = Helper(cur + 1, out cur);
                    for (int i = 0; i < repeat; i++)
                    {
                        sb.Append(inner);
                    }
                    repeat = 0;
                    continue;
                }


                if (c == ']')
                {
                    next = cur + 1;
                    return sb.ToString();
                }

                sb.Append(c);
                cur++;
            }
        }

        public string DecodeString(string s)
        {
            _input = s;
            return Helper(0, out _);
        }
        public string DecodeStringSlow(string s)
        {
            if (s == "")
                return "";
            List<Element> elms = new List<Element>();
            int pre = Parse(s[0]);
            foreach (var item in s)
            {
                int type = Parse(item);
                if (elms.Count == 0)
                {
                    Element elm = new Element(type);
                    elm.Add(item);
                    elms.Add(elm);
                    continue;
                }
                if (type == pre && type != 3 && type != 4)
                {
                    elms[elms.Count - 1].Add(item);
                }
                else
                {
                    pre = type;
                    Element elm = new Element(type);
                    elm.Add(item);
                    elms.Add(elm);
                }
            }
            Stack<Element> queue = new Stack<Element>();
            for (int i = 0; i < elms.Count; i++)
            {
                if (elms[i].type == 4)
                {
                    Element str = queue.Pop();
                    while (queue.Count > 0)
                    {
                        Element tmp = queue.Peek();
                        if (tmp.type != 2)
                            break;
                        tmp = queue.Pop();
                        tmp.Add(str.getStr());
                        str = tmp;
                    }
                    Element bracket = queue.Pop();
                    Element num = queue.Pop();
                    Element nextStr = null;
                    if (queue.Count == 0 || queue.Peek().type != 2)
                        nextStr = new Element(2);
                    else
                        nextStr = queue.Pop();
                    int max = num.getNum();
                    string wk = str.getStr();
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < max; j++)
                    {
                        builder.Append(wk);
                    }
                    nextStr.Add(builder.ToString());
                    queue.Push(nextStr);
                }
                else
                {
                    queue.Push(elms[i]);
                }
            }
            StringBuilder builder1 = new StringBuilder();
            while (queue.Count > 1)
            {
                Element elm = queue.Pop();
                Element elm2 = queue.Pop();
                elm2.Add(elm.getStr());
                queue.Push(elm2);
            }
            return queue.Pop().getStr();
        }
        private int Parse(char c)
        {
            if (c - '0' >= 0 && c - '0' <= 9)
            {
                return 1;
            }
            else if (c - 'a' >= 0 && c - 'a' < 26)
            {
                return 2;
            }
            else if (c - 'A' >= 0 && c - 'A' < 26)
            {
                return 2;
            }
            else if (c == '[')
            {
                return 3;
            }
            else if (c == ']')
            {
                return 4;
            }
            return -1;
        }
    }
    class Element
    {
        public int type { get; set; }
        public List<char> elms { get; set; }
        public Element(int type)
        {
            this.type = type;
        }
        public void Add(char elm)
        {
            if (elms == null)
            {
                elms = new List<char>();
            }
            elms.Add(elm);
        }

        public void Add(string elm)
        {
            if (elms == null)
            {
                elms = new List<char>();
            }
            elms.AddRange(elm.ToCharArray());
        }
        public int getNum()
        {
            if (type != 1)
                return -1;
            StringBuilder builder = new StringBuilder();
            foreach (var item in elms)
            {
                builder.Append(item);
            }
            return int.Parse(builder.ToString());
        }

        public string getStr()
        {
            if (type != 2)
                return "";
            StringBuilder builder = new StringBuilder();
            foreach (var item in elms)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
    }
}
