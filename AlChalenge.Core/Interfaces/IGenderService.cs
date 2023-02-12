using AtChalenge.Core.Entities;

namespace AtChalenge.Core.Interfaces
{
    public interface IGenderService
    {
        Task<bool> DeleteGender(int id);
        Task<Gender> GetGender(int id);
        Task<IEnumerable<Gender>> GetGenders();
        Task<bool> CreateGender(Gender gender);
        Task<bool> UpdateGender(int id, Gender gender);
    }
}