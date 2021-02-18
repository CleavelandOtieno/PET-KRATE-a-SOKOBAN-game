using System;
using System.Drawing;

namespace GAMEPROJECTBYCLEAVELANDO

{
    public enum ItemType
    {
        Wall,
        Floor,
        Package,
        Goal,
        Sokoban,
        PackageOnGoal,
        SokobanOnGoal,
        Space
    }
    public enum MoveDirection
    {
        Right,
        Up,
        Down,
        Left
    }
	public class Level
	{
	    private string name = string.Empty;
	    private ItemType[,] levelMap;
	    private int nrOfGoals = 0;
	    private int levelNr = 0;
	    private int width = 0;
	    private int height = 0;
	    private string levelSetName = string.Empty;
	    
	    private int moves = 0;
	    private int pushes = 0;             
	    
	    private int sokoPosX;         
	    private int sokoPosY; 
	    
	    private bool isUndoable = false;
	    private MoveDirection sokoDirection = MoveDirection.Right;
	    public const int ITEM_SIZE = 30;
	    private Item item1, item2, item3;
	    private Item item1U, item2U, item3U;
	    private int movesBeforeUndo = 0;
	    private int pushesBeforeUndo = 0; 
        private Bitmap img;
        private Graphics g;
		
        public string Name
        {
            get { return name; }
        }
        
        public int LevelNr
        {
            get { return levelNr; }
        }
        
        public int Width
        {
            get { return width; }
        }
        
        public int Height
        {
            get { return height; }
        }
        
        public string LevelSetName
        {
            get { return levelSetName; }
        }

        public int Moves
        {
            get { return moves; }
        }
        
        public int Pushes
        {
            get { return pushes; }
        }
        
