using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScared : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private bool dead  = false;
    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Scared", true);
            audioS.enabled = true;
        }
        if (other.CompareTag("Hit") && !dead)
        {
            dead = true;
            
            StartCoroutine(WaitAndExecute(1f));
            audioS.enabled = false;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Scared", false);
            audioS.enabled = false;
        }
    }

    IEnumerator WaitAndExecute(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Dead", true);
        GetComponentInParent<BoxCollider>().enabled = false;
        GameManager.Instance.SubtractScore(1);
    }
}
