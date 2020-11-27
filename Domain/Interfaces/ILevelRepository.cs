using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ILevelRepository
    {
         IEnumerable<Class> GetClasses();  
    }
}