        public bool IsUndoable
        {
            get { return isUndoable; }
        }
		public Level(string aName, ItemType[,] aLevelMap, int aWidth,
		    int aHeight, int aNrOfGoals, int aLevelNr, string aLevelSetName)
		{
		    name = aName;
			width = aWidth;
			height = aHeight;
			levelMap = aLevelMap;
			nrOfGoals = aNrOfGoals;
			levelNr = aLevelNr;
			levelSetName = aLevelSetName;
		}
		public Image DrawLevel()
		{
            int levelWidth = (width + 2) * Level.ITEM_SIZE;
            int levelHeight = (height + 2) * Level.ITEM_SIZE;
            
            img = new Bitmap(levelWidth, levelHeight);
            g = Graphics.FromImage(img);
            
		    Font statusText = new Font("Tahoma", 10, FontStyle.Bold);
		    
            g.Clear(Color.FromArgb(27, 33, 61));
            for (int i = 0; i < width + 2; i++)
            {
                g.DrawImage(ImgSpace, ITEM_SIZE * i, 0,
                    ITEM_SIZE, ITEM_SIZE);
                g.DrawImage(ImgSpace, ITEM_SIZE * i,
                    (height + 1) * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            }
            for (int i = 1; i < height + 1; i++)
                g.DrawImage(ImgSpace, 0, ITEM_SIZE * i,
                    ITEM_SIZE, ITEM_SIZE);
            for (int i = 1; i < height + 1; i++)
                g.DrawImage(ImgSpace, (width + 1) * ITEM_SIZE,
                    ITEM_SIZE * i, ITEM_SIZE, ITEM_SIZE);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Image image = GetLevelImage(levelMap[i, j], sokoDirection);

                    g.DrawImage(image, ITEM_SIZE + i * ITEM_SIZE,
                        ITEM_SIZE + j * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
                    
                    
                    if (levelMap[i, j] == ItemType.Sokoban ||
                        levelMap[i, j] == ItemType.SokobanOnGoal)
                    {
                        sokoPosX = i;
                        sokoPosY = j;
                    }
                }
            }
            
            return img;
		}
		public Image DrawChanges()
		{
            Image image1 = GetLevelImage(item1.ItemType, sokoDirection);
            g.DrawImage(image1, ITEM_SIZE + item1.XPos * ITEM_SIZE,
                ITEM_SIZE + item1.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
		    
            Image image2 = GetLevelImage(item2.ItemType, sokoDirection);
            g.DrawImage(image2, ITEM_SIZE + item2.XPos * ITEM_SIZE,
                ITEM_SIZE + item2.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            
            if (item3 != null)
            {
                Image image3 = GetLevelImage(item3.ItemType, sokoDirection);
                g.DrawImage(image3, ITEM_SIZE + item3.XPos * ITEM_SIZE,
                    ITEM_SIZE + item3.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            }
            
            return img;
		}
		public bool IsFinished()
		{
		    int nrOfPackagesOnGoal = 0;
		    
		    for (int i = 0; i < width; i++)
		        for (int j = 0; j < height; j++)
		            if (levelMap[i, j] == ItemType.PackageOnGoal)
		                nrOfPackagesOnGoal++;
		            
		    return nrOfPackagesOnGoal == nrOfGoals ? true : false;
		}
		public Image Undo()
		{
            Image image1 = GetLevelImage(item1U.ItemType, sokoDirection);
            g.DrawImage(image1, ITEM_SIZE + item1U.XPos * ITEM_SIZE,
                ITEM_SIZE + item1U.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            levelMap[item1U.XPos, item1U.YPos] = item1U.ItemType;
		
            Image image2 = GetLevelImage(item2U.ItemType, sokoDirection);
            g.DrawImage(image2, ITEM_SIZE + item2U.XPos * ITEM_SIZE,
                ITEM_SIZE + item2U.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            levelMap[item2U.XPos, item2U.YPos] = item2U.ItemType;

            Image image3 = GetLevelImage(item3U.ItemType, sokoDirection);
            g.DrawImage(image3, ITEM_SIZE + item3U.XPos * ITEM_SIZE,
                ITEM_SIZE + item3U.YPos * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
            levelMap[item3U.XPos, item3U.YPos] = item3U.ItemType;
            if (!(sokoPosX == item1U.XPos && sokoPosY == item1U.YPos))
            {
                if (levelMap[sokoPosX, sokoPosY] == ItemType.Sokoban)
                {
                    levelMap[sokoPosX, sokoPosY] = ItemType.Floor;
                    g.DrawImage(GetLevelImage(ItemType.Floor, MoveDirection.Up),
                        ITEM_SIZE + sokoPosX * ITEM_SIZE, ITEM_SIZE +
                        sokoPosY * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
                }
                else if (levelMap[sokoPosX, sokoPosY] == ItemType.SokobanOnGoal)
                {
                    levelMap[sokoPosX, sokoPosY] = ItemType.Goal;
                    g.DrawImage(GetLevelImage(ItemType.Goal, MoveDirection.Up),
                        ITEM_SIZE + sokoPosX * ITEM_SIZE, ITEM_SIZE +
                        sokoPosY * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE);
                }
            }
            sokoPosX = item1U.XPos;
            sokoPosY = item1U.YPos;
            moves = movesBeforeUndo;
            pushes = pushesBeforeUndo;
            
            isUndoable = false;
		    
		    return img;
		}
        public void MoveSokoban(MoveDirection direction)
        {
            sokoDirection = direction;
		    
            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUp();
                    break;
                case MoveDirection.Down:
                    MoveDown();
                    break;
                case MoveDirection.Right:
                    MoveRight();
                    break;
                case MoveDirection.Left:
                    MoveLeft();
                    break;
            }
        }
		private void MoveUp()
		{
		    if ((levelMap[sokoPosX, sokoPosY - 1] == ItemType.Package ||
		        levelMap[sokoPosX, sokoPosY - 1] == ItemType.PackageOnGoal) &&
		        (levelMap[sokoPosX, sokoPosY - 2] == ItemType.Floor ||
		        levelMap[sokoPosX, sokoPosY - 2] == ItemType.Goal))
		    {
		        item3U = new Item(levelMap[sokoPosX, sokoPosY - 2], sokoPosX, sokoPosY - 2);
		        item2U = new Item(levelMap[sokoPosX, sokoPosY - 1], sokoPosX, sokoPosY - 1);
		        item1U = new Item(levelMap[sokoPosX, sokoPosY], sokoPosX, sokoPosY);
		        
		        if (levelMap[sokoPosX, sokoPosY - 2] == ItemType.Floor)
		        {
		            levelMap[sokoPosX, sokoPosY - 2] = ItemType.Package;
		            item3 = new Item(ItemType.Package, sokoPosX, sokoPosY - 2);
		        }
		        else if (levelMap[sokoPosX, sokoPosY - 2] == ItemType.Goal)
		        {
		            levelMap[sokoPosX, sokoPosY - 2] = ItemType.PackageOnGoal;
		            item3 = new Item(ItemType.PackageOnGoal, sokoPosX, sokoPosY - 2);
		        }
                if (levelMap[sokoPosX, sokoPosY - 1] == ItemType.Package)
                {
                    levelMap[sokoPosX, sokoPosY - 1] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX, sokoPosY - 1);
                }
                else if (levelMap[sokoPosX, sokoPosY - 1] == ItemType.PackageOnGoal)
                {
                    levelMap[sokoPosX, sokoPosY - 1] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX, sokoPosY - 1);
                }
                
                isUndoable = true;
                UpdateCurrentSokobanPosition();
                movesBeforeUndo = moves;
                pushesBeforeUndo = pushes;
                moves++;
                pushes++;
                sokoPosY--;
		    }
		    else if (levelMap[sokoPosX, sokoPosY - 1] == ItemType.Floor ||
		        levelMap[sokoPosX, sokoPosY - 1] == ItemType.Goal)
		    {
                if (levelMap[sokoPosX, sokoPosY - 1] == ItemType.Floor)
                {
                    levelMap[sokoPosX, sokoPosY - 1] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX, sokoPosY - 1);
                }
                else if (levelMap[sokoPosX, sokoPosY - 1] == ItemType.Goal)
                {
                    levelMap[sokoPosX, sokoPosY - 1] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX, sokoPosY - 1);
                }
                
                item3 = null;
                UpdateCurrentSokobanPosition();
                moves++;
                sokoPosY--;
		    }
		}
		private void MoveDown()
		{
            if ((levelMap[sokoPosX, sokoPosY + 1] == ItemType.Package ||
                levelMap[sokoPosX, sokoPosY + 1] == ItemType.PackageOnGoal) &&
                (levelMap[sokoPosX, sokoPosY + 2] == ItemType.Floor ||
                levelMap[sokoPosX, sokoPosY + 2] == ItemType.Goal))
            {
                item3U = new Item(levelMap[sokoPosX, sokoPosY + 2], sokoPosX, sokoPosY + 2);
                item2U = new Item(levelMap[sokoPosX, sokoPosY + 1], sokoPosX, sokoPosY + 1);
                item1U = new Item(levelMap[sokoPosX, sokoPosY], sokoPosX, sokoPosY);
                
                if (levelMap[sokoPosX, sokoPosY + 2] == ItemType.Floor)
                {
                    levelMap[sokoPosX, sokoPosY + 2] = ItemType.Package;
                    item3 = new Item(ItemType.Package, sokoPosX, sokoPosY + 2);
                }
                else if (levelMap[sokoPosX, sokoPosY + 2] == ItemType.Goal)
                {
                    levelMap[sokoPosX, sokoPosY + 2] = ItemType.PackageOnGoal;
                    item3 = new Item(ItemType.PackageOnGoal, sokoPosX, sokoPosY + 2);
                }
		            
                if (levelMap[sokoPosX, sokoPosY + 1] == ItemType.Package)
                {
                    levelMap[sokoPosX, sokoPosY + 1] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX, sokoPosY + 1);
                }
                else if (levelMap[sokoPosX, sokoPosY + 1] == ItemType.PackageOnGoal)
                {
                    levelMap[sokoPosX, sokoPosY + 1] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX, sokoPosY + 1);
                }
                
                isUndoable = true;
                UpdateCurrentSokobanPosition();
                movesBeforeUndo = moves;
                pushesBeforeUndo = pushes;
                moves++;
                pushes++;
                sokoPosY++;
            }
            else if (levelMap[sokoPosX, sokoPosY + 1] == ItemType.Floor ||
                levelMap[sokoPosX, sokoPosY + 1] == ItemType.Goal)
            {
                if (levelMap[sokoPosX, sokoPosY + 1] == ItemType.Floor)
                {
                    levelMap[sokoPosX, sokoPosY + 1] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX, sokoPosY + 1);
                }
                else if (levelMap[sokoPosX, sokoPosY + 1] == ItemType.Goal)
                {
                    levelMap[sokoPosX, sokoPosY + 1] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX, sokoPosY + 1);
                }
                
