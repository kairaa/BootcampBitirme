using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dtos;
using Mvc.Models.Entities;
using Mvc.Services.Contracts;

namespace Mvc.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoriesRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto createCategoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(createCategoryDto);
                await _categoryRepository.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(categoryId);
            if(category == null)
            {
                return View("ErrorPage", "Home");
            }
            await _categoryRepository.DeleteAsync(categoryId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(categoryId);
            if(category is not null)
            {
                var updateCategoryDto = _mapper.Map<UpdateCategoryDto>(category);
                return View(updateCategoryDto);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryRepository.GetAsync(updateCategoryDto.CategoryId);
                _mapper.Map(updateCategoryDto, category);
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
