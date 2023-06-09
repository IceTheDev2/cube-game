using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbosy component called 'Rb'.
    public Rigidbody Rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // We marked this as FixedUpdate because we
    // are using it to mess with physics.
    /// <summary>
    /// Called 50 times per second, this function adds a force of 2000 on the z-axis,
    /// and checks if the user is pressing the D, A, left arrow, or right arrows key,
    /// to correctly move the player.
    /// </summary>
    void FixedUpdate()
    {
        // Add a forward force
        Rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Add a force of 2000 on the z-axis.

        float horizontalInput = Input.GetAxis("Horizontal");

        Rb.AddForce(horizontalInput * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
