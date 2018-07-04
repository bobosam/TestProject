namespace NamesManipulate
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TransliterateNames
    {
        private const string CyrLat = "cyrlat";
        private const string BGNPGGN = "bgnpggn";
        private const string Danchev = "danchev";
        private const string BDSISO = "bdsiso";
        private const string Cyrilic = "cyrilic";

        private static List<string> startFile = new List<string>();
        private static List<string> cyrilicNames = new List<string>();
        private static List<string> latinNames = new List<string>();

        public static void Main()
        {
            GetData();
            TransliterateNamesByStandart(Cyrilic);
            TransliterateNamesByStandart(CyrLat);
            TransliterateNamesByStandart(BGNPGGN);
            TransliterateNamesByStandart(Danchev);
            TransliterateNamesByStandart(BDSISO);

            File.WriteAllText("../../LogFile.txt", string.Empty);
            int countOfNames = 0;
            int countOfErrors = 0;

            for (int i = 0; i < latinNames.Count; i++)
            {
                string currentName = Transliterate(latinNames[i]);
                countOfNames++;

                if (currentName != cyrilicNames[i])
                {
                    string errorLog = string.Format("Index --> {0}      latin --> {1}       cyrilic --> {2}         current --> {3}", i, latinNames[i], cyrilicNames[i], currentName);
                    File.AppendAllText("../../LogFile.txt", errorLog + Environment.NewLine);
                    countOfErrors++;
                }
            }

            string errorsCount = string.Format("Names --> {0}  Errors --> {1}", countOfNames, countOfErrors);
            File.AppendAllText("../../LogFile.txt", errorsCount + Environment.NewLine);
        }

        private static string Transliterate(string p)
        {
            return "testReturn";
        }

        private static void TransliterateNamesByStandart(string standart)
        {
            foreach (var name in startFile)
            {
                if (standart == Cyrilic)
                {
                    latinNames.Add(name);
                    cyrilicNames.Add(name);

                    continue;
                }

                var currentName = TransliterateCharacters.Translterate(standart, name);

                cyrilicNames.Add(name);
                latinNames.Add(currentName);
            }
        }

        private static void GetData()
        {
            startFile.Clear();

            const int BufferSize = 4096;
            using (var fileStream = File.OpenRead("../../UniqueNamesPeshtera.txt"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line = streamReader.ReadLine();
                string[] rowNames = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var name in rowNames)
                {
                    startFile.Add(name.ToLower());
                }
            }
        }
    }
}
