using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTests
{
    //Enemy Health Tests
    //multiple test cases with varying health levels
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
    //Enemy Health Tests END

    //Player Movement Test
    /*
    [Test]
    public void MovesAlongXAxis_Right_HorizontalInput()
    {
        GameObject testObject = new GameObject();
        PlayerMovement playerScript = testObject.AddComponent<PlayerMovement>();

        Assert.AreEqual(1(expected value), actual value: playerScript.CalculateMovement((speed)1,(x)1,(z)0,1).x,(time.deltaTime)0.1f);
    }
    */
    [Test]
    public void MovesAlongXAxis_Right_HorizontalInput()
    {
        TestMoveDirection(1, 1, 1, 0);
    }

    [Test]
    public void MovesAlongXAxis_Left_HorizontalInput()
    {
        TestMoveDirection(-1, 1, -1, 0);
    }

    [Test]
    public void MovesAlongZAxis_Up_VerticalInput()
    {
        TestMoveDirection(1, 1, 0, 1);
    }

    [Test]
    public void MovesAlongZAxis_Down_VerticalInput()
    {
        TestMoveDirection(-1,1,0,-1);
    }

    private static void TestMoveDirection(int direction,int speed,int x, int z)
    {
        GameObject testObject = new GameObject();
        PlayerMovement playerScript = testObject.AddComponent<PlayerMovement>();

        if(x == 0)
            Assert.AreEqual(direction, playerScript.CalculateMovement(speed, x, z, 1).z, 0.1f);
        if (z == 0)
            Assert.AreEqual(direction, playerScript.CalculateMovement(speed, x, z, 1).x, 0.1f);
    }
}
