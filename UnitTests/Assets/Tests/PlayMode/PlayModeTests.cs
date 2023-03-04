using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayModeTests
{
    [UnityTest]
    public IEnumerator Projectile_morethan5s_isINactive()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        GameObject testObject = new GameObject();
        DestroyObj destroyObj = testObject.AddComponent<DestroyObj>();

        yield return new WaitForSeconds(6);
        Assert.IsFalse(testObject.activeSelf);
        //initial approach: destroyed obj and checked for null but bug
        //Assert.IsNull(testObject); //expected: null, but was <null> ???
        //Assert.AreEqual(null,testObject);
    }

    [UnityTest]
    public IEnumerator Projectile_ifNotInstantiated_isNull()
    {
        yield return null;
        var playerObject = GameObject.FindGameObjectWithTag("Bullet");
        Assert.IsNull(playerObject);
    }

    [UnityTest]
    public IEnumerator Projectile_lessthan5s_isActive()
    {
        GameObject testObject = new GameObject();
        DestroyObj destroyObj = testObject.AddComponent<DestroyObj>();

        yield return new WaitForSeconds(5);
        //Ctrl+R+M => extract method for efficient code
        Assert.IsTrue(testObject.activeSelf);
    }
}
