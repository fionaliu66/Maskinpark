using Maskinpark.Models;
using Maskinpark.Services;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
namespace Maskinpark.Components.Pages
{
    public partial class MachineOverview
    {
		private MockDataService _mockDataService;

		[Inject]
		private MockDataService MockDataService
		{
			get => _mockDataService;
			set => _mockDataService = value;
		}
		public List<Machine> Machines { get; set; }
        private string Title = "Machine Overview";



        protected async override Task OnInitializedAsync()
        {
            Machines = await _mockDataService.GetMachinesAsync();
        }

		private void ChangeStatusState(Machine machine)
		{
			machine.Status = machine.Status == MachineStatus.Online? MachineStatus.Offline : MachineStatus.Online;
			MockDataService.lastModified = machine.MachineName;
		}

	}
}
