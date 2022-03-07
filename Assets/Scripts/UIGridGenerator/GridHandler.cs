using UnityEngine;
using UnityEngine.UI;

public class GridHandler : MonoBehaviour
{
    // Input variables.
    [SerializeField] GameObject tilePrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] int columns = 0;
    [SerializeField] int rows = 0;
    [SerializeField] int areaOfInterest = 0;

    // Scree size in pixels.
    float screenHeight = 0;
    float screenWidth = 0;

    // Reference screen size in pixels.
    float refScreenHeight = 575;
    float refScreenWidth = 325;
    float heightToWidthRatio = 0.6f;

    // Screen safe area.
    Rect safeArea;
    float safeAreaWidth = 0;
    float safeAreaHeight = 0;
    float bottomOffset = 100;

    // Tile size as per screen size.
    float tileHeight = 0;
    float tileWidth = 0;
    float tileOffset = 0;

    // Font size as per screen size.
    int refFontSize = 40;
    int fontSize = 0;

    // 2D array to store reference of tiles.
    public GameObject[,] tileGrid = null;

    // 2D array to store wether tile is open or not.
    public bool[,] tileState = null;

    // Previous grid size to delete that grid.
    int currentRowNumber = 0;
    int currentColNumber = 0;

    // To avoid opening of tiles when menu panel is open.
    [HideInInspector] public bool canOpenTile = true;

    void Start()
    {
        GenerateUIGrid();
    }

    void Update()
    {
        // To detect touch input and open tiles accordingly.
        if(Input.touchCount > 0 && canOpenTile)
        {
            float touch_x = Input.GetTouch(0).position.x;
            float touch_y = Input.GetTouch(0).position.y;

            // To get tile index based on touch position.
            int rowNumber = (int)((safeAreaHeight / (tileHeight + tileOffset)) - (touch_y / (tileHeight + tileOffset)));
            int columnNumber = (int)(touch_x / (tileWidth + tileOffset));

            // To ensure index is within range.
            if (rowNumber < currentRowNumber && rowNumber >= 0 && columnNumber < currentColNumber && columnNumber >= 0)
            {
                OpenTiles(rowNumber, columnNumber);
            }
        }
    }

    // To calculate and set values of all variables.
    public void SetAllVariables()
    {
        // Distance between two consecutive tiles.
        tileOffset = 3f;

        // To generate tiles within safe area.
        safeArea = Screen.safeArea;
        safeAreaWidth = safeArea.width;
        safeAreaHeight = safeArea.height;

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        tileWidth = (safeAreaWidth - (tileOffset * (columns + 1))) / columns;

        //  Bottom margin.
        float bottonOffset = bottomOffset * Mathf.Max((screenHeight / refScreenHeight), (screenWidth / refScreenWidth));

        tileHeight = (safeAreaHeight - bottonOffset - (tileOffset * (rows + 1))) / rows;
        tileHeight = Mathf.Min(tileHeight, tileWidth * heightToWidthRatio);

        fontSize = refFontSize;
    }

    public int GetAreaOfInterest()
    {
        return areaOfInterest;
    }

    public void SetAreaOfInterest(int aoi)
    {
        areaOfInterest = aoi;
    }

    public int GetColumnNumber()
    {
        return columns;
    }

    public void SetColumnNumber(int col)
    {
        columns = col;
    }

    public int GetRowNumber()
    {
        return rows;
    }

    public void SetRowNumber(int row)
    {
        rows = row;
    }

    // To generate UI grid as per row and column number.
    public void GenerateUIGrid()
    {
        DeletGrid();
        SetAllVariables();

        tileGrid = new GameObject[rows, columns];
        tileState = new bool[rows, columns];

        Image tempImage;
        Text tempText;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // To create new tile.
                GameObject tile = Instantiate(tilePrefab);

                // To attach newly created tile to canvas.
                tile.transform.SetParent(canvas.transform);

                tempImage = tile.GetComponent<Image>();

                // To calulate x and y position of tile on screen.
                float x_position = (tileWidth * j) + (tileOffset * (j + 1));
                float y_position = safeAreaHeight - ((tileHeight * i) + (tileOffset * (i + 1)));

                // To set tile position and its height and width.
                tempImage.rectTransform.position = new Vector2( x_position, y_position);
                tempImage.rectTransform.sizeDelta = new Vector2(tileWidth, tileHeight);

                tempText = tempImage.GetComponentInChildren<Text>();
                tempText.fontSize = fontSize;

                // To display randlomy generated data.
                tempText.text = (Random.Range(0, (rows + columns))).ToString();
                tempText.enabled = false;

                // To store reference of tile in array.
                tileGrid[i,j] = tile;
                tileState[i,j] = false;
            }
        }

        currentRowNumber = rows;
        currentColNumber = columns;
    }

    // To open tiles based on values of AOI, row and column number.
    void OpenTiles(int rowNumber, int columnNumber)
    {
        for(int i= -areaOfInterest; i <= areaOfInterest; i++)
        {
            for(int j= -areaOfInterest; j <= areaOfInterest; j++)
            {
                if( (i + rowNumber) < currentRowNumber && (rowNumber + i) >= 0  && (j + columnNumber) < currentColNumber && (columnNumber + j) >= 0)
                {
                    if( !tileState[rowNumber + i, columnNumber + j] ) 
                    {
                        // To display data.
                        tileGrid[rowNumber + i, columnNumber + j].GetComponentInChildren<Text>().enabled = true;
                        
                        // To set color of tile.
                        tileGrid[rowNumber + i, columnNumber + j].GetComponent<Image>().color = GetRandomColour();

                        // To change state of tile to opened.
                        tileState[rowNumber + i, columnNumber + j] = true;
                    }
                }
            }
        }
    }

    // Random color generator.
    Color GetRandomColour()
    {
        return new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          1f
        );
    }

    // To destroy all grid elements.
    void DeletGrid()
    {
        if(tileGrid != null)
        {
            for (int i = 0; i < currentRowNumber; i++)
            {
                for (int j = 0; j < currentColNumber; j++)
                {
                    Destroy(tileGrid[i,j]);
                }
            }
            tileGrid = null;
            tileState = null;
        }
    }
}
