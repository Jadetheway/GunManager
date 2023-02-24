using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public List<GameObject> Guns = new List<GameObject>();


    public Transform gunPos;
    private int startNumber;
    private GameObject currentGun;
    public GameObject startGun;
    private GameObject ActiveGun;

    int index;
    private bool hasAGun;

    public PickupController PickupController;

    // Start is called before the first frame update
    void Start()
    {
        Guns.Add(startGun);
        currentGun = Instantiate(Guns[index], gunPos.transform.position, gunPos.transform.rotation);
        index = 0;
        currentGun = Guns[index];
        hasAGun = true;
        currentGun.transform.position = gunPos.transform.position;
        currentGun.transform.rotation = gunPos.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.J) && Guns.Count > 1)
        {

            index += 1;
            Destroy(currentGun.gameObject);
            ActiveGun = Instantiate(Guns[index], gunPos.transform.position, gunPos.transform.rotation);

        }
        if (index > Guns.Capacity)
        {
            index = 1;
        }

     
            currentGun = Guns[index];
            currentGun.transform.position = gunPos.transform.position;
            currentGun.transform.rotation = gunPos.transform.rotation;
        

        Debug.Log(index);
    }
    public void NewObjectCollected(GameObject ObjectCollected)
    {
        Guns.Add(ObjectCollected.gameObject);
        Destroy(currentGun.gameObject);
        index += 1;
        currentGun = Instantiate(Guns[index], gunPos.transform.position, gunPos.transform.rotation);
    }
}
