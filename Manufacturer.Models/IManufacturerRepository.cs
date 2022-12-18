using Dul.Domain.Common;
namespace Manufacturer.Models
{
    public interface IManufacturerRepository
    {
        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        Task<Manufacturer> AddManufacturerAsync(Manufacturer manufacturer);
        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        Task<List<Manufacturer>> GetManufacturersAsync();
        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Manufacturer> GetManufacturerAsync(int id);
        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        Task<Manufacturer> EditManufacturerAsync(Manufacturer manufacturer);
        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteManufacturerAsync(int id);
        /// <summary>
        /// 페이징
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<Manufacturer>> GetAllAsync(int pageIndex, int pageSize);
        /// <summary>
        /// 페이징
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagingResult<Manufacturer>> GetAllByPageAsync(int pageIndex, int pageSize);
    }
}
