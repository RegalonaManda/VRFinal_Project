using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Checkpuzzle1 : MonoBehaviour
{

    [SerializeField]
    private AudioSource hoverSource, selectedSource;
    [SerializeField]
    private Transform PlayerTransform, Level2StartPosition;


    private bool dinosaurCheck = false, turttleCheck = false, bearCheck = false, reindeerCheck = false;
    private bool minigameCompleted = false;

    // Update is called once per frame
    void Update()
    {
        
        if(turttleCheck == true && dinosaurCheck == true && bearCheck == true && reindeerCheck == true)
        {
            minigameCompleted = true;
        }

        if(minigameCompleted == true)
        {
            Debug.Log("Minigame 1 finished");
            PlayerTransform.position = Level2StartPosition.position;
        }

    }

    public void PuzzleCheck(int i)
    {
        switch (i)
        {
            case 0:
                turttleCheck = true;
                break;
            case 1:
                dinosaurCheck = true;
                break;
            case 2: bearCheck = true;
                break;
            case 3: reindeerCheck = true;
                break;
            default: break;
        }
    }

    public void HoverSound()
    {
        hoverSource.Play();
    }

    public void SelectedSound()
    {
        selectedSource.Play();
    }


}
