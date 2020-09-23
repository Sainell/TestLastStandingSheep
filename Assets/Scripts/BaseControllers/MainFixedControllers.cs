namespace LastStandingSheep
{
    public class MainFixedControllers : StartControllers
    {
        #region ClasLifeCycles

        public MainFixedControllers(GameContext context)
        {
            Add(new CharacterController(context));
            Add(new InputController(context));
        }

        #endregion
    }
}