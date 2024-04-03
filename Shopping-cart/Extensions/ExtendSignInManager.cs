using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Shopping_cart.Controllers;
using Shopping_cart.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Shopping_cart.Extensions
{
    public static class ExtendSignInManager
    {
        //public static async Task<SignInResult> ExtendPasswordSignInAsync(this SignInManager<ApplicationUser> signInManager,
        //    UserManager<ApplicationUser> userManager,
        //    string userName, string password,
        //    bool isPersistent, bool lockoutOnFailure)
        //{

        //    if (await userManager.FindByEmailAsync(userName) is var user &&
        //        user != null &&
        //        !await userManager.CheckPasswordAsync(user, password) &&
        //        await userManager.GetAccessFailedCountAsync(user) == 4)
        //    {

        //    }

        //    return await signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        //}
    }
}
