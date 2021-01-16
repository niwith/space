using System.Threading.Tasks;

namespace Space.Game.Services
{
    public abstract class BaseSaveService : ISaveService
    {
        protected abstract Task InternalSaveAsync(GlobalGameState gameState);
        protected abstract Task<GlobalGameState> InternalLoadAsync();

        public abstract Task<bool> CheckPlayerHasSaveAsync();

        public async Task SaveAsync(GlobalGameState gameState)
        {
            await InternalSaveAsync(gameState);
        }

        public async Task<GlobalGameState> TryLoadAsync()
        {
            return await InternalLoadAsync();
        }
    }
}