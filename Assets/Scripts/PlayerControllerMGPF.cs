using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMGPF : MonoBehaviour
{
    public GameObject destinationPrefab;
    public NavMeshAgent navMeshAgent;

    public GameObject pria, wanita;
    RaycastHit hit;


    private void Start()
    {
        LoadData();

    }
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

    //Load save an
    public void LoadData()
    {
        //Ambil data jenis kelamin
        if (GameManager.instance.GameSave.JenisKelamin == "Pria")
        {
            pria.SetActive(true);
            wanita.SetActive(false);
        }
        else
        {
            pria.SetActive(false);
            wanita.SetActive(true);
        }
    }

}
