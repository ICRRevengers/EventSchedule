using EventProjectSWP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

/*
namespace EventProjectSWP.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }


       [HttpGet("GenerateQrCode")]
       public async Task<ActionResult> QRCode(string Text)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qRCodeData = _qrCode.CreateQrCode(Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qRCodeData);
            System.Drawing.Image qrCodeImage = qrCode.GetGraphic(20);

            var bytes = ImageToByteArray(qrCodeImage);
            return File(bytes, "image/bmp");
        }

    }
  }

*/