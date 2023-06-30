using Microsoft.AspNetCore.Mvc;
using Portfolio.Services;

namespace Portfolio.Controllers;

public class CustomControllerBase : Controller
{
    protected AuthenticationService AuthenticationService;

    protected CustomControllerBase(AuthenticationService auth)
    {
        AuthenticationService = auth;
    }
}