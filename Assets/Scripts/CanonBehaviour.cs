using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject canonball_instant;
    [SerializeField] private Transform shooting_point;
    [SerializeField] private Transform muzzle;
    [SerializeField] private string aim_tag;
    [SerializeField] private HealthSystem health;

    private bool able_to_shoot = true;
    [SerializeField] private float shoot_reload_time = 0.5f;

    public void Shoot()
    {
        if (able_to_shoot && !health.dead)
        {
            GameObject new_canonball = Instantiate(canonball_instant, shooting_point.position, shooting_point.rotation);
            new_canonball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(800f, 0));
            new_canonball.tag = aim_tag;
            able_to_shoot = false;
            StartCoroutine(Shoot_reload());
        }
    }

    public void RotateMuzzle(float Zrotation)
    {
        if (Zrotation > 0 && muzzle.transform.rotation.z <= 0.4)
        {
            muzzle.Rotate(new Vector3(0, 0, Zrotation));
        }
        if (muzzle.transform.rotation.z >= -0.4 && Zrotation < 0)
        {
            muzzle.Rotate(new Vector3(0, 0, Zrotation));
        }
    }

    IEnumerator Shoot_reload()
    {
        yield return new WaitForSeconds(shoot_reload_time);
        able_to_shoot = true;
    }
}
