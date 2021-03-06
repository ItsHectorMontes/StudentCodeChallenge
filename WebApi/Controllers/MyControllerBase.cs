using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller to use Mediator.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]    
    public class MyControllerBase : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

    }
}

