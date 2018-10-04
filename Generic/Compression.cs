//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace Generic
{
    public class Compression
    {
        //Comprime los archivos contenidos en la carpeta especificada en el parametro directoryPath, 
        //inFolder: Indica si se comprimiran los archivos dentro del mismo folder seleccionado
        //password: Establece una contraseña para el ZIP generado
        public static void Compress(string directoryPath, bool inFolder = true, string password = null)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                string basePath = Global.GetFolderPath(directoryPath);
                string pathFile = null;

                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = password;

                    foreach (FileInfo file in directory.GetFiles())
                    {
                        string pathZip = String.Format("{0}\\{1}.zip", basePath, directory.Name);

                        if (inFolder)
                            pathFile = String.Format("{0}\\{1}", directory.Name, file.Name);
                        else pathFile = file.Name;

                        zip.AddEntry(pathFile, file.OpenRead());
                        zip.Save(pathZip);
                    }
                }
            }
            catch { throw; }
        }

        //password: Establece una contraseña para el ZIP generado
        public static void Compress(string[] files, string fileName = null,
                                    string destPath = null, string password = null)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = password;

                    foreach (string fullPath in files)
                    {
                        FileInfo fileZIP = new FileInfo(fullPath);
                        string pathZip = String.Format("{0}\\{1}.zip", destPath, fileName);

                        zip.AddEntry(fileZIP.Name, fileZIP.OpenRead());
                        zip.Save(pathZip);
                    }
                }
            }
            catch { throw; }
        }


        //descomprime los archivos contenidos en la carpeta especificada en el parametro pathZipFile, 
        //password: Contraseña con la cual se descomprimira, si el archivo tiene alguna establecida
        //pathDest: Ruta especifica donde se quiere que se descompriman los archivos
        public static void Decompress(string pathZipFile, string password = null, string pathDest = null)
        {
            try
            {
                string pathUNZIP = Global.GetFolderPath(pathZipFile);

                if (!String.IsNullOrEmpty(pathDest)) pathUNZIP = pathDest;

                using (ZipFile zip = ZipFile.Read(pathZipFile))
                {
                    zip.Password = password;
                    zip.ExtractAll(pathUNZIP);
                }
            }
            catch { throw; }
        }

    }
}
