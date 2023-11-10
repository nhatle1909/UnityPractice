//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Unity.IO.LowLevel.Unsafe;
//using Unity.VisualScripting;
//using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

//namespace Assets
//{

//    public class RunningState : IAnimationState
//    {
//        private Animator animator = GameObject.Find("Player").GetComponent<Animator>();
//        private Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

//        private float horizontal;
//        private float speed;
//        public RunningState(float horizontal)
//        {
//            this.horizontal = horizontal;
//        }
//        public void Enter()
//        {
//            animator.SetBool(AnimationStringManager.Running, true);
//        }

//        public void Exit()
//        {
//            animator.SetBool(AnimationStringManager.Running, false);
//        }

//        public void Update()
//        {
//            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
//        }
//    }

//    public class CrouchState : IAnimationState
//    {
//        private Animator animator = GameObject.Find("Player").GetComponent<Animator>();
//        private Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

//        private float horizontal;
//        private float speed;
//        public void Enter()
//        {
//            animator.SetBool(AnimationStringManager.Crouch, true);
//        }

//        public void Exit()
//        {
//            animator.SetBool(AnimationStringManager.Crouch, false);
//        }

//        public void Update()
//        {
//            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
//        }
//    }
//    public class IdleState : IAnimationState
//    {
//        private float horizontal;
//        public void Enter()
//        {
//            throw new NotImplementedException();
//        }

//        public void Exit()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update()
//        {
//            if (horizontal == 0f)
//            {
//                StateMachine.SwitchState(new RunningState(horizontal));
//            }
//        }
//    }

//    public class StateMachine : MonoBehaviour
//    {
//        public IAnimationState State { get; set; }
//        private void OnEnable()
//        {
//            State = new IdleState();
//        }

//        private void Update()
//        {
//            State.Update();
//        }

//        public void SwitchState(IAnimationState newState)
//        {
//            State.Exit();
//            State = newState;
//            State.Enter();
//        }
//    }
//}
