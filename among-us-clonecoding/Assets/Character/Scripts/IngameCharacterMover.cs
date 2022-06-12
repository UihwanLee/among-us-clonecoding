using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum EPlayerType
{
    Crew,
    Imposter
}

public class IngameCharacterMover : CharacterMover
{
    [SyncVar]
    public EPlayerType playerType;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if(hasAuthority)
        {
            IsMovealbe = true;

            var myRoomPlayer = AmongUsRoomPlayer.MyRoomPlayer;

            CmdSetPlayerCharacter(myRoomPlayer.nickname, myRoomPlayer.playerColor);
        }

        GameSystem.Instance.AddPlayer(this);
    }

    [Command]
    private void CmdSetPlayerCharacter(string nickname, EPlayerColor color)
    {
        this.nickname = nickname;
        playerColor = color;
    }
}
