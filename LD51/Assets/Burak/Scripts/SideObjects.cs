using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideObjects : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public float xPos;
    public int spawnAmount;
    public float zDist = 10;

    public bool isNeg = false;

    public GameObject player;

    public bool canSpawn = true;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(canSpawn)
            StartCoroutine(SpawnThings());
    }
    IEnumerator SpawnThings()
    {
        int i = 1;
        float zPos = player.transform.position.z + 100;
        Debug.Log("Start" + i + " " + zPos);
        while (i < spawnAmount)
        {
            if (isNeg)
            {
                GameObject obj = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj.transform.position = new Vector3(xPos, obj.transform.position.y - 2000, zPos + zDist + (i * 600));
                GameObject obj2 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj2.transform.position = new Vector3(-xPos, obj.transform.position.y - 2000, zPos + zDist + (i * 600));
                GameObject obj3 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj3.transform.position = new Vector3(xPos * 2, obj.transform.position.y - 2000, zPos + zDist + (i * 600));
                GameObject obj4 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj4.transform.position = new Vector3(-xPos * 2, obj.transform.position.y - 2000, zPos + zDist + (i * 600));
                GameObject obj5 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj5.transform.position = new Vector3(xPos * 4, obj.transform.position.y - 2000, zPos + zDist + (i * 600));
                GameObject obj6 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj6.transform.position = new Vector3(-xPos * 4, obj.transform.position.y - 2000, zPos + zDist + (i * 600));


                obj.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj2.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj3.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj4.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj5.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj6.transform.DOMoveY(obj.transform.position.y + 1200, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                i++;
            }
            else
            {

                GameObject obj = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj.transform.position = new Vector3(xPos, obj.transform.position.y + 2000, zPos + zDist + (i * 600));
                GameObject obj2 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj2.transform.position = new Vector3(-xPos, obj.transform.position.y + 2000, zPos + zDist + (i * 600));
                GameObject obj3 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj3.transform.position = new Vector3(xPos * 2, obj.transform.position.y + 2000, zPos + zDist + (i * 600));
                GameObject obj4 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj4.transform.position = new Vector3(-xPos * 2, obj.transform.position.y + 2000, zPos + zDist + (i * 600));
                GameObject obj5 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj5.transform.position = new Vector3(xPos * 4, obj.transform.position.y + 2000, zPos + zDist + (i * 600));
                GameObject obj6 = Instantiate(objects[Random.Range(0, objects.Count)], this.transform);
                obj6.transform.position = new Vector3(-xPos * 4, obj.transform.position.y + 2000, zPos + zDist + (i * 600));

                obj.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj2.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj3.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj4.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj5.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                obj6.transform.DOMoveY(obj.transform.position.y - 2000, Random.Range(8f, 15f)).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
                i++;
            }

        }

        yield return null;

    }
}
