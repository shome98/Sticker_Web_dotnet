using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Repository.Interfaces;
using Sticker_Web_dotnet.Utility;

namespace Sticker_Web_dotnet.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class VendorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VendorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var vendobj = await _unitOfWork.Vendor.GetAllAsync();
                return View(vendobj);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return View(new Vendor());
                }
                else
                {
                    Vendor vendobj = await _unitOfWork.Vendor.GetAsync(u => u.Id == id);
                    return View(vendobj);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Vendor vendobj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (vendobj.Id == 0)
                    {
                        await _unitOfWork.Vendor.AddAsync(vendobj);
                    }
                    else
                    {
                        await _unitOfWork.Vendor.UpdateAsync(vendobj);
                    }

                    await _unitOfWork.SaveAsync();
                    return RedirectToAction("Index", "Vendor");
                }
                else
                {
                    return View(vendobj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                Vendor prodfromdb = await _unitOfWork.Vendor.GetAsync(u => u.Id == id);
                if (prodfromdb == null)
                {
                    return NotFound();
                }
                return View(prodfromdb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DelectPost(int id)
        {
            try
            {
                Vendor prodCategory = await _unitOfWork.Vendor.GetAsync(u => u.Id == id);
                if (prodCategory == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Vendor.RemoveAsync(prodCategory);
                await _unitOfWork.SaveAsync();
                return RedirectToAction("Index", "Vendor");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
