using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string LevelName;
    public GameObject player;

    public float x;
    public float y;
    public float z;
    public AudioSource lightsOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Valve.VR.SteamVR_Fade.Start(Color.black, 0.5f);
            StartCoroutine(waiter());
            
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LevelName);
        player.transform.position = new Vector3(x, y, z);
        lightsOn.Play();
        yield return new WaitForSeconds(1f);
        GiveCommand.StaticPostRequest("CompleteLevel");
        Valve.VR.SteamVR_Fade.Start(Color.white, 0f);
        Valve.VR.SteamVR_Fade.Start(Color.clear, 0.5f);



    }
}
