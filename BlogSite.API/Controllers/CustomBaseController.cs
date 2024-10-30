using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.API.Controllers;
public class CustomBaseController(DecoderService decoderService) : ControllerBase
{

    protected string GetUser()
    {
        return decoderService.GetUserId();
    }
}
