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
        public string MqttPassword { get; set; }
    }
}
