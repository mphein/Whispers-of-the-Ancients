using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioEvents : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference menuMusic {get; private set; }

    public static AudioEvents instance {get; private set;}

    private void Awake(){
        if(instance != null){
            //Debug.LogError("Found more than one Audio Manager in scene");
        }
        instance = this;
    }
}
