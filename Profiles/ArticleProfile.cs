using AutoMapper;
using StiftApi.Dtos;

namespace StiftApi.Models
{
  public class RecordProfile : Profile
  {
    public RecordProfile()
    {
      // Source -> Target
      CreateMap<Record, RecordReadDto>();
      CreateMap<RecordCreateDto, Record>();
    }
  }
}