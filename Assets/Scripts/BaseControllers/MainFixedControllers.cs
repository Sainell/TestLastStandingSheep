namespace LastStandingSheep
{
    public sealed class MainFixedControllers : StartControllers
    {
        #region ClasLifeCycles

        public MainFixedControllers(GameContext context)
        {
            Add(new CharacterController(context));
            Add(new InputController(context));
            Add(new SheepBotController(context));
        }

        #endregion
    }
}