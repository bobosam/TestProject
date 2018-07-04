namespace NamesManipulate
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public static class TransliterateCharacters
    {
        private const string CyrLat = "cyrlat";
        private const string BGNPGGN = "bgnpggn";
        private const string Danchev = "danchev";
        private const string BDSISO = "bdsiso";
        private const string Cyrilic = "cyrilic";

       public static string Translterate(string standart, string name)
       {
           var stringBuilder = new StringBuilder();

           for (int i = 0; i < name.Length; i++)
           {
               var currentChar = name[i];

               switch (currentChar)
               {
                   case 'а':
                       if (standart == CyrLat)
                       {
                           stringBuilder.Append("а");
                       }
                       else
                       {
                           stringBuilder.Append("a");
                       }

                       break;

                   case 'б':
                       stringBuilder.Append("b");
                       break;

                   case 'в':
                       stringBuilder.Append("v");
                       break;

                   case 'г':
                       stringBuilder.Append("g");
                       break;

                   case 'д':
                       stringBuilder.Append("d");
                       break;

                   case 'е':
                       if (standart == CyrLat)
                       {
                           stringBuilder.Append("е");
                       }
                       else
                       {
                           stringBuilder.Append("e");
                       }

                       break;

                   case 'ж':
                       if (standart == CyrLat)
                       {
                           stringBuilder.Append("j");
                       }
                       else
                       {
                           stringBuilder.Append("zh");
                       }

                       break;

                   case 'з':
                       stringBuilder.Append("z");
                       break;

                   case 'и':
                       stringBuilder.Append("i");
                       break;

                   case 'й':
                       if (standart == BGNPGGN)
                       {
                           stringBuilder.Append("y");
                       }
                       else if (standart == Danchev)
                       {
                           stringBuilder.Append("i");
                       }
                       else
                       {
                           stringBuilder.Append("j");
                       }

                       break;

                   case 'к':
                       if (standart == CyrLat)
                       {
                           stringBuilder.Append("к");
                       }
                       else
                       {
                           stringBuilder.Append("k");
                       }

                       break;

                   case 'л':
                       stringBuilder.Append("l");
                       break;

                   case 'м':
                       stringBuilder.Append("m");
                       break;

                   case 'н':
                       stringBuilder.Append("n");
                       break;

                   case 'о':
                       if (standart == CyrLat)
                       {
                           stringBuilder.Append("о");
                       }
                       else
                       {
                           stringBuilder.Append("o");
                       }

                       break;

                   case 'п':
                       stringBuilder.Append("p");
                       break;

                   case 'р':
                       stringBuilder.Append("r");
                       break;

                   case 'с':
                       stringBuilder.Append("s");
                       break;

                   case 'т':
                       stringBuilder.Append("t");
                       break;

                   case 'у':
                       if (standart == Danchev)
                       {
                           stringBuilder.Append("ou");
                       }
                       else
                       {
                           stringBuilder.Append("u");
                       }

                       break;

                   case 'ф':
                       stringBuilder.Append("f");
                       break;

                   case 'х':
                       if (standart == BGNPGGN)
                       {
                           stringBuilder.Append("kh");
                       }
                       else if (standart == BDSISO)
                       {
                           stringBuilder.Append("x");
                       }
                       else
                       {
                           stringBuilder.Append("h");
                       }

                       break;

                   case 'ц':
                       if (standart == BGNPGGN || standart == Danchev)
                       {
                           stringBuilder.Append("ts");
                       }
                       else
                       {
                           stringBuilder.Append("c");
                       }

                       break;

                   case 'ч':
                       stringBuilder.Append("ch");
                       break;

                   case 'ш':
                       stringBuilder.Append("sh");
                       break;

                   case 'щ':
                       stringBuilder.Append("sht");
                       break;

                   case 'ъ':
                       if (standart == Danchev || standart == BGNPGGN)
                       {
                           stringBuilder.Append("u");
                       }
                       else if (standart == CyrLat)
                       {
                           stringBuilder.Append("y");
                       }
                       else
                       {
                           stringBuilder.Append("a");
                       }

                       break;

                   case 'ь':
                       if (standart == Danchev || standart == BDSISO)
                       {
                           stringBuilder.Append("y");
                       }
                       else
                       {
                           stringBuilder.Append("j");
                       }

                       break;

                   case 'ю':
                       if (standart == BDSISO || standart == Danchev)
                       {
                           stringBuilder.Append("yu");
                       }
                       else if (standart == CyrLat)
                       {
                           stringBuilder.Append("iu");
                       }
                       else
                       {
                           stringBuilder.Append("ju");
                       }

                       break;

                   case 'я':
                       if (standart == BGNPGGN)
                       {
                           stringBuilder.Append("ia");
                       }
                       else if (standart == BDSISO)
                       {
                           stringBuilder.Append("ya");
                       }
                       else if (standart == Danchev)
                       {
                           stringBuilder.Append("ja");
                       }
                       else
                       {
                           stringBuilder.Append("q");
                       }

                       break;

                   default:
                       break;
               }
           }

           string currentName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(stringBuilder.ToString());

           return currentName;
       }
    }
}
