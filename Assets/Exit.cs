using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Player player;
    public GameObject exitPanel;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        exitPanel.SetActive(true);
        player.speed = 0;
    }

    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
