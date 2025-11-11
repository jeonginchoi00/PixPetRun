
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
    }

    public enum PopupType
    {
        NONE = 0,


    }
    #endregion
}
