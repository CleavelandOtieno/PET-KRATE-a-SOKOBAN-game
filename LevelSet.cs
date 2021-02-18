using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;

namespace GAMEPROJECTBYCLEAVELANDO
{
    public class LevelSet
    {
        private ArrayList levels = new ArrayList();
        
        private string title = string.Empty;
        private string description = string.Empty;
        private string filename = string.Empty;
        
        private int currentLevel = 0;
        private int nrOfLevelsInSet = 0;
        private int lastFinishedLevel = 0;
		
        public string Title
        {
            get { return title; }
        }
        
        public string Description
        {
            get { return description; }
        }

        public string Filename
        {
            get { return filename; }
        }
        
        public int NrOfLevelsInSet
        {
            get { return nrOfLevelsInSet; }
        }
        
        public int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        
        public int LastFinishedLevel
        {
            set { lastFinishedLevel = value; }
        }
        public LevelSet(string aTitle, string aDescription,int aNrOfLevels, string aFilename)
        {
            title = aTitle;
            description = aDescription;
            nrOfLevelsInSet = aNrOfLevels;
            filename = aFilename;
        }
        public LevelSet() {}
		public Level this[int index]
		{
		    get { return (Level)levels[index]; }
		}
        public void SetLevelSet(string setName)
        {		    
            XmlDocument doc = new XmlDocument();
            doc.Load(setName);
		    
		    filename = setName;
		    title = doc.SelectSingleNode("//Title").InnerText;
		    description = doc.SelectSingleNode("//Description").InnerText;

		    XmlNode levelCollection =doc.SelectSingleNode("//LevelCollection");
		    XmlNodeList levels = doc.SelectNodes("//Level");
		    nrOfLevelsInSet = levels.Count;
        }
        public void SetLevelsInLevelSet(string setName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(setName);
            XmlNodeList levelInfoList = doc.SelectNodes("//Level");
            
            int levelNr = 1;
            foreach (XmlNode levelInfo in levelInfoList)
            {
                LoadLevel(levelInfo, levelNr);
                levelNr++;
            }
        }
        private void LoadLevel(XmlNode levelInfo, int levelNr)
        {           
            XmlAttributeCollection xac = levelInfo.Attributes;
            string levelName = xac["Id"].Value;
            int levelWidth = int.Parse(xac["Width"].Value);
            int levelHeight = int.Parse(xac["Height"].Value);
            int nrOfGoals = 0;
            XmlNodeList levelLayout = levelInfo.SelectNodes("L");
            ItemType[,] levelMap = new ItemType[levelWidth, levelHeight];
            for (int i = 0; i < levelHeight; i++)
            {
                string line = levelLayout[i].InnerText;
                bool wallEncountered = false;
                for (int j = 0; j < levelWidth; j++)
                {
                    if (j >= line.Length)
                        levelMap[j, i] = ItemType.Space;
                    else
                    {
                        switch (line[j].ToString())
                        {
                            case " ":
                                if (wallEncountered)
                                    levelMap[j, i] = ItemType.Floor;
                                else
                                    levelMap[j, i] = ItemType.Space;
                                break;
                            case "#":
                                levelMap[j, i] = ItemType.Wall;
                                wallEncountered = true;
                                break;
                            case "$":
                                levelMap[j, i] = ItemType.Package;
                                break;
                            case ".":
                                levelMap[j, i] = ItemType.Goal;
                                nrOfGoals++;
                                break;
                            case "@":
                                levelMap[j, i] = ItemType.Sokoban;
                                break;
                            case "*":
                                levelMap[j, i] = ItemType.PackageOnGoal;
                                nrOfGoals++;
                                break;
                            case "+":
                                levelMap[j, i] = ItemType.SokobanOnGoal;
                                nrOfGoals++;
                                break;
                            case "=":
                                levelMap[j, i] = ItemType.Space;
                                break;
                        }
                    }
                }
            }
            levels.Add(new Level(levelName, levelMap, levelWidth,
                levelHeight, nrOfGoals, levelNr, title));
        }
        public static ArrayList GetAllLevelSetInfos()
        {
            ArrayList levelSets = new ArrayList();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .GetName().CodeBase).Substring(6);
            string [] fileEntries = Directory.GetFiles(path + "/levels");
            foreach (string filename in fileEntries)
            {
                FileInfo fileInfo = new FileInfo(filename);
                
                if (fileInfo.Extension.Equals(".xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filename);
                    
                    string title = doc.SelectSingleNode("//Title").InnerText;
                    string description =
                        doc.SelectSingleNode("//Description").InnerText;
                    string email = doc.SelectSingleNode("//Email").InnerText;
                    string url = doc.SelectSingleNode("//Url").InnerText;
                    XmlNode levelInfo
                        = doc.SelectSingleNode("//LevelCollection");
                    string author = levelInfo.Attributes[0].Value;
                    XmlNodeList levels = doc.SelectNodes("//Level");
                    
                    levelSets.Add(new LevelSet(title, description,levels.Count, filename));
                }
            }
            
            return levelSets;
        }
    }
}
