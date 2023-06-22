using System.Net;
using System.Text.Json;
using TrabajandoJson;

        GetProvinciasArgentinas();



        static void GetProvinciasArgentinas()
        {
            var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            valoresMonedas Lista = JsonSerializer.Deserialize<valoresMonedas>(responseBody);
                            System.Console.WriteLine("Todas las monedas y sus respectivos precios");
                            System.Console.WriteLine($"Moneda: {Lista.bpi.EUR.description} - Precio: $ {Lista.bpi.EUR.rate_float}");
                            System.Console.WriteLine($"Moneda: {Lista.bpi.GBP.description} - Precio: $ {Lista.bpi.GBP.rate_float}");
                            System.Console.WriteLine($"Moneda: {Lista.bpi.USD.description} - Precio: $ {Lista.bpi.USD.rate_float}");

                            System.Console.WriteLine("Informacion de USD");
                            System.Console.WriteLine($"moneda: {Lista.bpi.USD.code}");
                            System.Console.WriteLine($"codigo: {Lista.bpi.USD.symbol}");
                            System.Console.WriteLine($"descripcion: {Lista.bpi.USD.description}");
                            System.Console.WriteLine($"precio: {Lista.bpi.USD.rate}");
                            System.Console.WriteLine($"precio2: {Lista.bpi.USD.rate_float}");
                            
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }
        }

