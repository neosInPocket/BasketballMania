using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class HorizontalLineRenderer : MonoBehaviour
{
	[SerializeField] private Transform _openingEdge;
	[SerializeField] private Transform _closingEdge;
	[SerializeField] private Transform _screenOpeningBorder;
	[SerializeField] private Transform _screenClosingBorder;
	[SerializeField] private LinePieceRenderer _leftPiece;
	[SerializeField] private LinePieceRenderer _rightPiece;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] private float _speed;
	protected Vector3 _moveDirection => Vector2.down;
	protected float _gapLength => _openingEdge.transform.localPosition.x - _closingEdge.transform.localPosition.x;
	
	private void Start()
	{
		_leftPiece.TriggerEnter += OnPieceTriggerEnter;
		_rightPiece.TriggerEnter += OnPieceTriggerEnter;
		SetPosition();
	}
	
	private void OnPieceTriggerEnter()
	{
		_speed *= -1;
		SetPosition();
	}
	
	private void FixedUpdate()
	{
		_rb.velocity = _moveDirection * _speed;
	}
	
	public void SetPosition()
	{
		var x1 = _screenOpeningBorder.transform.localPosition.x + _gapLength;
		var x2 = _screenClosingBorder.transform.localPosition.x - _gapLength;
		var random = Random.Range(x1, x2);
		transform.localPosition = new Vector2(random, transform.localPosition.y);
	}
}
