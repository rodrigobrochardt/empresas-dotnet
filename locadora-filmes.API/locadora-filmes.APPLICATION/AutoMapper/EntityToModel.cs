using AutoMapper;
using locadora_filmes.DOMAIN.Entities;

namespace locadora_filmes.APPLICATION.AutoMapper
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<UsuarioModel, UsuarioModel>();
            CreateMap<Filme, FilmeModel>();
            CreateMap<Administrador, AdministradorModel>();


        }
    }
}
