using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework9.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace homework9.Model
{
  public class ModelDataGenerator :IModelDataGenerator
  {
    private readonly IConfiguration _config;
    private readonly IServiceProvider _provider;
    public ModelDataGenerator(IConfiguration config, IServiceProvider provider) 
    {
      _config = config;
      _provider = provider;
    }
    public IModelData Generate() 
    {
      Random rand = new Random();
      var value = rand.Next(_config.GetValue<int>("MinValue"), _config.GetValue<int>("MaxValue") + 1);
      var ret = _provider.GetService<IModelData>();
        //(IModelData)ActivatorUtilities.CreateInstance<IModelData>(_provider).setFromInt(value);
      
      return ret.setFromInt(value);       
      
    }
  }
}
