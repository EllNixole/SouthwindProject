

namespace EF_ModelFirst
{
    public class ActionFactory
    {
        public static IAction GetAction(int input)
        {
            switch (input)
            {
                case 1:
                    return new CreateAction();
                case 2:
                    return new ReadAction();
                case 3:
                    return new UpdateAction();
                case 4:
                    return new DeleteAction();
                default:
                    return null;
            }
        }
    }
}
