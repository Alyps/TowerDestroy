using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield_Button : MonoBehaviour
{
    [SerializeField] GameObject cooldown_panel;
    [SerializeField] Button shield_button;
    [SerializeField] Shield_script shield_object;
    TMPro.TMP_Text text;
    
    [SerializeField] private int cooldown_time = 15; 
    private int timer;


    private void Start()
    {
        text = cooldown_panel.GetComponentInChildren<TMPro.TMP_Text>();
    }

    public void Shield_button_pressed()
    {
        if (shield_object.Activate())
        {
            StartCoroutine(CooldowmTimer());
        }
    }

    IEnumerator CooldowmTimer()
    {
        timer = cooldown_time;
        shield_button.interactable = false;
        cooldown_panel.SetActive(true);
        while (timer > 0)
        {
            if (timer >= 10)
            {
                text.text = "0:" + timer.ToString();
            }
            else if (timer < 10)
            {
                text.text = "0:0" + timer.ToString();
            }
            yield return new WaitForSeconds(1f);
            timer--;
        }
        shield_button.interactable = true;
        cooldown_panel.SetActive(false);
    }

    public void ResetShield()
    {
        StopAllCoroutines();
        shield_button.interactable = true;
        cooldown_panel.SetActive(false);
        shield_object.gameObject.SetActive(false);
    }


}
