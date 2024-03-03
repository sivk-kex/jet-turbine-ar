using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
public abstract class PressOnPlane : MonoBehaviour
{
    protected InputAction m_PressAction ; 

    protected virtual void Awake (){
        //assigning binding for touch 
        m_PressAction = new InputAction("touch" , binding : "<Pointer>/press"); 
        m_PressAction.started +=ctx  => {
            //if pointer device is available 
            if (ctx.control.device is Pointer device ) {
                OnPressBegan(device.position.ReadValue()  ); 
            }
        }; 
        m_PressAction.performed +=ctx => {
            if (ctx.control.device is Pointer device ) {
                OnPress( device.position.ReadValue());
            }
        }; 
        m_PressAction.canceled += _ => OnPressCancel() ; 
    }
    protected virtual void OnEnable() {
        m_PressAction.Enable() ;
    }
    protected virtual void OnDisable() {
        m_PressAction.Disable() ; 
    }
    protected virtual void OnDestroy() {
        m_PressAction.Dispose() ;
    }
    protected virtual void OnPress(Vector3 position ){} 
    protected virtual void OnPressBegan(Vector3 position) {} 
    protected virtual void OnPressCancel() {}  
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started") ; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ok") ;
    }
}
