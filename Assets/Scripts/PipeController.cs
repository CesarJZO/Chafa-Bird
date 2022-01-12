using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float waitingTime = 1;
    void Awake()
    {
        StartCoroutine("PlacePipe");
    }
    IEnumerator PlacePipe()
    {
        if (BirdController.Hit)
            yield return null;
        float height = Random.Range(-5, 5);
        Instantiate(pipePrefab, new Vector3(20, height, 0), Quaternion.identity);
        yield return new WaitForSeconds(waitingTime);
        if (!BirdController.Hit)
            StartCoroutine("PlacePipe");
    }
}
