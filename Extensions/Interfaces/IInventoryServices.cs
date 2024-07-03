using FieldMRIServices.Model;

namespace FieldMRIServices.Extensions.Interfaces
{
    public interface IIventoryServices
    {
        Task<int> AddOrUpdateInventoryAsync(InventoryModel ieeeModel);
        Task<InventoryModel> GetInventoryByIdAsync(int id);
        Task<List<InventoryModel>> GetInventoryAsync();
        Task<int> DeleteInventoryAsync(int id);

        Task<List<PhotoModel>> GetPhotoByInventoryIdAsync(int InventoryId);
        Task<List<PhotoModel>> GetPhotosAsync();
    }
}
