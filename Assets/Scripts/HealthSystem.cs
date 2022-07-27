using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float max_health = 20;
    private float current_health;

    public bool dead { get; private set; }

    [SerializeField] Image HP_bar;
    private Rect HP_rect;



    private void Start()
    {
        current_health = max_health;
        HP_rect = HP_bar.rectTransform.rect;
        dead = false;
    }

    public void TakeDamage(float damage)
    {
        if (!dead)
        {
            current_health -= damage;
            if (current_health <= 0)
            {
                dead = true;
            }
            HP_bar.rectTransform.sizeDelta = new Vector2((1 - (current_health / max_health)) * -HP_rect.width, 0);
            HP_bar.rectTransform.anchoredPosition = new Vector2((1 - (current_health / max_health)) * -HP_rect.width * 0.5f, 0f);
        }
    }

    public void Restart_hp()
    {
        current_health = max_health;
        HP_bar.rectTransform.sizeDelta = new Vector2(0, 0);
        HP_bar.rectTransform.anchoredPosition = new Vector2(0, 0f);
        dead = false;
    }


}
