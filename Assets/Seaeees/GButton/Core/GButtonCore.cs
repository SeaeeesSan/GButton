using Seaeees.GButton.Tween;
using System.Collections;
using UnityEngine;

namespace Seaeees.GButton.Core
{
	internal class GButtonCore
	{
		private GButtonAudioPlayer audioPlayer;

		private GButtonFillAnimationPlayer fillAnimationPlayer;

		private GButtonScaleAnimationPlayer scaleAnimationPlayer;

		public GButtonCore(GButtonAudioPlayer audioPlayer, GButtonFillAnimationPlayer fillAnimationPlayer, GButtonScaleAnimationPlayer scaleAnimationPlayer)
		{
			this.audioPlayer = audioPlayer;
			this.fillAnimationPlayer = fillAnimationPlayer;
			this.scaleAnimationPlayer = scaleAnimationPlayer;
		}

		public void CalculateScale()
		{
			this.scaleAnimationPlayer.CalculateScale();
		}

		public void PlayButtonEffects(AnimationType type)
		{
			this.audioPlayer.PlayAudio(type);
			this.fillAnimationPlayer.PlayFillAmoutAnimation(type);
			this.scaleAnimationPlayer.PlayScaleAnimation(type);
		}
	}
}