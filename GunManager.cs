using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    //Naming consisitency. You don't need to follow the Microsoft naming convention but you should be consistent
    public List<GameObject> Guns = new List<GameObject>();


    public Transform GunPos;
    private int _startNumber;
    private GameObject _currentGun;
    public GameObject StartGun;
    private GameObject _activeGun;

    //This defaults to null if not assigned a value
    int _index;
    private bool _hasAGun;

    public PickupController PickupController;

    // Start is called before the first frame update
    void Start()
    {
        //This needs to be reordered.
        //_index is null before it is assigned a value of 0 so we need to rearange this

        //Add a gun to the list of guns
        Guns.Add(StartGun);
        //Assign the value of _index
        _index = 0;
        _currentGun = Instantiate(Guns[_index], GunPos.transform.position, GunPos.transform.rotation);
        //Add a null check just incase something went wrong
        if(_currentGun != null )
            _hasAGun = true;

        //These two lines are taken care of in the Instantiate call
        /*_currentGun.transform.position = GunPos.transform.position;
        _currentGun.transform.rotation = GunPos.transform.rotation;*/
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.J) && Guns.Count > 1)
        {

            _index += 1;
            Destroy(_currentGun.gameObject);
            _activeGun = Instantiate(Guns[_index], GunPos.transform.position, GunPos.transform.rotation);

        }
        if (_index > Guns.Capacity)
        {
            _index = 1;
        }

     
            _currentGun = Guns[_index];
            _currentGun.transform.position = GunPos.transform.position;
            _currentGun.transform.rotation = GunPos.transform.rotation;
        

        Debug.Log(_index);
    }
    public void NewObjectCollected(GameObject ObjectCollected)
    {
        Guns.Add(ObjectCollected.gameObject);
        Destroy(_currentGun.gameObject);
        _index += 1;
        _currentGun = Instantiate(Guns[_index], GunPos.transform.position, GunPos.transform.rotation);
    }
}
