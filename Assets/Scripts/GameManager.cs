using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }


    // Variable para almacenar la puntuación
    [SerializeField] private int score;
    public TextMeshProUGUI objetivo;

    void Awake()
    {
        // Asegúrate de que solo haya un GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Elimina cualquier instancia adicional
        }
    }

    private void Start()
    {
        score = 10;
    }

    // Método para agregar puntos
    public void AddScore(int points)
    {
        score += points;

        //Debug.Log("Score: " + score); // Imprime la puntuación actual
    }

    // Método para restar puntos
    public void SubtractScore(int points)
    {
        score -= points;
        //Debug.Log("Score: " + score); // Imprime la puntuación actual
    }

    // Método para obtener la puntuación actual
    public int GetScore()
    {
        return score;
    }
    private void Update()
    {
        if (score > 0)
        {
            objetivo.text = score.ToString();
        }
        

        if(score <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("MenuScene");
        }
    }
}
