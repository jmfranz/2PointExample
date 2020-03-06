using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

public class ObserverMeshToggler : MonoBehaviour
{
    public void DisableObserverMeshes()
    {
        var spatialAwarenessService = CoreServices.SpatialAwarenessSystem;
        var dataProviderAccess = spatialAwarenessService as IMixedRealityDataProviderAccess;
        var meshObservers = dataProviderAccess?.GetDataProviders<IMixedRealitySpatialAwarenessMeshObserver>();
        if (meshObservers == null) return;

        foreach (var meshObserver in meshObservers)
        {
            if (meshObserver != null)
                meshObserver.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
        }
    }

    public void ChangeObserverResolution()
    {
        var spatialAwarenessService = CoreServices.SpatialAwarenessSystem;
        var dataProviderAccess = spatialAwarenessService as IMixedRealityDataProviderAccess;
        var meshObservers = dataProviderAccess?.GetDataProviders<IMixedRealitySpatialAwarenessMeshObserver>();
        if (meshObservers == null) return;

        foreach (var meshObserver in meshObservers)
        {
            if (meshObserver != null)
                meshObserver.LevelOfDetail = SpatialAwarenessMeshLevelOfDetail.Fine;
        }
    }

    public void EnableObserverMeshes()
    {
        var spatialAwarenessService = CoreServices.SpatialAwarenessSystem;
        var dataProviderAccess = spatialAwarenessService as IMixedRealityDataProviderAccess;
        var meshObservers = dataProviderAccess?.GetDataProviders<IMixedRealitySpatialAwarenessMeshObserver>();
        if (meshObservers == null) return;

        foreach (var meshObserver in meshObservers)
        {
            if (meshObserver != null)
                meshObserver.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
        }
    }
}
