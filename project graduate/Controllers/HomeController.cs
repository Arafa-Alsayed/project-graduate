using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project_graduate.Models;

namespace project_graduate.Controllers
{
    public class HomeController : Controller
    {
        public string downloadtext;
        public string key = "1234567890Abff26";
        [Obsolete]
        private readonly IHostingEnvironment _hosting;
        private readonly ILogger<HomeController> _logger;

        myclass op = new myclass();

        [Obsolete]
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hosting)
        {
            _logger = logger;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Text()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Text(string orignalmsg)
        {// Encryptclass ecrypt = new Encryptclass();
            myclass op = new myclass();
            Encryption op2 = new Encryption();
            
            op.orignalmsg = orignalmsg;
            string str = XXTEA.Encrypt(op.orignalmsg, key);
            op.cryptomsg = op2.convert_to_RNA(op2.convert_to_dna(op2.split_binary(op2.StringToBinary(str))));
            string document = op.cryptomsg;
            //decryption 
            // op.cryptomsg = XXTEA.Decrypt(orignalmsg, key);
            //create file or put Encrypt message in file
            //path which file put in
            string path_Root = _hosting.WebRootPath;
            string docPath = path_Root + "\\files\\";

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Encryptmessage.txt")))
            {
                outputFile.Write(document);
            }
            return View("Text", op);

        }
        [HttpGet]
        public IActionResult Indexfile()
        {
            return View();
        }
        
        [HttpPost]
        [Obsolete]
        public IActionResult Indexfile(IFormFile File)

        {
            fileclass op = new fileclass();
            Encryption op2 = new Encryption();
            if (File == null || File.Length == 0) return Content("file not selected");
            //get path
            string path_Root = _hosting.WebRootPath;
            string path_to_files = path_Root + "\\files\\" + File.FileName;

            //copyfiles
            using (var stream = new FileStream(path_to_files, FileMode.Create))
            {
                File.CopyTo(stream);
            }



            // read file
            FileStream fileStream = new FileStream(path_to_files, FileMode.Open);

            using (StreamReader reader = new StreamReader(fileStream))
            {
                // string line = reader.ReadLine();
                string line = reader.ReadToEnd();
                //  op.Encryptfile = line;
                string str = XXTEA.Encrypt(line, key);
                op.Encryptfile = op2.convert_to_RNA(op2.convert_to_dna(op2.split_binary(op2.StringToBinary(str))));
              

            }
            downloadtext = op.Encryptfile;
            //delete file
            FileInfo fi = new FileInfo(path_to_files);
            if (fi != null)
            {
                System.IO.File.Delete(path_to_files);
                fi.Delete();
            }
            ///////////////////
            //create file or put Encrypt message in file
            //path which file put in
            string docPath = path_Root + "\\files\\";

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Encryptmessage.txt")))
            {
                outputFile.Write(downloadtext);
            }

            return View("Indexfile", op);


        }
        [HttpGet]
        [Obsolete]
        //best code for downloadfile
        public ActionResult DownloadEncryptDocument()
        {
            string path_Root = _hosting.WebRootPath;
            var path = path_Root + "\\files\\" + "Encryptmessage.txt";


            string filePath = path;
            string fileName = "Encryptmessage.txt";
            //delete file from wwwroot files
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            FileInfo fi = new FileInfo(path);
            if (fi != null)
            {
                System.IO.File.Delete(path);
                fi.Delete();
            }

            return File(fileBytes, "application/force-download", fileName);

        }
        // Decryption_Class Action
        /// /////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult DecryptionText()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult DecryptionText(string cryptomsg)
        {
            myclass op = new myclass();
            Decryption_Class op2 = new Decryption_Class();


            string str = op2.BinaryToString(op2.convert_DNA_to_binary(op2.convert_finalDNA_to_DNA(op2.split_DNA(cryptomsg))));
               
            op.orignalmsg = XXTEA.Decrypt(str, key);
            //decryption 
            // op.cryptomsg = XXTEA.Decrypt(orignalmsg, key);
            string document = op.orignalmsg;
            //decryption 
            // op.cryptomsg = XXTEA.Decrypt(orignalmsg, key);
            //create file or put Encrypt message in file
            //path which file put in
            string path_Root = _hosting.WebRootPath;
            string docPath = path_Root + "\\files\\";

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Decryptmessage.txt")))
            {
                outputFile.Write(document);
            }

            return View("DecryptionText", op);
        }
        [HttpGet]
        public IActionResult DecryptionFile()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        //Decryption file
        public IActionResult DecryptionFile(IFormFile File)
        {
            fileclass op = new fileclass();
            Decryption_Class op2 = new Decryption_Class();
            if (File == null || File.Length == 0) return Content("file not selected");
            //get path
            string path_Root = _hosting.WebRootPath;
            string path_to_files = path_Root + "\\files\\" + File.FileName;

            //copyfiles
            using (var stream = new FileStream(path_to_files, FileMode.Create))
            {
                File.CopyTo(stream);
            }



            // read file
            FileStream fileStream = new FileStream(path_to_files, FileMode.Open);

            using (StreamReader reader = new StreamReader(fileStream))
            {
                // string line = reader.ReadLine();
                string line = reader.ReadToEnd();
                //  op.Encryptfile = line;
                string str = op2.BinaryToString(op2.convert_DNA_to_binary(op2.convert_finalDNA_to_DNA(op2.split_DNA(line))));
                op.Decryptfile = XXTEA.Decrypt(str, key);


            }
            downloadtext = op.Decryptfile;
            //delete file
            FileInfo fi = new FileInfo(path_to_files);
            if (fi != null)
            {
                System.IO.File.Delete(path_to_files);
                fi.Delete();
            }
            ///////////////////
            //create file or put Encrypt message in file
            //path which file put in
            string docPath = path_Root + "\\files\\";

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Decryptmessage.txt")))
            {
                outputFile.Write(downloadtext);
            }

            return View("DecryptionFile", op);

        }


        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"}

        };
        }
        [HttpGet]
        [Obsolete]
        //best code for downloadfile
        public ActionResult DownloadDecryptDocument()
        {
            string path_Root = _hosting.WebRootPath;
            var path = path_Root + "\\files\\" + "Decryptmessage.txt";

            
            string filePath = path;
            string fileName = "Decryptmessage.txt";
            //delete file from wwwroot files
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            FileInfo fi = new FileInfo(path);
            if (fi != null)
            {
                System.IO.File.Delete(path);
                fi.Delete();
            }

            return File(fileBytes, "application/force-download", fileName);

        }
        //////////////////////////////////////////////////////////////////
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Encryption_choose()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Decryption_choose()
        {
            return View();
        }
    }
}
