using Atb.Data.Entitys;
using Atb.Data;
using Atb.Models;
using Microsoft.AspNetCore.Mvc;

//автоматична валідація моделі, прив’язка параметрів
[ApiController]
//маршрут api/categories
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    //ін'єкція залежностей
    private readonly MyAppDbContext myAppDbContext;
    private readonly IConfiguration configuration;

    public CategoriesController(MyAppDbContext myAppDbContext, IConfiguration configuration)
    {
        this.myAppDbContext = myAppDbContext;
        this.configuration = configuration;
    }

    //GET api/categories - отримати всі категорії
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(myAppDbContext.Categories.ToList());
    }

    //POST api/categories - створити нову категорію
    //приймає модель CategoryCreateModel з форми (ім'я та зображення)
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryCreateModel model)
    {
        //створюємо нову категорію
        var newCategory = new CategoryEntity { Name = model.Name };

        //якщо є зображення - зберігаємо його
        if (model.Image != null)
        {
            //створюємо унікальне ім'я файлу
            //зчитуємо шлях з конфігурації або використовуємо "images" за замовчуванням
            //створюємо директорію, якщо її немає
            var fileName = Guid.NewGuid() + ".jpg";
            var dirPath = configuration.GetValue<string>("DirPath") ?? "images";
            var fullDirPath = Path.Combine(Directory.GetCurrentDirectory(), dirPath);
            Directory.CreateDirectory(fullDirPath);
            var filePath = Path.Combine(fullDirPath, fileName);

            //зберігаємо файл асинхронно 
            using var stream = new FileStream(filePath, FileMode.Create);
            await model.Image.CopyToAsync(stream);

            //зберігаємо шлях до зображення в категорії (/image/file name)
            newCategory.Image = $"/{dirPath}/{fileName}";
        }

        //додаємо категорію в базу даних
        myAppDbContext.Categories.Add(newCategory);
        await myAppDbContext.SaveChangesAsync();
        return Ok(newCategory);
    }

    //DELETE api/categories/{id} - видалити категорію за id
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        //знаходимо категорію за id 
        //якщо не знайдено - повертаємо 404
        var category = await myAppDbContext.Categories.FindAsync(id);
        if (category == null) return NotFound();

        //видаляємо категорію з бази даних
        myAppDbContext.Categories.Remove(category);
        await myAppDbContext.SaveChangesAsync();
        return NoContent();
    }
}
