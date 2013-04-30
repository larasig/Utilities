using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckEntries
{
    class EntryFromFile
    {
        public String FileName
        {
            get;
            set;
        }

        internal EntryFromFile(String fileName)
        {
            FileName = fileName;
        }

        internal IEnumerable<String> Lines
        {
            get
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        String l = sr.ReadLine();
                        if (!String.IsNullOrEmpty(l.Trim()) && !l.StartsWith("#"))
                        {
                            yield return l;
                        }
                    }
                }
            }
        }

        private List<String> _Lines;

        internal List<String> FindMissingEntries(EntryFromFile cmp)
        {
            if (_Lines == null)
            {
                _Lines = new List<string>();
                _Lines.AddRange(Lines);
            }
            List<String> result = new List<String>();
            //result.AddRange(cmp.Lines);

            foreach (var s in cmp.Lines)
            {
                if (!_Lines.Contains(s))
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }
}
