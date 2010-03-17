using System;
using System.Collections.Generic;
using System.Text;
using Latino.TextMining;
using System.IO;

namespace LatinoTest
{
    class Program2
    {
        static void Main(string[] args)
        {
            LanguageDetector lang_det = new LanguageDetector();
            lang_det.ReadCorpus(@"C:\Users\Miha\Desktop\LangDetectCorpus");
            //LanguageProfile p = lang_det.FindMatchingLanguage("To je slovenski stavek. Čeprav ga naš detektor ne zazna pravilno. Mogoče šumniki pomagajo...");
            //Console.WriteLine(p.Code);
            //Console.WriteLine(lang_det.GetLanguageProfile("et"));
            StreamWriter w = new StreamWriter("c:\\krneki\\lang_sim.txt");
            foreach (LanguageProfile p in lang_det.LanguageProfiles)
            {
                w.Write("{0}\t", p.Code);
            }
            w.WriteLine();
            foreach (LanguageProfile p in lang_det.LanguageProfiles)
            {
                foreach (LanguageProfile p2 in lang_det.LanguageProfiles)
                {
                    w.Write("{0}\t", Math.Max(p.CalcSpearman(p2), p2.CalcSpearman(p)));
                }
                w.WriteLine();
            }
            w.Close();
        }
    }
}
