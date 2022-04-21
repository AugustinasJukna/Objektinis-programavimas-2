using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Lab5_WebApp
{
    public interface IResults //Custom interface for outputs
    {
        string ReturnHeader();
        TableRow ToTableRow();

        TableRow ReturnRowHeader();
    }
}
