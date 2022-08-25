using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCRandomation : MonoBehaviour
{
    public SkinnedMeshRenderer characterMesh;
    public SkinnedMeshRenderer[] _meshes;


    private void Start()
    {
        int charIndex = Random.Range(0, _meshes.Length);
        characterMesh.sharedMesh = _meshes[charIndex].sharedMesh;
        characterMesh.materials = _meshes[charIndex].sharedMaterials;
    }
}

