using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems ; 
using UnityEngine.XR.ARFoundation ; 
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch ; 


[RequireComponent(typeof(ARRaycastManager) , typeof(ARPlaneManager))] ;
public class planeObject : MonoBehaviour
{
    [SerializeField] 
    private ARRaycastManager arraycastmanger ; 
    private ARPlaneManager arplanemanager ; 
    public GameObject prefab ; 
    private List<ARRaycastManager> hits  = new List<ARRaycastHit>() ;
    private void Awake() {
        arraycastmanger = GetComponent<ARRaycastManager>() ; 
        arplanemanager = GetComponent<arplanemanager>() ; 

    }
    private void onEnable () {
        EnhancedTouch.TouchSimulation.Enable() ; 
        EnhancedTouch.EnhancedTouchSupport.Enable() ;

    }
    private void onDisable() {
        EnhancedTouch.TouchSimulation.Disable() ;
        EnhancedTouch.EnhancedTouchSupport.Disable() ; 
    }
    private void onFingerDown(EnhancedTouch.Finger finger ){
          if (finger.index != 0 ) return ; 

          if(arraycastmanger.Raycast(finger.currentTouch.screenPosition, hits , TrackableType.PlaneWithinPolygon)){
            foreach(ARRaycastHit  hits in hit ){
                Pose pose = hit.pose ; 
                GameObject  obj = Instantiate(prefab , pose.position , pose.rotaiton ) ; 
            }
          }
    }
}
