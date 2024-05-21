using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Checkpuzzle1 : MonoBehaviour
{

    [SerializeField]
    private Transform DinosaurTransform, TurttleTransform, BearTransform, RaindeerTransform;

    [SerializeField]
    private Transform DinosaurSocketTransform, TurttleSocketTransform, BearSocketTransform, RaindeerSocketTransform;

    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DinosaurTransform == DinosaurSocketTransform)
        {
            audioSource.Play();
        }

    }
}
