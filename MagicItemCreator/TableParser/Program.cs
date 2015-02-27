using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TableParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine("Usage: TableParser table.txt");
                return;
            }

            ParseTable(args[0]);

            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static void ParseTable(string p)
        {
            using (FileStream fs = File.OpenRead(p))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    String line;
                    Regex rex = new Regex(@"(?:[^(<tbody>)])*(?:[^(<tr>)])* *<tr><td(?: class="")?>(?<minormini>[0-9]+)?(?:-(?<minormaxi>[0-9]+)?)?</td><td(?: class="")?>(?<mediummini>[0-9]+)?(?:-(?<mediummaxi>[0-9]+)?)?</td><td(?: class="")?>(?<majormini>[0-9]+)?(?:-(?<majormaxi>[0-9]+)?)?</td>(?:<td>(?:<(?<tag>[^td >])*[^>]*>)*(?<X>(?:(?!</\k<tag>>)(?!</td>).)*)(?:</\k<tag>>)* *</td>)*</tr>");
                    //La ligne relou : <tr><td>-</td><td>-</td><td>89-90</td><td><i><a href="#vorpal">Vorpal</a></i><sup>2</sup> </td><td>+5 bonus</td></tr>
                    //Le probleme : Ca ne matche pas [Vorpal] mais [Vorpal</a></i><sup>2</sup> ]
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        Console.WriteLine("Matching line :");
                        Console.WriteLine(line);
                        Console.WriteLine();
                        Match m = rex.Match(line);
                        if (m.Success)
                        {
                            Console.WriteLine("Line matched !");
                            Console.WriteLine("Minor: " + m.Groups["minormini"].Value + " - " + m.Groups["minormaxi"].Value);
                            Console.WriteLine("Medium: " + m.Groups["mediummini"].Value + " - " + m.Groups["mediummaxi"].Value);
                            Console.WriteLine("Major: " + m.Groups["majormini"].Value + " - " + m.Groups["majormaxi"].Value);

                            if (m.Groups["X"].Success)
                            {
                                foreach (Capture c in m.Groups["X"].Captures)
                                {
                                    Console.WriteLine("X : [" + c.Value + "]");
                                }
                            }

                            Console.WriteLine("All captures:");

                            for (int ctr = 1; ctr <= m.Groups.Count - 1; ctr++)
                            {
                                if (m.Groups[ctr].Success)
                                    Console.WriteLine("Group {0}: {1}",
                                                      ctr, m.Groups[ctr].Value);
                                else
                                    Console.WriteLine("Group {0}: <no match>", ctr);
                            }
            
                        }
                    }
                }
            }
        }
    }
}
