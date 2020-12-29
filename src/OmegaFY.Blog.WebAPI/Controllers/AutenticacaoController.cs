using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.WebAPI.Controllers
{

    public class AutenticacaoController : ApiControllerBase<PostagensController>
    {

        public AutenticacaoController(ILogger<PostagensController> logger,
                                      IServiceBus serviceBus,
                                      IMapperServices mapper) : base(logger, serviceBus, mapper)
        {

        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterUsuarioAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> RegistrarAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPatch]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> AlterarSenhaAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> LoginAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("logoff")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> LogoffAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> RefreshTokenAsync(object viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

    }

}
