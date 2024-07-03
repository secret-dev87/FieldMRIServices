using AutoMapper;
using FieldMRIServices.Entities;
using FieldMRIServices.Extensions.Interfaces;
using FieldMRIServices.Extensions.Services;
using FieldMRIServices.Model;
namespace FieldMRIServices.Data.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            //from databse - user
            CreateMap<Inventory, InventoryModel>();
            CreateMap<Photo, PhotoModel>();

            //from user -database
            CreateMap<InventoryModel, Inventory>();
            CreateMap<PhotoModel, Photo>();

            

        }
    }
}
