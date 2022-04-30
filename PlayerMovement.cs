using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    AudioSource footsteps;

    float speed = 3f;
    float speedWalk = 3f;
    float speedSprint = 6f;
    float gravity = -9.8f;
    float cooldown = 0.7f;
    float cooldownSprint = 0.5f;
    bool footstepCooldown;


    Vector3 velocity;

    void Start() {
        footsteps = GetComponent<AudioSource>();
    }

    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //SPRINTING
        if(Input.GetKey(KeyCode.LeftShift)) {
            speed = speedSprint;
        } else {
            speed = speedWalk;
        }

        //MOVEMENT
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //FOOTSTEPS COOLDOWN
        cooldown -= Time.deltaTime; 
        if(cooldown <= 0f) {
            footstepCooldown = true;
            if(Input.GetKey(KeyCode.LeftShift)) {
                cooldown = cooldownSprint;
            } else {
            cooldown = 0.7f;  
            }         
        } else {
            footstepCooldown = false;
        }

        //FOOTSTEP SOUNDS
        if(Input.GetKey(KeyCode.W) && footstepCooldown == true) {
            footsteps.pitch = Random.Range(0.8f, 1.1f);
            footsteps.Play();
        } else if(Input.GetKey(KeyCode.A) && footstepCooldown == true) {
            footsteps.pitch = Random.Range(0.8f, 1.1f);
            footsteps.Play();
        } else if(Input.GetKey(KeyCode.S) && footstepCooldown == true) {
            footsteps.pitch = Random.Range(0.8f, 1.1f);
            footsteps.Play();
        } else if(Input.GetKey(KeyCode.D) && footstepCooldown == true) {
            footsteps.pitch = Random.Range(0.8f, 1.1f);
            footsteps.Play();
        }
        
    }
}
