using AutoMapper;
using locadora_filmes.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace locadora_filmes.APPLICATION.AutoMapper
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Usuario, UsuarioModel>().ForMember(x => x.Senha, opt => opt.Ignore());
            CreateMap<Filme, FilmeModel>().AfterMap((x,y) => y.Atores = x.Atores.Split(",").ToList())
                                            .AfterMap((x,y) => y.Genero = x.Genero.Split(",").ToList());

            CreateMap<Voto, VotoModel>();

        }
    }
}
