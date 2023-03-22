using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            try
            {
                IPGlobalProperties computerProperties =
                    IPGlobalProperties.GetIPGlobalProperties();
                Console.WriteLine("Имя локального хоста: " + computerProperties.HostName);
                Console.WriteLine("Имя домена: " + computerProperties.DomainName);
                Console.WriteLine("Полное имя хоста: " + Dns.GetHostEntry("").HostName);

                
                    //Получаем все сетевые интерфейсы локального компьютера
                    NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                //Массив указателей
                if (adapters == null || adapters.Length < 1)
                {
                    Console.WriteLine("Сетевые адаптеры не найдены");
                    return;
                }
                Console.WriteLine("Количество сетевых интерфейсов:  {0}\n", adapters.Length);
                //Цикл по иинтерфейсам
                foreach(NetworkInterface adapter in adapters)
                {
                    Console.WriteLine(String.Empty.PadLeft(50, '='));
                    Console.WriteLine("Имя сетевого адаптера: {0}", adapter.Name);
                    Console.WriteLine("Тип сетевого интерфейса: {0}", adapter.NetworkInterfaceType);
                    Console.WriteLine("Описание интерфейса: {0}", adapter.Description);
                    Console.WriteLine("Состояние сетевого подключения: {0}", adapter.OperationalStatus);

                    //Получение и вывод физического адреса
                    PhysicalAddress physicalAddress = adapter.GetPhysicalAddress();
                    byte[] bytes = physicalAddress.GetAddressBytes();
                    Console.Write("Физический адрес: ");

                    for (int i = 0; i < bytes.Length; i++)
                    {

                        Console.Write("{0}", bytes[i].ToString("X2"));
                        if( i != bytes.Length - 1)
                        {
                            Console.Write("-");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Размер физического адреса: {0} байт", bytes.Length);

                    //Получение и вывод IP-адресов
                    //Получаем объект, описывающий конфигурацию сетевого интерфейса 
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();

                    //Получаем unicast-адреса, назначенные текущему интерфейсу
                    UnicastIPAddressInformationCollection unicastCollection =
                        adapterProperties.UnicastAddresses;
                    if(unicastCollection.Count > 0)
                    {
                        foreach (UnicastIPAddressInformation unicastAddr in unicastCollection)
                        { 

                            //Выводим IPv4
                            if(unicastAddr.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                Console.WriteLine("IPv4 адрес: {0}", unicastAddr.Address);
                                Console.WriteLine("Маска: " + unicastAddr.IPv4Mask);
                                Console.WriteLine("Размер IPv4-адреса: {0} байт", 
                                    unicastAddr.Address.GetAddressBytes().Length);
                                Console.WriteLine("Размер сетевого префикса: " + unicastAddr.PrefixLength + " бит");


                            }
                            //Выводим IPv6
                            if (unicastAddr.Address.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                Console.WriteLine("IPv6 адрес: {0}", unicastAddr.Address);
                               
                                Console.WriteLine("Размер IPv6-адреса: {0} байт", 
                                    unicastAddr.Address.GetAddressBytes().Length);
                                Console.WriteLine("Размер сетевого префикса: " + unicastAddr.PrefixLength + " бит");

                                

                            }

                        }
                        
                    }
                    Console.WriteLine();
                }

            }
            catch(Exception ex)
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
