using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Clients;
using SimpleShop.Domain;
using SimpleShop.Mvc.Areas.PersonalAccount.ViewModels;
using SimpleShop.Mvc.Controllers;

namespace SimpleShop.Areas.PersonalAccount.Controllers
{
    [Area("PersonalAccount")]
    public class HelpController : MvcBaseController
    {
        private readonly IMapper _mapper;
        private readonly IClientAppService _clientAppService;

        public HelpController(IClientAppService clientAppService, IMapper mapper)
        {
            _clientAppService = clientAppService;
            _mapper = mapper;
        }

        [Route("PersonalAccount/Help/Index")]
        [HttpGet("{clientId}")]
        public async Task<IActionResult> Index(int clientId)
        {
            var client = await _clientAppService.GetAsync(clientId);
            var model = _mapper.Map<ClientViewModel>(client);
            return View(model);
        }
    }
}
