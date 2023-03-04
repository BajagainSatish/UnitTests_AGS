using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(-10)]
    [TestCase(0)]
    [TestCase(-1)]
    public void DisableOnDeath_EmptyHealth_ObjectSetInactive(int hp) //NAMING CONVENTION => name.of.method.you're.testing_situtation.you're.putting.the.function.in_expected.result
    {
        //create a new gameobject and attach our script to that gameobject
        GameObject testObject = MakeFakeEnemy(0);

        // Use the Assert class to test conditions
        Assert.IsFalse(testObject.activeSelf); //check whether the object is still active after implementing above code
        //test run true if false(activeobject) i.e. object not active
    }

    [Test]
    [TestCase(1)]
    [TestCase(50)]
    [TestCase(100)]
    //[TestCase(50.4f)] //gives error as we have all int values, to make this run replace all int by float
    public void DisableOnDeath_HasHealth_ObjectRemainActive(int hp)
    {
        //create a new gameobject and attach our script to that gameobject
        GameObject testObject = MakeFakeEnemy(20);

        // Use the Assert class to test conditions
        Assert.IsTrue(testObject.activeSelf); //check whether the object is still active after implementing above code
        //test run true if true(activeobject) i.e. object active
    }

    private static GameObject MakeFakeEnemy(int health)
    {
        GameObject testObject = new GameObject();
        Enemy enemyScript = testObject.AddComponent<Enemy>();

        enemyScript.currentHealth = health;
        enemyScript.DisableOnDeath();
        return testObject;
    }
}
