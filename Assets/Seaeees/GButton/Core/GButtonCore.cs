using Seaeees.GButton.Tween;
using System.Collections;
using UnityEngine;

namespace Seaeees.GButton.Core
{
	internal class GButtonCore
	{
		private GButtonScaleAnimationPlayer scaleAnimationPlayer;
		private GButtonColorAnimationPlayer colorAnimationPlayer;
		private GButtonAudioPlayer audioPlayer;
		private GButtonImageChanger imageChanger;
		private GButtonFillAnimationPlayer fillAnimationPlayer;

		public GButtonCore(GButtonScaleAnimationPlayer scaleAnimationPlayer, GButtonColorAnimationPlayer colorAnimationPlayer, GButtonAudioPlayer audioPlayer, GButtonImageChanger imageChanger, GButtonFillAnimationPlayer fillAnimationPlayer)
		{
			this.scaleAnimationPlayer = scaleAnimationPlayer;
			this.colorAnimationPlayer = colorAnimationPlayer;
			this.audioPlayer = audioPlayer;
			this.imageChanger = imageChanger;
			this.fillAnimationPlayer = fillAnimationPlayer;
		}

		public void CalculateScale()
		{
			this.scaleAnimationPlayer.CalculateScale();
		}

		public void PlayButtonEffects(AnimationType type)
		{
			this.scaleAnimationPlayer.PlayScaleAnimation(type);
			this.colorAnimationPlayer.PlayColorAnimation(type);
			this.audioPlayer.PlayAudio(type);
			this.imageChanger.ChangeImage(type);
			this.fillAnimationPlayer.PlayFillAmoutAnimation(type);
		}
	}
}