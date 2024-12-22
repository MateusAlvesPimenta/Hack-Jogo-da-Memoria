using Microsoft.AspNetCore.Mvc;
using SystemFile = System.IO.File;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwitchCards : ControllerBase
    {
        [HttpPost]
        public IActionResult Switch(Path cardPath)
        {
            var copyPath = $"../Frontend/public/img/Card copy.jpg";
            var nullCard = $"../Frontend/public/img/nullCard.jpg";
            var path1 = $"../Frontend/public/{cardPath.path1}.jpg";
            var path2 = $"../Frontend/public/{cardPath.path2}.jpg";

            if (SystemFile.Exists(path1) &&
                SystemFile.Exists(path2))
            {
                SystemFile.Copy(path1, copyPath, true);
                SystemFile.Move(path2, path1, true);
                SystemFile.Move(copyPath, path2, true);
                return Ok();
            }
            else if (cardPath.path1.Length == 2 && 
                    cardPath.path2.Length > 2)
            {
                SystemFile.Copy(path2, copyPath, true);
                SystemFile.Move(copyPath, $"../Frontend/public/img/Card{cardPath.path1[0]}{cardPath.path1[1]}.jpg", true);
                SystemFile.Copy(nullCard, copyPath, true);
                SystemFile.Move(copyPath, path2, true);
            }
            else if(cardPath.path2.Length == 2 &&
                    cardPath.path1.Length > 2)
            {
                SystemFile.Copy(path1, copyPath, true);
                SystemFile.Move(copyPath, $"../Frontend/public/img/Card{cardPath.path2[0]}{cardPath.path2[1]}.jpg", true);
                SystemFile.Copy(nullCard, copyPath, true);
                SystemFile.Move(copyPath, path1, true);
            }

            return Ok();
        }
    }

    public class Path
    {
        public string path1 { get; set; }
        public string path2 { get; set; }
    }
}