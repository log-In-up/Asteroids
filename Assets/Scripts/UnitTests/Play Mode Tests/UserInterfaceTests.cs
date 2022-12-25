using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.TestTools;
using UserInterface;
using UserInterface.Screens;

public class UserInterfaceTests
{
    #region Fields
    private AsyncOperationHandle<GameObject> handleLoadUserInterface;

    private const string USER_INTERFACE = "User Interface",
        SCREEN_CONTENT = "User Interface(Clone)/Screen Content";
    #endregion

    #region Test setup
    [SetUp]
    public void Setup()
    {
        handleLoadUserInterface = Addressables.LoadAssetAsync<GameObject>(USER_INTERFACE);
    }

    [TearDown]
    public void Teardown()
    {

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

        GameObject ui = Object.Instantiate(handleLoadUserInterface.Result);

        UICore uiCore = ui.GetComponent<UICore>();
        uiCore.OpenScreen(UIScreen.BattleScreen);

        GameObject uiCoreObj = GameObject.Find(SCREEN_CONTENT);
        ScreenObserver[] screens = uiCoreObj.GetComponentsInChildren<ScreenObserver>(true);

        List<bool> actual = new List<bool>();
        foreach (ScreenObserver screen in screens)
        {
            actual.Add(screen.gameObject.activeInHierarchy);
        }

        List<bool> expected = new List<bool>()
        { 
            false, true, false, false, false, false, false, false, false, false, false
        };

        Assert.AreEqual(expected, actual);
    }
    #endregion
}
