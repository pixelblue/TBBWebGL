using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float speedIncreaseValue = 10.0f;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private LayerMask enemyLayer;

        private float speedIncrease;
        private void Update()
        {
            speedIncrease += Time.deltaTime * speedIncreaseValue;
            transform.position += Vector3.up * (speed + speedIncrease) * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if(((1<<coll.gameObject.layer) & enemyLayer) != 0)
            {
                var enemyCtrl = coll.GetComponent<EnemyController>();
                if(enemyCtrl != null) enemyCtrl.Hit(1);
                Destroy(this.gameObject);
            }

            if(((1<<coll.gameObject.layer) & wallLayer) != 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}