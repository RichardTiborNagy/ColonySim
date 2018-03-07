using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RobotPrototypes
{
    private static readonly Dictionary<string, Robot> Robots;

    public static Robot CloneRobot(string type)
    {
        return new Robot(Robots[type]);
    }

    static RobotPrototypes()
    {
        Robots = new Dictionary<string, Robot>();
        CreatePrototypes();
    }

    private static void CreatePrototypes()
    {
        Robots.Add("Construction", new Robot("Construction", 5));
    }
}
