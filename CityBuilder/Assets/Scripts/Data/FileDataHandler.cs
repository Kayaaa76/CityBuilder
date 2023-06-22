using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{

    private string dataDirpath = "";

    private string dataFileName = "";

    private bool useEncryption = false;

    private readonly string encryptionCodeWord = "CityBuilder";

    public FileDataHandler(string dataDirpath, string dataFileName, bool useEncryption)
    {
        this.dataDirpath = dataDirpath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        GameData data = new GameData();

        string fullPath = Path.Combine(dataDirpath, dataFileName);
        GameData loadedData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                //Load serialized data from file
                string dataToLoad = " ";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if(useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }
                
                //Deserialize data from Json back into C# Object
                loadedData= JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        return loadedData;
    }
    public void Save(GameData data)
    {
        string fullpath = Path.Combine(dataDirpath, dataFileName);
        try
        {
            //Creates directory that the file will be written to if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            //serialize c# game data object into Json
            string dataToStore = JsonUtility.ToJson(data,true);

            if(useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }


            //write serialized data to the file
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file" + fullpath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for(int i= 0; i<data.Length; i++) 
        {
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]); 
        }
        return modifiedData;
    }
}

