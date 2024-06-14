using Microsoft.AspNetCore.Components;
using Maskinpark.Models;
using Maskinpark.Services;

namespace Maskinpark.Components.Pages
{
    public partial class MachineDetail
    {
		private MockDataService _mockDataService;

		[Inject]
		private MockDataService MockDataService
		{
			get => _mockDataService;
			set => _mockDataService = value;
		}
		[Parameter]
        public int Id {  get; set; }
        public Machine Machine { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Machine = await _mockDataService.GetMachineAsync(Id);
		}
	}
}
