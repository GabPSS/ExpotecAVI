using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;

namespace ExpotecAVI
{
    //[Obsolete]
    //public class oldVideoAula : IDisposable
    //{
    //    /// <summary>
    //    /// Provides the path of the .vaula file
    //    /// </summary>
    //    public string FilePath;
    //    private readonly VAFileInfo pack;
    //    private readonly string TmpDir = Directory.GetCurrentDirectory() + "\\tmp";
    //    /// <summary>
    //    /// Provides the default extension for video playback
    //    /// </summary>
    //    public string DefaultVFExtension { get; set; } = ".mp4";

    //    private string JsonFilePath { get { return TmpDir + "\\index.json"; } }
    //    private string QuestionsPath { get { return TmpDir + "\\duvidas"; } }
    //    /// <summary>
    //    /// Provides the path towards the main video file to be played as the class
    //    /// </summary>
    //    public string MainVideoPath { get { return TmpDir + "\\main" + DefaultVFExtension; } }

    //    public string Title { get { return pack.Title; } }
    //    public string[] Duvidas { get { return pack.Duvidas; } }

    //    /// <summary>
    //    /// Initializes a new VideoAula with given file name
    //    /// </summary>
    //    /// <param name="filePath">The VAFileInfo zipped object to extract and play videos from</param>
    //    public VideoAula(string filePath)
    //    {
    //        FilePath = filePath;
    //        Unzip();
    //        pack = JsonConvert.DeserializeObject<VAFileInfo>(File.ReadAllText(JsonFilePath));
    //    }
    //    private void Unzip()
    //    {
    //        Dispose();
    //        Directory.CreateDirectory(TmpDir);
    //        ZipFile.ExtractToDirectory(FilePath, TmpDir);
    //    }

    //    public string GetVideoByQuestionIndex(int index)
    //    {
    //        return QuestionsPath + "\\" + index.ToString("000") + DefaultVFExtension;
    //    }

    //    public void Dispose()
    //    {
    //        try
    //        {
    //            string[] toRemove = Directory.EnumerateFiles(QuestionsPath).ToArray();
    //            for (int i = 0; i < toRemove.Length; i++)
    //            {
    //                File.Delete(toRemove[i]);
    //            }
    //        } 
    //        catch { }
    //        try
    //        {
    //            File.Delete(MainVideoPath);
    //        }
    //        catch { }
    //        try
    //        {
    //            File.Delete(JsonFilePath);
    //        }
    //        catch { }
    //        try
    //        {
    //            Directory.Delete(QuestionsPath);
    //        }
    //        catch { }
    //        try
    //        {
    //            Directory.Delete(TmpDir);
    //        }
    //        catch { }
    //    }
    //}

    //[Obsolete]
    //public class oldVAFileInfo
    //{
    //    public string Title;
    //    public string[] Duvidas;
    //}

    public class VideoAulaPackage : IDisposable
    {
        /*
         * Example folder structure:
         * tmp/
         *  index.json
         *  000.mp4
         *  001.mp4
         *  000/
         *    000.mp4
         *    001.mp4
         *  001/
         *    000.mp4
         *    001.mp4
         *    002.mp4
        */
        private readonly string TmpDir = Directory.GetCurrentDirectory() + "\\tmp";
        public string DefaultVFExtension = ".mp4";

        public string FilePath { get; set; }
        private string JsonFilePath { get { return TmpDir + "\\index.json"; } }
        
        private PackageInfo Package { get; set; }
        public string PackageTitle { get { return Package.Title; } }
        public VideoAula[] VideoAulas { get { return Package.VAulas; } }


        public VideoAulaPackage(string filePath)
        {
            FilePath = filePath;
            Unzip();
            Package = JsonConvert.DeserializeObject<PackageInfo>(File.ReadAllText(JsonFilePath));
        }
        private void Unzip()
        {
            Dispose();
            Directory.CreateDirectory(TmpDir);
            ZipFile.ExtractToDirectory(FilePath, TmpDir);
        }

        
        public string GetVideoPathByIndex(int index)
        {
            return TmpDir + "\\" + index.ToString("000") + DefaultVFExtension;
        }

        public string GetDuvidaVideoPathByIndexes(int videoIndex, int duvidaIndex)
        {
            return TmpDir + "\\" + videoIndex.ToString("000") + "\\" + duvidaIndex.ToString("000") + DefaultVFExtension;
        }

        public void Dispose()
        {
            string[] files = Array.Empty<string>(), folders = Array.Empty<string>();

            try
            {
                files = Directory.EnumerateFiles(TmpDir, "*.*", SearchOption.AllDirectories).ToArray();
            }
            catch { }

            try
            {
                folders = Directory.EnumerateDirectories(TmpDir, "*", SearchOption.AllDirectories).ToArray();
            }
            catch { }

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
            foreach (string folder in folders)
            {
                try
                {
                    Directory.Delete(folder);
                }
                catch { }
            }
            try
            {
                Directory.Delete(TmpDir);
            }
            catch { }
            
            //for (int i = 0; i < folders.Length; i++)
            //{
            //    for (int x = 0; x < files.Length; x++)
            //    {
            //        try
            //        {
            //            File.Delete(files[x]);
            //        } catch { }
            //    }
            //    try
            //    {
            //        Directory.Delete(folders[i]);
            //    }
            //    catch { }
            //}

        }

        public class PackageInfo
        {
            public string Title;
            public VideoAula[] VAulas;
        }
    }
    public class VideoAula
    {
        public string Title;
        public string[] Duvidas;
    }
}

//{
//    public class Package
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string Author { get; set; }
//        public DateTime Date { get; set; }
//        public List<VAFileInfo> Aulas { get; set; }

//    }

//    public class VAFileInfo : List<Chapter>
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string ID { get; set; }
//    }

//    public class Chapter
//    {
//        public List<IRes> Res { get; set; }
//        public List<Question> Questions { get; set; }
//    }

//    public class Question
//    {
//        public string Title { get; set; }
//        public string Src { get; set; }
//    }

//    public interface IRes
//    {
//        string Src { get; set; }
//        float From { get; set; }
//        float To { get; set; }
//    }

//    public class Img : IRes
//    {
//        public string Src { get; set; }
//        public float X { get; set; }
//        public float Y { get; set; }
//        public float Width { get; set; }
//        public float Height { get; set; }
//        public float From { get; set; }
//        public float To { get; set; }
//    }
//}
