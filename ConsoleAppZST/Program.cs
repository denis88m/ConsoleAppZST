
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Zstandard.Net;
using ZstdNet;

namespace ConsoleAppZST
{
    class Program
    {
        public const string INPUT = @"C:\ZstFile\partner_feed_en.json.zst";
        public const string OUTPUT = @"C:\ZstFile\TESTARRAY90.json";

        static async Task Main(string[] args)
        {
            string inputPath = INPUT;
            string outputPath = OUTPUT;
            await FilterAndWriteToJsonArrayAsync(inputPath, outputPath, 200);
        }

        private static async Task FilterAndWriteToJsonArrayAsync(string inputPath, string outputPath, int numLines)
        {
            using (var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (var decompressor = new DecompressionStream(inputStream))
            using (var txtReader = new StreamReader(decompressor))
            using (var jsonArray = new StreamWriter(outputPath))
            {
                jsonArray.WriteLine("[");

                for (int i = 0; i < numLines && !txtReader.EndOfStream; i++)
                {
                    string line = txtReader.ReadLine();
                    if (line != null)
                    {
                        if (i > 0)
                        {
                            jsonArray.WriteLine(",");
                        }

                        jsonArray.Write(line);
                    }
                }

                jsonArray.WriteLine();
                jsonArray.WriteLine("]");
            }

            Console.WriteLine("Array JSON completo scritto su: " + outputPath);
        }
    }
}

// CODICE PER ARRAY JSON CHIUDERE IN UNA ARRAY.
/*
 * using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Zstandard.Net;
using ZstdNet;

namespace ConsoleAppZST
{
    class Program
    {
        public const string INPUT = @"C:\ZstFile\partner_feed_en.json.zst";
        public const string OUTPUT = @"C:\ZstFile\TEST808080.json";

        static async Task Main(string[] args)
        {
            string inputPath = INPUT;
            string outputPath = OUTPUT;
            await FilterAndWriteToJsonArrayAsync(inputPath, outputPath, 10);
        }

        private static async Task FilterAndWriteToJsonArrayAsync(string inputPath, string outputPath, int numLines)
        {
            using (var inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (var decompressor = new DecompressionStream(inputStream))
            using (var txtReader = new StreamReader(decompressor))
            using (var jsonArrayWriter = new StreamWriter(outputPath))
            {
                jsonArrayWriter.WriteLine("["); 

                for (int i = 0; i < numLines && !txtReader.EndOfStream; i++)
                {
                    string line = txtReader.ReadLine();
                    if (line != null)
                    {
                        if (i > 0)
                        {
                            jsonArrayWriter.WriteLine(","); 
                        }

                        jsonArrayWriter.Write(line); 
                    }
                }

                jsonArrayWriter.WriteLine(); 
                jsonArrayWriter.WriteLine("]"); 
            }

            Console.WriteLine("Array JSON completo scritto su: " + outputPath);
        }
    }
}
 * 
*/
// CODICE PER CONVERTIRE IN ARRAY ogni RIGA IN FILE JSON
/*
 * namespace ConsoleAppZST
{
    class Program
    {
        public const string INPUT = @"C:\ZstFile\partner_feed_en.json.zst";
        public const string OUTPUT = @"C:\ZstFile\TESTTEST46.json";
        static async Task Main(string[] args)
        {
            string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
            string outputPath = @"C:\ZstFile\TESTTEST2.json";
            
            File.Create(outputPath).Close();
            string[] lines = await ReadFirstNLinesFromZstd(inputPath, 10);

            // Scrivi le righe nel file di output
            File.WriteAllLines(outputPath, lines);
        }


        private static async Task AppendLineToFileAsync(string path, string line)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitepsace.");

            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}
               
            using (var file = File.Open(path, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                await writer.WriteLineAsync(line);
                await writer.FlushAsync();
            }
        }


        public static async Task<string[]> ReadFirstNLinesFromZstd(string zstdPath, int numLines)
        {
            //string line = string.Empty;
            var lines = new List<string>();

            using (var inputStream = new FileStream(zstdPath, FileMode.Open, FileAccess.Read))
            using (var decompressor = new DecompressionStream(inputStream))
            using (var txtReader = new StreamReader(decompressor))
            {
                for (int i = 0; i < numLines && !txtReader.EndOfStream; i++)
                {
                    
                    string line = txtReader.ReadLine();
                    if (line != null)
                    {
                        if (i == numLines - 1)

                        {
                            line = " [ " + line + " ]";

                        }
                        else
                        {
                            
                            line = " [ "  + line + " ,";
                        }
                        //else
                        //{
                        //    line += txtReader.ReadLine() + ",";
                        //}

                        await AppendLineToFileAsync(OUTPUT, line);
                        Console.WriteLine(line);
                        //lines.Add(line);
                    }
                }
            }

            return lines.ToArray();
        }
    }
}
*/
//CODICE PER FILTRARE IL FILE JSON.
/*
 using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {
        string inputPath = @"C:\Users\HP\Desktop\Zst\adressnew.json"; 
        string outputPath = @"C:\Users\HP\Desktop\Zst\FilterNew.json";
        FilterJson(inputPath, outputPath);
    }

    public static void FilterJson(string jsonPath, string outputPath)
    {

        string[] lines = File.ReadAllLines(jsonPath);


        var filteredLines = lines.Where(line =>
        {

            try
            {
                var json = JsonDocument.Parse(line).RootElement;


                if (json.TryGetProperty("region", out var region) &&
                    region.TryGetProperty("country_code", out var country_code) &&
                    country_code.ToString() == "AL")
                {
                    return true;
                }
            }
            catch (System.Text.Json.JsonException)
            {

            }

            return false;
        });


        File.WriteAllLines(outputPath, filteredLines);
    }

}
 * 
 * 
 * 
 * 
 */

// CODICE da rivedere non modificato sviluppato con alfredo .. ERORE FILE NOT FOUND
/*  
 * 
 * using System;
using System.IO;
using System.Collections.Generic;
using ZstdNet;
using System.Linq;
using System.Text.Json;

namespace ConsoleAppZST
{
    class Program
    {
        public const string INPUT = @"C:\ZstFile\partner_feed_en.json.zst";
        public const string OUTPUT = @"C:\ZstFile\TESTTEST2.json";
        static async Task Main(string[] args)
        {
            string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
            string outputPath = @"C:\ZstFile\TESTTEST2.json";

            string[] lines = await ReadFirstNLinesFromZstd(inputPath, 10);

            // Scrivi le righe nel file di output
            File.WriteAllLines(outputPath, lines);
        }


        private static async Task AppendLineToFileAsync(string path, string line)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentOutOfRangeException(nameof(path), path, "Was null or whitepsace.");

            if (!File.Exists(path))
            {
                File.Create(path);
            }
               
            using (var file = File.Open(path, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                await writer.WriteLineAsync(line);
                await writer.FlushAsync();
            }
        }


        public static async Task<string[]> ReadFirstNLinesFromZstd(string zstdPath, int numLines)
        {
            string line = string.Empty;
            var lines = new List<string>();

            using (var inputStream = new FileStream(zstdPath, FileMode.Open, FileAccess.Read))
            using (var decompressor = new DecompressionStream(inputStream))
            using (var txtReader = new StreamReader(decompressor))
            {
                for (int i = 0; i < numLines && !txtReader.EndOfStream; i++)
                {
                    if (i == 0)
                    {
                        line = "[ ";
                    }
                    else if (txtReader.EndOfStream)
                    {
                        line += " ]";
                    }
                    else
                    {
                        line += txtReader.ReadLine() + ",";
                    }

                    await AppendLineToFileAsync(OUTPUT, line);
                    Console.WriteLine(line);
                    //lines.Add(line);
                }
            }

            return lines.ToArray();
        }
    }
}
 */


// CONVERTIRE TUTTO IL FILE array  DA ZST to txt  * iL FILE E PESANTE CI VUOLE TROPPO TEMPO*
/*
 * {
            string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
            string outputPath = @"C:\ZstFile\outputALLArraytest.txt";

            string[] lines = ReadAllNLinesFromZstd(inputPath);

            // Scrivi le righe nel file di output
            File.WriteAllLines(outputPath, lines);
            Console.WriteLine(outputPath);
        }

        public static string[] ReadAllNLinesFromZstd(string zstdPath)
        {
            using (var inputStream = new FileStream(zstdPath, FileMode.Open, FileAccess.Read))
            using (var decompressor = new DecompressionStream(inputStream))
            using (var txtReader = new StreamReader(decompressor))
            {
                var lines = new List<string>();
                while (!txtReader.EndOfStream)
                {
                    string line = txtReader.ReadLine();
                    lines.Add(line);
                }
                return lines.ToArray();
            }
        }
 */

// CONVERTIRE 10 RIGHE/ OGNI RIGA SIA INSERITA IN UN ARRAY.

/*
//{
//            string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
//            string outputPath = @"C:\ZstFile\output10Array.txt";

//            string[] lines = ReadFirstNLinesFromZstd(inputPath, 10);

//            // Scrivi le righe nel file di output
//            File.WriteAllLines(outputPath, lines);
//        }

//        public static string[] ReadFirstNLinesFromZstd(string zstdPath, int numLines)
//        {
//            using (var inputStream = new FileStream(zstdPath, FileMode.Open, FileAccess.Read))
//            using (var decompressor = new DecompressionStream(inputStream))
//            using (var txtReader = new StreamReader(decompressor))
//            {
//                var lines = new List<string>();
//                for (int i = 0; i < numLines && !txtReader.EndOfStream; i++)
//                {
//                    string line = txtReader.ReadLine();
//                    lines.Add(line);
//                }
//                return lines.ToArray();
//            }
//        }
*/

// CONVERTIRE UN FILE ZST TO TXT  . PER 10 RIGHE
/*
{
string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
string outputPath = @"C:\ZstFile\output20Righe.txt";

ConvertZstdToTxt(inputPath, outputPath, 10); //  10 Righe
}

public static void ConvertZstdToTxt(string zstdPath, string txtPath, int numLines)
{
using (var inputStream = new FileStream(zstdPath, FileMode.Open, FileAccess.Read))
using (var decompressor = new DecompressionStream(inputStream))
using (var txtStream = new FileStream(txtPath, FileMode.Create, FileAccess.Write))
using (var txtWriter = new StreamWriter(txtStream))
{
    int linesRead = 0;
    using (var txtReader = new StreamReader(decompressor))
    {
        while (linesRead < numLines && !txtReader.EndOfStream) 
        {
            string line = txtReader.ReadLine();
            txtWriter.WriteLine(line);
            linesRead++;
        }

    }
}
} */


