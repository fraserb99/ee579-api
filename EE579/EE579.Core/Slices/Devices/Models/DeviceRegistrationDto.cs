using System.ComponentModel.DataAnnotations;

namespace EE579.Core.Slices.Devices.Models
{
    public class DeviceRegistrationDto
    {

        /// <summary>
        /// The password that the device will send to connect to the Iot Hub MQTT broker
        /// </summary>
        /// <example>SharedAccessSignature sr=EE579T-Iot-Hub.azure-devices.net%2Fdevices%2F00%3A0a%3A95%3A9d%3A68%3A16&amp;sig=P5ZwP6DSCBjclOl2IFEb6AkAcczdT7w1Nn8MoGBtZn0%3D&amp;se=36324632293</example>
        [Required]
        public string Password { get; set; }

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
