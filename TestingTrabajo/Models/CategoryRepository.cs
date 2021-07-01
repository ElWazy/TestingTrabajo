using System;
using System.Collections.Generic;

namespace TestingTrabajo.Models
{
    interface CategoryRepository
    {
        string GetName();

        List<Category> GetAll();
        Category GetByName(string name);
        void Save(Category category);
        void Update(Category category);
    }
}
