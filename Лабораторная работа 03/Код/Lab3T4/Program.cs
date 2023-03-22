using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Lab3T4
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            try
            {
                string dnsName;
                Console.Write("Введите доменное имя: ");
                dnsName = Console.ReadLine().Trim(new char[] { ' ', '\n' });

                IPAddress[] ipAddr = Dns.GetHostByName(dnsName).AddressList;

                foreach (IPAddress ip in ipAddr)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine($"\tIPv4 адрес: {ip}");
                    }

                    if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        Console.WriteLine($"\tIPv6 адрес: {ip}");
                    }
                }
                Console.WriteLine();

                 string[] aliases = Dns.GetHostByName(dnsName).Aliases;
                 Console.WriteLine($"Имя хоста: {Dns.GetHostByName(dnsName).HostName} \n");
                if (aliases.Length != 0)
                {
                    Console.WriteLine("Aliases: ");
                    foreach (string alias in aliases) { Console.WriteLine(alias); }
                }
                else
                    Console.WriteLine("Имен-псевдонимов нет!");
                //if (args is null)
                //{
                //    throw new ArgumentNullException(nameof(args));
                //}

                //try
                //{
                //    Console.Write("Введите имя хоста: ");
                //    string hostName = Console.ReadLine();

                //    IPHostEntry iPHostEntry = Dns.GetHostByName(hostName);

                //    Console.WriteLine(iPHostEntry.HostName);
                //    IPAddress[] ipAddr = iPHostEntry.AddressList;
                //    foreach (IPAddress ip in ipAddr)
                //    {
                //        Console.WriteLine("Адрес: " + ip);
                //    }
                //    string[] aliesNames = iPHostEntry.Aliases;
                //    foreach (string aliesName in aliesNames)
                //    {
                //        Console.WriteLine("Имя: " + aliesName);
                //    }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка" + ex.ToString());

            }
            finally
            {
                Console.ReadLine();
            }


        }
    }
}
