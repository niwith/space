using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Space.Game.Services;

namespace Space.Client.Shared
{
    public partial class LoadingScreen
    {
        [Inject]
        private ISaveService SaveService { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        bool isLoaded;

        string LoadingText { get; set; } = "Welcome commander";
        string WelcomeText { get; set; } = "";

        private Random _rand = new Random();

        private string[] _mandatoryLoadingText = new string[] {
            "Loading core interface...",
            "Loading ship's manifest...",
            "Initialising control systems..."
        };

        private string[] _loadingTextOptions = new string[] {
            "Contemplating the meaning of life...",
            "Clearing the crew browser history..."
        };

        private string _finalLoadingMessage = "Transitioning to manual control...";

        protected override async Task OnInitializedAsync()
        {
            if (await SaveService.CheckPlayerHasSaveAsync())
            {
                WelcomeText = "Welcome back commander";
            }
            await SaveService.SaveAsync(new Game.GlobalGameState { CommanderName = "Commander", HasCompletedIntroduction = false });

            var loadingWork = Task.Delay(6000); // TODO actual initialization job
            for (int i = 0; !loadingWork.IsCompleted; i++)
            {
                if (i < _mandatoryLoadingText.Length)
                {
                    LoadingText = _mandatoryLoadingText[i];
                }
                else
                {
                    LoadingText = _loadingTextOptions[_rand.Next(_loadingTextOptions.Length)];
                }
                StateHasChanged();
                await Task.Delay(2000);
            }
            LoadingText = _finalLoadingMessage;
            await Task.Delay(2000);
            isLoaded = true;
        }
    }
}