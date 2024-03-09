using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    public static StaminaSystem staminaSystemInstance;
    const float MAX_STAMINA = 10000;
    public float currStamina = MAX_STAMINA;
    public bool canSprint = true;

    void Awake() {
        staminaSystemInstance = this;
    }

    public bool CanSprint() {
        return canSprint;
    }

    public void Sprint() {
        if (currStamina > 0) currStamina--; 
        else {
            canSprint = false;
            RegainStamina();
        }
    }

    public void RegainStamina() {
        if (currStamina < MAX_STAMINA) currStamina++;
        if (currStamina == MAX_STAMINA) canSprint = true;
    }
}
