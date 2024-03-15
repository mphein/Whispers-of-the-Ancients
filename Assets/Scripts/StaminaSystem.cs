using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    public static StaminaSystem staminaSystemInstance;
    const int MAX_STAMINA = 3000;
    public int currStamina;
    public bool canSprint = true;
    public Slider staminaBar;
    public Image staminaFill;

    void Awake() {
        staminaSystemInstance = this;
    }

    void Start() {
        currStamina = MAX_STAMINA;
        staminaBar.maxValue = MAX_STAMINA;
        staminaBar.value = MAX_STAMINA;
    }

    public bool CanSprint() {
        return canSprint;
    }

    public void Sprint() {
        if (currStamina >= 0) {
            currStamina--;
            staminaBar.value = currStamina;
        } else {
            canSprint = false;
            staminaFill.color = new Color(190/255f, 0, 0);
        }
    }

    public void RegainStamina() {
        if (currStamina < MAX_STAMINA) {
            currStamina++;
            staminaBar.value = currStamina;
        }
        if (currStamina == MAX_STAMINA) {
            canSprint = true;
            staminaFill.color = new Color(108/255f, 217/255f, 62/255f);
        }
    }
}
