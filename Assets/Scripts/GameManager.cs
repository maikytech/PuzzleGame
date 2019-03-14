using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject finalPortal;
    public GameObject player;
    public Transform spawnPoint;
    public AudioClip[] collectableClips;


    private int itemsPerlevel = 3;
    private int points = 0;
    private int itemAmnt = 0;
    private int playerLifes = 3;
    private int hightScore;
    private bool stopMovement = false;
    private bool playerMovement = true;
    private AudioSource sounds;


    //Encapsulamiento de datos a traves de propiedades.
    public bool StopMovement {
        get { return stopMovement; }
    }

    private void Awake()
	{
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
	}

	
	void Start ()
    {
        SpawnPlayer();

        //GetInt retorna el valor correspondiente a la llave Score, si no tiene nada o no existe, por default definimos 0.
        hightScore = PlayerPrefs.GetInt("Score", 0);
        sounds = GetComponent<AudioSource>();
	}
	

	void Update () {

        if(itemsPerlevel <= itemAmnt)
        {
            EnablePortal(true);
        }
    }

    public void PickItem(){
        points += 10;
        itemAmnt++;
        sounds.PlayOneShot(collectableClips[1]);

        //print("Los puntos ganados son: " + points);

    }

    public void PickCoin()
    {
        points += 5;
        sounds.PlayOneShot(collectableClips[0]);
    }

    public void LoseLife(){
        if(playerLifes > 1){
            playerLifes--;
            KillPlayer();
            Invoke("SpawnPlayer", 1f);
        }else{
            playerLifes = 0;
            FinishGame();
        }

    }

    public void EnablePortal(bool isEnable){
        finalPortal.SetActive(isEnable);
        stopMovement = isEnable;
    }

    public void PlayerMove(bool canMove){
        playerMovement = canMove;
    }

    public void SpawnPlayer(){
        player.SetActive(true);
        PlayerMove(true);
        player.transform.position = spawnPoint.position;
    }

    public void KillPlayer(){
        PlayerMove(false);
        player.SetActive(false);
    }

    public void LevelCompleted()
    {
        PlayerMove(false);


        if(points > hightScore)
        {
            //Si el puntaje en points es mayor que lo que teniamos en Score, entonces reescribimos Score.
            PlayerPrefs.SetInt("Score", points);
            hightScore = points;
            
        }

        print("La puntuacion maxima es : " + hightScore);
        Invoke("LoadScene", 5f);
    }

    public void PlayAgain()
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        KillPlayer();
        stopMovement = true;
    }
}
