using System;
using UnityEngine;

namespace LastStandingSheep
{
    public class GameEventController : IUpdate, IAwake
    {
        public static Action WinEvent;

        public bool isWin;
        public bool isLost;

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
    }
}