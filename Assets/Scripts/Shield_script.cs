using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_script : MonoBehaviour
{
    [SerializeField] private float shield_hp = 3;
    private float curent_health = 3;

    public void TakeDamage(float damage)
    {
        curent_health -= damage;
        if (curent_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public bool Activate()
    {
        if (!gameObject.activeSelf)
        {
            curent_health = shield_hp;
            gameObject.SetActive(true);
            return true;
        }

        return false;
    }
}
