using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA;

public class ClickPlacer : MonoBehaviour, IMixedRealityPointerHandler { 
    // Start is called before the first frame update

    private int clickCount = 0;

    void Start()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if(clickCount > 2)
            return;

        var pos = eventData.Pointer.Result.Details.Point;
        GameObject P1 = GameObject.Find("P1");

        if (clickCount == 0)
        {
            P1.transform.position = pos;
        }
        else if (clickCount == 1)
        {
            //P1 is the pivot point of hte model.
            P1.transform.LookAt(pos);
            P1.transform.rotation = Quaternion.Euler(0, P1.transform.rotation.eulerAngles.y, 0);

            var model = P1.transform.GetChild(0);
            model.transform.parent = null;

            var modelChildren = model.transform.GetComponentsInChildren<Transform>();

            //Add an anchor to the pivot of the model.
            P1.AddComponent<WorldAnchor>();

            //De-parent and add anchor for each "target"
            //The trick here is to add anchors to targets instead of the model. Drift is unnavoidable however local drift
            // is is not as bad as the drift of the big model (because of angular velocity).
            //The hololens WILL autocorrect for drift as it gathers environemntal information.
            foreach (Transform child in modelChildren)
            {
                child.parent = null;
                child.gameObject.AddComponent<WorldAnchor>();
            }

            //We really don't need nor we should add an world anchor to the model because it is too big.
            //It is here for sake of the example.
            model.gameObject.AddComponent<WorldAnchor>();
            

            //Let's disable the spacial mesh :)
            //Note that the observer is still running we are just not rendering the mesh
            var spatialAwarenessService = CoreServices.SpatialAwarenessSystem;
            var dataProviderAccess = spatialAwarenessService as IMixedRealityDataProviderAccess;
            var meshObservers = dataProviderAccess?.GetDataProviders<IMixedRealitySpatialAwarenessMeshObserver>();
            foreach (var meshObserver in meshObservers)
            {
                if (meshObserver != null)
                    meshObserver.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
            }


        }
        //Reset the scene and try again '_
        else if (clickCount == 2)
        {
            clickCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        clickCount++;






    }


}
