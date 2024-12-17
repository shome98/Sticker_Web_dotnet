using Microsoft.AspNetCore.Mvc;
using Sticker_Web_dotnet.Repository.Interfaces;
using Sticker_Web_dotnet.Utility;
using System.Security.Claims;

namespace Sticker_Web_dotnet.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {

                if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart, (await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == claim.Value)).Count());
                }

                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
            else
            {
                HttpContext.Session.SetInt32(SD.SessionCart, 0);

                HttpContext.Session.Clear();
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
        }
    }
}
