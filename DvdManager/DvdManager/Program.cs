using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdManager.Models;
using DvdManager.View;
using DvdManager.Controllers;

namespace DvdManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DvdController controller = new DvdController();
            controller.Run();
        }
    }
}