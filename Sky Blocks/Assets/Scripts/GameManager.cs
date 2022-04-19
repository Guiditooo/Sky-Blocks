using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Transform tower;

    [SerializeField] private Transform spawn;

    [SerializeField] [Range(0,1.2f)]private float spawnCooldown;

    [SerializeField] private GameObject blockAnchor;
    [SerializeField] private Transform floor;

    [SerializeField] private Block_Controller currentBlock;

    private bool canSpawnOther = true;
    private HingeJoint blockJoint;

    private void Update()
    {
        if (canSpawnOther)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentBlock.DropBlock();

                canSpawnOther = false;
                StartCoroutine(SpawnerTimer(spawnCooldown));
            }
        }
    }

    IEnumerator SpawnerTimer(float time)
    {
        yield return new WaitForSeconds(time);
        canSpawnOther = true;

        var go = Instantiate(block, spawn.position, spawn.rotation, tower);
        currentBlock = go.GetComponent<Block_Controller>();
        go.GetComponent<Spawn_Configurator>().SetAnchorObject(blockAnchor);
        go.GetComponent<Spawn_Configurator>().SetFloor(floor);
    }

}
