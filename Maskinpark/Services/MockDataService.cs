using Maskinpark.Models;
using System.Diagnostics.Metrics;

namespace Maskinpark.Services
{
    public class MockDataService
    {
        private readonly List<Machine> _machines;
        private readonly Random _random = new Random();
        private int count = 5;

        public MockDataService()
        {
            _machines = new List<Machine>
            {
                new Machine{
                    Id = 1,
                    MachineName = "Machine 1",
                    MachineId = Guid.NewGuid(),
                    Status = MachineStatus.Online,
                    Temperature = GenerateNextDouble(0,100),//0-100
                    Pressure = GenerateNextDouble(0,300),//0-300psi
                    Vibration = GenerateNextDouble(0,10),//0-10g
                },
                 new Machine{
                     Id = 2,
                    MachineName = "Machine 2",
                    MachineId = Guid.NewGuid(),
                    Status = MachineStatus.Offline,
                    Temperature = GenerateNextDouble(0,100),//0-100
                    Pressure = GenerateNextDouble(0,300),//0-300psi
                    Vibration = GenerateNextDouble(0,10),//0-10g
                },
                  new Machine{
                    Id = 3,
                    MachineName = "Machine 3",
                    MachineId = Guid.NewGuid(),
                    Status = MachineStatus.Offline,
                    Temperature = GenerateNextDouble(0,100),//0-100
                    Pressure = GenerateNextDouble(0,300),//0-300psi
                    Vibration = GenerateNextDouble(0,10),//0-10g
                },
                   new Machine{
                    Id = 4,
                    MachineName = "Machine 4",
                    MachineId = Guid.NewGuid(),
                    Status = MachineStatus.Online,
                    Temperature = GenerateNextDouble(0,100),//0-100
                    Pressure = GenerateNextDouble(0,300),//0-300psi
                    Vibration = GenerateNextDouble(0,10),//0-10g
                },
                    new Machine{
                     Id = 5,
                    MachineName = "Machine 5",
                    MachineId = Guid.NewGuid(),
                    Status = MachineStatus.Online,
                    Temperature = GenerateNextDouble(0,100),//0-100
                    Pressure = GenerateNextDouble(0,300),//0-300psi
                    Vibration = GenerateNextDouble(0,10),//0-10g
                },
            };
        }
        public double GenerateNextDouble(double min, double max)
        {
            return min + (max - min) * _random.NextDouble();
        }


        public Task<List<Machine>> GetMachinesAsync()
        {
            return Task.FromResult(_machines);
        }
        public Task<Machine> GetMachineAsync(int id)
        {
            return Task.FromResult(_machines.Single(m => m.Id == id));
        }
        public Task AddMachineAsync(Machine machine)
        {
            machine.Id = count + 1;
            count += 1;
            machine.MachineId = Guid.NewGuid();
            _machines.Add(machine);
            return Task.CompletedTask;
        }
        public Task RemoveMachineAsync(Guid machineId)
        {
            var machine = _machines.FirstOrDefault(m => m.MachineId == machineId);
            if (machine != null)
            {
                _machines.Remove(machine);
            }
            return Task.CompletedTask;
        }
        public Task UpdateMachineAsync(Machine updatedMachine)
        {
            var machine = _machines.FirstOrDefault(m => m.MachineId == updatedMachine.MachineId);
            if (machine != null)
            {
                machine.MachineName = updatedMachine.MachineName;
                machine.Status = updatedMachine.Status;
                machine.Temperature = updatedMachine.Temperature;
                machine.Pressure = updatedMachine.Pressure;
                machine.Vibration = updatedMachine.Vibration;
            }
            return Task.CompletedTask;
        }
    }
}
