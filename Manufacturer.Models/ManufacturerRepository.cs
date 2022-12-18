using Dul.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Manufacturer.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        ManufacturerDbContext _context;
        public ManufacturerRepository(ManufacturerDbContext context)
        {
            _context= context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public async Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer)
        {
            _context.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }
        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        public async Task<List<Manufacturer>> GetManufacturersAsync()
        {
            return await _context.manufacturers.OrderBy(m => m.Id).ToListAsync();
        }
        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Manufacturer> GetManufacturerAsync(int id)
        {
            //return await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            return await _context.manufacturers.FindAsync();
        }
        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Manufacturer> EditManufacturerAsync(Manufacturer manufacturer)
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
        public async Task DeleteManufacturerAsync(int id)
        {
            //var manufacturer = await _context.Manufacturers.Where(m => m.Id == id).SingleOrDefaultAsync();
            var manufacturer = await _context.manufacturers.FindAsync(id);
            if (manufacturer != null)
            {
                _context.manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Manufacturer>> GetAllAsync(int pageIndex, int pageSize = 10)
        {
            return await _context.manufacturers
                .OrderBy(m => m.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// 위에 것 보다 이게 더 좋다함.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagingResult<Manufacturer>> GetAllByPageAsync(int pageIndex, int pageSize)
        {
            var totalRecords = await _context.manufacturers.CountAsync();   // 총 레코드 수
            var manufacturers = await _context.manufacturers
                .OrderBy(m => m.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagingResult<Manufacturer>(manufacturers, totalRecords); // 페이징된 데이터 + 카운트
        }
    }
}
