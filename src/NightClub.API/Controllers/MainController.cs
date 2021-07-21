using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NightClub.API.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class MainController : ControllerBase
    {
    }
}
