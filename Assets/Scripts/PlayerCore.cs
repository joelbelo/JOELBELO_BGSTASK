using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private Animator _anim;

    private bool _movementEnabled=true;
    private bool _moving = false;

    private Vector2 _initScale;

    private void Start()
    {
        _initScale = transform.localScale;
    }

    private void Update()
    {
        if (_movementEnabled)
        {
            _rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _speed;
        }
        //Anim
        if (_rigid.velocity.magnitude != 0)
        {
            if (!_moving)
            {
                _moving = true;
                _anim.Play("Rogue_run_01",0,0);
            }
        }
        else
        {
            if (_moving)
            {
                _moving = false;
                _anim.Play("Rogue_idle_01",0,0);
            }
        }
        
        //Invert X
        switch (_rigid.velocity.x)
        {
            case > 0:
                transform.localScale = _initScale;
                break;
            case < 0:
                transform.localScale = new Vector2(-_initScale.x,_initScale.y);
                break;
        }
    }

}