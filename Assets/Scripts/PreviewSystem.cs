using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{

    public static PreviewSystem instance;
    private GameObject previewObject;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Material previewMaterial;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    public void StopShowingPreview()
    {
        if (previewObject != null)
            Destroy(previewObject);
    }


    public void StartShowingPlacementPreview(GameObject prefab,Vector3 basePosition, Quaternion baseRotation)
    {
        
        previewObject = Instantiate(prefab, basePosition, baseRotation);
        PreparePreview(previewObject);
    }

    public void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer.name == "3dRange")
            {
                continue;
            }

            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterial;
            }
            renderer.materials = materials;
        }
    }

}

