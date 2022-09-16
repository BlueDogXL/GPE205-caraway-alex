using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<KeyboardController> players;
    public GameObject playerControllerPrefab;
    public GameObject pawnPrefab;
    // TODO: make sure these are right
    [Header("State Screen Objects")]
    public GameObject titleScreenStateObject;
    public GameObject mainScreenStateObject;
    public GameObject gameScreenStateObject;
    public GameObject pauseScreenStateObject;
    public GameObject gameOverScreenStateObject;
    [Header("Game Options")]
    public int numberOfPlayers;
    public bool isMapOfTheDay;
    public float sfxVolume;
    public float musicVolume;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Print");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SpawnPlayer(0);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //  for testing press p
        if (Input.GetKeyDown(KeyCode.P)){
            
        }
    }
    public void SpawnPlayer(int playerNumber)
    {
        GameObject newPlayer = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject newPawnObj = Instantiate(pawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController = newPlayer.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;

        if (newPawn != null)
        {
            if (players.Count > playerNumber)
            {
                players[playerNumber].pawn = newPawn;
            }
        }
    }
}
