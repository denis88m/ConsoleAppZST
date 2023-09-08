
//using System;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using System.Text.Json.Nodes;

//class Program
//{
//    public static void Main(string[] args)
//    {
//        string inputPath = @"C:\ZstFile\TESTTEST57.json";
//        string outputPath = @"C:\ZstFile\FILTER97TEST.json";
//        FilterJson(inputPath, outputPath);
//    }

//    public static void FilterJson(string jsonPath, string outputPath)
//    {
//        try
//        {
//            using (var fileStream = File.OpenRead(jsonPath))
//            using (var jsonDocument = JsonDocument.Parse(fileStream))
//            {
//                var root = jsonDocument.RootElement;

//                if (root.ValueKind == JsonValueKind.Array)
//                {
//                    // Il file contiene un array di oggetti JSON
//                    var filteredArray = new JsonArray();
//                    for (int i = 0; i < root.GetArrayLength(); i++)
//                    {
//                        var element = root[i];
//                        // Verifica 
//                        if (element.TryGetProperty("region", out var region) &&
//                            region.TryGetProperty("country_code", out var country_code) &&
//                            country_code.ToString() == "IT")
//                        {
//                            filteredArray.Add(element);
//                        }
//                    }

//                    // Serializza gli oggetti filtrati in un nuovo documento JSON
//                    using (var outputJsonStream = File.Create(outputPath))
//                    {
//                        var options = new JsonSerializerOptions
//                        {
//                            WriteIndented = true, 
//                        };
//                        JsonSerializer.Serialize(outputJsonStream, filteredArray, options);
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Il file non contiene un array di oggetti JSON.");
//                }
//            }

//            Console.WriteLine("Filtro completato con successo.");
//        }
        
       
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Si è verificato un errore sconosciuto: {ex.Message}");
//        }
//    }
//}


// PROVA CON IL CICLO FOR--- PROVA
/*
//using System;
//using System.IO;
//using System.Text.Json;
//using System.Collections.Generic;

//class Program
//{
//    public static void Main(string[] args)
//    {
//        string inputPath = @"C:\ZstFile\TESTTEST57.json";
//        string outputPath = @"C:\ZstFile\FILTER91TEST.json";
//        FilterJson(inputPath, outputPath);
//    }

//    public static void FilterJson(string jsonPath, string outputPath)
//    {
//        try
//        {
//            using (var fileStream = File.OpenRead(jsonPath))
//            using (var jsonDocument = JsonDocument.Parse(fileStream))
//            {
//                var root = jsonDocument.RootElement;

//                if (root.ValueKind == JsonValueKind.Array)
//                {
//                    // Filtra le righe che contengono "IT" nel loro contenuto
//                    var filteredList = new List<JsonElement>();
//                    for (int i = 0; i < root.GetArrayLength(); i++)
//                    {
//                        var element = root[i];
//                        if (element.ToString().Contains("IT"))
//                        {
//                            filteredList.Add(element);
//                        }
//                    }

//                    // Serializza la lista di oggetti filtrati in un nuovo documento JSON
//                    using (var outputJsonStream = File.Create(outputPath))
//                    {
//                        var options = new JsonSerializerOptions
//                        {
//                            WriteIndented = false, // Opzionale: per formattare il JSON in modo leggibile
//                        };
//                        JsonSerializer.Serialize(outputJsonStream, filteredList, options);
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Il file non contiene un array di oggetti JSON.");
//                }
//            }

//            Console.WriteLine("Filtro completato con successo.");
//        }
//        catch (IOException ex)
//        {
//            Console.WriteLine($"Si è verificato un errore durante la lettura/scrittura del file: {ex.Message}");
//        }
//        catch (UnauthorizedAccessException ex)
//        {
//            Console.WriteLine($"Impossibile accedere al file specificato: {ex.Message}");
//        }
//        catch (JsonException ex)
//        {
//            Console.WriteLine($"Si è verificato un errore durante il parsing JSON: {ex.Message}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Si è verificato un errore sconosciuto: {ex.Message}");
//        }
//    }
//}

*/


// PROVA METODO FILTER ARRAY
/*
 * 
using System;
using System.IO;
using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {
        string inputPath = @"C:\ZstFile\TESTTEST57.json";
        string outputPath = @"C:\ZstFile\FILTER80TEST.json";
        FilterJson(inputPath, outputPath);
    }

    public static void FilterJson(string jsonPath, string outputPath)
    {
        try
        {
            using (var fileStream = File.OpenRead(jsonPath))
            using (var jsonDocument = JsonDocument.Parse(fileStream))
            {
                var root = jsonDocument.RootElement;

                if (root.ValueKind == JsonValueKind.Array)
                {
                    // Filtra le righe che contengono "IT" nel loro contenuto
                    var filteredArray = new JsonArray();
                    foreach (var element in root.EnumerateArray())
                    {
                        if (element.ToString().Contains("IT"))
                        {
                            filteredArray.Objects.Add(element);
                        }
                    }

                    // Serializza gli oggetti filtrati in un nuovo documento JSON
                    using (var outputJsonStream = File.Create(outputPath))
                    {
                        JsonSerializer.Serialize(outputJsonStream, filteredArray.Objects);
                    }
                }
                else
                {
                    Console.WriteLine("Il file non contiene un array di oggetti JSON.");
                }
            }

            Console.WriteLine("Filtro completato con successo.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Si è verificato un errore durante la lettura/scrittura del file: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Impossibile accedere al file specificato: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Si è verificato un errore durante il parsing JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore sconosciuto: {ex.Message}");
        }
    }
}


 */



// FILTRARE IL FILE JSON  FILE.READLINES  ( per filtrare un file json )
/*
//using Newtonsoft.Json;
//using System;
//using System.IO;
//using System.Linq;
//using System.Text.Json;

//class Program
//{
//    public static void Main(string[] args)
//    {
//        string inputPath = @"C:\ZstFile\TESTTEST577.json";
//        string outputPath = @"C:\ZstFile\FILTERTEST74.json";
//        FilterJson(inputPath, outputPath);
//    }

//    public static void FilterJson(string jsonPath, string outputPath)
//    {

//        //string[] lines = File.ReadAllLines(jsonPath);

//        try
//        {
//            var filteredLines = File.ReadLines(jsonPath)
//                .Where(line =>
//                {
//                    try
//                    {
//                        var json = JsonDocument.Parse(line).RootElement;

//                        if (json.TryGetProperty("region", out var region) &&
//                            region.TryGetProperty("country_code", out var country_code) &&
//                            country_code.ToString() == "IT")
//                        {
//                            return true;
//                        }
//                    }
//                    catch (Newtonsoft.Json.JsonException)
//                    {
//                        // Ignora le righe con JSON non valido
//                    }

//                    return false;
//                });

//            File.WriteAllLines(outputPath, filteredLines);
//        }
//        catch (IOException e)
//        {
//            Console.WriteLine("Si è verificato un errore di I/O: " + e.Message);
//        }
//    }
//}
*/
// IL CODICE PER CONVERTIRE ZST TO JSON 10 RIGHE
/*
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using ZstdNet;

class Program
{
    public static void Main(string[] args)
    {
        string inputPath = @"C:\ZstFile\partner_feed_en.json.zst";
        string outputPath = @"C:\ZstFile\TESToutput10Righe.json";

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
}    }
*/