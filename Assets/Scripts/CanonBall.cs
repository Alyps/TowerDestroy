using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [SerializeField] private float life_time = 2f;
    [SerializeField] private float damage = 1;
    private void Start()
    {
        StartCoroutine(DestroyInTime());
    }

    IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(life_time);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag)
        {
            if (collision.TryGetComponent<HealthSystem>(out HealthSystem entity))
            {
                entity.TakeDamage(damage);
                Destroy(gameObject);
            }

            if (collision.GetComponentInParent<Shield_script>() != null)
            {
                collision.GetComponentInParent<Shield_script>().TakeDamage(damage);
                Destroy(gameObject);
            }

        }
    }
}
