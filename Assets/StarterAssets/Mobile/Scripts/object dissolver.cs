using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float DissolveTime = 2f;
    [SerializeField] bool IsDissolving = false;

    float DissolveProgress = 0f;
    MeshRenderer[] MeshRenderers;
    MaterialPropertyBlock PropertyBlock;

    // Start is called before the first frame update
    void Start()
    {
        //Retrieve all renderers
        MeshRenderers = GetComponentsInChildren<MeshRenderer>();

        // strt the dissolved progress at 0
        PropertyBlock = new MaterialPropertyBlock();
        PropertyBlock.SetFloat("_DissolveProgress", 0f);
        for (int index = 0; index < MeshRenderers.Length; ++index) 
        {
            MeshRenderers[index].SetPropertyBlock(PropertyBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDissolving)
        {
            // update the progress
            DissolveProgress += Time.deltaTime / DissolveTime;

            //update the dissolve progress
            PropertyBlock.SetFloat("_DissolveProgress", 0f);
            for (int index = 0; index < MeshRenderers.Length; ++index)
            {
                MeshRenderers[index].SetPropertyBlock(PropertyBlock);
            }

            //Finished
            if (DissolveProgress >= 1f)
                Destroy(gameObject);
        }
        
    }
}
