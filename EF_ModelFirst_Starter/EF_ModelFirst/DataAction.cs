using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst;

public abstract class DataAction
{

    public virtual void ExecuteQuery(string name, string city, string country, string postalCode) { }
    public virtual void ExecuteQuery(int ID) { }
    public virtual void ExecuteQuery(int customerID, string column, string value) { }


}
