using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	[SerializeField] private AudioSource _music;
	[SerializeField] private AudioSource _laser;
	[SerializeField] private AudioSource _pop;
	
	public float volume => _music.volume;
	
	private void Start()
	{
		AudioEvent.OnEvent += PlaySound;
	}
	
	private void PlaySound(AudioTypes type)
	{
		switch (type)
		{
			case AudioTypes.Laser:
				_laser.Play();
				break;
				
			case AudioTypes.Pop:
			_pop.Play();
			break;
		}
		
	}
	
	public void ChangeVolume(float value)
	{
		_music.volume = value;
	}
}
