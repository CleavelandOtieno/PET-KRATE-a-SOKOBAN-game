
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace GAMEPROJECTBYCLEAVELANDO
{
	public class PlayerData
	{
	    private string username = string.Empty;             
	    private string filepath = string.Empty;         
	    private int lastFinishedLevel = 0;
	    private string lastPlayedSet = string.Empty;
	       
        public string Name
        {
            get { return username; }
        }
        
        public int LastFinishedLevel
        {
            get { return lastFinishedLevel; }
        }

        public string LastPlayedSet
        {
            get { return lastPlayedSet; }
        }

		public PlayerData(string aName)
		{
		    username = aName;
		    
            // Read current path and remove the 'file:/' from the string
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .GetName().CodeBase).Substring(6);
            filepath = path + "/savegames/" + aName + ".xml";
		}
		
        

		public void LoadPlayerInfo(LevelSet levelSet)
		{            
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            XmlNode lastPlayedNameSet =
                doc.SelectSingleNode("//lastPlayedNameSet");
            lastPlayedNameSet.InnerText = levelSet.Filename;
                        
            doc.Save(filepath);
            lastFinishedLevel = 0;
		}
        public void SaveLevel(Level level)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            XmlNode lastFinishedLvl = doc.SelectSingleNode("//lastFinishedLevel");
            lastFinishedLvl.InnerText = level.LevelNr.ToString();

            XmlNode setName = doc.SelectSingleNode("/savegame/levelSets/" +
                "levelSet[@title = \"" + level.LevelSetName + "\"]");
            XmlNode nodeLevel = setName.SelectSingleNode("level[@levelNr = " +
                level.LevelNr + "]");

            if (nodeLevel == null)
            {
                XmlElement nodeNewLevel = doc.CreateElement("level");
                XmlAttribute xa = doc.CreateAttribute("levelNr");
                xa.Value = level.LevelNr.ToString();
                nodeNewLevel.Attributes.Append(xa);
                XmlElement moves = doc.CreateElement("moves");
                moves.InnerText = level.Moves.ToString();
                XmlElement pushes = doc.CreateElement("pushes");
                pushes.InnerText = level.Pushes.ToString();

                nodeNewLevel.AppendChild(moves);
                nodeNewLevel.AppendChild(pushes);
                setName.AppendChild(nodeNewLevel);
            }
            else
            {
                XmlElement moves = nodeLevel["moves"];
                XmlElement pushes = nodeLevel["pushes"];
                int nrOfMoves = int.Parse(moves.InnerText);
                int nrOfPushes = int.Parse(pushes.InnerText);

                if (level.Pushes < nrOfPushes)
                {
                    pushes.InnerText = level.Pushes.ToString();
                    moves.InnerText = level.Moves.ToString();
                }
                else if (level.Pushes == nrOfPushes && level.Moves < nrOfMoves)
                    moves.InnerText = level.Moves.ToString();
            }

            doc.Save(filepath);
        }
        public void LoadLastGameInfo()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            
            XmlNode lastPlayedNameSet =
                doc.SelectSingleNode("//lastPlayedNameSet");
            lastPlayedSet = lastPlayedNameSet.InnerText;
            XmlNode lastFinishedLvl =
                doc.SelectSingleNode("//lastFinishedLevel");
            lastFinishedLevel = int.Parse(lastFinishedLvl.InnerText);
        }

        public void SaveLevelSet(LevelSet levelSet)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            XmlNode lastFilename = doc.SelectSingleNode("//lastPlayedNameSet");
            lastFilename.InnerText = levelSet.Filename;
            XmlNode lastFinishedLvl = doc.SelectSingleNode("//lastFinishedLevel");
            lastFinishedLvl.InnerText = "0";

            XmlNode setName = doc.SelectSingleNode("/savegame/levelSets/" +
                "levelSet[@title = \"" + levelSet.Title + "\"]");
            
            if (setName == null) // We play set for the first time
            {
                XmlNode levelSets = doc.GetElementsByTagName("levelSets")[0];
                
                XmlElement newLevelSet = doc.CreateElement("levelSet");
                XmlAttribute xa = doc.CreateAttribute("title");
                xa.Value = levelSet.Title;
                newLevelSet.Attributes.Append(xa);
                XmlElement lastFinishedLevelInSet = doc.CreateElement("lastFinishedLevelInSet");
                lastFinishedLevelInSet.InnerText = "0";
                
                newLevelSet.AppendChild(lastFinishedLevelInSet);
                levelSets.AppendChild(newLevelSet);
            }
            
            doc.Save(filepath);
        }
        public void CreatePlayer(LevelSet levelSet)
        {
            XmlDocument doc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter(filepath, null);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteProcessingInstruction("xml",
                "version='1.0' encoding='ISO-8859-1'");
            writer.WriteStartElement("savegame");
            writer.Close();

            doc.Load(filepath);

            XmlNode root = doc.DocumentElement;
            XmlElement playerName = doc.CreateElement("playerName");
            playerName.InnerText = username;
            XmlElement lastPlayedNameSet =
                doc.CreateElement("lastPlayedNameSet");
            lastPlayedNameSet.InnerText = levelSet.Filename;
            XmlElement lastFinishedLevel =
                doc.CreateElement("lastFinishedLevel");
            lastFinishedLevel.InnerText = "0";
            XmlElement levelSets = doc.CreateElement("levelSets");

            XmlElement nodeLevelSet = doc.CreateElement("levelSet");
            XmlAttribute xa = doc.CreateAttribute("title");
            xa.Value = levelSet.Title;
            nodeLevelSet.Attributes.Append(xa);
            XmlElement lastFinishedLevelInSet =
                doc.CreateElement("lastFinishedLevelInSet");
            lastFinishedLevelInSet.InnerText = "0";

            nodeLevelSet.AppendChild(lastFinishedLevelInSet);
            levelSets.AppendChild(nodeLevelSet);
            root.AppendChild(playerName);
            root.AppendChild(lastPlayedNameSet);
            root.AppendChild(lastFinishedLevel);
            root.AppendChild(levelSets);

            doc.Save(filepath);
        }
        public static ArrayList GetPlayeruserNames()
        {
            ArrayList userNames = new ArrayList();
		    
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().
                GetName().CodeBase).Substring(6);

            string [] fileEntries = Directory.GetFiles(path + "/savegames");
		    
            foreach(string filename in fileEntries)
            {
                FileInfo fileInfo = new FileInfo(filename);
                if (fileInfo.Extension.Equals(".xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filename);
                    
                    XmlNode playerName = doc.SelectSingleNode("//playerName");
                    if (playerName != null)
                        userNames.Add(playerName.InnerText);
                }
            }
		    
            return userNames;
        }
	}
}
