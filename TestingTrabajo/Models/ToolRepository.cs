using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTrabajo.Models
{
    interface ToolRepository
    {

        string getName();

        Tool AddTool(string uuid, string name, int category_id_fk, int stock, int real_stock);
        Tool UpdateTool(string uuid, string name, int category_id_fk, int stock, int real_stock);

    }

}
