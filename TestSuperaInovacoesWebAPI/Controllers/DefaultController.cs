using System.Web.Http;

namespace TestSuperaInovacoesWebAPI.Controllers
{
    [RoutePrefix("api/v1")]
    public class DefaultController : ApiController
    {
        [Route("testeGet")]
        [HttpGet]
        public string TesteGet()
        {
            return "teste get";
        }
    }
}