namespace EF_ModelFirst;

public interface IDataAction
{
    public abstract void Execute(Customer customer);
    public abstract void Execute(int ID);
    public abstract void Execute(int customerID, string column, string value);

}
