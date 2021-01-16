using System.Threading.Tasks;

namespace Space.Game.Services
{
    public interface ISaveService
    {
        Task SaveAsync(GlobalGameState gameState);
        Task<GlobalGameState> TryLoadAsync();
        Task<bool> CheckPlayerHasSaveAsync();
    }
}