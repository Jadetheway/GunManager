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
            Destroy(_currentGun.gameObject);//This can be simplified to Destroy(_currentGun) because it already is a GameObject
            //There needs to be a check here to be sure that the index is not higher than the (List.Count-1)
            //A cool way to do this is using the Modulus (%) operator 
                //Modulus is the remainder from long division For example 1%2 = 1 because 2 does not go into 1 evenly and 1 is leftover, 2%2 = 0 because 2 goes into 2 evenly so there is nothing leftover
            _index = _index % Guns.Count;//This will make sure that the index never goes above the size of the list
            _activeGun = Instantiate(Guns[_index], GunPos.transform.position, GunPos.transform.rotation);

        }
        /*if (_index > Guns.Capacity)//Capacity is not the same as count and can be larger than total amount of items in the list
        {
            _index = 1;
        }*/

        //Unless you specifically want _activeGun and _currentGun to be different. this could be simplified to _currentGun = _activeGun
        _currentGun = Guns[_index];
            _currentGun.transform.position = GunPos.transform.position;
            _currentGun.transform.rotation = GunPos.transform.rotation;
        

        Debug.Log(_index);
    }
    public void NewObjectCollected(GameObject ObjectCollected)//The Microsoft naming convention is camelCase for paramaters. so objectCollected rather than uppercase O but it's okay as long as you stay consistent
    {
        Guns.Add(ObjectCollected.gameObject);//This can be simplified to Guns.Add(ObjectCollected) because it already is a GameObject
        Destroy(_currentGun.gameObject);//This can be simplified to _currentGun because it already is a GameObject
        _index += 1;
        //Should have an index check to be sure that you aren't going above the amount of items in the list
        _index = _index % Guns.Count;
        _currentGun = Instantiate(Guns[_index], GunPos.transform.position, GunPos.transform.rotation);
    }
}
