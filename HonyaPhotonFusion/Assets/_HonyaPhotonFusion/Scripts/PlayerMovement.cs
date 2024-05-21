using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Fusion;

public class PlayerMovement : NetworkBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5f;

    private void Awake()
    {
        var list = new List<int>();
        this._controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
    }

    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority)
        {
            return;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * _speed;
        _controller.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
