using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApi.Models
{
    public class AnalistaDBContext : DbContext
    {
        public AnalistaDBContext() : base("name=AnalistaDBContext")
        { }

        public virtual DbSet<Analista> Analistas { get; set; }

    }
}