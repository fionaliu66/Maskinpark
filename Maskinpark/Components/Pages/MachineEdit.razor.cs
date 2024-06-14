using Maskinpark.Models;
using Maskinpark.Services;
using Microsoft.AspNetCore.Components;

namespace Maskinpark.Components.Pages
{
    public partial class MachineEdit
    {
        [Parameter]
        public int Id {  get; set; }
        [SupplyParameterFromForm]
        public Machine Machine { get; set; }

		[Inject]
        public MockDataService MockDataService {  get; set; }
		[Inject]
		public NavigationManager NavigationManager { get; set; }
		protected bool IsSaved;
		protected string Message = string.Empty;
		protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
			Machine = await MockDataService.GetMachineAsync(Id);
        }

        protected async Task HandleValidSubmit()
		{
		
		}

		protected void HandleInvalidSubmit()
		{
			StatusClass = "alert-danger";
			Message = "There are some validation errors. Please try again.";

		}
		protected void NavigateToOverview()
		{
			NavigationManager.NavigateTo("/employeeoverview");
		}
	}
}
