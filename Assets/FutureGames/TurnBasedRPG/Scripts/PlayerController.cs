using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using  UnityEngine.UI;

namespace FutureGames.TurnBasedRPG
{
    
    /// <summary>
    /// The controller for the player. PlayerInput might be a better name but it also has some functionality
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Actor controlledActor;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button upButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button fireButton;
        [SerializeField] private Button endTurnButton;

        [SerializeField] private int maxActionsInTurn = 3;

        private int currentQueuedActions;

        private bool inFireMode;

        private Camera mainCamera;
        
        private void Awake()
        {
            mainCamera = Camera.main;
            leftButton.onClick.AddListener(AddMoveLeftAction);
            rightButton.onClick.AddListener(AddMoveRightAction);
            upButton.onClick.AddListener(AddMoveUpAction);
            downButton.onClick.AddListener(AddMoveDownAction);
            fireButton.onClick.AddListener(ToggleFireMode);
            endTurnButton.onClick.AddListener(EndTurn);
            GameEvents.instance.OnControlledActorChanged += OnChangeActor;
        }

        private void OnChangeActor(Actor actorToChangeTo)
        {
            controlledActor = actorToChangeTo;
        }

        private void AddMoveLeftAction()
        {
            if(!IsActionAvailable()) return;
            controlledActor.AddMoveAction(Vector3.left);
        }

        private void AddMoveRightAction()
        {
            if(!IsActionAvailable()) return;
            controlledActor.AddMoveAction(Vector3.right);
        }
        
        private void AddMoveUpAction()
        {
            if(!IsActionAvailable()) return;
            controlledActor.AddMoveAction(Vector3.forward);
        }
        
        private void AddMoveDownAction()
        {
            if(!IsActionAvailable()) return;
            controlledActor.AddMoveAction(Vector3.back);
        }

        private void EndTurn()
        {
            currentQueuedActions = 0;
            controlledActor.ExecuteActions();
            GameEvents.instance.EndTurn();
        }

        private void ToggleFireMode()
        {
            inFireMode = !inFireMode;
            leftButton.interactable = !inFireMode;
            rightButton.interactable = !inFireMode;
            upButton.interactable = !inFireMode;
            downButton.interactable = !inFireMode;
            endTurnButton.interactable = !inFireMode;
        }

        private bool IsActionAvailable()
        {
            if (currentQueuedActions >= maxActionsInTurn) return false;
            currentQueuedActions++;
            return true;
        }

        private void Update()
        {
            if (inFireMode)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if(!IsActionAvailable()) return;
                        ToggleFireMode();
                        controlledActor.AddRangedAttack(hit.point);
                    }
                }
            }
        }
    }
}
