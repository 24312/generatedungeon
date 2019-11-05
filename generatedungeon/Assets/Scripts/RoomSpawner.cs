using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 = bot
    // 2 = top
    // 3 = left
    // 4 = right

    private Roomtemplates Templates;
    private int Rand;
    private bool Spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        Templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (Spawned == false){
            if (openingDirection == 1)
            {
                Rand = Random.Range(0, Templates.BotRooms.Length);
                Instantiate(Templates.BotRooms[Rand], transform.position, Templates.BotRooms[Rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                Rand = Random.Range(0, Templates.TopRooms.Length);
                Instantiate(Templates.TopRooms[Rand], transform.position, Templates.TopRooms[Rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                Rand = Random.Range(0, Templates.LeftRooms.Length);
                Instantiate(Templates.LeftRooms[Rand], transform.position, Templates.LeftRooms[Rand].transform.rotation);

            }
            else if (openingDirection == 4)
            {
                Rand = Random.Range(0, Templates.RightRooms.Length);
                Instantiate(Templates.RightRooms[Rand], transform.position, Templates.RightRooms[Rand].transform.rotation);
            }
            Spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            Destroy(gameObject);
        }
    }
}
