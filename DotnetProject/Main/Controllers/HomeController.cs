using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Main.Models;
using BLL;
using BOL;
namespace HRPortal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Register(){ 
        return View();
    }


    [HttpPost]
    public IActionResult Register(int UserId,string UserName, string Email, string Password){
        BusinessLayer.InsertData(UserId,UserName, Email, Password);
        return RedirectToAction("Login");
    }

    public IActionResult Login(){
        return View();
    }

    static User validUser;
    [HttpPost]
    public IActionResult Login(string Email, string Password){
        validUser = BusinessLayer.Login(Email, Password);
        if(validUser!=null){
            ViewData["User"]=validUser;
            return RedirectToAction("Profile");
        }
        else{
            ViewData["msg"]="Invalid Credentials!!!";
        }
        return View();
    }

    public IActionResult Profile(){
        List<Blog> allBlog = BusinessLayer.ViewAllBlog();
        ViewData["Blog"]=allBlog;
        return View();
    }


    public IActionResult Edit(int id){
        List<Blog> allUser = BusinessLayer.ViewAllBlog();
        Blog emp = allUser.Find((e)=>e.BlogId==id);
        ViewData["Blog"]=emp;
        return View();
    }
    [HttpPost]
    public IActionResult Edit(int BlogId, string Title, string Content, int UserId, int CategoryId){
        BusinessLayer.EditBlog(BlogId,Title, Content, UserId, CategoryId);
        return RedirectToAction("Profile");
    }

    // public IActionResult Delete(int id){
    //     List<User> allUser = BusinessLayer.ViewAllUser();
    //     User emp = allUser.Find((e)=>e.UserId==id);
    //     ViewData["emp"]=emp;
    //     BusinessLayer.DeleteUser(emp);
    //     return RedirectToAction("Profile");
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