                item3 = null;
                UpdateCurrentSokobanPosition();
                moves++;
                sokoPosY++;
            }
        }
        private void MoveRight()
        {
            if ((levelMap[sokoPosX + 1, sokoPosY] == ItemType.Package ||
                levelMap[sokoPosX + 1, sokoPosY] == ItemType.PackageOnGoal) &&
                (levelMap[sokoPosX + 2, sokoPosY] == ItemType.Floor ||
                levelMap[sokoPosX + 2, sokoPosY] == ItemType.Goal))
            {
                item3U = new Item(levelMap[sokoPosX + 2, sokoPosY], sokoPosX + 2, sokoPosY);
                item2U = new Item(levelMap[sokoPosX + 1, sokoPosY], sokoPosX + 1, sokoPosY);
                item1U = new Item(levelMap[sokoPosX, sokoPosY], sokoPosX, sokoPosY);
                
                if (levelMap[sokoPosX + 2, sokoPosY] == ItemType.Floor)
                {
                    levelMap[sokoPosX + 2, sokoPosY] = ItemType.Package;
                    item3 = new Item(ItemType.Package, sokoPosX + 2, sokoPosY);
                }
                else if (levelMap[sokoPosX + 2, sokoPosY] == ItemType.Goal)
                {
                    levelMap[sokoPosX + 2, sokoPosY] = ItemType.PackageOnGoal;
                    item3 = new Item(ItemType.PackageOnGoal, sokoPosX + 2, sokoPosY);
		        }    
                if (levelMap[sokoPosX + 1, sokoPosY] == ItemType.Package)
                {
                    levelMap[sokoPosX + 1, sokoPosY] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX + 1, sokoPosY);
                }
                else if (levelMap[sokoPosX + 1, sokoPosY] == ItemType.PackageOnGoal)
                {
                    levelMap[sokoPosX + 1, sokoPosY] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX + 1, sokoPosY);
                }
                
                isUndoable = true;
                UpdateCurrentSokobanPosition();
                movesBeforeUndo = moves;
                pushesBeforeUndo = pushes;
                moves++;
                pushes++;
                sokoPosX++;
            }
            else if (levelMap[sokoPosX + 1, sokoPosY] == ItemType.Floor ||
                levelMap[sokoPosX + 1, sokoPosY] == ItemType.Goal)
            {
                if (levelMap[sokoPosX + 1, sokoPosY] == ItemType.Floor)
                {
                    levelMap[sokoPosX + 1, sokoPosY] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX + 1, sokoPosY);
                }
                else if (levelMap[sokoPosX + 1, sokoPosY] == ItemType.Goal)
                {
                    levelMap[sokoPosX + 1, sokoPosY] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX + 1, sokoPosY);
                }
                
                item3 = null;
                UpdateCurrentSokobanPosition();
                moves++;
                sokoPosX++;
            }
        }
        
        
        /// <summary>
        /// Move left
        /// </summary>
        private void MoveLeft()
        {
            if ((levelMap[sokoPosX - 1, sokoPosY] == ItemType.Package ||
                levelMap[sokoPosX - 1, sokoPosY] == ItemType.PackageOnGoal) &&
                (levelMap[sokoPosX - 2, sokoPosY] == ItemType.Floor ||
                levelMap[sokoPosX - 2, sokoPosY] == ItemType.Goal))
            {
                item3U = new Item(levelMap[sokoPosX - 2, sokoPosY], sokoPosX - 2, sokoPosY);
                item2U = new Item(levelMap[sokoPosX - 1, sokoPosY], sokoPosX - 1, sokoPosY);
                item1U = new Item(levelMap[sokoPosX, sokoPosY], sokoPosX, sokoPosY);
                
                if (levelMap[sokoPosX - 2, sokoPosY] == ItemType.Floor)
                {
                    levelMap[sokoPosX - 2, sokoPosY] = ItemType.Package;
                    item3 = new Item(ItemType.Package, sokoPosX - 2, sokoPosY);
                }
                else if (levelMap[sokoPosX - 2, sokoPosY] == ItemType.Goal)
                {
                    levelMap[sokoPosX - 2, sokoPosY] = ItemType.PackageOnGoal;
                    item3 = new Item(ItemType.PackageOnGoal, sokoPosX - 2, sokoPosY);
		        }    
                if (levelMap[sokoPosX - 1, sokoPosY] == ItemType.Package)
                {
                    levelMap[sokoPosX - 1, sokoPosY] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX - 1, sokoPosY);
                }
                else if (levelMap[sokoPosX - 1, sokoPosY] == ItemType.PackageOnGoal)
                {
                    levelMap[sokoPosX - 1, sokoPosY] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX - 1, sokoPosY);
                }
                
                isUndoable = true;
                UpdateCurrentSokobanPosition();
                movesBeforeUndo = moves;
                pushesBeforeUndo = pushes;
                moves++;
                pushes++;
                sokoPosX--;
            }
            else if (levelMap[sokoPosX - 1, sokoPosY] == ItemType.Floor ||
                levelMap[sokoPosX - 1, sokoPosY] == ItemType.Goal)
            {
                if (levelMap[sokoPosX - 1, sokoPosY] == ItemType.Floor)
                {
                    levelMap[sokoPosX - 1, sokoPosY] = ItemType.Sokoban;
                    item2 = new Item(ItemType.Sokoban, sokoPosX - 1, sokoPosY);
                }
                else if (levelMap[sokoPosX - 1, sokoPosY] == ItemType.Goal)
                {
                    levelMap[sokoPosX - 1, sokoPosY] = ItemType.SokobanOnGoal;
                    item2 = new Item(ItemType.SokobanOnGoal, sokoPosX - 1, sokoPosY);
                }
                
                item3 = null;
                UpdateCurrentSokobanPosition();  
                moves++;              
                sokoPosX--;
            }
        }
        private void UpdateCurrentSokobanPosition()
        {
            if (levelMap[sokoPosX, sokoPosY] == ItemType.Sokoban)
            {
                levelMap[sokoPosX, sokoPosY] = ItemType.Floor;
                item1 = new Item(ItemType.Floor, sokoPosX, sokoPosY);
            }
            else if (levelMap[sokoPosX, sokoPosY] == ItemType.SokobanOnGoal)
            {
                levelMap[sokoPosX, sokoPosY] = ItemType.Goal;
                item1 = new Item(ItemType.Goal, sokoPosX, sokoPosY);
            }
        }
		public Image GetLevelImage(ItemType itemType, MoveDirection direction)
		{
		    Image image;
		    
            if (itemType == ItemType.Wall)
                image = ImgWall;
            else if (itemType == ItemType.Floor)
                image = ImgFloor;
            else if (itemType == ItemType.Package)
                image = ImgPackage;
            else if (itemType == ItemType.Goal)
                image = ImgGoal;
            else if (itemType == ItemType.Sokoban)
            {
                if (direction == MoveDirection.Up)
                    image = ImgSokoUp;
                else if (direction == MoveDirection.Down)
                    image = ImgSokoDown;
                else if (direction == MoveDirection.Right)
                    image = ImgSokoRight;
                else
                    image = ImgSokoLeft;
            }
            else if (itemType == ItemType.PackageOnGoal)
                image = ImgPackageGoal;
            else if (itemType == ItemType.SokobanOnGoal)
            {
                if (direction == MoveDirection.Up)
                    image = ImgSokoUpGoal;
                else if (direction == MoveDirection.Down)
                    image = ImgSokoDownGoal;
                else if (direction == MoveDirection.Right)
                    image = ImgSokoRightGoal;
                else
                    image = ImgSokoLeftGoal;
            }
            else
                image = ImgSpace;
            
            return image;
		}
        public Image ImgWall
        {
            get { return
                Image.FromFile("graphics/original/wall2.bmp"); }
        }
		
        public Image ImgFloor
        {
            get { return
                Image.FromFile("graphics/original/floor2.bmp"); }
        }
        
        public Image ImgPackage
        {
            get { return
                Image.FromFile("graphics/original/package2.bmp"); }
        }
        
        public Image ImgPackageGoal
        {
            get { return
                Image.FromFile("graphics/original/package_goal2.bmp"); }
        }
        
        public Image ImgGoal
        {
            get { return
                Image.FromFile("graphics/original/goal2.bmp"); }
        }
        
        public Image ImgSokoUp
        {
            get { return
                Image.FromFile("graphics/original/soko_up2.bmp"); }
        }
        
        public Image ImgSokoDown
        {
            get { return
                Image.FromFile("graphics/original/soko_down2.bmp"); }
        }
        
        public Image ImgSokoRight
        {
            get { return
                Image.FromFile("graphics/original/soko_right2.bmp"); }
        }
        
        public Image ImgSokoLeft
        {
            get { return
                Image.FromFile("graphics/original/soko_left2.bmp"); }
        }
        
        public Image ImgSokoUpGoal
        {
            get { return
                Image.FromFile("graphics/original/soko_goal_up.bmp"); }
        }
        
        public Image ImgSokoDownGoal
        {
            get { return
                Image.FromFile("graphics/original/soko_goal_down.bmp"); }
        }
        
        public Image ImgSokoRightGoal
        {
            get { return
                Image.FromFile("graphics/original/soko_goal_right.bmp"); }
        }
        
        public Image ImgSokoLeftGoal
        {
            get { return
                Image.FromFile("graphics/original/soko_goal_left.bmp"); }
        }
        
        public Image ImgSpace
        {
            get { return
                Image.FromFile("graphics/original/space2.bmp"); }
        }
	}
}
