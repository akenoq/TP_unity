using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TankControls : MonoBehaviour
{

	public Rigidbody ShellPrefab;
	public Transform Barrel;

	public float Speed;
	public float TurnSpeed;

	private float _forwardAxis;
	private float _sideAxis;

	private Rigidbody _rigidbody;
	
	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Move();
		Turn();
	}

	void Move()
	{
		var shift = Speed * transform.forward * Time.deltaTime * _forwardAxis;
		_rigidbody.MovePosition(_rigidbody.position + shift);
	}

	void Turn()
	{
		var turn = TurnSpeed * Time.deltaTime * _sideAxis;
		var turnY = Quaternion.Euler(0, turn, 0);
		
		_rigidbody.MoveRotation(_rigidbody.rotation * turnY);
	}

	// Update is called once per frame
	void Update ()
	{

		_forwardAxis = Input.GetAxis("Vertical1");
		_sideAxis = Input.GetAxis("Horizontal1");
		
		if (Input.GetMouseButtonDown(0))
		{
			Rigidbody shell = Instantiate(ShellPrefab, Barrel.position, Barrel.rotation);
			shell.AddForce(shell.transform.forward * 700);
			
		}
	}
}
