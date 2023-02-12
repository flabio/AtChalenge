using AtChalenge.Core.Entities;

namespace AtChalenge.Core.Interfaces
{
    public interface IGenderRepository
    {
        Task<bool> CreateGender(Gender gender);
        Task<bool> DeleteGender(int id);
        Task<Gender> GetGender(int id);
        Task<IEnumerable<Gender>> GetGenders();
        Task<bool> UpdateGender(int id, Gender gender);
    }
}