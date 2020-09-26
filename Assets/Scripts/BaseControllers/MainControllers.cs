namespace LastStandingSheep
{
    public class MainControllers : StartControllers
    {
        #region ClasLifeCycles

        public MainControllers(GameContext context)
        {
            //add controllers
           
            Add(new PlatformController(context));
            
            Add(new InitializeInteractableObjectController(context));
            Add(new PlayerTriggerController(context));
            Add(new SheepTriggerController(context));
            Add(new GameEventController());

        }

        #endregion
    }
}