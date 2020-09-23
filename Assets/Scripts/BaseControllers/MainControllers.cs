namespace LastStandingSheep
{
    public class MainControllers : StartControllers
    {
        #region ClasLifeCycles

        public MainControllers(GameContext context)
        {
            //add controllers
            Add(new PlatformController(context));
        }

        #endregion
    }
}