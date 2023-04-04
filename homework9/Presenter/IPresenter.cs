using System;
using System.Collections.Generic;
using System.Text;

namespace homework9.Settings
{
   interface IPresenter
   {
     void RunGame();
    void setInput(int action, string payload);

   }
}
