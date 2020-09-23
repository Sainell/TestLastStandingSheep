using UnityEngine;

namespace LastStandingSheep
{
    [CreateAssetMenu(fileName = "NewData", menuName = "CreateData/PlatformData", order = 0)]
    public sealed class PlatformData : ScriptableObject
    {
        [SerializeField]
        public PlatformStruct PlatformStruct;
        public PlatformModel PlatformModel;
        public float RespawnTime;
        public float DelayBeforMove;
        public float MoveTime;
        public float DelayBeforOff;
        public float MoveSpeed;
        private int _index;
        private float _time;
        private bool _isRespawn;
        private bool _isMoving;

        private void OnEnable()
        {
            _index = 0;
            _time = 0;
        }

        public void Updating()
        {
            Timer();
        }

        
        public void Timer()
        {
            
            _time += Time.deltaTime;

            if (_time>= RespawnTime)
            {
                if (!_isRespawn)
                {
                    Respawn(_index, true);
                    _isRespawn = true;
                }

            }
            if(_time>=DelayBeforMove)
            {
                if (!_isMoving)
                {
                    StartMove();
                }
            }

            if(_time>=DelayBeforOff)
            {
                Respawn(_index, false);
                _isRespawn = false;
                _time = 0;
                _index++;
                if(_index >= PlatformStruct.SpawnPoints.Length)
                {
                    _index = 0;
                }
            }
        }

        private void Respawn(int index, bool isActive)
        {
            var randomIndex = Random.Range(0, PlatformStruct.SpawnPoints.Length);
            PlatformModel.Platform.transform.GetChild(index).gameObject.SetActive(isActive);
            PlatformModel.Platform.transform.position = PlatformStruct.SpawnPoints[randomIndex];
        }

        private void StartMove()
        {
            if (_time < MoveTime)
            {
                PlatformModel.Platform.transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime, Space.World);
            }
        }
       

    }
}