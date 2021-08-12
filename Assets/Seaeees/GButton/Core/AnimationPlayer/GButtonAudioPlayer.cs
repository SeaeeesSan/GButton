using Seaeees.GButton.Tween;
using UnityEngine;

namespace Seaeees.GButton.Core
{
	internal class GButtonAudioPlayer
	{
		private bool useAudioPlayer;

		private AudioSource audioSource;

		private AudioClip hoverEnterAudioClip;
		private AudioClip hoverExitAudioClip;
		private AudioClip downAudioClip;
		private AudioClip upAudioClip;

		public GButtonAudioPlayer(bool useAudioPlayer, AudioSource audioSource, AudioClip hoverEnterAudioClip, AudioClip hoverExitAudioClip, AudioClip downAudioClip, AudioClip upAudioClip)
		{
			this.useAudioPlayer = useAudioPlayer;
			this.audioSource = audioSource;
			this.hoverEnterAudioClip = hoverEnterAudioClip;
			this.hoverExitAudioClip = hoverExitAudioClip;
			this.downAudioClip = downAudioClip;
			this.upAudioClip = upAudioClip;
		}

		public void PlayAudio(AnimationType animationType)
		{
			if(!audioSource) return;
			if(!useAudioPlayer) return;
			if(animationType == AnimationType.PointerEnter)
				audioSource.PlayOneShot(hoverEnterAudioClip);
			else if(animationType == AnimationType.PointerExit)
				audioSource.PlayOneShot(hoverExitAudioClip);
			else if(animationType == AnimationType.PointerDown)
				audioSource.PlayOneShot(downAudioClip);
			else if(animationType == AnimationType.PointerUp)
				audioSource.PlayOneShot(upAudioClip);
		}
	}
}