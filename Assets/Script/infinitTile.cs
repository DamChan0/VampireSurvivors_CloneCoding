using UnityEngine;

public class InfiniteTileMap : MonoBehaviour
{
    public GameObject tileMapPrefab; // 타일맵 프리팹 (미리 만들어진 타일맵 오브젝트)
    public int tileSize = 20; // 하나의 타일맵 크기 (타일 단위)
    public int gridSize = 3; // 타일맵 배열 크기 (여기서는 3x3 배열)

    private GameObject[,] tileMapGrid; // 타일맵을 저장하는 2D 배열
    private Transform player; // 플레이어 위치를 추적하기 위한 변수

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // 태그가 "Player"인 오브젝트를 찾음
        tileMapGrid = new GameObject[gridSize, gridSize]; // 3x3 배열 초기화

        // 타일맵 생성 및 초기 위치 설정
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0); // 각 타일맵의 초기 위치 계산
                tileMapGrid[x, y] = Instantiate(tileMapPrefab, position, Quaternion.identity); // 타일맵 생성
            }
        }
    }

    void Update()
    {
        Vector3 playerPosition = player.position; // 플레이어의 현재 월드 좌표 가져오기
        int playerTileX = Mathf.FloorToInt(playerPosition.x / tileSize); // 플레이어가 속한 타일맵의 X 인덱스
        int playerTileY = Mathf.FloorToInt(playerPosition.y / tileSize); // 플레이어가 속한 타일맵의 Y 인덱스

        // 타일맵 재배치 검사
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 tilePosition = tileMapGrid[x, y].transform.position; // 현재 타일맵 위치
                int tileX = Mathf.FloorToInt(tilePosition.x / tileSize); // 현재 타일맵의 X 인덱스
                int tileY = Mathf.FloorToInt(tilePosition.y / tileSize); // 현재 타일맵의 Y 인덱스

                // 플레이어와 너무 멀어진 타일맵을 새 위치로 이동
                if (Mathf.Abs(tileX - playerTileX) > 1 || Mathf.Abs(tileY - playerTileY) > 1)
                {
                    tileMapGrid[x, y].transform.position = new Vector3(
                        (tileX + (tileX < playerTileX ? gridSize : -gridSize)) * tileSize, // 새로운 X 위치
                        (tileY + (tileY < playerTileY ? gridSize : -gridSize)) * tileSize, // 새로운 Y 위치
                        0
                    );
                }
            }
        }
    }
}
