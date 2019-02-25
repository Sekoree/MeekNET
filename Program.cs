using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HeyRed.Mime;

namespace MeekNET
{
    class Program
    {
        public static async Task<ImgData> GetImg(Loids loid)
        {
            WebClient wc = new WebClient();
            string ApiJson = await wc.DownloadStringTaskAsync($"https://api.meek.moe/{GetLoid(loid)}");
            ApiResponse ar = JsonConvert.DeserializeObject<ApiResponse>(ApiJson);
            Stream im = new MemoryStream(await wc.DownloadDataTaskAsync($"https://api.meek.moe/im/?image={ar.Url}&resize=500"));
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

        public static async Task<ImgUrl> GetImgURL(Loids loid)
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

        private static string GetLoid(Loids a)
        {
            switch (a)
            {
                case Loids.ProjectDiva:
                    return "diva";
                case Loids.KagamineRin:
                    return "rin";
                case Loids.OtomachiUna:
                    return "una";
                case Loids.Gumi:
                    return "gumi";
                case Loids.MegurineLuka:
                    return "luka";
                case Loids.IA:
                    return "ia";
                case Loids.Fukase:
                    return "fukase";
                case Loids.HatsuneMiku:
                    return "miku";
                case Loids.KagamineLen:
                    return "len";
                case Loids.Kaito:
                    return "kaito";
                case Loids.KasaneTeto:
                    return "teto";
                case Loids.Meiko:
                    return "meiko";
                case Loids.YuzukiYukari:
                    return "yukari";
                case Loids.SFA2Miki:
                    return "miki";
                case Loids.Lily:
                    return "lily";
                case Loids.Mayu:
                    return "mayu";
                case Loids.AokiLapis:
                    return "aoki";

            }
            return null;
        }

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

        public class ApiResponse
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
