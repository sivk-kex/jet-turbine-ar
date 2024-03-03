using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation ; 
using UnityEngine.XR.ARSubsystems; 
using UnityEngine.InputSystem ; 
//importing dependencies 
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : PressOnPlane //inherited class
{

    [SerializeField] 
    GameObject prefab ; 
    GameObject spawner; 
    bool isPressed ; 
    ARRaycastManager aRRaycastManager ; 
    List<ARRaycastHit> hits = new List<ARRaycastHit>() ; 
    //initializing var
    protected override void Awake() {
        base.Awake() ; 
        aRRaycastManager = GetComponent<ARRaycastManager>() ; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Pointer.current == null || isPressed == false) //no pointer or no tap {
            return ; 
        } 
        //on pointer or on touch 
        var TouchPosition = Pointer.current.position.ReadValue() ;  
        var hitpose = hits[0].pose ;
        // spawning object 
        if(spawner == null){
            spawner = Instantiate(prefab , hitpose.position , hitpose.rotation) ; 
        }
        else {
            spawner.transform.position = hitpose.position ; 
            spawner.transform.rotation = hitpose.rotation ; 

        }
    }
    protected override void OnPress(Vector3 position) => isPressed = true ; 
    protected override void OnPressCancel() => isPressed =false ; 
}
