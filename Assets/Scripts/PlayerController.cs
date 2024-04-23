using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveY, moveX;
    float rotX;
    private CharacterController characterController;
    [SerializeField] private Animator animator;
    public float sensivityRotate = 0.8f;
    [SerializeField] public GameObject hit;
    // Vector que contiene la velocidad actual del personaje.
    private Vector3 currentVelocity;


    private void Awake()
    {
        // Bloquear el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;

        // Hacer que el cursor sea invisible
        Cursor.visible = false;
    }
    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        
        
    }

    void Update()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        rotX = Input.GetAxis("Mouse X");

        // Obtén el vector de movimiento actual del CharacterController.
        currentVelocity = characterController.velocity;

        // Calcula la magnitud de la velocidad para obtener la velocidad total.
        float speed = currentVelocity.magnitude;

        //Forwad & Back
        if (moveY > 0f)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Back", false);
        }
        else if (moveY < 0f)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Back", true);
        }
        else if (moveY == 0f)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Back", false);
        }

        //Walk Left & Right
        if (moveX > 0f)
        {
            animator.SetBool("WalkR", true);
            animator.SetBool("WalkL", false);
        }
        else if (moveX < 0f)
        {
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", true);
        }
        else if (moveX == 0f)
        {
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
        }

        ////Turn
        //if (rotX > sensivityRotate)
        //{
        //    animator.SetBool("TurnR", true);
        //}
        //else if (rotX < -sensivityRotate)
        //{
        //    animator.SetBool("TurnL", true);
        //}
        //else
        //{
        //    animator.SetBool("TurnL", false);
        //    animator.SetBool("TurnR", false);
        //}

        //Attack
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("Attack", true);
            hit.gameObject.SetActive(true);

        }
        else
        {
            animator.SetBool("Attack", false);
            hit.gameObject.SetActive(false);
        }


        //Jump
        if (Input.GetButton("Jump"))
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }


        // Para desbloquear el cursor con una tecla específica (por ejemplo, Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
