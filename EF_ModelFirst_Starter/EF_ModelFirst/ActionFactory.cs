

namespace EF_ModelFirst;

public class ActionFactory
{
    public static DataAction GetAction(int input)
    {
        switch (input)
        {
            case 1:
                return new Add();
            case 2:
                return new Read();
            case 3:
                return new Update();
            case 4:
                return new Delete();
            default:
                return null;
        }
    }
}
