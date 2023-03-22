using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace Lab3T3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

                Console.WriteLine($"Адрес петли обратной связи IPv4: " + IPAddress.Loopback);
                Console.WriteLine($"Широковещательный IPv4-адрес: " + IPAddress.Broadcast);
                Console.WriteLine($"Адрес, обозначающий все сетевые интерфейсы данного узла IPv4: " + IPAddress.Any);

                Console.WriteLine($"Адрес петли обратной связи IPv6: " + IPAddress.IPv6Loopback);
                Console.WriteLine($"Широковещательный IPv6-адрес: Отсутствует");
                Console.WriteLine($"Адрес, обозначающий все сетевые интерфейсы данного узла IPv6: " + IPAddress.IPv6Any);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
