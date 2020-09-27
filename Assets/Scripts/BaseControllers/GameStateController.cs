using System.Collections.Generic;


namespace LastStandingSheep
{
    public abstract class GameStateController
    {
        #region Fields

        private readonly List<StartControllers> _updateFeatures;
        private readonly List<StartControllers> _fixedUpdateFeatures;

        #endregion


        #region ClassLifeCycle

        protected GameStateController(int capacity = 5)
        {
            _updateFeatures = new List<StartControllers>(capacity);
            _fixedUpdateFeatures = new List<StartControllers>(capacity);
        }

        #endregion


        #region Methods

        protected void AddUpdateFeature(StartControllers controller)
        {
            _updateFeatures.Add(controller);
        }

        protected void AddFixedUpdateFeature(StartControllers controller)
        {
            _fixedUpdateFeatures.Add(controller);
        }


        public void Initialize()
        {
            foreach (var feature in _updateFeatures)
            {
                feature.OnAwake();
            }

            foreach (var feature in _fixedUpdateFeatures)
            {
                feature.OnAwake();
            }

        }

        public void Updating(UpdateType updateType)
        {
            List<StartControllers> features = null;
            switch (updateType)
            {
                case UpdateType.Update:
                    features = _updateFeatures;
                    break;
                case UpdateType.Fixed:
                    features = _fixedUpdateFeatures;
                    break;

                default:
                    break;
            }

            foreach (var feature in features)
            {
                feature.Updating();
            }
        }

        #endregion
    }
}