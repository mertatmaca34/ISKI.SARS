using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Controllers;

public class UsersController(IApiService apiService) : Controller
{
    private readonly IApiService _apiService = apiService;

    public async Task<IActionResult> Index()
    {
        var users = await _apiService.GetUsersAsync();
        return View(users);
    }

    public IActionResult Create()
    {
        return View(new UserViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _apiService.CreateUserAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _apiService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _apiService.UpdateUserAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _apiService.DeleteUserAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
