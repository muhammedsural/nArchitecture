using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    //Asencron ve senkron database işlemlerini(CRUD ve diğer işlemler get felan) core katmanında implemente edilmiş. Bunları IBrandRepository üzerinden Application katmanınında kullanıyoruz. İster Asenkron ister senkron kullanılabilir. Brande özel operasyonlarımızıda burada kullanabiliriz.
    public interface IBrandRepository : IAsyncRepository<Brand>, IRepository<Brand> 
    {
    }
}
