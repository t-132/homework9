using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9.Model
{
  public enum ModelStates
  {
    Unknown = 0,
    New = 1,
    Generated = 2,
    WaitResponce = 3,
    CheckFailLess = 4,
    CheckFailMore = 5,
    Win = 6,
    GameFail = 7,
    Exit = 8
  };
}
