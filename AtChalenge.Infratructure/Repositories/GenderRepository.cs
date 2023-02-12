using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AtChalenge.Infrastructure.Repositories
{
    public class GenderRepository :IGenderRepository
    {
        private readonly AtChalengeContext _context;
        public GenderRepository(AtChalengeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            try
            {
                var results = await _context.Genders.Where(x=>x.IsActive==true).ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CreateGender(Gender gender)
        {
            try
            {
                _context.Genders.Add(gender);
                var row = await _context.SaveChangesAsync();
                if (row > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Gender> GetGender(int id)
        {
            try
            {
                var result = await _context.Genders.Where(x => x.IsActive == true).FirstOrDefaultAsync(x=>x.IdGender==id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateGender(int id, Gender gender)
        {
            try
            {
                var currentGender = await GetGender(id);
                if (currentGender != null)
                {
                    currentGender.Name = gender.Name;
                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteGender(int id)
        {
            try
            {
                var currentGender = await GetGender(id);
                if (currentGender != null)
                {
                    currentGender.IsActive = false;
                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
