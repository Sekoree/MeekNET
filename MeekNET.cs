using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HeyRed.Mime;
using MeekNET.Enums;

namespace MeekNET
{
    public class MeekMoe
    {
        public async Task<ImgData> GetImg(Loids loid)
        {
            WebClient wc = new WebClient();
            string ApiJson = await wc.DownloadStringTaskAsync($"https://api.meek.moe/{GetLoid(loid)}");
            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(ApiJson);
            MemoryStream im = new MemoryStream(await wc.DownloadDataTaskAsync($"https://api.meek.moe/im/?image={ar.Url}&resize=500"))
            {
                Position = 0
            };
            ImgData iu = new ImgData
            {
                Url = ar.Url,
                ProxyUrl = $"https://api.meek.moe/im/?image={ar.Url}&resize=500",
                Creator = ar.Creator,
                Image = im,
                FileType = MimeGuesser.GuessExtension(im)
            };
            return iu;
        }

        public async Task<ImgUrl> GetImgURL(Enums.Loids loid)
        {
            WebClient wc = new WebClient();
            string ApiJson = await wc.DownloadStringTaskAsync($"https://api.meek.moe/{GetLoid(loid)}");
            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(ApiJson);
            ImgUrl iu = new ImgUrl
            {
                Url = ar.Url,
                ProxyUrl = $"https://api.meek.moe/im/?image={ar.Url}&resize=500",
                Creator = ar.Creator
            };
            return iu;
        }

        private string GetLoid(Enums.Loids a)
        {
            switch (a)
            {
                case Enums.Loids.ProjectDiva:
                    return "diva";
                case Enums.Loids.KagamineRin:
                    return "rin";
                case Enums.Loids.OtomachiUna:
                    return "una";
                case Enums.Loids.Gumi:
                    return "gumi";
                case Enums.Loids.MegurineLuka:
                    return "luka";
                case Enums.Loids.IA:
                    return "ia";
                case Enums.Loids.Fukase:
                    return "fukase";
                case Enums.Loids.HatsuneMiku:
                    return "miku";
                case Enums.Loids.KagamineLen:
                    return "len";
                case Enums.Loids.Kaito:
                    return "kaito";
                case Enums.Loids.KasaneTeto:
                    return "teto";
                case Enums.Loids.Meiko:
                    return "meiko";
                case Enums.Loids.YuzukiYukari:
                    return "yukari";
                case Enums.Loids.SFA2Miki:
                    return "miki";
                case Enums.Loids.Lily:
                    return "lily";
                case Enums.Loids.Mayu:
                    return "mayu";
                case Enums.Loids.AokiLapis:
                    return "aoki";

            }
            return null;
        }

        private class ApiResponse
        {
            public string Url { get; set; }
            public string Creator { get; set; }
        }

        public class ImgUrl
        {
            public string Url { get; set; }
            public string ProxyUrl { get; set; }
            public string Creator { get; set; }
            public string FileType { get; set; }
        }

        public class ImgData : ImgUrl
        {
            public Stream Image { get; set; }
        }
    }
}

namespace MeekNET.Enums
{
      public enum Loids
        {
            ProjectDiva,
            KagamineRin,
            OtomachiUna,
            Gumi,
            MegurineLuka,
            IA,
            Fukase,
            HatsuneMiku,
            KagamineLen,
            Kaito,
            KasaneTeto,
            Meiko,
            YuzukiYukari,
            SFA2Miki,
            Lily,
            Mayu,
            AokiLapis
        }
}
