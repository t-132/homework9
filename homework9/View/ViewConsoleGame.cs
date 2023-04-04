using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9.View
{
  public class ViewConsoleGame : IViewGame
  {
    public ViewConsoleGame()
    {
    }

    public (int input, string payload) Display()
    {
      AnsiConsole.Clear();
      return (-1, null);
    }

    public (int input, string payload) Display(string message)
    {
      return (0, AnsiConsole.Ask<string>(message));
    }
  }
}
