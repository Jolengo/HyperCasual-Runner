using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonPlacer : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] public Fon[] FonPrefabs;
    [SerializeField] public Fon FirstFon;

     private List<Fon> spawnedFons = new List<Fon>();

    private void Start()
    {
        spawnedFons.Add(FirstFon);
    }

    private void Update()
    {
        if (Player.position.x > spawnedFons[spawnedFons.Count - 1].End.position.x - 20)
        {
            SpawnFon();
        }
    }

    private void SpawnFon()
    {
        Fon newFon = Instantiate(FonPrefabs[Random.Range(0, FonPrefabs.Length)]);

        newFon.transform.position = spawnedFons[spawnedFons.Count - 1].End.position - newFon.Begin.localPosition;

        spawnedFons.Add(newFon);

        if (spawnedFons.Count >= 4)
        {
            //Destroy(FirstFon);
            Destroy(spawnedFons[0].gameObject);
            spawnedFons.RemoveAt(0);
            
        }
    }
}
