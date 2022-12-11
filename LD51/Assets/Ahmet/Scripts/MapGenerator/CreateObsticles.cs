using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObsticles : MonoBehaviour
{
    GameSingelton gameSingelton;
    AudioManager audioManager;
    public string type = "1";
    public GameObject[] wall;

    public Transform[] transforms;
    // Start is called before the first frame update
    void Start()
    {
        gameSingelton = GameSingelton.Instance;
        audioManager = AudioManager.instance;
        SetObsticles();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //-500 -400 -300 -200 -100 0 100 200 300 400 500 hard
    //-500 -300 -100 100 300 500 z eksenleri 6 x 7 mid
    //-500 100 300
    public void SetObsticles()
    {
        if (audioManager.diff == AudioManager.Diff.begginer)
        {
            if (type == "1")
            {
                int zPos = -500;
                for (int j = 0; j < 6; j++)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 400;
                }
                zPos = -500;
            }
            //-400 0 400
            //-400 -200 0 200 400 mid
            //-450 -350  -250 -150 -50 50 150 250 350 450 hard
            else if (type == "2")
            {
                int zPos = -400;
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 400;
                }
                zPos = -500;
            }
        }
        else if (audioManager.diff == AudioManager.Diff.mid)
        {
            if (type == "1")
            {
                int zPos = -500;
                for (int j = 0; j < 6; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 200;
                }
                zPos = -500;
            }
            //-400 -200 0 200 400 mid
            //-450 -350  -250 -150 -50 50 150 250 350 450 hard
            else if (type == "2")
            {
                int zPos = -400;
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 200;
                }
                zPos = -500;
            }
        }
        else if (audioManager.diff == AudioManager.Diff.hard)
        {
            if (type == "1")
            {
                int zPos = -500;
                for (int j = 0; j < 11; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 100;
                }
                zPos = -500;
            }
            //-400 -200 0 200 400 mid
            //-450 -350  -250 -150 -50 50 150 250 350 450 hard
            else if (type == "2")
            {
                int zPos = -450;
                for (int j = 0; j < 10; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int randomObstacle = Random.Range(0, wall.Length);
                        int _random = Random.Range(0, 7);
                        int randomX = Random.Range(0, 360);
                        int randomY = Random.Range(0, 360);
                        int randomZ = Random.Range(0, 360);
                        GameObject wallClone = Instantiate(wall[randomObstacle], transforms[_random].position + new Vector3(0, 0, zPos), Quaternion.Euler(randomX, randomY, randomZ));
                        wallClone.transform.SetParent(this.gameObject.transform);
                    }
                    zPos += 100;
                }
                zPos = -500;
            }
        }


    }
}
