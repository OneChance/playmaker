// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Animator")]
	[Tooltip("Force the normalized time of a state to a user defined value. Only works on base layer. Should not be used in transition.")]
	//[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1072")]
	public class AnimatorForceStateNormalizedTime: FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Animator))]
		[Tooltip("The Target. An Animator component is required")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("The normalized time for the base layer")]
		public FsmFloat normalizedTime;
		
		[Tooltip("Repeat every frame. Useful for changing over time.")]
		public bool everyFrame;
		
		private Animator _animator;
		
		public override void Reset()
		{
			gameObject = null;
			normalizedTime= null;
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
			
			ForceNormalizedTime();
			
			if (!everyFrame) 
			{
				Finish();
			}
		}
	
		public override void OnUpdate()
		{
			ForceNormalizedTime();
		}
		
	
		void ForceNormalizedTime()
		{		
			if (_animator==null)
			{
				return;
			}
			
			_animator.ForceStateNormalizedTime(normalizedTime.Value);
		}
		
	}
}