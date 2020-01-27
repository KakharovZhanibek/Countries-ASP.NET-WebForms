using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsEmpty2.Models;

namespace WebFormsEmpty2.Interfaces
{
    public interface IMultyOther<T> where T : class
    {
        IQueryable<T> GetAllById(int Id);        
    }
}
