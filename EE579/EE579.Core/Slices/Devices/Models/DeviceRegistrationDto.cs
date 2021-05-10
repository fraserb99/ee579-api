using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceRegistrationDto
    {

        /// <summary>
        /// The password that the device will send to connect to the Iot Hub MQTT broker
        /// </summary>
        /// <example>HostName=IFTTT-Iot-Hub.azure-devices.net;DeviceId=00:0a:95:9d:68:16;SharedAccessKey=El50EkQ/S/9qp5dd/V3VpsizIvSv+SA8TVF3QiGc93A=</example>
        [Required]
        public string ConnectionString { get; set; }

        /// <summary>
        /// The MQTT host that the device should connect to
        /// </summary>
        /// <example>IFTTT-Iot-Hub.azure-devices.net</example>
        [Required]
        public string Host { get; set; } = "IFTTT-Iot-Hub.azure-devices.net";

        /// <summary>
        /// The port that the device should connect to
        /// </summary>
        /// <example>IFTTT-Iot-Hub.azure-devices.net</example>
        [Required]
        public int Port { get; set; } = 8883;
        /// <summary>
        /// The topic that the device should subscribe to in order to receive cloud-to-device messages
        /// </summary>
        /// <example>devices/{deviceId}/messages/devicebound/#</example>
        [Required]
        public string Topic { get; set; }
    }
}
