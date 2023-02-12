using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;

namespace AtChalenge.Core.Services
{
    public class GenderService :IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<Gender> GetGender(int id)
        {
            return await _genderRepository.GetGender(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await _genderRepository.GetGenders();
        }

        public async Task<bool> CreateGender(Gender gender)
        {

            return await _genderRepository.CreateGender(gender);
        }

        public async Task<bool> UpdateGender(int id, Gender gender)
        {
            return await _genderRepository.UpdateGender(id, gender);
        }
        public async Task<bool> DeleteGender(int id)
        {
            return await _genderRepository.DeleteGender(id);
        }

        #region
        //method private

      
        #endregion
    }
}
