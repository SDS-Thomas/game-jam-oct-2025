using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class AttackScript : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    private GameObject attackObject;
    private InputAction attackAction;

    private float attackDelayTimer;
    private float attackDurationTimer;

    [SerializeField][Range(0, 10)] private float attackDelay;
    [SerializeField][Range(0, 10)] private float attackDuration;

    private PlayerController playerController;

    void Start()
    {
        attackObject = Instantiate(attackPrefab);
        attackObject.transform.SetParent(gameObject.transform);
        attackObject.SetActive(false);

        attackAction = InputSystem.actions.FindAction("Player/Attack");
        playerController = gameObject.GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        attackDelayTimer -= Time.deltaTime;
        attackDurationTimer -= Time.deltaTime;

        // Attack starts when button is pressed and not in delay
        bool attacking = attackAction.ReadValue<float>() > 0.1f;
        if (attacking && attackDurationTimer < 0 && attackDelayTimer < 0)
            Attack();

        // Attack in progress
        if (attackDurationTimer > 0)
        {
            attackObject.transform.position = transform.position;
            if (playerController.isFlipped)
                attackObject.transform.position -= attackPrefab.transform.localPosition;
            else
                attackObject.transform.position += attackPrefab.transform.localPosition;
            attackObject.GetComponent<SpriteRenderer>().flipX = playerController.isFlipped;
        }

        // Attack end
        if (attackDurationTimer < 0)
            attackObject.SetActive(false);
    }

    void Attack()
    {
        attackObject.SetActive(true);

        attackDelayTimer = attackDelay;
        attackDurationTimer = attackDuration;
    }
}
