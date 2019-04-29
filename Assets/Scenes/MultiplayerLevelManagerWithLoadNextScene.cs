using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Tools;
namespace MoreMountains.CorgiEngine
{
    public class MultiplayerLevelManagerWithLoadNextScene : MultiplayerLevelManager
    {
        
        
        protected override IEnumerator MultiplayerEndGame(string winnerID)
        {
            // we wait for 1 second
            yield return new WaitForSeconds(1f);
            // we freeze all characters
            FreezeCharacters();
            // wait for another second
            yield return new WaitForSeconds(1f);

            // if we find a MPGUIManager, we display the end game screen with the name of the winner
            if (GUIManager.Instance.GetComponent<MultiplayerGUIManager>() != null)
            {
                GUIManager.Instance.GetComponent<MultiplayerGUIManager>().ShowMultiplayerEndgame();
                GUIManager.Instance.GetComponent<MultiplayerGUIManager>().SetMultiplayerEndgameText(winnerID + " WINS");
                //winnerID为player3格式，[7]能得到数字，tempID可以得到玩家积分索引
                int playerID = winnerID[6] - '1';
                GameManager.Instance.AddPlayerScore(playerID);
                




            }
            // we wait for 2 seconds
            yield return new WaitForSeconds(2f);
            // we reload the current scene to start a new game
            LoadingSceneManager.LoadScene("BaseXiaoRen");
        }
    }
}

