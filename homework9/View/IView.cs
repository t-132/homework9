using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9.View
{
  interface IView
  {
    (int input, string payload) Display();
  }

  interface IViewMenu : IView
  {    
  }

  interface IViewGame : IView
  {
    (int input, string payload) Display(string message);
  }

}
