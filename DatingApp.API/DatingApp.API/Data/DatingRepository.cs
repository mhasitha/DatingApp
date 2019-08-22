using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhoto(int id)
        {
            return await _context.Photos.FirstOrDefaultAsync(m => m.UserId == id && m.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await _context.Photos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<User> GetUser(int Id)
        {
            return await _context.Users.Include(m => m.Photos).FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(m => m.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
