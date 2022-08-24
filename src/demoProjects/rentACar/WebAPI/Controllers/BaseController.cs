using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        //Bütün controllerlarda mediatr gerekecek o nedenle basecontroller oluşturuldu.CQRS kullandığımız için mediatr kullanıyoruz bu nedenle mediatr nesnesi almamız gerekir.
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        
    }
}
