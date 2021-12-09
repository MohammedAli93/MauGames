using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    public GameObject[] sections;
    public int zPos = 40;
    public bool creatingSection = false;

    public int secNum;

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 2);
        Instantiate(sections[secNum], new Vector3(-16, -19, zPos), Quaternion.identity);
        zPos += 40;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
