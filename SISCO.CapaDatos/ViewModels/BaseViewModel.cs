using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISCO.CapaDatos.ViewModels
{
    public abstract class BaseViewModel
    {
        public BaseViewModel()
        {

        }

        public abstract bool IsValid();
    }
}
