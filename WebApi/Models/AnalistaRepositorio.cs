using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AnalistaRepositorio : IAnalistaRepositorio
    {
        private List<Analista> analistas = new List<Analista>();

       
        public IEnumerable<Analista> GetAll()
        {
            return analistas;
        }

        public Analista Get(int id)
        {
            return analistas.Find(e => e.id == id);
        }
        public bool Add(Analista analista)
        {
            bool addResult = false;
            if (analista == null)
            {
                return addResult;
            }
            int index = analistas.FindIndex(e => e.id == analista.id);
            if (index == -1)
            {
                analistas.Add(analista);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            analistas.RemoveAll(e => e.id == id);
        }

        public bool Update(Analista analista)
        {
            if (analista == null)
            {
                throw new ArgumentNullException("analista");
            }
            int index = analistas.FindIndex(e => e.id == analista.id);
            if (index == -1)
            {
                return false;
            }
            analistas.RemoveAt(index);
            analistas.Add(analista);
            return true;
        }
    }
}