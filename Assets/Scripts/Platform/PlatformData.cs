using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/PlatformData", order = 0)]
    public sealed class PlatformData : ScriptableObject
    {
        public static Action<bool> PlatformIsMove;

        [SerializeField]
        public PlatformStruct PlatformStruct;
        public PlatformModel PlatformModel;
        public float RespawnTime;
        public float StartMoveTime;
        public float MoveTime;
        public float HideTime;
        private int _index;
        private float _time;
        private bool _isRespawn;
        private bool _isMoving;
        private bool _isHide;

        private void OnEnable()
        {
            _index = 1;
            _time = 0;
            _isMoving = false;
            _isRespawn = false;
            _isHide = false;
        }

        public void Updating()
        {
            Timer();
            PlatformAction();
        }


        private void Timer()
        {
            _time += Time.deltaTime;
        }

        private void PlatformAction()
        {
            if (_time >= RespawnTime)
            {
                if (!_isRespawn)
                {
                    Respawn(_index, true);
                    _isRespawn = true;
                    _time = 0;
                }

            }
            if (_time >= StartMoveTime)
            {
                if (!_isMoving)
                {
                    StartMove();
                    _isMoving = true;
                    _time = 0;
                }
            }

            if (_time >= HideTime)
            {
                if (!_isHide)
                {
                    Respawn(_index, false);

                    _isHide = true;
                    _index++;
                    if (_index >= PlatformStruct.SpawnPoints.Length)
                    {
                        _index = 1;
                    }
                }
                if (_time >= HideTime + 1f)
                {

                    _time = 0;
                    _isHide = false;
                    _isRespawn = false;
                    _isMoving = false;
                    PlatformIsMove?.Invoke(false);
                }
            }
        }

        private void Respawn(int index, bool isActive)
        {
            var randomIndex = UnityEngine.Random.Range(0, PlatformStruct.SpawnPoints.Length);
            PlatformModel.Platform.transform.GetChild(index).gameObject.SetActive(isActive);
            PlatformModel.Platform.transform.GetChild(0).gameObject.SetActive(isActive);
            PlatformModel.Platform.transform.position = PlatformStruct.SpawnPoints[index];
        }

        private void StartMove()
        {
            PlatformModel.Platform.transform.GetChild(0).gameObject.SetActive(false);
            PlatformIsMove?.Invoke(true);
            PlatformModel.Platform.transform.DOMoveY(30, MoveTime);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(PlatformModel.Ocean.transform.DOMoveY(25, MoveTime)).AppendInterval(2f).Append(PlatformModel.Ocean.transform.DOMoveY(15, MoveTime));
        }


        
    }
}