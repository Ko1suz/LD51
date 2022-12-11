using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject carPrefab;

    public Transform[] wayPoints;

    public int carAmount = 24;

    private void Start()
    {
        StartCoroutine(SpawnThings());
    }

    IEnumerator SpawnThings()
    {
        int i = 1;
        float zPos = GameSingelton.Instance.player.transform.position.z;
        Debug.Log("Start" + i + " " + zPos);
        while (i < carAmount)
        {
            Vector3 pos = wayPoints[Random.Range(0, wayPoints.Length)].position;
            GameObject obj = Instantiate(carPrefab, pos, Quaternion.identity, this.transform);
            obj.transform.position = pos + new Vector3(Random.Range(-10,10), Random.Range(-80, 150), Random.Range(-80, 150));
            i++;
        }

        yield return null;

    }
}
