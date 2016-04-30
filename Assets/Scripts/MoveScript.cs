namespace FV
{
    using UnityEngine;
    using System.Collections;

    public class MoveScript : MonoBehaviour
    {

        #region Variables

        /// <summary>
        /// Vitesse de déplacement
        /// </summary>
        public Vector2 speed = new Vector2(10, 10);

        /// <summary>
        /// Direction
        /// </summary>
        public Vector2 direction = new Vector2(-1, 0);

        private Vector2 movement;

        #endregion

        #region Méthodes publiques

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // 2 - Calcul du mouvement
            movement = new Vector2(
              speed.x * direction.x,
              speed.y * direction.y);
        }

        /// <summary>
        /// Met à jour la position du personnage
        /// </summary>
        void FixedUpdate()
        {
            // 5 - Déplacement
            this.GetComponent<Rigidbody2D>().velocity = movement;
        }

        #endregion

        #region Méthodes privées

        #endregion
    }
}
