using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework9.Settings;
using Spectre;
using Spectre.Console;

namespace homework9.View
{
  public class ViewConsoleMenu : IViewMenu
  {
    private string[] choices = { "Новая игра", "Выход" };    
    public ViewConsoleMenu()
    {      
    }

    public (int input, string payload) Display()
    {
      AnsiConsole.Clear();

      var Selection = new SelectionPrompt<int>().Title("Что будем делать?").AddChoices(new[] { 1, 2 });
      Selection.UseConverter<int>((x => choices[x - 1]));
      var input = AnsiConsole.Prompt(Selection);
      return (input, null);
    }
  }
}
