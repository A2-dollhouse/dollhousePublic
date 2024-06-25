using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public List<ANode> path;
    ANode[,] grid;


    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    void Start()
    {
        nodeDiameter = nodeRadius * 2; // 설정한 노드 반지름으로 지름을 구함
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // 그리드의 x 크기
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter); // 그리드의 y 크기
        CreateGrid();
    }

    //그리드 생성 메서드
    private void CreateGrid()
    {
        grid = new ANode[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
        Vector3 worldPoint;

        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] =new ANode(walkable, worldPoint, x, y);
            }
        }

    }

    // 선택된 노드의 8방향의 이웃노드를 반환해서 열린 목록에 추가하기 위한 함수
    public List<ANode> GetNeighborNodes (ANode node)
    {
        List<ANode> neighbor = new List<ANode>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;     // 자기자신인 경우 스킵

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                // X, Y의 값이 Grid 범위안에 있을 경우
                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbor.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbor;
    }


    // 유니티 상의 WorldPosition 위치값으로 생성된 그리드의 위치로 변환해서 노드를 반환하는 함수 >>> Scene에 있는 현재 오브젝트와 목표 오브젝트가 있는 노드를 얻기 위한 함수
    public ANode GetNodeFromWorldPoint(Vector3 worldPosition) 
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1)*percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1)*percentY);
        return grid[x, y];
    }


    //노드를 시각적으로 표시하는 메서드
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        if(grid != null)
        {
            foreach(ANode node in grid)
            {
                Gizmos.color = (node.isWalkable) ? Color.green : Color.red;
                
                //탐색된 path의 노드표시(검은색)
                if(path != null)
                {
                    if(path.Contains(node))
                        Gizmos.color = Color.black;
                }

                Gizmos.DrawCube(node.worldPos, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
}
