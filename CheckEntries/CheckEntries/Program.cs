using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CheckEntries
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryFromFile entry1 = new EntryFromFile(@"E:\ext\all_malwareindication.txt");
            EntryFromFile entry2 = new EntryFromFile(@"E:\ext\malware_type_ngrams.txt");
            foreach (var e in entry1.FindMissingEntries(entry2))
            {
                Trace.WriteLine(e);
            }
        }

        
    }
}
