using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace NWQ_check
{
    class Program
    {
        static void Main(string[] args)
        {
            string macType = string.Empty;
            long maxSpeed = 1;

            for (; ; )
            {
                //look at each adapter found and list it.
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    var temptype = nic.NetworkInterfaceType.ToString();
                    IPv4InterfaceStatistics stats = nic.GetIPv4Statistics();
                    //ethernet adpter that is connected (diffrent types)
                    if (nic.Speed > maxSpeed && temptype == "Ethernet")
                    {

                        //Deal with Bluetooth Nic that shows as wired
                        if (nic.Name == "Bluetooth Network Connection")
                        {
                            //do noting
                        }

                        else
                        {
                            Console.WriteLine("Wired Network connection Found.");
                            Console.WriteLine("Name:" + nic.Name);
                            Console.WriteLine("Speed: " + nic.Speed);
                            Console.WriteLine("Output queue length: " + stats.OutputQueueLength);
                            Console.WriteLine("Bytes recieved: " + stats.BytesReceived);
                            Console.WriteLine("Bytes sent: " + stats.BytesSent);
                            Console.WriteLine("incoming errors: " + stats.IncomingPacketsWithErrors);
                            Console.WriteLine("Outgoing errors: " + stats.OutgoingPacketsWithErrors);
                            Console.WriteLine("incoming packets discarded: " + stats.IncomingPacketsDiscarded);
                            Console.WriteLine("Outgoing packets discarded " + stats.OutgoingPacketsDiscarded);
                            Console.WriteLine("NonUnicast packets sent: " + stats.NonUnicastPacketsSent);
                            Console.WriteLine("NonUnicast packets Recieved: " + stats.NonUnicastPacketsReceived);
                            Console.WriteLine("Unicast packets sent: " + stats.UnicastPacketsSent);
                            Console.WriteLine("Unicast packets Recieved: " + stats.UnicastPacketsReceived);
                            Console.WriteLine("");

                            using (StreamWriter w = File.AppendText(@"C:\temp\NWQ_Check.log"))
                            {
                                Log("-----------------------------------------------------------------------------------------------------------------", w);
                                Log("Wired Network connection Found.", w);
                                Log("Name:" + nic.Name, w);
                                Log("Speed: " + nic.Speed, w);
                                Log("Output queue length: " + stats.OutputQueueLength, w);
                                Log("Bytes recieved: " + stats.BytesReceived, w);
                                Log("Bytes sent: " + stats.BytesSent, w);
                                Log("incoming errors: " + stats.IncomingPacketsWithErrors, w);
                                Log("Outgoing errors: " + stats.OutgoingPacketsWithErrors, w);
                                Log("incoming packets discarded: " + stats.IncomingPacketsDiscarded, w);
                                Log("Outgoing packets discarded " + stats.OutgoingPacketsDiscarded, w);
                                Log("NonUnicast packets sent: " + stats.NonUnicastPacketsSent, w);
                                Log("NonUnicast packets Recieved: " + stats.NonUnicastPacketsReceived, w);
                                Log("Unicast packets sent: " + stats.UnicastPacketsSent, w);
                                Log("Unicast packets Recieved: " + stats.UnicastPacketsReceived, w);
                                Log("-----------------------------------------------------------------------------------------------------------------", w);
                            }




                        }
                    }

                    if (nic.Speed > maxSpeed && temptype == "GigabitEthernet")
                    {
                        Console.WriteLine("Wired GB connection Found.");
                        Console.WriteLine("Name:" + nic.Name);
                        Console.WriteLine("Speed: " + nic.Speed);
                        Console.WriteLine("Output queue length: " + stats.OutputQueueLength);
                        Console.WriteLine("Bytes recieved: " + stats.BytesReceived);
                        Console.WriteLine("Bytes sent: " + stats.BytesSent);
                        Console.WriteLine("incoming errors: " + stats.IncomingPacketsWithErrors);
                        Console.WriteLine("Outgoing errors: " + stats.OutgoingPacketsWithErrors);
                        Console.WriteLine("incoming packets discarded: " + stats.IncomingPacketsDiscarded);
                        Console.WriteLine("Outgoing packets discarded " + stats.OutgoingPacketsDiscarded);
                        Console.WriteLine("NonUnicast packets sent: " + stats.NonUnicastPacketsSent);
                        Console.WriteLine("NonUnicast packets Recieved: " + stats.NonUnicastPacketsReceived);
                        Console.WriteLine("Unicast packets sent: " + stats.UnicastPacketsSent);
                        Console.WriteLine("Unicast packets Recieved: " + stats.UnicastPacketsReceived);
                        Console.WriteLine("");

                        using (StreamWriter w = File.AppendText(@"C:\temp\NWQ_Check.log"))
                        {
                            Log("-----------------------------------------------------------------------------------------------------------------", w);
                            Log("Wired GB Network connection Found.", w);
                            Log("Name:" + nic.Name, w);
                            Log("Speed: " + nic.Speed, w);
                            Log("Output queue length: " + stats.OutputQueueLength, w);
                            Log("Bytes recieved: " + stats.BytesReceived, w);
                            Log("Bytes sent: " + stats.BytesSent, w);
                            Log("incoming errors: " + stats.IncomingPacketsWithErrors, w);
                            Log("Outgoing errors: " + stats.OutgoingPacketsWithErrors, w);
                            Log("incoming packets discarded: " + stats.IncomingPacketsDiscarded, w);
                            Log("Outgoing packets discarded " + stats.OutgoingPacketsDiscarded, w);
                            Log("NonUnicast packets sent: " + stats.NonUnicastPacketsSent, w);
                            Log("NonUnicast packets Recieved: " + stats.NonUnicastPacketsReceived, w);
                            Log("Unicast packets sent: " + stats.UnicastPacketsSent, w);
                            Log("Unicast packets Recieved: " + stats.UnicastPacketsReceived, w);
                            Log("-----------------------------------------------------------------------------------------------------------------", w);
                        }
                    }
                }
                Thread.Sleep(10000);
            }


          
            //Console.ReadKey();
            }
        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("{0}: {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logMessage);
        }

    }
}
