using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public Timer timerScript;
    public PlayerMovement playerMovement;
    [SerializeField] public static float distanceTraveled;
    [SerializeField]  public static int minutes;
    [SerializeField] public static int seconds;
    [SerializeField] public static float time;
   
    
    private void Awake()
    {    
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Salir del juego
            Application.Quit();

            // Si estás en el editor de Unity, detén la reproducción
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            time += Timer.elapsedTime;
            minutes = Timer.minutes;
            seconds = Timer.seconds;
            distanceTraveled = playerMovement.getdistanceTraveled();
            SceneManager.LoadScene(2);
        }   
    }
}
