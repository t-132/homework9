using homework9.Settings;
using homework9.View;
using homework9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace homework9.Presenter
{
  internal class Presenter : IPresenter
  {
    private readonly IViewMenu _menu;
    private readonly IViewGame _game;
    private readonly IModelInput _imodel;
    private readonly IModelState _smodel;

    private int Action;
    private string Payload;
    public Presenter(IModel model, IViewMenu menu, IViewGame game) 
    {      
      _imodel = model;
      _smodel = model; 
      _menu = menu;
      _game = game;
    }

    public void setInput(int action, string payload) 
    {
      Action = action;
      Payload = payload;
    }
 
    public void RunGame() 
    {
      
      for (; ; )
      {
        (Action, Payload) = _menu.Display();
        if (Action == 2) return;
        _imodel.InitNewGame();
        (Action,Payload) = _game.Display($"Угадай число\r\nосталось попыток {_smodel.GetAttemptsLeft()}");
        for (; ; )
        {
          _imodel.CheckResponce(Payload);
          var result = _smodel.GetState();
          if (result == ModelStates.GameFail) {_game.Display($"не получилось, введите что-нибудь"); break; }
          if (result == ModelStates.Win) { _game.Display($"получилось, введите что-нибудь"); break; }
          if (result == ModelStates.CheckFailLess) { (Action, Payload) = _game.Display($"меньше, осталось попыток {_smodel.GetAttemptsLeft()}"); continue; }
          if (result == ModelStates.CheckFailMore) { (Action, Payload) = _game.Display($",больше, осталось попыток {_smodel.GetAttemptsLeft()}"); continue; }
          _game.Display("ошибка, введите что-нибудь");
          break;
        }
      }
    }
  }
}
