using AutoMapper;
using Model.DTO;
using Model.Entity.DB;
using System.Collections.Generic;

namespace Service.Conversao
{
    public class ConversaoEntityDTO : IConversaoEntityDTO
    {
        protected static IMapper _mapper;

        public ConversaoEntityDTO()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                //ENTITY -> DTO
                cfg.CreateMap<Produto, ProdutoDTO>();

                //DTO -> ENTITY
                cfg.CreateMap<ProdutoDTO, Produto>();
            });
            _mapper = mapConfig.CreateMapper();
        }

        public virtual List<U> Converter<T, U>(List<T> lista)
        {
            return _mapper.Map<List<T>, List<U>>(lista);
        }

        public virtual U Converter<T, U>(T entity)
        {
            return _mapper.Map<T, U>(entity);
        }

        public virtual U Converter<T, U>(T origem, U destino)
        {
            return _mapper.Map<T, U>(origem, destino);
        }

    }
}
