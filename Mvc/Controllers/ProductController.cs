using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;

namespace Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IMapper mapper, IProductsRepository productRepository, ICategoriesRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(new CreateProductDto
            {
                Categories = categories
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto createProductDto)
        {
            //createProductDto.ProductImageFileName = "~/img/samsung.jpg";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
            FileInfo fileInfo = new FileInfo(createProductDto.ProductImageFile.FileName);
            string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4) + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);
            //fileInfo["Name"] veya fileInfo.name
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                createProductDto.ProductImageFile.CopyTo(stream);
            }

            createProductDto.Categories = await _categoryRepository.GetAllAsync();
            createProductDto.ProductImage = ReadFile(fileNameWithPath);
            //if (ModelState.IsValid)
            //{
            var product = _mapper.Map<Product>(createProductDto);
            await _productRepository.AddAsync(product);
            return RedirectToAction(nameof(Index));
            //}
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            if (product == null)
            {
                return View("ErrorPage", "Home");
            }
            await _productRepository.DeleteAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            if (product is not null)
            {
                var updateProductDto = _mapper.Map<UpdateProductDto>(product);
                return View(updateProductDto);
            }
            return RedirectToAction(nameof(Index));
        }

        //TODO: Update Product View'ini ekle
        //TODO: UpdateProductDto'yu oluştur

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                var product = await _productRepository.GetAsync(updateProductDto.ProductId);
                _mapper.Map(updateProductDto, product);
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private static byte[] ReadFile(string name)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(name);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(name, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int)numBytes);

            return data;
        }

    }
}
