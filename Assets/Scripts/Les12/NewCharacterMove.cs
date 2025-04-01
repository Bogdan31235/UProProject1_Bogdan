using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMControllerLes12;

public class NewCharacterMove : CharacterMove
{
    [SerializeField]
    protected float _speedRun = 20;//скорость бега
    [SerializeField]
    protected float _speedCrawl = 5;//скорость ползани€
    [SerializeField]
    protected string _clipRun;//клип бега
    [SerializeField]
    protected string _clipCrawl;//клип ползка

    private Dictionary<MovementType, IMoving> _movementStrategies;// создаЄт словарь с типами движени€ и интерфейсом
    private IMoving _currentMove;//хранит текущее значение движени€

    public override void Enter()
    {
        InitializeMovementStrategies();//запускаем паррент стратеги€
        SetMovement(MovementType.Wall);//берЄт значение ходьбы
    }

    public override void Do()
    {
        float moveInput = Input.GetAxis(nameV) * Time.deltaTime;

        if (moveInput == 0)//провер€ем нажата ли кнопка
        {
            GetComponentInParent<FSMControllerLes12>().SwitchState(NewCharacterState.Idle);//если нет значит стоим
            return;
        }

        HandleMovementInput();//обрабатывает анимацию
        _currentMove.Move(moveInput);//держит текущую стратегию движени€
    }

    private void InitializeMovementStrategies()//инициализируем стратегии
    {
        _movementStrategies = new Dictionary<MovementType, IMoving>//берЄм состо€ни€ из словар€
        {
            { MovementType.Wall, new WallMove(_speedWallkin, transform, _animator, _clip) },//значение ходьбы
            { MovementType.Run, new RunMove(_speedRun, transform, _animator, _clipRun) },//значение бега
            { MovementType.Crawl, new CrawlMove(_speedCrawl, transform, _animator, _clipCrawl) }//значение ползка
        };
    }

    private void HandleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))//провер€ем нажата ли кнопка бега
        {
            SetMovement(MovementType.Run);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))//нажата ли кнопка ползка
        {
            SetMovement(MovementType.Crawl);
        }
        else if ((Input.GetKeyUp(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift)) ||
                 (!Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.LeftShift)))
        {
            SetMovement(MovementType.Wall);//выполн€етс€  ходьба если shift и  ctrl не выполн€ютс€
        }
    }

    private void SetMovement(MovementType type)
    {
        if (_movementStrategies.TryGetValue(type, out IMoving move))
        {
            _currentMove = move;
            _currentMove.PlayClip();
        }
        else
        {
            Debug.LogError($"Movement type {type} not found!");
        }
    }

    private enum MovementType
    {
        Wall,
        Run,
        Crawl
    }
}


