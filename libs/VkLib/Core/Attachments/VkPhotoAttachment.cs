﻿using System;
using Newtonsoft.Json.Linq;
using VkLib.Core.Photos;
using VkLib.Extensions;

namespace VkLib.Core.Attachments
{
    /// <summary>
    /// Photo attachments
    /// <seealso cref="http://vk.com/dev/photo"/>
    /// </summary>
    public class VkPhotoAttachment : VkAttachment
    {
        /// <summary>
        /// Album id
        /// </summary>
        public long AlbumId { get; set; }

        /// <summary>
        /// Up to 75x75
        /// </summary>
        public string SourceSmall { get; set; }

        /// <summary>
        /// Up to 130x130
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Up to 604x604
        /// </summary>
        public string SourceBig { get; set; }

        /// <summary>
        /// Up to 807x807
        /// </summary>
        public string SourceXBig { get; set; }

        /// <summary>
        /// Up to 1280x1024
        /// </summary>
        public string SourceXXBig { get; set; }

        /// <summary>
        /// Up to 2560x2048
        /// </summary>
        public string SourceXXXBig { get; set; }

        /// <summary>
        /// Returns url to max available size
        /// </summary>
        public string SourceMax
        {
            get { return SourceXXXBig ?? SourceXXXBig ?? SourceXXBig ?? SourceXBig ?? SourceBig ?? Source ?? SourceSmall; }
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date added
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public override string Type { get { return "photo"; } }

        public VkPhotoAttachment()
        {

        }

        public VkPhotoAttachment(VkPhoto photo)
        {
            this.Id = photo.Id;
            this.OwnerId = photo.OwnerId;
            this.Source = photo.Photo130;
            this.SourceBig = photo.Photo604;
            this.SourceSmall = photo.Photo75;
            this.SourceXBig = photo.Photo807;
            this.SourceXXBig = photo.Photo1280;
            this.SourceXXXBig = photo.Photo2560;
            this.Date = photo.Created;
            this.Width = photo.Width;
            this.Height = photo.Height;
        }

        public new static VkPhotoAttachment FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentException("Json can not be null.");

            var result = new VkPhotoAttachment();

            result.Id = (long)json["id"];

            result.OwnerId = (long)json["owner_id"];

            if (json["album_id"] != null)
                result.AlbumId = (long)json["album_id"];

            if (json["photo_75"] != null)
                result.SourceSmall = (string)json["photo_75"];

            if (json["photo_130"] != null)
                result.Source = (string)json["photo_130"];

            if (json["photo_604"] != null)
                result.SourceBig = (string)json["photo_604"];

            if (json["photo_807"] != null)
                result.SourceXBig = (string)json["photo_807"];

            if (json["photo_1280"] != null)
                result.SourceXXBig = (string)json["photo_1280"];

            if (json["photo_2560"] != null)
                result.SourceXXXBig = (string)json["photo_2560"];

            if (json["width"] != null)
                result.Width = (int)json["width"];

            if (json["height"] != null)
                result.Height = (int)json["height"];

            if (json["text"] != null)
                result.Text = (string)json["text"];

            if (json["date"] != null)
                result.Date = DateTimeExtensions.UnixTimeStampToDateTime((long)json["date"]);

            return result;
        }
    }
}
