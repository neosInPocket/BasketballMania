using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLineRenderer : MonoBehaviour
{
	[SerializeField] private Transform _openingEdge;
	[SerializeField] private Transform _closingEdge;
	[SerializeField] private Transform _screenOpeningBorder;
	[SerializeField] private Transform _screenClosingBorder;
	[SerializeField] private Rigidbody2D _rb;
	[SerializeField] private float _speed;
	[SerializeField] private LinePieceRenderer _upPiece;
	[SerializeField] private LinePieceRenderer _downPiece;
	protected Vector3 _moveDirection => Vector2.right;
	protected float _gapLength => _openingEdge.transform.localPosition.y - _closingEdge.transform.localPosition.y;
	
	private void Start()
	{
		_upPiece.TriggerEnter += OnPieceTriggerEnter;
		_downPiece.TriggerEnter += OnPieceTriggerEnter;
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
		var y1 = _screenOpeningBorder.transform.localPosition.y + _gapLength;
		var y2 = _screenClosingBorder.transform.localPosition.y - _gapLength;
		var random = Random.Range(y1, y2);
		transform.localPosition = new Vector2(transform.localPosition.x, random);
	}
	
	
}
