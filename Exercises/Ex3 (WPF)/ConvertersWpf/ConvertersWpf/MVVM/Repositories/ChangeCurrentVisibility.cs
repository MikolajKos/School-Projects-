using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvertersWpf.MVVM.Repositories
{
    public class ChangeCurrentVisibility
    {
        public Visibility visibility;

        public ChangeCurrentVisibility(Visibility myVisibility)
        {
            this.visibility = myVisibility;
        }

        public Visibility ChangeMyVisibility()
        {
//            if (visibility == Visibility.Visible) 
  //              return Visibility.Hidden;
            
            return Visibility.Hidden;
        }
    }
}
