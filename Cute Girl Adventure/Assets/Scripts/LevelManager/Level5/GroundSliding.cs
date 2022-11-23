using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GroundSliding : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] float speed;
    [SerializeField] PlayableDirector phiCaught;

    [HideInInspector] public bool gameStarted;

    void Update()
    {
        if(gameStarted)
        {
            objectToMove.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (DeathTrigger.instance.endRoad)
            {
                speed = 0;
                phiCaught.enabled = true;
                StartCoroutine(DialogueSystem.instance.TypingDialogue(2.6f));
                gameStarted = false;
            }
            else if(DeathTrigger.instance.isDead)
            {
                speed = 0;
            }
        }
    }
}
