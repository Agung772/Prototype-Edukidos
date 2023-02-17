using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMGPF : MonoBehaviour
{
    public GameObject destinationPrefab;
    public NavMeshAgent navMeshAgent;
    RaycastHit hit;
    bool click;
    void Update()
    {



        if (navMeshAgent.remainingDistance == 0)
        {

        }
        else if (navMeshAgent.remainingDistance < 0.1f)
        {
            DestroyDestination();
        }

    }
    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyDestination();
        }
    }
    public void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                navMeshAgent.SetDestination(hit.point);

                SpawndDestination();
            }
        }
    }

    void SpawndDestination()
    {
        Instantiate(destinationPrefab, hit.point + new Vector3(0, 0, 0), Quaternion.identity);
    }
    void DestroyDestination()
    {
        if (GameObject.FindObjectOfType<Destination>() != null)
        {
            GameObject distinationObject = GameObject.FindObjectOfType<Destination>().gameObject;
            Destroy(distinationObject);
        }

    }

}
