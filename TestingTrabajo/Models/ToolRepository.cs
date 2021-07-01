using System;
using System.Collections.Generic;

namespace TestingTrabajo.Models
{
    interface ToolRepository
    {

        string getName();

        List<Tool> GetAll();
        Tool GetByName(string name);
        Tool GetByUUID(string uuid);
        void Add(Tool tool);
        void Update(Tool tool);

    }

}
