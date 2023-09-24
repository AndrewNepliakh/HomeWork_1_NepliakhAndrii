using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
   [SerializeField] private Character _character;
   [SerializeField] private SpriteRenderer _spriteRenderer;
   [SerializeField] private Rigidbody2D _rigidbody2D;
   [SerializeField] private Animator _animator;

   private readonly string _idleAnimation = "Idle";
   private readonly string _runRightAnimation = "RunRight";
   private readonly string _runLeftAnimation = "RunLeft";
   private readonly string _jumpUpAnimation = "JumpUp";
   private readonly string _jumpDownAnimation = "JumpDown";
   private readonly string _climbAnimation = "Climb";
   private readonly string _playerShoot = "PlayerShoot";
   
   private bool _isIdle;
   private bool _isRunRight;
   private bool _isRunLeft;
   private bool _isJumpUp;
   private bool _isJumpDown;
   private bool _isClimb;
   private bool _isShoot;

   public void Shoot()
   {
      if(_isShoot) return;
      ResetAllFlags();
      _isShoot = true;
      _animator.Play(_playerShoot);
   }

   private void Update()
   {
      SetAnimation();
   }

   private void SetAnimation()
   {
      if(_character.IsDead) return;
      
      if (_character.IsOnLadder)
      {
         if (_rigidbody2D.velocity.y > 0.1f && !_isClimb)
         {
            ResetAllFlags();
            _isClimb = true;
            _isShoot = false;
            _animator.Play(_climbAnimation);
         }
      }
      
      if (_rigidbody2D.velocity.magnitude < 0.1f && !_isIdle && !_isShoot)
      {
         ResetAllFlags();
         _isIdle = true;
         _animator.Play(_idleAnimation);
      }
      
      if (_rigidbody2D.velocity.x > 0.1f && !_isRunRight)
      {
         if (_isJumpDown) return;
         ResetAllFlags();
         _isRunRight = true;
         _isShoot = false;
         _animator.Play(_runRightAnimation);
         _spriteRenderer.flipX = false;
      }
      
      if (_rigidbody2D.velocity.x < 0.0f && !_isRunLeft)
      {
         if (_isJumpDown) return;
         ResetAllFlags();
         _isRunLeft = true;
         _isShoot = false;
         _animator.Play(_runLeftAnimation);
         _spriteRenderer.flipX = true;
      }
      
      if (_rigidbody2D.velocity.y > 0.1f && !_isJumpUp)
      {
         ResetAllFlags();
         _isJumpUp = true;
         _isShoot = false;
         _animator.Play(_jumpUpAnimation);
      }
      
      if (_rigidbody2D.velocity.y < 0.0f && !_isJumpDown)
      {
         ResetAllFlags();
         _isJumpDown = true;
         _isShoot = false;
         _animator.Play(_jumpDownAnimation);
      }
   }

   private void ResetAllFlags()
   {
      _isIdle = false;
      _isRunRight = false;
      _isRunLeft = false;
      _isJumpUp = false;
      _isJumpDown = false;
      _isClimb = false;
      _isShoot = false;
   }
}
