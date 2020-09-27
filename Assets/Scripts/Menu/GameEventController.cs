using System;
using UnityEngine;


namespace LastStandingSheep
{
    public sealed class GameEventController : IUpdate, IAwake
    {
        #region Fields

        public static Action WinEvent;

        public bool isWin;
        public bool isLost;

        #endregion


        #region Methods

        public void Updating()
        {
            SheepCounter();
        }

        private void SheepCounter()
        {
            if (!isLost)
            {
                if (!isWin)
                {
                    var count = GameObject.FindGameObjectsWithTag("Sheep");
                    if (count.Length == 0)
                    {
                        isWin = true;
                        WinEvent?.Invoke();
                    }
                }
            }
        }

        private void OnLost()
        {
            isLost = true;
        }

        public void OnAwake()
        {
            CharacterData.PlayerDie += OnLost;
        }

        #endregion
    }
}