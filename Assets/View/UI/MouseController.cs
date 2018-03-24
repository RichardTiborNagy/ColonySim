using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public string JobType { get; set; }

    public int startingX;
    public int startingY;
    public int currentX;
    public int currentY;

    private bool multipleSelection = false;

    void Update () {

        if (Input.mousePosition.x <= 128 && Input.mousePosition.y <= 75) return;

        Vector3 currPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentX = Mathf.RoundToInt(currPos.x);
        currentY = Mathf.RoundToInt(currPos.y);

        currentX=Mathf.Clamp(currentX, 0, 49);
        currentY=Mathf.Clamp(currentY, 0, 49);
        startingX=Mathf.Clamp(startingX, 0, 49);
        startingY=Mathf.Clamp(startingY, 0, 49);

        if (Input.GetMouseButtonDown(0))
        {
            
            startingX = currentX;
            startingY = currentY;
            multipleSelection = true;
        }

        if (Input.GetMouseButton(0) && multipleSelection)
        {
            gameObject.transform.position = new Vector3((startingX + currentX) / 2f, (startingY + currentY) / 2f);
            gameObject.transform.localScale = new Vector3(Mathf.Abs(currentX - startingX) + 1, Mathf.Abs(currentY - startingY) + 1, 1);
        }
        else
        {
            gameObject.transform.position = new Vector3(currentX, currentY);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }


        if (Input.GetMouseButtonUp(0))
        {

            multipleSelection = false;

            if (currentX < startingX)
            {
                currentX += startingX;
                startingX = -(startingX - currentX);
                currentX -= startingX;
            }
            if (currentY < startingY)
            {
                currentY += startingY;
                startingY = -(startingY - currentY);
                currentY -= startingY;
            }



            if(JobType != null)
            {
                if (JobType == "Cancel")
                {
                    for (int i = startingX; i <= currentX; i++)
                    {
                        for (int j = startingY; j <= currentY; j++)
                        {
                            World.Current.JobManager.CancelJob(World.Current[i, j]);
                        }
                    }

                    return;
                }

                for (int i = startingX; i <= currentX; i++)
                {
                    for (int j = startingY; j <= currentY; j++)
                    {
                        World.Current.JobManager.CreateJob(Prototypes.Jobs.Get(JobType), World.Current[i, j]);
                    }
                }
            }
        }

    }
}
