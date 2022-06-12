using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameSystem : NetworkBehaviour
{
    public static GameSystem Instance;

    private List<IngameCharacterMover> players = new List<IngameCharacterMover>();

    public void AddPlayer(IngameCharacterMover player)
    {
        if(!players.Contains(player))
        {
            players.Add(player);
        }
    }

    private IEnumerator GameReady()
    {
        var manager = NetworkManager.singleton as AmongUsRoomManager;
        while(manager.roomSlots.Count != players.Count)
        {
            yield return null;
        }

        for(int i=0; i < manager.imposterCount; i++)
        {
            var player = players[Random.Range(0, players.Count)];
            if(player.playerType != EPlayerType.Imposter)
            {
                player.playerType = EPlayerType.Imposter;
            }
            else
            {
                i--;
            }
        }

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(IngameUIManager.Instance.IngameIntroUI.ShowIntroSequence());
    }

    public List<IngameCharacterMover> GetPlayerList()
    {
        return players;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameReady());
    }
}
