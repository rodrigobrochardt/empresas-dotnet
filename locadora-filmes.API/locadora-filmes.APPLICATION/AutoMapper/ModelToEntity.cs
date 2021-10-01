using AutoMapper;
using locadora_filmes.DOMAIN.Entities;

namespace locadora_filmes.APPLICATION.AutoMapper
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<UsuarioModel, Usuario>();
            CreateMap<FilmeModel, Filme>();
            CreateMap<VotoModel, Voto>();



        }
    }
}
