using homework9.Models;
using Microsoft.Extensions.Configuration;

namespace homework9.Model
{
  public class Model : IModel
  {
    private IModelData Number;
    private ModelStates State;
    private bool StateChanged;
    private int AttemptsLeft;     
    private readonly IModelDataGenerator _gen;
    private readonly IConfiguration _config;

    public Model(IModelDataGenerator gen, IConfiguration config, IModelData data)
    {
      _gen = gen;
      _config= config;
      Number = data;
      Init();      
    }

    public void CheckResponce(string responce)
    {
      if (!(State == ModelStates.WaitResponce || State == ModelStates.CheckFailLess || State == ModelStates.CheckFailMore)) 
      { 
        State = ModelStates.Unknown;
        return;
      }

      AttemptsLeft--;

      if (AttemptsLeft > 0)
      {
       
        var ResponceData = Number.CreateFromString(responce);

        var check = Number.CompareTo(ResponceData);

        if (0 == check)
        {
          State = ModelStates.Win;
          return;
        }
        else if (check > 0) State = ModelStates.CheckFailLess;
        else State = ModelStates.CheckFailMore;
      }
      else State = ModelStates.GameFail;
    }
    public void InitNewGame() { Init(); }

    public ModelStates GetState() { return State; }
    private void Init()
    {
      State = ModelStates.Unknown;
      Number = _gen.Generate();
      State = ModelStates.New;
      AttemptsLeft = _config.GetValue<int>("AttemptsLeft");
      State = ModelStates.WaitResponce;
    }
    public int GetAttemptsLeft() => AttemptsLeft;
  }
}
