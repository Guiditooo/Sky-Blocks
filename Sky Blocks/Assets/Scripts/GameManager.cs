using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Transform tower;
    [SerializeField] private Transform crane;

    [SerializeField] private Transform spawn;

    [SerializeField] [Range(0,1.2f)]private float spawnCooldown;

    [SerializeField] private GameObject blockAnchor;
    [SerializeField] private Transform floor;

    [SerializeField] private Block_Controller currentBlock;

    private bool canSpawnOther = true;
    private HingeJoint blockJoint;

    private float lerperTime = 0;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

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
        if (lerperTime > time)
            lerperTime = 0;
    
        yield return new WaitForSeconds(time);

        lerperTime += Time.deltaTime;

        canSpawnOther = true;

        var go = Instantiate(block, spawn.position, spawn.rotation, tower);
        currentBlock = go.GetComponent<Block_Controller>();
        go.GetComponent<Spawn_Configurator>().SetAnchorObject(blockAnchor);
        go.GetComponent<Spawn_Configurator>().SetFloor(floor);
        go.tag = "ActualBlock";
        /*Vector3 auxCamPos = Camera.main.transform.position;
        Vector3 auxCranePos = crane.position;

        Camera.main.transform.position = Vector3.Lerp(auxCamPos, new Vector3(auxCamPos.x, auxCamPos.y + block.transform.localScale.y * 2, auxCamPos.z), lerperTime / time);
        crane.transform.position = Vector3.Lerp(auxCranePos, new Vector3(auxCranePos.x, auxCranePos.y + block.transform.localScale.y * 2, auxCranePos.z), lerperTime / time);
    */}

}
