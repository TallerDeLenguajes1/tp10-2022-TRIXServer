using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

System.Console.Clear();
System.Console.WriteLine($"--\tCivilizations");
System.Console.WriteLine("--");

var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";

root civilizations = null;

try
{
    using (WebResponse response = request.GetResponse())
    {
        using (Stream strReader = response.GetResponseStream())
        {
            if (strReader == null) return;

            using (StreamReader objReader = new StreamReader(strReader))
            {
                string contenidoJson = objReader.ReadToEnd();

                civilizations = JsonSerializer.Deserialize<root>(contenidoJson);

                foreach (var item in civilizations.civilization)
                {
                    Console.WriteLine($"Id: {item.Id}\tNombre: {item.Name}");

                }

            }
            
        }

    }

}

catch (System.Exception)
{
    throw;

}

System.Console.WriteLine("--");

if (civilizations != null)
{
    int posicion;
    do
    {
        System.Console.Write($"Elija una civilizacion del 1 al {civilizations.civilization.Count}: ");
        posicion = (Convert.ToInt32(Console.ReadLine())) - 1;
        System.Console.WriteLine("--");

    }
    while (posicion < 0 || posicion > (civilizations.civilization.Count - 1));

    System.Console.WriteLine($"Id:\t\t{civilizations.civilization[posicion].Id}");
    System.Console.WriteLine($"Nombre:\t\t{civilizations.civilization[posicion].Name}");
    System.Console.WriteLine($"Expansion:\t{civilizations.civilization[posicion].Expansion}");
    System.Console.WriteLine($"Ejercito:\t{civilizations.civilization[posicion].ArmyType}");
    System.Console.WriteLine("--");

    foreach (var item in civilizations.civilization[posicion].UniqueUnit)
    {
        System.Console.Write($"{item}");

    }

    System.Console.WriteLine();
    System.Console.WriteLine("--");

    foreach (var item in civilizations.civilization[posicion].UniqueTech)
    {
        System.Console.Write($"{item}");

    }

    System.Console.WriteLine();
    System.Console.WriteLine("--");

    foreach (var item in civilizations.civilization[posicion].TeamBonus)
    {
        System.Console.Write($"{item}");

    }
    
    System.Console.WriteLine();
    System.Console.WriteLine("--");

}


