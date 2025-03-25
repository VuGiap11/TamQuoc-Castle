using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsBuyManager : MonoBehaviour
{
    public int rows = 1; // Số hàng
    public int columns = 13; // Số cột
    public float spacing = 1f; // Khoảng cách giữa các điểm
    public List<Vector3> gridPoints = new List<Vector3>();
    public List<ImageTeamBuy> imageMaps = new List<ImageTeamBuy>();
    public ImageTeamBuy pointPrefabs;
    public Transform SpawnPoint;
    public Transform pos01;
    public Transform PosHero;

    public static TeamsBuyManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GeneratePoints();
    }
    void GeneratePoints()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = col * spacing;
                float y = row * spacing;
                Vector3 point = pos01.position + new Vector3(x, -y, 0f);
                gridPoints.Add(point);
                ImageTeamBuy imageMap;
                //heroShowAvatar = Instantiate(HeroShowAvatarPreb);
                //imageMap = Instantiate(pointPrefabs, point, Quaternion.identity);
                imageMap = Instantiate(pointPrefabs);
                imageMap.transform.position = point;
                imageMap.x = col;
                imageMap.y = row;
                if (imageMap.TryGetComponent<ImageTeamBuy>(out ImageTeamBuy show))
                {
                    this.imageMaps.Add(show);
                    //show.ChangeBackGround();
                }
                imageMap.transform.SetParent(SpawnPoint.transform);
            }
        }
    }
}
