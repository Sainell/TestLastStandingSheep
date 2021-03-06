﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace LastStandingSheep
{
    public sealed class GameContext : BaseContext
    {
        #region Fields

        public CharacterModel CharacterModel;
        public InputModel InputModel;
        public PlatformModel PlatformModel;
        public List<SheepBotModel> SheepBotModelList = new List<SheepBotModel>();

        public event Action<IInteractable> AddObjectHandler = delegate (IInteractable interactable) { };

        private readonly SortedList<InteractableObjectType, List<IInteractable>> _onTriggers;
        private readonly List<IInteractable> _interactables;

        #endregion


        #region ClassLifeCycle

        public GameContext()
        {
            _onTriggers = new SortedList<InteractableObjectType, List<IInteractable>>();
            _interactables = new List<IInteractable>();
        }

        #endregion


        #region Methods

        public void AddTriggers(InteractableObjectType InteractionType, ITrigger TriggerInterface)
        {
            if (!_interactables.Contains(TriggerInterface))
            {
                _interactables.Add(TriggerInterface);
            }

            if (_onTriggers.ContainsKey(InteractionType))
            {
                _onTriggers[InteractionType].Add(TriggerInterface);
            }
            else
            {
                _onTriggers.Add(InteractionType, new List<IInteractable>
                {
                    TriggerInterface
                });
            }

            TriggerInterface.DestroyHandler = DestroyHandler;
            AddObjectHandler.Invoke(TriggerInterface);
        }

        private void DestroyHandler(ITrigger TriggerInterface, InteractableObjectType InteractionType)
        {
            _onTriggers[InteractionType].Remove(TriggerInterface);
            _interactables.Remove(TriggerInterface);
        }

        public List<T> GetTriggers<T>(InteractableObjectType InteractionType) where T : class, IInteractable
        {
            return _onTriggers.ContainsKey(InteractionType) ? _onTriggers[InteractionType].Select(trigger => trigger as T).ToList() : null;
        }

        public List<IInteractable> GetTriggers(InteractableObjectType InteractionType)
        {
            return _onTriggers.ContainsKey(InteractionType) ? _onTriggers[InteractionType] : _onTriggers[InteractionType] = new List<IInteractable>();
        }

        public List<IInteractable> GetListInteractable()
        {
            return _interactables;
        }

        #endregion
    }
}