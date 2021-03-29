using UnityEngine;

namespace Wrenji.Player
{

    public class Player_Movement : MonoBehaviour
    {

        public LegacyController2D controller;

        //Variables
        private Rigidbody rb;
        private Animator animator;

        //Basic Moves
        bool jump;
        bool crouch;
        bool block;

        //Movement
        private Vector3 movement = new Vector3(0f, 0f, 0f);
        private float magnitude;
        float speed;

        //Attacks //each attack has these variables
        private int attackIndex;
        private Vector3[] attackPosition;
        private float[] attackRange;
        private float[] attackDamage;

        public LayerMask enemyLayer;

        //For test
        public Vector3 placeholderPosition;
        public float placeholderRange;

        void Start()
        {
            this.rb = this.GetComponent<Rigidbody>();
            this.animator = this.GetComponent<Animator>();
            attackRange = new float[7];
            attackPosition = new Vector3[7];

            Settings();

        }

        void Update()
        {
            BasicMovementInput("q", "left shift");
        }

        private void FixedUpdate()
        {
            this.controller.Move(this.speed * Time.fixedDeltaTime * this.movement, crouch, jump);
        }

        void attack(int i)
        {
            //animation
            animator.SetInteger("Attack", i);

            //Create hit radius
            Vector3 realAttackPosition = attackPosition[i] + this.transform.position;
            Collider[] hitEnemies = Physics.OverlapSphere(realAttackPosition, attackRange[i], enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                //hit enemies
            }

        }

        //for testing
        void OnDrawGizmosSelected()
        {
            attackPosition = new Vector3[7];
            attackRange = new float[7];
            int i = 0;

            attackPosition[i] = placeholderPosition;
            attackRange[i] = placeholderRange;

            Gizmos.DrawWireSphere(attackPosition[i] + this.transform.position, attackRange[i]);

        }

        void Settings()
        {
            speed = 300;
            jump = false;
            crouch = false;
            block = false;
        }

        //Finished
        void BasicMovementInput(string blockKey, string crouchKey)
        {
            this.block = Input.GetKey(blockKey);

            if (block)
            {
                this.movement = new Vector3(0f, 0f, 0f);
                this.crouch = false;
                this.jump = false;
            }

            else

            {
                this.crouch = Input.GetKey(crouchKey);

                if (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 1.9f)
                {

                    this.movement = new Vector3(Input.GetAxis("Horizontal") / Mathf.Sqrt(2), 0f, Input.GetAxis("Vertical") / Mathf.Sqrt(2));
                }

                else
                {
                    this.movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

                }

                if (crouch)
                {
                    this.jump = false;
                }

                else
                {
                    this.jump = Input.GetAxis("Jump") > 0;

                }
            }

            //ANIMATIONS
            animator.SetBool("Jump", jump);
            animator.SetBool("Crouch", crouch);
            animator.SetBool("Block", block);
        }

        //unused
        protected void Movement()
        {
            this.rb.MovePosition(this.transform.position + (this.speed * Time.deltaTime * this.movement));
        }

    }

}

//Tutorials Used: https://www.youtube.com/watch?v=ixM2W2tPn6cˆ, https://www.youtube.com/watch?v=sPiVz1k-fEs

//To Do
// adjust colliders for crouching
// player health system, enemy health system