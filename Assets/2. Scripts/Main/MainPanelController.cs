using UnityEngine;

public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton(int index)
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.SinglePlay);
    }

    public void OnClickDualPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.DualPlay);
    }

    public void OnClickMultiPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.MutiPlay);
    }

    public void OnClickSettingButton()
    {
        
    }
}
