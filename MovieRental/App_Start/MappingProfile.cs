using AutoMapper;
using MovieRental.Dtos;
using MovieRental.Models;

namespace MovieRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Series, SeriesDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Documentary, DocumentaryDto>();
            Mapper.CreateMap<DocumentaryGenre, DocumentaryGenreDto>();

            //Dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());


            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<SeriesDto, Series>()
                .ForMember(s => s.Id, opt => opt.Ignore());

            Mapper.CreateMap<DocumentaryDto, Documentary>()
                .ForMember(s => s.Id, opt => opt.Ignore());

        }
    }
}