using System.ComponentModel.DataAnnotations;

namespace Jira.MVC.Models;
/// <summary>
/// user login view model
/// </summary>
public class LoginVm
{
    /// <summary>
    /// User's login(userName, email)
    /// </summary>
    [Required(ErrorMessage = "Please provide a field!")]
    public string Login { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    [Required(ErrorMessage = "Please provide a Password!")]
    public string Password { get; set; }
}