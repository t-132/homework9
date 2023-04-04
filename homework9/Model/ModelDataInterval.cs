using homework9.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9.Model
{
  public class ModelDataInterval : ModelData
  {
    public int interval;
    public ModelDataInterval(IConfiguration config)
    {
      interval = config.GetValue<int>("interval");
    }

    public ModelDataInterval(IConfiguration config, int data) : base(data)
    {
      interval = config.GetValue<int>("interval");
    }

    public ModelDataInterval(int vinterval, int data) : base(data)
    {
      interval = vinterval;
    }
    public override IModelData CreateFromString(string value)
    {
      var data = Int32.Parse(value);
      return new ModelDataInterval(interval, data);
    }

    public override int CompareTo(object? other)
    {
      if (other == null)
        throw new ArgumentNullException("other");
      if (other.GetType().IsSubclassOf(typeof(ModelData)))
      {
        int diff = ((ModelDataInterval)other)._data - this._data;
        if (diff <= this.interval || -diff <= this.interval)
          return 0;
        base.CompareTo(other);
      }

      throw new ArgumentException("other");
    }
  }
}
