using System;
using TesteLandis.Business.Interface;
using TesteLandis.Crud;
using TesteLandis.Crud.Interfaces;
using TesteLandis.Entidades;
using TesteLandis.Useful.Enumerators;

namespace TesteLandis.Business
{
    class EndpointBusiness : IEndpointBusiness
    {
        private readonly IEndpointCrud _endpointCrud;
        public EndpointBusiness()
        {
            _endpointCrud = new EndpointCrud();
        }
        public void Edit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Insert a endpoint serial number:");
                var serialNumber = Console.ReadLine();
                var endpoint = _endpointCrud.Find(serialNumber);
                if (endpoint != null)
                {
                    PrintSwitchStateInstructions();
                    var newState = int.Parse(Console.ReadLine());
                    endpoint.SwitchState = (SwitchState)newState;
                    _endpointCrud.Edit(endpoint);
                }
                else
                {
                    Console.WriteLine("Endpoint not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error performing editing: " + ex.Message);
            }
        }

        public void Find()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Insert a endpoint serial number:");
                var serialNumber = Console.ReadLine();
                var endpoint = _endpointCrud.Find(serialNumber);
                if (endpoint != null)
                    PrintEndpoint(endpoint);
                else
                {
                    Console.WriteLine("Endpoint not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error performing editing: " + ex.Message);
            }
        }

        public void Insert()
        {
            try
            {
                Console.Clear();
                var endpoint = new Endpoint();

                Console.WriteLine("Insert the endpoint serial number:");
                endpoint.EndpointSerialNumber = Console.ReadLine();

                InsertMeterModelId(endpoint);

                Console.WriteLine("Insert the meter number:");
                endpoint.MeterNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Insert the meter firmware version:");
                endpoint.MeterFirmwareVersion = Console.ReadLine();

                InsertSwitchState(endpoint);

                _endpointCrud.Insert(endpoint);
                Console.Clear();
                Console.WriteLine("Insertion performed successfully");
                Console.WriteLine("\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error entering endpoint: " + ex.Message);
            }
        }

        public void List()
        {
            try
            {
                Console.Clear();
                var epList = _endpointCrud.List();
                foreach (var ep in epList)
                {
                    PrintEndpoint(ep);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error listing endpoints: " + ex.Message);
            }
        }

        public void Remove()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Insert a endpoint serial number:");
                var serialNumber = Console.ReadLine();
                var endpoint = _endpointCrud.Find(serialNumber);
                if (endpoint != null)
                {
                    _endpointCrud.Remove(endpoint);
                    Console.Clear();
                    Console.WriteLine("Removal successful");
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Endpoint not found.");
                    Console.WriteLine("\n\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing endpoint: " + ex.Message);
            }
        }

        private void PrintEndpoint(Endpoint endpoint)
        {
            Console.WriteLine("Endpoint serial number: {0}", endpoint.EndpointSerialNumber);
            Console.WriteLine("Meter Model Id: {0}", endpoint.MeterModelId);
            Console.WriteLine("Meter Number: {0}", endpoint.MeterNumber);
            Console.WriteLine("Meter Firmware Version: {0}", endpoint.MeterFirmwareVersion);
            Console.WriteLine("Switch State: {0}", endpoint.SwitchState);
            Console.WriteLine("\n");
        }

        private void PrintSwitchStateInstructions()
        {
            Console.WriteLine("Insert a \"Switch State\" option:");
            Console.WriteLine("(0) - Disconnected");
            Console.WriteLine("(1) - Connected");
            Console.WriteLine("(2) - Armed");
        }

        private void InsertSwitchState(Endpoint endpoint)
        {
            PrintSwitchStateInstructions();
            var switchState = (SwitchState)int.Parse(Console.ReadLine());
            if (switchState == SwitchState.Connected ||
                switchState == SwitchState.Disconnected ||
                switchState == SwitchState.Armed)
            {
                endpoint.SwitchState = switchState;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid option.\n\n");
                InsertSwitchState(endpoint);
            }
        }

        private static void InsertMeterModelId(Endpoint endpoint)
        {
            Console.WriteLine("Insert the meter model id:");
            Console.WriteLine("({0}) - {1}", MeterModelId.NSX1P2W.GetHashCode(), MeterModelId.NSX1P2W);
            Console.WriteLine("({0}) - {1}", MeterModelId.NSX1P3W.GetHashCode(), MeterModelId.NSX1P3W);
            Console.WriteLine("({0}) - {1}", MeterModelId.NSX2P3W.GetHashCode(), MeterModelId.NSX2P3W);
            Console.WriteLine("({0}) - {1}", MeterModelId.NSX3P4W.GetHashCode(), MeterModelId.NSX3P4W);
            var meterModelId = (MeterModelId)int.Parse(Console.ReadLine());
            if (meterModelId == MeterModelId.NSX1P2W ||
                meterModelId == MeterModelId.NSX1P3W ||
                meterModelId == MeterModelId.NSX2P3W ||
                meterModelId == MeterModelId.NSX3P4W)
            {
                endpoint.MeterModelId = meterModelId;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid option.\n\n");
                InsertMeterModelId(endpoint);
            }
        }
    }
}
