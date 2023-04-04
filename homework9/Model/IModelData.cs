using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9.Model
{
  /* очень глупо получается 
interface IModelData<T> 
{
  public void setFromString(string value);
  int CompareTo(T other);
}

class ModelData<T> : IModelData<T> where T : IComparable<T>
{
  private T _data { get; set; }    

  public ModelData() { }
  public ModelData(T data) { _data = data; }
  public void setFromString(string value)
  {
    _data = (T)Convert.ChangeType(value, typeof(T));       
  }
  public int CompareTo(T other) { return _data.CompareTo(other); }
}*/

}
