using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    
    public interface IAnalistaRepositorio
    {
        IEnumerable<Analista> GetAll();
        Analista Get(int id);
        bool Add(Analista analista);
        void Remove(int id);
        bool Update(Analista analista);
    }
}