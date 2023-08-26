using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnimator : MonoBehaviour
{
    [SerializeField] private float _maxTilt = .1f;
    [SerializeField] private float _tiltSpeed = 1;
    public bool _isFlipped = false;
    private TarodevController.IPlayerController _player;
    Vector3 playerScale;
    void Awake() => _player = GetComponentInParent<TarodevController.IPlayerController>();
    private void Start()
    {
        playerScale = this.transform.localScale;
    }

    void Update()
    {
        if (_player == null) return;

        // Flip the sprite
        if (_player.Input.X != 0)
        {
            transform.localScale = new Vector3(_player.Input.X > 0 ? playerScale.x : -playerScale.x, playerScale.y, 1f);
            if (_player.Input.X > 0)
            {
                _isFlipped = false;
            }
            else
            {
                _isFlipped = true;
            }
        }

    }
}
