using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        private Rigidbody2D rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Hit(int damage)
        {
            //rb.AddForce(Vector2.up * 10.0f, ForceMode2D.Force);
            rb.velocityY = 3.0f;
            
            StartCoroutine(HitSprite());
        }

        private IEnumerator HitSprite()
        {
            var mat = sprite.material;
            var lerpValue = 0.0f;
            while (lerpValue <= 1.0f)
            {
                lerpValue += Time.deltaTime * 5.0f;
                
                var color = Mathf.LerpUnclamped(10.0f, 0.0f, lerpValue);
                mat.SetFloat("_Glow", color);
                yield return null;
            }
            
            mat.SetFloat("_Glow", 0.0f);
        }
    }
}