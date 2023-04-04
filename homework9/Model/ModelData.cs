using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Transactions;
using homework9.Models;

namespace homework9.Models
{
  public abstract class IModelData : IComparable
  {
    public abstract IModelData CreateFromString(string value);
    public abstract IModelData setFromInt(int value);
    public abstract int CompareTo(object other);
  }

  public class ModelData : IModelData
  {
    protected int _data { get; set; }

    public ModelData() { }
    public ModelData(int data) { _data = data; }
    public override IModelData CreateFromString(string value)
    {
      var data = Int32.Parse(value);
      return new ModelData(data);
      //data = (T)Convert.ChangeType(value, typeof(T));
    }

    public override IModelData setFromInt(int value)
    {
      _data = value;
      return this;
    }
    public override int CompareTo(object? other)
    {
      if (other == null)
        throw new ArgumentNullException("other");
      if (other is ModelData)
        return _data.CompareTo(((ModelData)other)._data);
      throw new ArgumentException("other");
    }
  }
    
}
