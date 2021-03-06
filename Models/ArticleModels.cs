using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BSDN_API.Models;

namespace BSDN_API.Models
{
    public interface IArticle
    {
        int ArticleId { set; get; }
        int ViewNumber { set; get; }
        [MaxLength(256)] string Title { set; get; }
        string Content { set; get; }
        DateTime PublishDate { set; get; }
        int UserId { set; get; }
    }

    public class Article
    {
        public int ArticleId { set; get; }
        public int ViewNumber { set; get; }
        [MaxLength(256)] public string Title { set; get; }
        public string Content { set; get; }
        public DateTime PublishDate { set; get; }

        public List<ArticleTag> ArticleTags { set; get; }
        public List<Comment> Comments { set; get; }

        // FK_User_Article
        public int UserId { set; get; }
        public User User { set; get; }
    }

    public class ArticleInfo
    {
        public int ArticleId { set; get; }
        public int ViewNumber { set; get; }
        [MaxLength(256)] public string Title { set; get; }
        public string Content { set; get; }
        public DateTime PublishDate { set; get; }

        public List<TagInfo> TagInfos { set; get; }
        public int CommentCount { set; get; }

        public int UserId { set; get; }
        public string NickName { set; get; }

        public ArticleInfo(Article article, BSDNContext context)
        {
            ArticleId = article.ArticleId;
            ViewNumber = article.ViewNumber;
            Title = article.Title;
            Content = article.Content;
            PublishDate = article.PublishDate;
            if (article.ArticleTags == null || article.ArticleTags.Count == 0)
            {
                TagInfos = null;
            }
            else
            {
                TagInfos = article.ArticleTags
                    .Where(at => at.ArticleId == article.ArticleId)
                    .Select(
                        at => context.Tags.FirstOrDefault(t => t.TagId == at.TagId)
                    ).Select(t => new TagInfo(t)).ToList();
            }

            CommentCount = article.Comments?.Count ?? 0;
            UserId = article.UserId;
            NickName = article.User?.Nickname;
        }
    }
}