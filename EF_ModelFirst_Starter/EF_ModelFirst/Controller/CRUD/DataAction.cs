namespace EF_ModelFirst;

public abstract class DataAction
{
    public virtual void Execute(Customer customer) { }
    public virtual void Execute(string customerID) { }
    public virtual void Execute(string customerID, string column, string value) { }
}
