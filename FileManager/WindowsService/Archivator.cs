using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Lr4Win
{
    class Archivator
    {
        private string errorFile = @"C:Lr4\FileManager\error.txt";
        private Encryptor encrypt = new Encryptor();

        public void Archive(string fileName, string targetDir)
        {
            encrypt.encryptFileName = encrypt.TargetEncryptedFilePath(fileName, targetDir);

            try
            {
                using (var memory = new MemoryStream())
                {
                    using (var zip = new ZipArchive(memory, ZipArchiveMode.Create, true))
                    {
                        var memoryFile = zip.CreateEntry(Path.GetFileName(encrypt.encryptFileName));

                        FileStream sourceStream = default;

                        while (true)//Catching file locked in other process
                        {           //Until it free from other process
                            try
                            {
                                sourceStream = new FileStream(fileName, FileMode.Open);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }                    
                        encrypt.Encrypt(sourceStream, memoryFile);
                        
                    }
                    using (var encryptedFileStream = new FileStream(Path.Combine(targetDir, Path.GetFileNameWithoutExtension(fileName) + ".zip"), FileMode.Create))
                    {
                        memory.Seek(0, SeekOrigin.Begin);
                        memory.CopyTo(encryptedFileStream);
                    }
                }
            }
            catch (Exception e)
            {
                using (var errorStream = new StreamWriter(new FileStream(errorFile, FileMode.OpenOrCreate)))
                {
                    errorStream.Write(e.Message + "\n\n" + e.StackTrace);
                }
                //MessageBox.Show("Ошибка: " + e.Message);
            }
        }

        public void Dearchive(string fileName, string targetDir)
        {
            try
            {
                using (var zip = ZipFile.OpenRead(fileName))
                {
                    var file = zip.Entries[0];

                    encrypt.decryptFileName = encrypt.TargetDecryptedFilePath(file.Name, targetDir);

                    using (var targetStream = new FileStream(encrypt.decryptFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        encrypt.Decrypt(targetStream, file);
                    }
                }
 
            }
            catch (Exception e)
            {
                using (var errorStream = new StreamWriter(new FileStream(errorFile, FileMode.OpenOrCreate)))
                {
                    errorStream.Write(e.Message + "\n\n" + e.StackTrace);
                }
            }

            Thread.Sleep(1000);
        }
    }
}
