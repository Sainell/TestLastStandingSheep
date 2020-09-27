using UnityEngine;


namespace LastStandingSheep
{
    public sealed class SheepTriggerController : IAwake
    {
        #region Fields

        private readonly GameContext _context;
        private Collider _target;

        #endregion


        #region ClassLifeCycles

        public SheepTriggerController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var ocean = _context.GetTriggers(InteractableObjectType.Sheep);
            foreach (var trigger in ocean)
            {
                var oceanBehavior = trigger as Trigger;
                oceanBehavior.OnFilterHandler += OnFilterHandler;
                oceanBehavior.OnTriggerEnterHandler += OnTriggerEnterHandler;
                oceanBehavior.OnTriggerExitHandler += OnTriggerExitHandler;
            }
        }

        #endregion


        #region ITearDownController

        public void TearDown()
        {
            var ocean = _context.GetTriggers(InteractableObjectType.Ocean);
            foreach (var trigger in ocean)
            {
                var oceanBehavior = trigger as Trigger;
                oceanBehavior.OnFilterHandler -= OnFilterHandler;
                oceanBehavior.OnTriggerEnterHandler -= OnTriggerEnterHandler;
                oceanBehavior.OnTriggerExitHandler -= OnTriggerExitHandler;
            }
        }

        #endregion


        #region Methods

        private bool OnFilterHandler(Collider tagObject)
        {
            return tagObject.CompareTag("Ocean");
        }

        private void OnTriggerEnterHandler(ITrigger enteredObject, Collider other)
        {
            enteredObject.IsInteractable = true;
            _context.CharacterModel.CharacterData.OnTriggerEnter(other);
        }

        private void OnTriggerExitHandler(ITrigger enteredObject, Collider other)
        {
            enteredObject.IsInteractable = false;
            _context.CharacterModel.CharacterData.OnTriggerExit(other);
        }

        #endregion
    }
}