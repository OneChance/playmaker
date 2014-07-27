// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Animator")]
	[Tooltip("Returns true if a transform is controlled by the Animator. Can also send events")]
	public class GetAnimatorIsControlled: FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Animator))]
		[Tooltip("The Target. An Animator component is required")]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[Tooltip("The GameObject transform to check for control.")]
		public FsmGameObject transform;
		
		[ActionSection("Results")]
		
		[UIHint(UIHint.Variable)]
		[Tooltip("True if automatic matching is active")]
		public FsmBool isControlled;
		
		[Tooltip("Event send if the transform is controlled")]
		public FsmEvent isControlledEvent;
		
		[Tooltip("Event send if the transform is not controlled")]
		public FsmEvent isNotControlledEvent;
		
		private Animator _animator;
		
		private Transform _transform;
		
		public override void Reset()
		{
			gameObject = null;
			transform = null;
			isControlled = null;
			isControlledEvent = null;
			isNotControlledEvent = null;
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
			
			GameObject targetGo = transform.Value;
			
			if (targetGo==null)
			{
				Finish();
				return;
			}
				
			_transform = targetGo.transform;
			
			DoCheckIsControlled();
			
			Finish();
			
		}
	
		void DoCheckIsControlled()
		{		
			if (_animator==null)
			{
				return;
			}
			
			bool _isControlled = _animator.IsControlled(_transform);
			isControlled.Value = _isControlled;
			
			if (_isControlled)
			{
				Fsm.Event(isControlledEvent);
			}else{
				Fsm.Event(isNotControlledEvent);
			}
		}
		
	}
}