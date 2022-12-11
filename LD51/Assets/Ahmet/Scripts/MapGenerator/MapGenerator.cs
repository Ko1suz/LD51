using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    GameSingelton gameSingelton;
    Transform playerTrans;
    [Header("Dimensions")]
    public GameObject Dimension_1;
    public GameObject Dimension_2;

    [Header("Walls")]
    public GameObject Wall;





    private float lastDMSpos = 500;
    private float targetDistance = 500;


    // Start is called before the first frame update
    void Start()
    {
        gameSingelton = GameSingelton.Instance;
        playerTrans = gameSingelton.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCal();
    }


    void DistanceCal() //500 1500 2500 3500 4500 
    {
        if (gameSingelton.player.transform.position.z >= targetDistance)
        {
            lastDMSpos += 1000;
            CreateNewDeminsion_1(Dimension_1);
            CreateNewDeminsion_2(Dimension_2);
            targetDistance += 1000;
            if (gameSingelton.dimensionTransform.Dimensions_2.Capacity > 2)
            {
                Destroy(gameSingelton.dimensionTransform.Dimensions_2[0].gameObject);
                gameSingelton.dimensionTransform.Dimensions_2.Remove(gameSingelton.dimensionTransform.Dimensions_2[0]);
            }
            if (gameSingelton.dimensionTransform.Dimensions_1.Capacity > 2)
            {
                Destroy(gameSingelton.dimensionTransform.Dimensions_1[0].gameObject);
                gameSingelton.dimensionTransform.Dimensions_1.Remove(gameSingelton.dimensionTransform.Dimensions_1[0]);
            }


        }
    }

    void CreateNewDeminsion_1(GameObject _dimension)
    {
        GameObject cloneDimension = Instantiate(_dimension, new Vector3(0, -7, lastDMSpos), _dimension.transform.rotation);
        if (gameSingelton.dimensionTransform.dimension_1 == false){cloneDimension.SetActive(false);}
        gameSingelton.dimensionTransform.Dimensions_1.Add(cloneDimension);
        cloneDimension.GetComponent<CreateObsticles>().type = "1";
    }

    void CreateNewDeminsion_2(GameObject _dimension)
    {
        GameObject cloneDimension = Instantiate(_dimension, new Vector3(0, -7, lastDMSpos), _dimension.transform.rotation);
        if (gameSingelton.dimensionTransform.dimension_1 == true){cloneDimension.SetActive(false);}
        gameSingelton.dimensionTransform.Dimensions_2.Add(cloneDimension);
        cloneDimension.GetComponent<CreateObsticles>().type = "2";
    }


}
