﻿using Sticker_Web_dotnet.Repository.Interfaces;
using Sticker_Web_dotnet.Models;
using Sticker_Web_dotnet.Models.ViewModels;
using Sticker_Web_dotnet.Services.Interfaces;

namespace Sticker_web.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task AddAsync(Product obj)
        {
            try
            {
                await _unitOfWork.Product.AddAsync(obj);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An occured while adding the new product!!! ", ex);
            }

        }
        public async Task<Product> GetAsync(int? id)
        {
            try
            {
                return await _unitOfWork.Product.GetAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting the particular product with id {id}!!!", ex);
            }
        }
        public async Task<IEnumerable<Product>> GetAllAsync(string include)
        {
            try
            {
                var objProductModel = await _unitOfWork.Product.GetAllAsync(includeProperties: include);
                return objProductModel;
            }
            catch (Exception ex)
            {
                throw new Exception("An occured while getting the products ", ex);
            }
        }
        public async Task RemoveAsync(Product obj)
        {
            try
            {
                // Get the web root path
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Check if the product has an associated image
                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    // Construct the full path to the image file
                    var imagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Delete the image file
                        System.IO.File.Delete(imagePath);
                    }
                }
                await _unitOfWork.Product.RemoveAsync(obj);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the product with id {obj.Id}!!!", ex);
            }
        }
        public async Task UpdateAsync(Product obj)
        {
            try
            {
                await _unitOfWork.Product.UpdateAsync(obj);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the product with id ${obj.Id}!!!", ex);
            }
        }
        public ProductVM ImageHandle(ProductVM productVM, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product\");

                // Ensure the directory exists
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }

                if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                productVM.Product.ImageUrl = @"\images\product\" + fileName;
                return productVM;
            }
            return productVM;
        }

    }
}