using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] private Vector2 spawnRate;

        
        private float currentSpawnRate;
        private float timer;

        private void Start()
        {
            timer = 0.0f;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                var newObj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                ApplyForce(newObj);
                timer = CalcSpawnRate();
            }
        }

        protected virtual void ApplyForce(GameObject newObj)
        {
            
        }

        private float CalcSpawnRate()
        {
            return Random.Range(spawnRate.x, spawnRate.y);
        }
    }
}