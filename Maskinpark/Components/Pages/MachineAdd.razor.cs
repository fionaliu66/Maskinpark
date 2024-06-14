using Maskinpark.Models;
using Maskinpark.Services;
using Microsoft.AspNetCore.Components;
namespace Maskinpark.Components.Pages
{
    public partial class MachineAdd
    {
        [SupplyParameterFromForm]
        public Machine Machine { get; set; }
        private string Title = "Add New Machine";
        [Inject]
        public MockDataService MockDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected string Message = string.Empty;
        protected bool IsSaved = false;
        protected override void OnInitialized()
        {
            Machine ??= new Machine();
        }

        private async Task HandleValidSubmit()
        {
            await MockDataService.AddMachineAsync(Machine);
            IsSaved = true;
            Message = "Machine has been added";

        }
        private void HandleInvalidSubmit()
        {

            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/machineoverview");
        }
    }
}
