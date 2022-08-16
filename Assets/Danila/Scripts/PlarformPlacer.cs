using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlarformPlacer : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] public Plarform[] PlarformPrefabs;
    [SerializeField] public Plarform FirstPlarform;

    private List<Plarform> spawnedPlarforms = new List<Plarform>();

    private void Start()
    {
        spawnedPlarforms.Add(FirstPlarform);
    }

    private void Update()
    {
        if (Player.position.x > spawnedPlarforms[spawnedPlarforms.Count - 1].End.position.x - 30)
        {
            SpawnPlarform();
        }
    }

    private void SpawnPlarform()
    {
        Plarform newPlarform = Instantiate(GetRandomPlatfrom());

        newPlarform.transform.position = spawnedPlarforms[spawnedPlarforms.Count - 1].End.position - newPlarform.Begin.localPosition;

        spawnedPlarforms.Add(newPlarform);

        if (spawnedPlarforms.Count >= 5)
        {
            Debug.Log(spawnedPlarforms[0].gameObject);
            Destroy(spawnedPlarforms[0].gameObject);
            spawnedPlarforms.RemoveAt(0);
            Destroy(FirstPlarform.gameObject);
        }
    }

    private Plarform GetRandomPlatfrom()
    {
        List<float> chances = new List<float>();
        for (int i = 0; i < PlarformPrefabs.Length; i++)
        {
            chances.Add(PlarformPrefabs[i].ChanceFromDistance.Evaluate(Player.transform.position.x));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return PlarformPrefabs[i];
            }
        }

        return PlarformPrefabs[PlarformPrefabs.Length - 1];


    }
}
    