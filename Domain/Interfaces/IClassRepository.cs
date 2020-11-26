using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IClassRepository
    {
         IEnumerable<Class> GetClasses();  
    }
}