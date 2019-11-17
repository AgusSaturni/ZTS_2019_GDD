using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Manejo_Logico
{
    class helperControls
    {
        public static List<T> GetControls<T>(Control container) where T : Control
        {
            List<T> controls = new List<T>();
            foreach (Control c in container.Controls)
            {
                if (c is T)
                    controls.Add((T)c);
                controls.AddRange(GetControls<T>(c));
            }
            return controls;
        }

    }
}
