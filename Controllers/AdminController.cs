using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly Appdbcontext context;
        private readonly IWebHostEnvironment env;
        public AdminController(Appdbcontext context,IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        string UploadFile(Product pro)
        {
            string Filename = null;
            if (pro.Pic != null)
            {
                string Uploaddir = Path.Combine(env.WebRootPath, "Uploadpic");
                Filename = pro.Pic.FileName;
                string Filepath = Path.Combine(Uploaddir, Filename);
                var Filestream = new FileStream(Filepath, FileMode.Create);
                pro.Pic.CopyTo(Filestream);
            }
            return Filename;
        }
        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = (from e1 in context.Products
                            join e2 in context.Categories
                            on e1.Cid equals e2.Cid
                            select new Product
                            {
                                Pid = e1.Pid,
                                Name = e1.Name,
                                Cid = e1.Cid,
                                Category = e2.CategoryName,
                                Description = e1.Description,
                                Price = e1.Price,
                                Ppic = e1.Ppic,
                            }).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Create()
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var catlist = context.Categories.ToList();
                ViewBag.catlist = catlist;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(string name,Product pro)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                pro.Ppic = UploadFile(pro);
                var dataexists = await context.Products.Where(x => x.Name == name).FirstOrDefaultAsync();
                if (dataexists == null)
                {
                    context.Products.Add(pro);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Product Already Exists");
                    return View(pro);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var catlist = context.Categories.ToList();
                ViewBag.catlist = catlist;
                var data = await (from e1 in context.Products
                                  join e2 in context.Categories
                                  on e1.Cid equals e2.Cid
                                  where e1.Pid == id
                                  select new Product
                                  {
                                      Pid = e1.Pid,
                                      Name = e1.Name,
                                      Cid = e1.Cid,
                                      Category = e2.CategoryName,
                                      Description = e1.Description,
                                      Price = e1.Price,
                                      Ppic = e1.Ppic,
                                      Pic = e1.Pic,
                                  }).FirstOrDefaultAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product pro)
        {
            try
            {
                var email = HttpContext.Session.GetString("Useremail");
                if (email != null)
                {
                    var dataexists = await context.Products.Where(x => x.Name == pro.Name && x.Pid != pro.Pid).FirstOrDefaultAsync();
                    if (dataexists == null)
                    {
                        string Filename = null;
                        if (pro.Pic != null)
                        {
                            string Uploaddir = Path.Combine(env.WebRootPath, "Uploadpic");
                            Filename = pro.Pic.FileName;
                            string Filepath = Path.Combine(Uploaddir, Filename);
                            var file = new FileInfo(Filepath);
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        pro.Ppic = UploadFile(pro);
                        context.Entry(pro).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Product Already Exists");
                        return View(pro);
                    }
                } 
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg1=ex.Message;
                return View();
            }

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = await (from e1 in context.Products
                                  join e2 in context.Categories
                                  on e1.Cid equals e2.Cid
                                  where e1.Pid == id
                                  select new Product
                                  {
                                      Pid = e1.Pid,
                                      Name = e1.Name,
                                      Cid = e1.Cid,
                                      Category = e2.CategoryName,
                                      Description = e1.Description,
                                      Price = e1.Price,
                                      Ppic = e1.Ppic,
                                  }).FirstOrDefaultAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                var data = await (from e1 in context.Products
                                  join e2 in context.Categories
                                  on e1.Cid equals e2.Cid
                                  where e1.Pid == id
                                  select new Product
                                  {
                                      Pid = e1.Pid,
                                      Name = e1.Name,
                                      Cid = e1.Cid,
                                      Category = e2.CategoryName,
                                      Description = e1.Description,
                                      Price = e1.Price,
                                      Ppic = e1.Ppic,
                                  }).FirstOrDefaultAsync();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product pro)
        {
            var email = HttpContext.Session.GetString("Useremail");
            if (email != null)
            {
                context.Products.Remove(pro);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Adminlogin adminlogin, string email)
        {
            var validuser = await context.Adminlogins.Where(x => x.AdminEmail == adminlogin.AdminEmail && x.Password == adminlogin.Password).FirstOrDefaultAsync();
            if (validuser != null)
            {
                HttpContext.Session.SetString("Useremail", adminlogin.AdminEmail);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "No User Found");
                return View(adminlogin);
            }
        }
    }
}
