using UnityEngine;

namespace LastStandingSheep
{
    public class TriggerController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Sheep"))
            {
                 _rigidbody.AddForce((collision.transform.forward+Vector3.up ) * 3, ForceMode.Impulse);
            }


        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Ocean"))
            {
                _animator.Play("Sheep|Die");
                Destroy(gameObject, 2f);
                
            }
        }
    }
}