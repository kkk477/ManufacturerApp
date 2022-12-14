using ManufacturerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ManufacturerApp.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        ApplicationDbContext _context;
        public ManufacturerRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
        {
            _context.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }
        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        public async Task<List<Manufacturer>> GetManufacturers()
        {
            return await _context.Manufacturers.OrderBy(m => m.Id).ToListAsync();
        }
        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Manufacturer> GetManufacturer(int id)
        {
            //return await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            return await _context.Manufacturers.FindAsync();
        }
        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Manufacturer> EditManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return manufacturer;
        }
        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteManufacturer(int id)
        {
            //var manufacturer = await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
        }



    }
}
