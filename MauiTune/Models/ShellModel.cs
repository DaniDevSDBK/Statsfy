using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsfy.Models
{
    class ShellModel
    {
        private bool _isVisible;
        private static ShellModel _instance;

        public bool IsVisible { get => _isVisible; set => _isVisible = value; }
        public static ShellModel Instance => _instance ?? new ShellModel();
        private ShellModel() {
            _isVisible = false;
        }
    }
}
