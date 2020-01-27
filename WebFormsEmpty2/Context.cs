using System;
using System.Data.Entity;
using System.Linq;
using WebFormsEmpty2.Models;

public class Context : DbContext
{

    public Context()
        : base("name=MyDb")
    {
    }

    public DbSet<Country> Country { get; set; }

}


