namespace ManufacturerApp.Models
{
    public interface IManufacturerRepository
    {
        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        Task<Manufacturer> AddManufacturer(Manufacturer manufacturer);
        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        Task<List<Manufacturer>> GetManufacturers();
        /// <summary>
        /// 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Manufacturer> GetManufacturer(int id);
        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        Task<Manufacturer> EditManufacturer(Manufacturer manufacturer);
        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteManufacturer(int id);
    }
}
