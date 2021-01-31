//Author: Kingyan Incorporated

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public static StaminaBar instance;
    public bool canRun = true;

    [SerializeField] int maxStamina = 100;
    [SerializeField] int regenTime = 2;
    [SerializeField] float currentStamina;
    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Uses a set amount of stamina, then regenerates it after 2 seconds.
    /// </summary>
    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            canRun = true;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            canRun = false;
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(regenTime);

        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            canRun = true;
            yield return regenTick;
        }

        regen = null;
    }
}
