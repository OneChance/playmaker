// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Animator")]
	[Tooltip("Sets the playback speed of the Animator. 1 is normal playback speed")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1072")]
	public class SetAnimatorPlayBackSpeed: FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Animator))]
		[Tooltip("The Target. An Animator component is required")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("The playBack speed")]
		public FsmFloat playBackSpeed;
		
		[Tooltip("Repeat every frame. Useful for changing over time.")]
		public bool everyFrame;
		
		private Animator _animator;
		
		public override void Reset()
		{
			gameObject = null;
			playBackSpeed= null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			// get the animator component
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			if (go==null)
			{
				Finish();
				return;
			}
			
			_animator = go.GetComponent<Animator>();
			
			if (_animator==null)
			{
				Finish();
				return;
			}
			
			DoPlayBackSpeed();
			
			if (!everyFrame) 
			{
				Finish();
			}
		}
	
		public override void OnUpdate()
		{
			DoPlayBackSpeed();
		}
		
	
		void DoPlayBackSpeed()
		{		
			if (_animator==null)
			{
				return;
			}
			
			_animator.speed = playBackSpeed.Value;
			
		}
		
	}
}