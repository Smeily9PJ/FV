namespace FV
{
    using UnityEngine;
    using System.Collections;

    public class PlayerScript : MonoBehaviour
    {

        #region Variables

        /// <summary>
        ///  La vitesse de déplacement
        /// </summary>
        public Vector2 speed = new Vector2(20, 20);

        /// <summary>
        /// Stockage du mouvement
        /// </summary>
        private Vector2 movement;

        private float jump_current;

        private const float JUMP_MAX = 100;

        #endregion

        #region Méthodes publiques

        void Start()
        {
            jump_current = 100;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (jump_current != 0f)
            {
                jump_current = 0f;
            }
        }

        void Update()
        {
            // 3 - Récupérer les informations du clavier/manette
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            float jump = movement.y;

            if(inputY != 0f && this.Jump())
            {
                this.jump_current += 1;
                jump = speed.y * inputY;
            }

            // 4 - Calcul du mouvement
            movement = new Vector2(
              speed.x * inputX,
              jump);
                
            
        }

        void FixedUpdate()
        {
            Camera.main.transform.Translate(movement * Time.deltaTime);

            // 5 - Déplacement
            this.GetComponent<Rigidbody2D>().velocity = movement;
        }

        void OnDestroy()
        {
            // Game Over.
            // Ajouter un nouveau script au parent
            // Car cet objet va être détruit sous peu
            // transform.parent.gameObject.AddComponent<GameOverScript>();
        }

        #endregion

        #region Méthodes privées

        private bool Jump()
        {
            return this.jump_current < JUMP_MAX;
        }

        #endregion
    }
}