using System.Threading.Tasks;
using Blazored.LocalStorage;
using Space.Game;
using Space.Game.Services;

namespace Space.Client.Services
{
    public class BlazorLocalStorageSaveService : BaseSaveService, ISaveService
    {
        private const string SaveGameLocalStorageKey = "spaceSaveGame";
        private readonly ILocalStorageService _localStorage;

        public BlazorLocalStorageSaveService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task InternalSaveAsync(GlobalGameState gameState)
        {
            await _localStorage.SetItemAsync(SaveGameLocalStorageKey, gameState);
        }

        protected override async Task<GlobalGameState?> InternalLoadAsync()
        {
            if (!await _localStorage.ContainKeyAsync(SaveGameLocalStorageKey))
            {
                return null;
            }
            return await _localStorage.GetItemAsync<GlobalGameState>(SaveGameLocalStorageKey);
        }

        public override async Task<bool> CheckPlayerHasSaveAsync()
        {
            return await _localStorage.ContainKeyAsync(SaveGameLocalStorageKey);
        }
    }
}