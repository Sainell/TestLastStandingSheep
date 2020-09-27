namespace LastStandingSheep
{
    public class MainControllers : StartControllers
    {
        #region ClasLifeCycles

        public MainControllers(GameContext context)
        {  
            Add(new InitializeInteractableObjectController(context));
            Add(new PlatformController(context));
            Add(new PlayerTriggerController(context));
            Add(new SheepTriggerController(context));
            Add(new GameEventController());
        }

        #endregion
    }
}