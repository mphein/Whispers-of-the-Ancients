using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter(Collider obj) {
        if (obj.gameObject.tag == "Player") {
            Exit.exitInstance.WinConditionMet();
            Destroy(gameObject);
        }
    }
}
