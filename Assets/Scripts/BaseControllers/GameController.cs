using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LastStandingSheep
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        private GameStateController _activeController;

        #endregion

        #region UnityMethods

        private void Start()
        {
            GameContext context = new GameContext();
            //serives
            _activeController = new GameSystemsController(context);
            _activeController.Initialize();
            
        }

        private void Update()
        {
            _activeController.Updating(UpdateType.Update);
        }

        private void FixedUpdate()
        {
            _activeController.Updating(UpdateType.Fixed);
        }

        #endregion
    }
}