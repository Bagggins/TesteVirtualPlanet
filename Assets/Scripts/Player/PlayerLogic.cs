using MeshPencil.Common.Controllers;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MeshPencilController _pencilController;
    [SerializeField] private Transform[] _legs;
    [SerializeField] private ConstantForce _constantForce;

    private void Start()
    {
        _pencilController.OnFinish.AddListener(LandPlayer);
        _pencilController.BeforeMeshSpawned.AddListener(RemoveLastDrawnLeg);
    }

    private void RemoveLastDrawnLeg()
    {
        foreach (Transform leg in _legs)
        {
            foreach (Transform child in leg)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void LandPlayer()
    {
        _rigidbody.useGravity = true;
        _pencilController.OnFinish.RemoveListener(LandPlayer);
        _constantForce.enabled = true;
    }
}

