using FirstApp.DataContext;
using FirstApp.Entity;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Controllers;

public class FacultyController : Controller
{
    
private readonly AppDbContext _context;

    public FacultyController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _context.Faculties.ToListAsync();  // get all class info
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View(new FacultyVm()); // return view with empty model
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(FacultyVm model)
    {
        try
        {
            var info = new Faculty
            {
                Name = model.Name,
                Director = model.Director,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Faculties.AddAsync(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        try
        {
            var info = await _context.Faculties.Where(x=>x.Id== id).FirstOrDefaultAsync(); 
            if (info == null)
            {
                return NotFound();
            }

            var model = new FacultyVm()
            {
                Name = info.Name,
                Director = info.Director,
            };
            
            return View(model);
            
        }
        
        
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(long id, FacultyVm model)
    {
        try
        {
            var info = await _context.Faculties.Where(x=>x.Id== id).FirstOrDefaultAsync(); 
            if (info == null)
            {
                return NotFound();
            }

            info.Name = model.Name;
            info.Director = model.Director;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var info = await _context.Faculties.Where(x=>x.Id== id).FirstOrDefaultAsync(); 
            if (info == null)
            {
                return NotFound();
            }

            _context.Faculties.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}