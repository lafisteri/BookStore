using AutoMapper;
using BusinessLayer.DTO;
using Core.Models;

namespace BusinessLayer.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Book>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(x => x.Genre, opt => opt.MapFrom(src => src.Genre));
        }

    }
}
