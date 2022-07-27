using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private CanonBehaviour canon;
    private Shield_script shield;

    private void Start()
    {
        canon = GetComponentInChildren<CanonBehaviour>();
        shield = GetComponentInChildren<Shield_script>(true);
        StartCoroutine(EnemyShooting());
        StartCoroutine(ActivateShield());
    }

    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.6f, 0.8f));
            canon.Shoot();
        }
    }

    IEnumerator ActivateShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(8f, 15f));
            shield.Activate();
        }
    }


}
