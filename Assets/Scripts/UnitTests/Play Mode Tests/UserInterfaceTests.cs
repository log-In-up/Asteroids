using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.TestTools;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Text;
using System.Linq;
using UserInterface;

public class UserInterfaceTests
{
    #region Fields
    private GameObject _userInterface = null;

    private AsyncOperationHandle<GameObject> handleLoadUserInterface;

    private const string USER_INTERFACE = "User Interface",
        SCREEN_CONTENT = "User Interface(Clone)/Screen Content",
        BATTLE_RESULT = "Battle Result Screen", BATTLE = "Battle Screen",
        CHARACTERISTICS = "Characteristics Screen", GAME_LOADING = "Game Loading Screen",
        INVENTORY = "Inventory Screen", ITEM_STAT = "Item Stat Screen",
        LEVELS = "Levels Screen", MAIN_MENU = "Main Menu Screen",
        SETTINGS = "Settings Screen", SPLASH = "Splash Screen", STORE = "Store Screen";
    #endregion

    #region Test setup
    [SetUp]
    public void Setup()
    {
        handleLoadUserInterface = Addressables.LoadAssetAsync<GameObject>(USER_INTERFACE);

        handleLoadUserInterface.Completed += OnCompleteLoadUserInterface;
    }

    [TearDown]
    public void Teardown()
    {
        handleLoadUserInterface.Completed -= OnCompleteLoadUserInterface;
    }
    #endregion

    #region Tests
    [Test]
    public void UserInterfaceTestsSimplePasses() { }

    [UnityTest]
    public IEnumerator OpenScreenTest()
    {
        while (!handleLoadUserInterface.IsDone)
        {
            yield return null;
        }

        GameObject ui = Object.Instantiate(_userInterface);

        UICore uiCore = ui.GetComponent<UICore>();
        uiCore.OpenScreen(UIScreen.BattleScreen);

        GameObject uiCoreObj = GameObject.Find(SCREEN_CONTENT);
        RectTransform[] screens = uiCoreObj.GetComponentsInChildren<RectTransform>(true);

        List<bool> actual = new List<bool>();
        foreach (RectTransform screen in screens)
        {
            actual.Add(screen.gameObject.activeInHierarchy);
        }

        List<bool> expected = new List<bool>()
        { 
            true, false, true, false, false, false, false, false, false, false, false, false
        };

        Assert.AreEqual(expected, actual);
    }
    #endregion

    #region Event methods
    private void OnCompleteLoadUserInterface(AsyncOperationHandle<GameObject> loadedObject)
    {
        _userInterface = loadedObject.Result;
    }
    #endregion
}
