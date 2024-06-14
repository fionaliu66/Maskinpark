using System.ComponentModel.DataAnnotations;

namespace Maskinpark.Models
{
    public class Machine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Name is too long.")]
        public string MachineName { get; set; }
        public Guid MachineId { get; set; }
        public MachineStatus Status { get; set; }
        [Required]
		[Range(0, 100, ErrorMessage = "Temperature must be between 0 and 100.")]
		public double Temperature { get; set; }
        [Required]
		[Range(0, 300, ErrorMessage = "Pressure must be between 0 and 300 psi.")]
		public double Pressure { get; set; }
        [Required]
		[Range(0, 10, ErrorMessage = "Vibration must be between 0 and 10 g.")]
		public double Vibration { get; set; }
    }
    public enum MachineStatus
    {
        Online,
        Offline
    }
}
