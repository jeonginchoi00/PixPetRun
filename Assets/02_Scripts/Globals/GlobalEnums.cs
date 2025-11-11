
namespace Globals
{
    #region Game
    public enum GameState
    {
        GAME_START = 0,
        GAME_CLEAR = 1,
        GAME_END = 2,
        GAME_ALLCLEAR = 3
    }
    #endregion

    #region UI
    public enum PageType
    {
        NONE = 0,

        // Start
        START = 100,

        // Stage
        STAGE = 200,

        // End
        END = 300
    }

    public enum PopupType
    {
        NONE = 0,


    }
    #endregion

    #region SOUND
    public enum SoundType
    {
        // BGM
        BGM = 100,

        // SFX
        SFX_COLLECTED = 200,
        SFX_CLICK = 201,
        SFX_JUMP = 202,
        SFX_CLEAR = 203,
        SFX_GAMEOVER = 204,
        SFX_HIT = 205,
        SFX_SPRING = 206
    }
    #endregion
}
