using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectSpawner : Spawner
    {
        [SerializeField] private bool applyForce;
        [SerializeField] private float forceMultiplier;

        protected override void ApplyForce(GameObject newObj)
        {
            if (applyForce)
            {
                var rb = newObj.GetComponent<Rigidbody2D>();
                rb.velocity = transform.up * forceMultiplier;
            }
        }
    }
}