using TesteLandis.Useful.Enumerators;

namespace TesteLandis.Entidades
{
    public class Endpoint
    {
        public string EndpointSerialNumber { get; set; }
        public MeterModelId MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchState SwitchState { get; set; }
    }
}
