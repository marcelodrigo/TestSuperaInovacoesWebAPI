using System.Collections.Generic;

namespace Service.Conversao
{
    public interface IConversaoEntityDTO
    {
        List<U> Converter<T, U>(List<T> lista);
        U Converter<T, U>(T entity);
        U Converter<T, U>(T origem, U destino);
    }
}