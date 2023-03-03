using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerMGPF : MonoBehaviour
{
    public GameObject destinationPrefab;
    public NavMeshAgent navMeshAgent;
    public Transform cameraMetaGame;

    public GameObject pria, wanita;
    public AnimatorKarakter animatorKarakter;


    RaycastHit hit;
    string conditionAnimasi;

    //Anti typo
    [HideInInspector]
    public string 
        _Idle = "Idle", 
        _Walk = "Walk", 
        _Tegak = "Tegak", 
        _Interaksi = "Interaksi", 
        _Senang = "Senang", 
        _Sedih = "Sedih";


    private void Start()
    {
        LoadData();

    }
    void Update()
    {
        if (navMeshAgent == null) return;

        if (navMeshAgent.remainingDistance == 0)
        {

        }
        else if (navMeshAgent.remainingDistance < 0.1f)
        {
            DestroyDestination();
        }

        //Animasi
        if (navMeshAgent.remainingDistance == 0 && conditionAnimasi != "Idle")
        {
            conditionAnimasi = "Idle";
            print("Idle");

        }
        else if (navMeshAgent.remainingDistance > 0.1f && conditionAnimasi != "Walk")
        {
            conditionAnimasi = "Walk";
            print("Sedang jalan");
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
        if (SaveManager.instance.GameSave.karakter == "Cowok")
        {
            pria.SetActive(true);
            wanita.SetActive(false);
        }
        else
        {
            pria.SetActive(false);
            wanita.SetActive(true);
        }

        //PosisiPlayer
        navMeshAgent.enabled = false;
        transform.position = SaveManager.instance.GameSave.posisiPlayer;
        cameraMetaGame.position = transform.position + cameraMetaGame.gameObject.GetComponent<CameraFollow>().offset;
        navMeshAgent.enabled = true;
    }

}
