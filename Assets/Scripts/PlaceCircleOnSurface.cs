using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using CommonUsages = UnityEngine.InputSystem.CommonUsages;
using System.Collections.Generic;

public class PlaceCircleOnSurface : MonoBehaviour
{
    public GameObject circlePrefab;
    public XRController controller;
    private GameObject currentCircle;
    private XRController xrc;
    

    public InputHelpers.Button button;

    void Start()
    {
        xrc = (XRController)GameObject.FindObjectOfType(typeof(XRController));
        Debug.Log("xrc: " + xrc);

        //var inputDevices = new List<UnityEngine.XR.InputDevice>();
        //UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        //foreach (var device in inputDevices)
        //{
        //    Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        //}
    }

    private void Update()
    {
        //if(controller.TryGetFeatureValue(CommungUsages.trigger, out int trigger))
        //if (controller.inputDevice.TryGetFeatureValue(CommonUsages.PrimaryTrigger, out bool isPressed) && isPressed)
        //if(true)
        //if (currentInteractor.GetComponent<ActionBasedController>().activateAction.action.ReadValue<float>() > 0.5f)
        bool pressed;



        if (controller.inputDevice.IsPressed(button, out pressed))
        {
            Debug.Log("button: " + button + "pressed: " + pressed);
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(controller.transform.position, controller.transform.forward, out hitInfo);

            if (hit)
            {
                if (currentCircle == null)
                {
                    currentCircle = Instantiate(circlePrefab, hitInfo.point, Quaternion.identity);
                }
                else
                {
                    currentCircle.transform.position = hitInfo.point;
                }
            }
        }
    }
}
