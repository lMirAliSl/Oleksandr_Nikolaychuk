using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;
using System;
using System.Data;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace Test.WebApi{
    [Binding]
    public sealed class WebApiBasics{
        static string token = "sl.BWcdUY1zsl3l53qmswsalJTFJYrHQ8eldGSfy2rYTZHIjzkgfXgHiqK63ezcgPagf6uUnIT6pOwCQXnCAY7oTjrnhXIVUEYRPstGdgGR4ofkT0TLrnahvY12fEn1LKritX1Riz2BDV_r";
        DropboxClient dbx = new DropboxClient(token);
        string filePath = @"D:\Mine\Univercity\RTP\WebApi\Text.txt";
        string filename = "DropBoxFile.txt";
        string url = "";
        string folder = "";

        [Given(@"user information")]
        public void user_information(){
            var user = dbx.Users.GetCurrentAccountAsync().Result;
            Console.WriteLine("name: " + user.Name);
            Console.WriteLine("email adress: " + user.Email);
            Console.WriteLine("country: " + user.Country);
        }

        [When(@"upload file")]
        public void upload_file(){
            var memory = new MemoryStream(File.ReadAllBytes(filePath));
            var updated = dbx.Files.UploadAsync(folder + "/" + filename, WriteMode.Overwrite.Instance, body: memory);
            updated.Wait();
            var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(folder + "/" + filename);
            tx.Wait();
            url = tx.Result.Url;
        }

        [Then(@"result")]
        public void result(){
            Console.Write("upload accepted\nLink: " + url + "\n");
        }

        Metadata file = new Metadata();
        [Given(@"file existence check")]
        public void file_existence_check(){
            
            bool check = false;
            var list = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var item in list.Result.Entries.Where(i => i.IsFile)){
                if (item.Name == filename){
                    check = true;
                    break;
                }
            }
            if (!check){
                throw new FileNotFoundException("file does not exist");
            }
        }

        [When(@"get file metadata")]
        public void get_file_meta_data(){
            var list = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var item in list.Result.Entries.Where(i => i.IsFile)){
                if (item.Name == filename){
                    file = item;
                    break;
                }
            }
        }

        [Then(@"output metadata")]
        public void output_metadata(){
            Console.WriteLine("name: " + file.Name);
            Console.WriteLine("path: " + file.PathDisplay);
            Console.WriteLine("ID: " + file.AsFile.Id);
            Console.WriteLine("modified: " + file.AsFile.ClientModified);
        }

        [When(@"delete file")]
        public void delete_file(){
            var list = dbx.Files.ListFolderAsync(string.Empty);
            foreach (var item in list.Result.Entries.Where(i => i.IsFile))
            {
                if (item.Name == filename)
                {
                    file = item;
                    break;
                }
            }
            var folders = dbx.Files.DeleteV2Async(file.PathLower);
            var result = folders.Result;
        }

        [Then(@"message of delete")]
        public void delete_message(){
            Console.Write("delete accepted!\n");
        }
    }
}