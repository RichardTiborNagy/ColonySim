using UnityEngine;

public class Test : MonoBehaviour
{
    //private float _timer = 1f;
    
    // Use this for initialization
    void Start ()
    {
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        World.Current.CreateRobot(Prototypes.Robots.Get("Construction"), World.Current[45,49]);
        
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[5, 5]);
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[5, 6]);
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[4, 5]);
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 5]);
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 6]);
        //World.Current.CreateBuilding(BuildingPrototypes.CloneBuilding("Wall"), World.Current[6, 7]);
        //World.Current.CreateJob(JobPrototypes.CloneJob("BuildWall"), World.Current[20,20]);

        //foreach (var tile in World.Current[0,0].TilesInRange(1))
        //{
        //    Debug.Log(tile.X + " " + tile.Y);
        //}

    }
    
    // Update is called once per frame
    void Update ()
    {
        //World.Current.Update(Time.deltaTime);
    }
}
